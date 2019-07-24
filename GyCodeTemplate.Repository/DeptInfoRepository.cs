using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Repository.Interface;

namespace GyCodeTemplate.Repository
{
    public class DeptInfoRepository : IDeptInfoRepository
    {
        private readonly GyCodeTemplateContext db = new GyCodeTemplateContext();
        public DeptInfo Del(int infoID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeptInfo> GetList()
        {
            return db.DeptInfo;
        }

        public DeptInfo GetOne(int infoID)
        {
            return db.DeptInfo.Find(infoID);
        }

        public void Save(DeptInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
