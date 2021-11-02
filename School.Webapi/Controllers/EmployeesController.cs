using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities;
using School.Webapi.Entities.DTOs.EmployeeDTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.EmployeeRepasitory;
using School.Webapi.Services.ImageManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepasitory _employeeRepasitory;
        private readonly IMapper _mapper;
        private readonly IImageManager _imageManager;

        public EmployeesController(IEmployeeRepasitory employeeRepasitory,
            IMapper mapper, IImageManager imageManager)
        {
            this._employeeRepasitory = employeeRepasitory;
            this._mapper = mapper;
            this._imageManager = imageManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery]
            PaginationParametres paginationParametres)
        {
            var dtos = _mapper.Map<IEnumerable<EmployeeDTOMain>>(
                await _employeeRepasitory.GetAllAsync(paginationParametres)
                );

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _employeeRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else
            {
                EmployeeDTO dto = _mapper.Map<EmployeeDTO>(obj);
                dto.ImagePath = _imageManager.GetFullPath(obj.ImageName);
                return Ok(dto);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] 
            EmployeeDTOCreated employeeDTOcreated)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            Employee employee = _mapper.Map<Employee>(employeeDTOcreated);

            if (employeeDTOcreated.ImageFile != null)
            {
                if (!_imageManager.CheckIsImage(employeeDTOcreated.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(employeeDTOcreated.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                string downloadedFile = await _imageManager
                                    .UploadFileAsync(employeeDTOcreated.ImageFile);

                if (downloadedFile == null) return BadRequest("Image can not download");
                else employee.ImageName = downloadedFile;
            }

            return Created("New is created",
                await _employeeRepasitory.CreateAsync(employee));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromForm] EmployeeDTOCreated employeeDTOcreated)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var employee = await _employeeRepasitory.GetAsync(id);

            if (employee == null) return NotFound("Id is'nt correct");

            if (employeeDTOcreated.ImageFile != null)
            {
                if (!_imageManager.CheckIsImage(employeeDTOcreated.ImageFile.FileName))
                    return BadRequest("The file isn't image file");

                if (!_imageManager.CheckImageSize(employeeDTOcreated.ImageFile))
                    return BadRequest("Image length is longer than 2MB");

                if (employeeDTOcreated.ImageFile.FileName != employee.ImageName)
                    employee.ImageName = await _imageManager.ChangeFileAsync(
                        employee.ImageName, employeeDTOcreated.ImageFile);
            }

            _mapper.Map(employeeDTOcreated, employee);

            await _employeeRepasitory.UpdateAsync(id, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _employeeRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else
            {
                string path = obj.ImageName;
                await _employeeRepasitory.DeleteAsync(id);
                _imageManager.DeleteFile(path);
                return NoContent();
            }
        }
    }
}
