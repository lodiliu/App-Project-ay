using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace ADT.XingZhi.IDAL.APP
{
    /// <summary>
    /// 业务处理层接口
    /// </summary>
    public interface IFile
    {

        #region  成员方法
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(Models.APP.File model);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(Models.APP.File model);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int id);
        int DeleteByfid(int id);

        void UpdateOrderId(DataTable dt);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Models.APP.File GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int id);
        #endregion  成员方法


    }
}
