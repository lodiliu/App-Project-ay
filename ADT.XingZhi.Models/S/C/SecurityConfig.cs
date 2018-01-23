using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ADT.XingZhi.Models.S.C
{
    /// <summary>
    /// 2-安全配置
    /// </summary>
    public class SecurityConfig
    {
        public SecurityConfig() { }
        public SecurityConfig(Dictionary<string, string> dic)
        {
            if (dic != null && dic.Count > 0)
            {
                foreach (string key in dic.Keys)
                {
                    string value = dic[key];
                    PropertyInfo property = GetType().GetProperty(key);
                    if (property == null)
                    {
                        continue;
                    }
                    else
                    {
                        property.SetValue(this, Convert.ChangeType(value, property.PropertyType, CultureInfo.CurrentCulture), null);
                    }
                }
            }
        }
        /// <summary>
        /// 初始口令
        /// </summary>
        public string InitPwd { get; set; }
        /// <summary>
        /// 启用后台管理操作日志
        /// </summary>
        public int AdminLog { get; set; }
        /// <summary>
        /// 后台最大登陆失败次数
        /// </summary>
        public int MaxLoginFailedTimes { get; set; }
    }
}
