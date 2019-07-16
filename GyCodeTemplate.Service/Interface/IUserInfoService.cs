using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Repository;

namespace GyCodeTemplate.Service.Interface
{
    public interface IUserInfoService
    {
        List<UserInfo> GetUserInfoList();
    }
}
