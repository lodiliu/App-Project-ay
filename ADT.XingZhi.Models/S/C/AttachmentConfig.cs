using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ADT.XingZhi.Models.S.C
{
    /// <summary>
    /// 4-附件配置
    /// </summary>
    public class AttachmentConfig
    {
        public AttachmentConfig() { }
        public AttachmentConfig(Dictionary<string, string> dic)
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
        /// 导入Excel文件类型
        /// </summary>
        public string ImportExcelExt { get; set; }
        /// <summary>
        /// 导入Excel文件最大大小（单位：MB）
        /// </summary>
        public int ImportExcelMaxSize { get; set; }
        /// <summary>
        /// 上传通讯密钥
        /// </summary>
        public string FileServerMD5Key { get; set; }
        /// <summary>
        /// 是否上传至共享目录
        /// </summary>
        public string EnabledUploadShare { get; set; }
        /// <summary>
        /// 上传文件目录
        /// </summary>
        public string UploadDir { get; set; }
        /// <summary>
        /// 上传文件访问基地址
        /// </summary>
        public string UploadUrl { get; set; }
        /// <summary>
        /// 上传文件的保存目录规则
        /// </summary>
        public string UploadFilePathRule { get; set; }
        /// <summary>
        /// 上传文件名保存规则
        /// </summary>
        public string FileNameRule { get; set; }
        /// <summary>
        /// 允许上传图片类型
        /// </summary>
        public string UploadImgExt { get; set; }
        /// <summary>
        /// 允许上传图片最大大小（单位：KB）
        /// </summary>
        public int UploadImgMaxSize { get; set; }
        /// <summary>
        /// 允许上传文件类型
        /// </summary>
        public string UploadFileExt { get; set; }
        /// <summary>
        /// 允许上传文件最大大小（单位：MB）
        /// </summary>
        public int UploadFileMaxSize { get; set; }
    }
}
