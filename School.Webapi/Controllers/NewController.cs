using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.NewRepasitory;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly INewRepasitory _newRepasitory;
        private readonly IMapper _mapper;

        public NewController(INewRepasitory newRepasitory,
            IMapper imapper)
        {
            this._newRepasitory = newRepasitory;
            this._mapper = imapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newRepasitory.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _newRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else return Ok(obj);
        }

        // POST api/<NewController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] NewDTO newDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (newDTO == null) return BadRequest();

            var newObj = _mapper.Map<New>(newDTO);
            return Created("New is created", 
                await _newRepasitory.CreateAsync(newObj));
        }

        // PUT api/<NewController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromBody] NewDTO newDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (newDTO == null) return BadRequest();

            New newObj = _mapper.Map<New>(newDTO);

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
                await _newRepasitory.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
