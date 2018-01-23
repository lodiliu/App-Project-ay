using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System.Data;

namespace ADT.XingZhi.BLL.S
{
    public class RoleUser
    {
        private readonly IRoleUser dal = null;
        public RoleUser()
        {
            dal = DataAccess.CreateRoleUser();
        }
        #region  Method
        /// <summary>
        /// 根据DataTable批量添加角色用户(利用表变量类型结合方式）--SQLServer2008或以上用
        /// </summary>
        /// <param name="dt">DataTable</param>
        public int BatchSave(DataTable dt)
        {
            return dal.BatchSave(dt);
        }
        /// <summary>
        /// 根据角色编号和用户编号删除一条数据
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public int Delete(int roleId, int userId)
        {
            return dal.Delete(roleId, userId);
        }
        /// <summary>
        /// 根据角色编号和用户编号组批量删除（以英文","隔开)
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="userId">用户编号组</param>
        public int BatchDelete(int roleId, string ids)
        {
            return dal.BatchDelete(roleId, ids);
        }
        #endregion
    }
}
