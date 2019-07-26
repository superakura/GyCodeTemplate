using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Repository;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;

namespace GyCodeTemplate.Service.Interface
{
    public interface IDeptInfoService
    {
        DeptInfo GetOneDeptInfo(int deptID);

        List<DeptInfo> GetDeptFatherList();

        List<DeptInfo> GetDeptList();

        DeptInfo DelDeptInfo(int deptID);

        bool SaveDept(DeptInfo deptInfo);
    }
}
