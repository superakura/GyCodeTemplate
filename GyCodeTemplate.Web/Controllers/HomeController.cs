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

namespace GyCodeTemplate.Web.Controllers
{
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

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
    }
}
