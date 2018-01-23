using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ADT.XingZhi.DAL.S
{
    /// <summary>
    /// 站点配置
    /// </summary>
    public class SiteSingleton : Models.S.C.SiteConfig
    {
        private static SiteSingleton singleton;
        private static readonly object padlock = new object();
        public static SiteSingleton Singleton
        {
            get
            {
                if (singleton == null)
                {
                    lock (padlock)
                    {
                        if (singleton == null)
                        {
                            singleton = new SiteSingleton();
                        }
                    }
                }
                return singleton;
            }
            set
            {
                singleton = value;
            }
        }
        public SiteSingleton()
        {
            Dictionary<string, string> dic = new DAL.S.Config().GetConfigByGroupId(1);
            if (dic != null)
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
    }
    /// <summary>
    /// 附件配置单实例
    /// </summary>
    public sealed class AttachmentSingleton : Models.S.C.AttachmentConfig
    {
        private static AttachmentSingleton singleton;
        private static readonly object padlock = new object();
        public static AttachmentSingleton Singleton
        {
            get
            {
                if (singleton == null)
                {
                    lock (padlock)
                    {
                        if (singleton == null)
                        {
                            singleton = new AttachmentSingleton();
                        }
                    }
                }
                return singleton;
            }
            set
            {
                singleton = value;
            }
        }
        public AttachmentSingleton()
        {
            Dictionary<string, string> dic = new DAL.S.Config().GetConfigByGroupId(4);
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
    }
}
