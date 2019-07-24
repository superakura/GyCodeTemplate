using System;
using System.Collections.Generic;
using System.Text;

namespace GyCodeTemplate.Service.Dto
{
    public class UserInfoDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string UserDeptName { get; set; }
        public string Duty { get; set; }
        public string Remark { get; set; }
    }
}
