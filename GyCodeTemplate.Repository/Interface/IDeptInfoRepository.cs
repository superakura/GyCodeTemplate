using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GyCodeTemplate.Models;

namespace GyCodeTemplate.Repository.Interface
{
    public interface IDeptInfoRepository
    {
        IQueryable<DeptInfo> GetList();

        DeptInfo GetOne(int infoID);

        void Save(DeptInfo info);

        DeptInfo Del(int infoID);
    }
}
