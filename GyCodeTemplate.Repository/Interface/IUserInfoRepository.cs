using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;

namespace GyCodeTemplate.Repository.Interface
{
    public interface IUserInfoRepository
    {
        List<UserInfo> GetList();

        UserInfo GetOne(int id);
    }
}
