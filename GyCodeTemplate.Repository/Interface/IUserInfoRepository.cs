using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using System.Linq;

namespace GyCodeTemplate.Repository.Interface
{
    public interface IUserInfoRepository
    {
        IQueryable<UserInfo> GetList();

        UserInfo GetOne(int userInfoID);

        bool SaveUserInfo(UserInfo userInfo);

        UserInfo DelUserInfo(int userInfoID);
    }
}
