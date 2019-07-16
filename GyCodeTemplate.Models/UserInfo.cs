using System;
using System.Collections.Generic;

namespace GyCodeTemplate.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Remark { get; set; }
    }
}
