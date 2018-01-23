
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
    public interface IApplicationitem
    {

        #region  成员方法
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Applicationitem model);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Applicationitem model);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int id);

        int DeleteByAid(int aid, string mid, int type);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Applicationitem GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int aid,int mid,int pid);

        /// <summary>
        /// 查询活动添加的字段
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int a_id);
        #endregion  成员方法


    }

}