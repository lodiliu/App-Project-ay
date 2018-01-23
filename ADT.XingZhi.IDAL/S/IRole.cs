
using System.Data;
namespace ADT.XingZhi.IDAL.S
{
    public interface IRole
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Save(ADT.XingZhi.Models.S.Role model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int DeleteById(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ADT.XingZhi.Models.S.Role GetModelById(int id);
        int GetMaxOrderId();
        void UpdateOrderId(DataTable dt);
        #endregion  成员方法
    }
}
