using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyProjectTest.Shared;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace BlazorWebAssemblyProjectTest.Server.Controllers
{
    [ApiController]
    [Route("api/user")] //gettoken
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AdminController(ILogger<AdminController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login", new User());
        }


        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);
                if (result.Succeeded)
                {
                    return View("NewQuestion", user);
                }
            }
            return View("Login", user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register", new User());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User users)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = users.Login,
                    //Password = users.Password
                };
                var result = await _userManager.CreateAsync(user, user.Password);
                if (result.Succeeded)
                {
                    return Login();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Register", users);
        }


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
