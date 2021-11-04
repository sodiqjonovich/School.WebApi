using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Webapi.Entities;
using School.Webapi.Entities.DTOs.PupilDTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.PupilRepasitory;
using School.Webapi.Services.ImageManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilsController : ControllerBase
    {
        private readonly IPupilRepasitory _pupilRepasitory;
        private readonly IMapper _mapper;
        private readonly IImageManager _imageManager;

        public PupilsController(IPupilRepasitory pupilRepasitory,
            IMapper imapper, IImageManager imageManager)
        {
            this._pupilRepasitory = pupilRepasitory;
            this._mapper = imapper;
            this._imageManager = imageManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            PaginationParametres paginationParametres)
        {
            var objects = await _pupilRepasitory.GetAllAsync(paginationParametres);

            var metadata = new
            {
                objects.TotalCount,
                objects.PageSize,
                objects.CurrentPage,
                objects.TotalPages,
                objects.HasNext,
                objects.HasPrevious
            };

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(metadata));

            var dtos = _mapper.Map<IEnumerable<PupilDTOMain>>(
                    objects);

            return Ok(dtos);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _pupilRepasitory.GetAsync(id);

            if (obj == null) return NotFound();
            else
            {
                PupilDTO dto = _mapper.Map<PupilDTO>(obj);
                dto.ImagePath = _imageManager.GetFullPath(obj.ImageName);
                return Ok(dto);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] 
            PupilDTOCreated pupilDTOCreated)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var newObj = _mapper.Map<Pupil>(pupilDTOCreated);

            if (pupilDTOCreated.ImageFile != null)
            {
                if(!_imageManager.CheckIsImage(pupilDTOCreated.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(pupilDTOCreated.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                string downloadedFile = await _imageManager
                                    .UploadFileAsync(pupilDTOCreated.ImageFile);

                if (downloadedFile == null) return BadRequest("Image can not download");
                else newObj.ImageName = downloadedFile;
            }
            
            return Created("Pupil is created",
                await _pupilRepasitory.CreateAsync(newObj));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromForm] PupilDTOCreated pupilDTOedited)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var pupil = await _pupilRepasitory.GetAsync(id);

            if (pupil == null) return NotFound("Id is'nt correct");

            if (pupilDTOedited.ImageFile != null)
            {
                if (!_imageManager.CheckIsImage(pupilDTOedited.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(pupilDTOedited.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                if (pupilDTOedited.ImageFile.FileName != pupil.ImageName)
                    pupil.ImageName = await _imageManager.ChangeFileAsync(
                        pupil.ImageName, pupilDTOedited.ImageFile);
            }

            _mapper.Map(pupilDTOedited, pupil);

            await _pupilRepasitory.UpdateAsync(id, pupil);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _pupilRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else
            {
                string path = obj.ImageName;
                await _pupilRepasitory.DeleteAsync(id);
                _imageManager.DeleteFile(path);
                return NoContent();
            }
        }
    }
}
