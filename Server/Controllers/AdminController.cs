﻿using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace BlazorWebAssemblyProjectTest.Server.Controllers
{ 
    [ApiController]
    [Route("api/admin")] //gettoken
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        //private UserManager<Admin> _adminManager;
        //private SignInManager<Admin> _signInManager;

        //public AdminController(UserManager<Admin> adminManager, SignInManager<Admin> signInManager)
        //{
        //    _adminManager = adminManager;
        //    _signInManager = signInManager;
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View("Login", new Admin());
        //}


        //public async Task<IActionResult> Login(Admin model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
        //        if (result.Succeeded)
        //        {
        //            return View("NewQuestion", model);
        //        }
        //    }
        //    return View("Login", model);
        //}


        [HttpPost("gettoken")]
        public ActionResult<string> GetToken([FromBody] Admin admin) 
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, admin.Login) };

            var token = new JwtSecurityToken(JwtOptions.Issuer, JwtOptions.Audience, claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(JwtOptions.GetKey(), SecurityAlgorithms.HmacSha256));

            string str = new JwtSecurityTokenHandler().WriteToken(token);
            _logger.LogInformation(str);

            return Ok(str);
        }

    }
}
