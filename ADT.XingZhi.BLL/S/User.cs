using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System;
using System.Data;
using System.Text;

namespace ADT.XingZhi.BLL.S
{
    public class User
    {
        private readonly IUser dal = null;
        public User()
        {
            dal = DataAccess.CreateUser();
        }
        #region Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model">ADT.XingZhi.Models.S.User</param>
        /// <param name="userRoleDT">用户角色信息DataTable</param>
        public int Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)
        {
            return dal.Add(model, userRoleDT);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model">ADT.XingZhi.Models.S.User</param>
        /// <param name="userRoleDT">用户角色信息DataTable</param>
        public int Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)
        {
            return dal.Modify(model, userRoleDT);
        }
        /// <summary>
        /// 设置禁用
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="disabled">true-已禁用，false-未禁用</param>
        /// <returns></returns>
        public int SetDisabled(int id, bool disabled)
        {
            return dal.SetDisabled(id, disabled);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.User GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username">用户名(也可以为姓名）</param>
        /// <returns></returns>
        public ADT.XingZhi.Models.S.User GetModelByUserName(string username)
        {
            return dal.GetModelByUserName(username);
        }
        /// <summary>
        /// 根据登录情况更新登录用户信息
        /// </summary>
        public int UpdateByLogin(int id, string ip)
        {
            return dal.UpdateByLogin(id, ip);
        }
        /// <summary>
        /// 修改档案
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public int ModifyInfo(Models.S.User model)
        {
            return dal.ModifyInfo(model);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户编号</param> 
        /// <param name="pwd">新密码</param>
        /// <param name="encrypt">安全密钥</param>
        /// <returns></returns>
        public int ModifyPwd(int id, string pwd, string encrypt)
        {
            return dal.ModifyPwd(id, pwd, encrypt);
        }
        /// <summary>
        /// 根据用户编号获取权限值列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable GetPermissionByUserId(int userId)
        {
            return dal.GetPermissionByUserId(userId);
        }
        /// <summary>
        /// 根据用户编号获取角色信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public string GetRoleByUserId(int userId)
        {
            return dal.GetRoleByUserId(userId);
        }
        /// <summary>
        /// 根据用户编号组获取权限值
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>string类型</returns>
        public string GetPurviewCodesByUserId(int userId)
        {
            using (DataTable dt = this.GetPermissionByUserId(userId))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder(",");
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.AppendFormat("{0},", dr["MPC_CODE"]);
                    }
                    return sb.ToString();
                }
                return String.Empty;
            }
        }

        /// <summary>
        ///  根据用户名查询除去本身数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(string user)
        {
            return dal.GetTable(user);
        }
        #endregion
    }
}
