using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.EmployeeRepasitory;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepasitory _employeeRepasitory;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepasitory employeeRepasitory,
            IMapper mapper)
        {
            this._employeeRepasitory = employeeRepasitory;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeRepasitory.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _employeeRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] 
            EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (employeeDTO == null) return BadRequest();

            Employee employee = _mapper.Map<Employee>(employeeDTO);

            return Created("New is created",
                await _employeeRepasitory.CreateAsync(employee));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (employeeDTO == null) return BadRequest();

            var newObj = _mapper.Map<Employee>(employeeDTO);

            await _employeeRepasitory.UpdateAsync(id, newObj);

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
                await _employeeRepasitory.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
