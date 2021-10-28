using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.GroupRepasitory;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepasitory _groupRepasitory;
        private readonly IMapper _mapper;

        public GroupsController(IGroupRepasitory groupRepasitory,
            IMapper imapper)
        {
            this._groupRepasitory = groupRepasitory;
            this._mapper = imapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _groupRepasitory.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _groupRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] GroupDTO groupDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (groupDTO == null) return BadRequest();

            var group = _mapper.Map<Group>(groupDTO);

            return Created("New is created",
                await _groupRepasitory.CreateAsync(group));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromBody] GroupDTO groupDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (groupDTO == null) return BadRequest();

            var group = _mapper.Map<Group>(groupDTO);

            await _groupRepasitory.UpdateAsync(id, group);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _groupRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else
            {
                await _groupRepasitory.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
