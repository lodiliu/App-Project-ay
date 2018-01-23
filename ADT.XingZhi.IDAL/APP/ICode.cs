
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
    public interface ICode
    {

        #region  成员方法
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Code model);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Code model);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int id);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Code GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable();

        /// <summary>
        /// 根据手机号查询最新一条数据
        /// </summary>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Code GetModel(string phon);
        #endregion  成员方法


    }

}

