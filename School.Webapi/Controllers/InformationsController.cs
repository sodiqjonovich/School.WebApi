using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.InformationRepasitory;
using System;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        private readonly IInformationRepasitory _informationRepasitory;
        private readonly IMapper _mapper;

        public InformationsController(
            IInformationRepasitory informationRepasitory,
            IMapper imapper)
        {
            this._informationRepasitory = informationRepasitory;
            this._mapper = imapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var information = await _informationRepasitory.Get();
            return Ok(information);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id,
            [FromBody] InformationDTO infoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (infoDTO == null) return BadRequest();

            Information information = _mapper.Map<Information>(infoDTO);
            await _informationRepasitory.UpdateAsync(id, information);
            return NoContent();
        }
    }
}
