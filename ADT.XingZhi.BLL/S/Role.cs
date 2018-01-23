using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System.Data;

namespace ADT.XingZhi.BLL.S
{
    public class Role
    {
        private readonly IRole dal = null;
        public Role()
        {
            dal = DataAccess.CreateRole();
        }
        #region  Method

        /// <summary>
        /// 保存一条数据
        /// </summary>
        public int Save(ADT.XingZhi.Models.S.Role model)
        {
            return dal.Save(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteById(int id)
        {
            return dal.DeleteById(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.Role GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        /// <summary>
        /// 获取最大排序编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrderId()
        {
            return dal.GetMaxOrderId();
        }
        /// <summary>
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt)
        {
            dal.UpdateOrderId(dt);
        }
        #endregion
    }
}
