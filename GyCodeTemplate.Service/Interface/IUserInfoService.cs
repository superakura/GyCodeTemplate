using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Models.ViewModels;
using GyCodeTemplate.Repository;
using GyCodeTemplate.Service.Dto;

namespace GyCodeTemplate.Service.Interface
{
    public interface IUserInfoService
    {
        VPageBootstrapTable<UserInfoDto> GetUserInfoList(VUserListCondition input);

        bool SaveUserInfo(UserInfo userInfo);

        UserInfo GetOneUserInfo(int userID);

        UserInfo DelUserInfo(int userID);

        bool ChangeUserInfoState(byte state, int userID);
    }
}
