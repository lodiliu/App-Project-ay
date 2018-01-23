using System;

namespace ADT.XingZhi.Models.S
{
    public class User
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 混淆字符
        /// </summary>
        public string Encrypt { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号码（多个以空格隔开）
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 座机号码（多个以空格隔开）
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime? PrevLoginTime { get; set; }
        /// <summary>
        /// 上一次登录IP
        /// </summary>
        public string PrevLoginIP { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 是否禁用（1-已禁用，0-未禁用）
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        public DateTime? LastModifyPasswordTime { get; set; }
    }
}
