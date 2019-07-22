using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyCodeTemplate.Models.ViewModels
{
    /// <summary>
    /// 用户列表查询条件
    /// </summary>
    public class VUserListCondition
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string userName { get; set; }
        public string duty { get; set; }
    }
}
