using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System.Data;

namespace ADT.XingZhi.BLL.S
{
    public class RoleMenuPurviewCode
    {
        private readonly IRoleMenuPurviewCode dal = null;
        public RoleMenuPurviewCode()
        {
            dal = DataAccess.CreateRoleMenuPurviewCode();
        }
        #region  Method
        /// <summary>
        /// 根据DataTable批量添加(利用表变量类型方式）--SQLServer2008或以上用
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public int BatchSave(DataTable dt, int roleId)
        {
            return dal.BatchSave(dt, roleId);
        }
        /// <summary>
        /// 根据角色编号获取权限值列表
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public DataTable GetPurviewCodeListByRoleId(int roleId)
        {
            return dal.GetPurviewCodeListByRoleId(roleId);
        }
        #endregion  Method
    }
}
