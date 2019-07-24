using System;
using System.Collections.Generic;

namespace GyCodeTemplate.Models
{
    public partial class DeptInfo
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int? DeptFatherId { get; set; }
        public double? DeptOrder { get; set; }
        public byte? DeptState { get; set; }
        public string DeptRemark { get; set; }
    }
}
