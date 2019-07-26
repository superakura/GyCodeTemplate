using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Service.Interface;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Models;
using GyCodeTemplate.Models.ViewModels;
using System.Linq;
using GyCodeTemplate.Service.Dto;

namespace GyCodeTemplate.Service
{
    public class UserInfoService : IUserInfoService
    {
        public readonly IUserInfoRepository _userInfoRepository;
        public readonly IDeptInfoRepository _deptInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository,IDeptInfoRepository deptInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _deptInfoRepository = deptInfoRepository;
        }

        /// <summary>
        /// 用户状态变更方法，用于用户锁定，用户软删除
        /// </summary>
        /// <param name="state"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool ChangeUserInfoState(byte state, int userID)
        {
            var info = _userInfoRepository.GetOne(userID);
            info.State = state;
            return _userInfoRepository.SaveUserInfo(info);
        }

        public UserInfo DelUserInfo(int userID)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetOneUserInfo(int userID)
        {
            //这里调用数据层方法，应用层可以根据实际需要增加更多的处理内容
            //例如：对不同权限的用户，只能返回用户的部分信息
            return _userInfoRepository.GetOne(userID);
            //if (userID==1)
            //{
            //    return _userInfoRepository.GetOne(userID);
            //}
            //else
            //{
            //    var info = _userInfoRepository.GetOne(userID);
            //    info.State = null;
            //    return info;
            //}
        }

        public VPageBootstrapTable<UserInfoDto> GetUserInfoList(VUserListCondition input)
        {
            var listUser = _userInfoRepository.GetList();
            var listDept = _deptInfoRepository.GetList();
            var list = from t in listUser
                       join d in listDept on t.UserDeptId equals d.DeptId
                       select new UserInfoDto
                       {
                           ID=t.Id,
                           Phone = t.Phone,
                           Remark = t.Remark,
                           UserDeptName = d.DeptName,
                           UserName = t.UserName,
                           Duty = t.Duty
                       };
            if (!string.IsNullOrEmpty(input.userName))
            {
                list = list.Where(w => w.UserName.Contains(input.userName));
            }
            if (!string.IsNullOrEmpty(input.duty))
            {
                list = list.Where(w => w.Duty.Contains(input.duty));
            }
            VPageBootstrapTable<UserInfoDto> page=new VPageBootstrapTable<UserInfoDto>();
            page.rows = list.Skip(input.offset).Take(input.limit).ToList();
            page.total = list.Count();
            return page;
        }

        /// <summary>
        /// 添加、修改用户信息方法
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool SaveUserInfo(UserInfo userInfo)
        {
            return _userInfoRepository.SaveUserInfo(userInfo);
        }
    }
}
