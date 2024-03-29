﻿using System;
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
        //1、单元测试实现
        //2、命名规范
        //3、用户权限控制的实现，系统认证架构的实现。
        //4、页面dto处理,dto和entity的自动映射
        //5、利用autofac实现自动批量注入
        //6、repository泛型的实现。
        //7、unit of work的实现
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
            var deptUserID = 0;
            int.TryParse(Request.Form["deptUserID"], out deptUserID);
            info.UserDeptId = deptUserID;
            info.State = 0;//用户状态默认为正常
            //如果添加用户，则设置用户创建日期字段
            if (userID==0)
            {
                info.CreatTime = DateTime.Now;
            }

            return _IService.SaveUserInfo(info) ? "ok" : "error";
        }

        [HttpPost]
        public JsonResult GetOne()
        {
            var userID = 0;
            int.TryParse(Request.Form["userID"], out userID);
            return Json(_IService.GetOneUserInfo(userID));
        }
    }
}