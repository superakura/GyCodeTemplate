using System;
using System.Collections.Generic;
using System.Text;
using GyCodeTemplate.Models;

namespace GyCodeTemplate.Models.ViewModels
{
    /// <summary>
    /// 用户列表返回
    /// </summary>
    public class VUserList
    {
        public int total { get; set; }
        public List<UserInfo> rows { get; set; }
    }
}
