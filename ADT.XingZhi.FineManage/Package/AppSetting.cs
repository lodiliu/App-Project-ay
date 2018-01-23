using System.Configuration;
using System;

namespace ADT.XingZhi.FineManage.Package
{
    public class AppSetting
    {
        #region 发送短信配置
        /// <summary>
        /// 账号
        /// </summary>
        public static string SMSAccount
        {
            get
            {
                return ConfigurationManager.AppSettings["smsAccount"] ?? "";
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public static string SMSPwd
        {
            get
            {
                return ConfigurationManager.AppSettings["smsPwd"] ?? "";
            }
        }
        /// <summary>
        /// URL
        /// </summary>
        public static string SMSURL
        {
            get
            {
                return ConfigurationManager.AppSettings["smsUrl"] ?? "";
            }
        }
        /// <summary>
        /// 签名
        /// </summary>
        public static string SMSSign
        {
            get
            {
                return ConfigurationManager.AppSettings["smsSign"] ?? "";
            }
        }
        /// <summary>
        /// 验证码有效期（单位：分钟）
        /// </summary>
        public static int SMSExpire
        {
            get
            {
                int expire = 30;
                Int32.TryParse(ConfigurationManager.AppSettings["smsExpire"], out expire);
                return expire; 
            }
        }
        /// <summary>
        /// 每天验证次数
        /// </summary>
        public static int SMSNum
        {
            get
            {
                int expire = 5;
                Int32.TryParse(ConfigurationManager.AppSettings["smsnum"], out expire);
                return expire;
            }
        }
        #endregion
    }
}
