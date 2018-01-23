using System;

namespace ADT.XingZhi.Models.S
{
    public class LoginTimes
    {
        /// <summary>
        /// 系统用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 是否是系统用户（1-是，0-否）
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int Times { get; set; }
    }
}
