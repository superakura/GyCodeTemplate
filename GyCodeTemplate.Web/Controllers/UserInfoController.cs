using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Models.ViewModels;
using GyCodeTemplate.Models;

namespace GyCodeTemplate.Web.Controllers
{
    public class UserInfoController : Controller
    {
        //目前需解决的问题：
        //1、单元测试方法的实现
        //2、crud的命名规范
        //3、用户权限控制的实现
        //4、页面dto处理
        //5、利用autofac实现自动批量注入
        private readonly IUserInfoService _IService;
        public UserInfoController(IUserInfoService service)
        {
            _IService = service;
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

            return Json(_IService.GetUserInfoList(input));
        }

        [HttpPost]
        public string Save()
        {
            var userID = 0;
            int.TryParse(Request.Form["userID"], out userID);
            //ID为0，创建一个对象，执行添加。ID不为0，执行更新。
            UserInfo info = userID == 0 ? new UserInfo() : _IService.GetOneUserInfo(userID);
            info.UserName = Request.Form["userName"];
            info.Duty = Request.Form["duty"];
            info.Phone = Request.Form["phone"];
            info.Remark= Request.Form["remark"];

            return _IService.SaveUserInfo(info) ? "ok" : "error";
        }
    }
}