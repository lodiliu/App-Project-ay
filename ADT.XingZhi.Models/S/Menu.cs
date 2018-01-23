
using System;
using System.Data.SqlClient;
using System.Reflection;
namespace ADT.XingZhi.Models.S
{
    /// <summary>
    /// 系统菜单表Model
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 排序路径
        /// </summary>
        public string OrderPath { get; set; }
        /// <summary>
        /// 层次（从0开始）
        /// </summary>
        public byte Level { get; set; }
        /// <summary>
        /// ICON路径
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 是否禁用（1-已禁用，0-未禁用）
        /// </summary>
        public bool Disabled { get; set; }
    }
}
