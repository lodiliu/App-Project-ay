using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.XingZhi.Models.X
{
    /// <summary>
    /// 消息推送表
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int _id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string _title { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string _context { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string _createduser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime _createdtime { get; set; }
        /// <summary>
        /// 启用标记
        /// </summary>
        public bool _deleteflag { get; set; }
    }
}
