using System;
using System.Collections.Generic;
using System.Text;

namespace GyCodeTemplate.Models.ViewModels
{
    /// <summary>
    /// bootstrapTable返回数据模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VPageBootstrapTable<T>
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}
