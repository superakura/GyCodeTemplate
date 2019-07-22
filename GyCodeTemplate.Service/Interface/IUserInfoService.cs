using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Models.ViewModels;
using GyCodeTemplate.Repository;

namespace GyCodeTemplate.Service.Interface
{
    public interface IUserInfoService
    {
        VPageBootstrapTable<UserInfo> GetUserInfoList(VUserListCondition input);
    }
}
