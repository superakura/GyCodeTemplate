﻿using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;
using GyCodeTemplate.Repository.Interface;
using System.Linq;

namespace GyCodeTemplate.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly GyCodeTemplateContext db = new GyCodeTemplateContext();

        public IQueryable<UserInfo> GetList()
        {
            return db.UserInfo;
        }

        public UserInfo GetOne(int userInfoID)
        {
            return db.UserInfo.Where(w => w.Id == userInfoID).FirstOrDefault();
        }

        public bool SaveUserInfo(UserInfo userInfo)
        {
            if (userInfo.Id == 0)
            {
                db.UserInfo.Add(userInfo);
            }
            else
            {
                var info = db.UserInfo.Find(userInfo.Id);
                if (info != null)
                {
                    info.UserName = userInfo.UserName;
                    info.Phone = userInfo.Phone;
                    info.Remark = userInfo.Remark;
                    info.UserDeptId = userInfo.UserDeptId;
                    info.Sex = userInfo.Sex;
                    info.State = userInfo.State;
                    info.Duty = userInfo.Duty;
                    info.UserPwd = userInfo.UserPwd;
                }
            }
            return db.SaveChanges() == 1 ? true : false;
        }

        public UserInfo DelUserInfo(int userInfoID)
        {
            var info = db.UserInfo.Find(userInfoID);
            if (info != null)
            {
                db.UserInfo.Remove(info);
                db.SaveChanges();
            }
            return info;
        }
    }
}
