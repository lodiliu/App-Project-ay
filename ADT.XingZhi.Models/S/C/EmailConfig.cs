using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ADT.XingZhi.Models.S.C
{
    /// <summary>
    /// 3-邮箱配置
    /// </summary>
    public class EmailConfig
    {
        public EmailConfig() { }
        public EmailConfig(Dictionary<string, string> dic)
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
        /// SMTP地址
        /// </summary>
        public string SMTPServerAddress { get; set; }
        /// <summary>
       /// SMTP端口号
       /// </summary>
        public string SMTPPort { get; set; }
        /// <summary>
       /// SMTP UserName
       /// </summary>
        public string SMTPUserName { get; set; }
        /// <summary>
       /// SMTP Password
       /// </summary>
        public string SMTPUserPassword { get; set; }
        /// <summary>
       /// Email 发件人
       /// </summary>
        public string MailSender { get; set; }

    }
}
