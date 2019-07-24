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
        public DateTime? CreatTime { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string Duty { get; set; }
        public byte? State { get; set; }
        public int? UserDeptId { get; set; }
    }
}
