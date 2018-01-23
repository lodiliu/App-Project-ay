using System;

namespace ADT.XingZhi.Models.S
{
    public class Log
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 动作（比如：添加，编辑，删除，查看）
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 操作链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 操作方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 操作用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 操作用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
