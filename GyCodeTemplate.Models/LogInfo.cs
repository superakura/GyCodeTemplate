using System;
using System.Collections.Generic;

namespace GyCodeTemplate.Models
{
    public partial class LogInfo
    {
        public int LogId { get; set; }
        public string LogContent { get; set; }
        public DateTime? CreatTime { get; set; }
        public int? UserId { get; set; }
    }
}
