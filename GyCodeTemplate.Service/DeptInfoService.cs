using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;
using System.Linq;
using GyCodeTemplate.Service.Interface;

namespace GyCodeTemplate.Service
{
    public class DeptInfoService : IDeptInfoService
    {
        private readonly IDeptInfoRepository _deptInfoRepository;
        public DeptInfoService(IDeptInfoRepository repo)
        {
            _deptInfoRepository = repo;
        }
        public DeptInfo DelDeptInfo(int deptID)
        {
            throw new NotImplementedException();
        }

        public List<DeptInfo> GetDeptFatherList()
        {
            return _deptInfoRepository.GetList().Where(w => w.DeptFatherId == 1).OrderBy(o=>o.DeptOrder).ToList();
        }

        public List<DeptInfo> GetDeptList()
        {
            return _deptInfoRepository.GetList().OrderBy(o => o.DeptOrder).ToList();
        }

        public DeptInfo GetOneDeptInfo(int deptID)
        {
            throw new NotImplementedException();
        }

        public bool SaveDept(DeptInfo deptInfo)
        {
            throw new NotImplementedException();
        }
    }
}
