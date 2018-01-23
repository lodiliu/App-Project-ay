
namespace ADT.XingZhi.Models.S
{
    public class MenuPurviewCode
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否禁用（1-已禁用，0-未禁用）
        /// </summary>
        public bool Disabled { get; set; }
    }
}
