using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GyCodeTemplate.Service.Interface;

namespace GyCodeTemplate.Web.Controllers
{
    public class UserInfoController : Controller
    {
        private IUserInfoService _service;
        public UserInfoController(IUserInfoService service)
        {
            _service = service;
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList()
        {
            return Json(_service.GetUserInfoList());
        }
    }
}