using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Models.ViewModels;

namespace GyCodeTemplate.Web.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService _service;
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
            var limit = 0;
            int.TryParse(Request.Form["limit"], out limit);

            var offset = 0;
            int.TryParse(Request.Form["offset"], out offset);

            VUserListCondition input = new VUserListCondition();
            input.limit = limit;
            input.offset = offset;
            input.userName = Request.Form["userName"];
            input.duty = Request.Form["duty"];

            return Json(_service.GetUserInfoList(input));
        }
    }
}