using System;

namespace ADT.XingZhi.Models.S
{
    public class File
    {
        /// <summary>
        /// 编号（GUID形式）
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 路径(不包括文件名称）
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 文件Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Ext { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public Int64 Size { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建者IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int Downloads { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extra { get; set; }
    }
}
