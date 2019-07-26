using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GyCodeTemplate.Models.ViewModels;
using GyCodeTemplate.Service.Interface;

namespace GyCodeTemplate.Web.Controllers
{
    public class DeptInfoController : Controller
    {
        private readonly IDeptInfoService _deptInfoService;
        public DeptInfoController(IDeptInfoService service)
        {
            _deptInfoService = service;
        }

        public IActionResult List()
        {
            return View();
        }

        public JsonResult GetDeptFatherList()
        {
            return Json(_deptInfoService.GetDeptFatherList());
        }
    }
}