﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Webapi.Entities;
using School.Webapi.Entities.DTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Repasitories.GroupRepasitory;
using System;
using System.Collections.Generic;
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
        
        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            PaginationParametres paginationParametres)
        {
            var objects = await _groupRepasitory.GetAllAsync(paginationParametres);

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

            var dtos = _mapper.Map<IEnumerable<GroupDTO>>(
                    objects);

            return Ok(dtos);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _groupRepasitory.GetAsync(id);
            if (obj == null) return NotFound();
            else return Ok(obj);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
