using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.DTOs.NewDTOs;
using School.Webapi.Entities.DTOs.PupilDTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.NewRepasitory;
using School.Webapi.Services.ImageManager;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewRepasitory _newRepasitory;
        private readonly IMapper _mapper;
        private readonly IImageManager _imageManager;

        public NewsController(INewRepasitory newRepasitory,
            IMapper imapper, IImageManager imageManager)
        {
            this._newRepasitory = newRepasitory;
            this._mapper = imapper;
            this._imageManager = imageManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            PaginationParametres paginationParametres)
        {
            return Ok(
                await _newRepasitory.GetAllAsync(paginationParametres)
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _newRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else {
                NewDTO dto = _mapper.Map<NewDTO>(obj);
                dto.ImagePath = _imageManager.GetFullPath(obj.ImageName);
                return Ok(dto);
            }
        }

        // POST api/<NewController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] 
             NewDTOCreated newDTOCreated)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var newObj = _mapper.Map<New>(newDTOCreated);

            if (newDTOCreated.ImageFile != null)
            {
                if (!_imageManager.CheckIsImage(newDTOCreated.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(newDTOCreated.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                string downloadedFile = await _imageManager
                                    .UploadFileAsync(newDTOCreated.ImageFile);

                if (downloadedFile == null) return BadRequest("Image can not download");
                else newObj.ImageName = downloadedFile;
            }

            return Created("New is created", 
                await _newRepasitory.CreateAsync(newObj));
        }

        // PUT api/<NewController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromForm] NewDTOCreated newDTOCreated)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var newObj = await _newRepasitory.GetAsync(id);

            if (newObj == null) return NotFound("Id is'nt correct");

            if (newDTOCreated.ImageFile != null)
            {
                if (!_imageManager.CheckIsImage(newDTOCreated.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(newDTOCreated.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                if (newDTOCreated.ImageFile.FileName != newObj.ImageName)
                    newObj.ImageName = await _imageManager.ChangeFileAsync(
                        newObj.ImageName, newDTOCreated.ImageFile);
            }

            _mapper.Map(newDTOCreated, newObj);

            await _newRepasitory.UpdateAsync(id, newObj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _newRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else
            {
                string path = obj.ImageName;
                await _newRepasitory.DeleteAsync(id);
                _imageManager.DeleteFile(path);
                return NoContent();
            }
        }
    }
}
