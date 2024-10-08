﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountService;

        public AccountController(IAccountRepository accountService)
        {
            _accountService = accountService;
        }
        // register
        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto registerDto)
        {
            var user = await _accountService.RegisterUser(registerDto);
            return Ok(user);
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login(string UserName, string Password)
        {
            var user = await _accountService.UserAuthentication(UserName, Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        // logout
        [HttpPost("Logout")]
        public async Task<ActionResult<AccountDto>> LogOut(string username)
        {
            var newLogout = await _accountService.LogOut(username);
            return newLogout;
        }


        // Profile

        [Authorize(Roles = "Admin", Policy = "full_access")] // only logged in users can have access to the profile
        //[Authorize(Policy = "update")]
        [HttpGet("Profile")]
        public async Task<ActionResult<AccountDto>> Profile()
        {
            return await _accountService.GetToken(User);
        }
    }
}
