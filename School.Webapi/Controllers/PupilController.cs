using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.PupilRepasitory;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly IPupilRepasitory _pupilRepasitory;
        private readonly IMapper _mapper;

        public PupilController(IPupilRepasitory pupilRepasitory,
            IMapper imapper)
        {
            this._pupilRepasitory = pupilRepasitory;
            this._mapper = imapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _pupilRepasitory.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _pupilRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] PupilDTO pupilDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (pupilDTO == null) return BadRequest();

            var newObj = _mapper.Map<Pupil>(pupilDTO);

            return Created("Pupil is created",
                await _pupilRepasitory.CreateAsync(newObj));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, 
            [FromBody] PupilDTO pupilDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (pupilDTO == null) return BadRequest();

            Pupil pupil = _mapper.Map<Pupil>(pupilDTO);
            
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
                await _pupilRepasitory.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
