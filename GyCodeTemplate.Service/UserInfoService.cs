using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;
using GyCodeTemplate.Models.ViewModels;
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

        public VPageBootstrapTable<UserInfo> GetUserInfoList(VUserListCondition input)
        {
            var list = _userInfoRepository.GetList();
            if (!string.IsNullOrEmpty(input.userName))
            {
                list = list.Where(w => w.UserName.Contains(input.userName));
            }
            if (!string.IsNullOrEmpty(input.duty))
            {
                list = list.Where(w => w.UserName.Contains(input.duty));
            }
            VPageBootstrapTable<UserInfo> page=new VPageBootstrapTable<UserInfo>();
            page.rows = list.Skip(input.offset).Take(input.limit).ToList();
            page.total = list.Count();
            return page;
        }
    }
}
