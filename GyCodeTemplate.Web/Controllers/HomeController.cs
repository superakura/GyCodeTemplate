using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GyCodeTemplate.Web.Models;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace GyCodeTemplate.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUserInfoService userInfoService;
        public HomeController(IUserInfoService service)
        {
            userInfoService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "system")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "admin")]
        public ViewResult IndexLay()
        {
            return View();
        }

        [AllowAnonymous][HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous][HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            var list = new List<dynamic> {
                new { UserName = "ym", Password = "111111", Role = "admin",Name="杨幂" },
                new { UserName = "gy", Password = "222222", Role = "system",Name="高源" }
            };
            var user = list.SingleOrDefault(s => s.UserName == userName && s.Password == password);
            if (user != null)
            {
                //用户标识
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, userName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                if (returnUrl == null)
                {
                    returnUrl = TempData["returnUrl"]?.ToString();
                }
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            else
            {
                const string badUserNameOrPasswordMessage = "用户名或密码错误！";
                return BadRequest(badUserNameOrPasswordMessage);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [AllowAnonymous][HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
