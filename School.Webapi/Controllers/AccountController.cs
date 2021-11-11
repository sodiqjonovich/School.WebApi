using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.Webapi.Entities.DTOs.UserDTOs;
using School.Webapi.Entities.Models;
using School.Webapi.Services.AuthorizeManager;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace School.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<User> userManager,
            IMapper imapper,
            IAuthManager authManager)
        {
            this._userManager = userManager;
            this._mapper = imapper;
            this._authManager = authManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(
            [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return Accepted();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginDTO loginDTO)
        {
            if (await _authManager.ValidateUser(loginDTO))
            {
                return Accepted(new 
                { 
                    Token = await _authManager.CreateToken()
                });
            }
            else return Unauthorized();
        }

        [Authorize (Roles = "User, Admin")]
        [HttpPost]
        [Route("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePassword(
            [FromForm] ChangePasswordDTO changePasswordDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await GetEmailByTokenAsync();

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user,
                    changePasswordDTO.CurrentPassword))
                {
                    await _userManager.ChangePasswordAsync(
                    user, changePasswordDTO.CurrentPassword,
                    changePasswordDTO.NewPassword);
                    return NoContent();
                }
                else return BadRequest("CurrentPassword is'nt correct");
            }
            else return BadRequest("User didn't found , You may try to Register");
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [Route("UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditAccaunt(
            [FromForm] UserDTOMain userDTOMain)
        {
            User user = await GetEmailByTokenAsync();
            if (user != null)
            {
                user.Firstname = userDTOMain.Firstname;
                user.Lastname = userDTOMain.Lastname;
                user.PhoneNumber = userDTOMain.PhoneNumber;
                await _userManager.UpdateAsync(user);
                return NoContent();
            }
            else return BadRequest("User not found");
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        [Route("GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccaunt()
        {
            User user = await GetEmailByTokenAsync();
            if (user != null)
            {
                var dto = _mapper.Map<UserDTOMain>(user);
                return Ok(dto);
            }
            else return NotFound();
        }

        private async Task<User> GetEmailByTokenAsync()
        {
            string email = String.Empty;

            if (User.Identity is ClaimsIdentity identity)
            {
                email = identity.FindFirst(ClaimTypes.Name).Value;
            }

            return await _userManager.FindByEmailAsync(email);
        }
    }
}
