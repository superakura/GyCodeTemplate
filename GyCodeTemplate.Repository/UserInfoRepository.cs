using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Repository.Interface;
using System.Linq;

namespace GyCodeTemplate.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private GyCodeTemplateContext db = new GyCodeTemplateContext();

        public List<UserInfo> GetList()
        {
            return db.UserInfo.ToList();
        }

        public UserInfo GetOne(int id)
        {
            return db.UserInfo.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
