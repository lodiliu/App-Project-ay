using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.XingZhi.Models.X
{
    public class PageRole
    {
        /// <summary>
        /// 模块代码
        /// </summary>
        public string _PageModel { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string _ModelName { get; set; }
        /// <summary>
        /// 页面代码
        /// </summary>
        public string _PageCode { get; set; }
        /// <summary>
        /// 页面名称
        /// </summary>
        public string _CodeName { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string _ApiUrl { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string _Flag { get; set; }
    }
}
