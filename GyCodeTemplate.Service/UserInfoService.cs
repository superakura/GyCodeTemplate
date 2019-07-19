using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;
using System.Linq;

namespace GyCodeTemplate.Service
{
    public class UserInfoService : IUserInfoService
    {
        public readonly IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }
        public List<UserInfo> GetUserInfoList()
        {
            return _userInfoRepository.GetList().ToList();
        }
    }
}
