using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.DALFactory.APP;
using ADT.XingZhi.IDAL.APP;
using ADT.CMS.Utility;

namespace ADT.XingZhi.BLL.APP
{

    public class package
    {
        private readonly Ipackage dal = null;
        public package()
        {
            dal = DataAccess.Createpackage();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.package model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int pk_id)
        {
            return dal.Delete(pk_id);
        }


        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int DeleteByaid(int aid)
        {
            return dal.DeleteByaid(aid);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.package model)
        {
            return dal.Update(model);
        }
          /// <summary>
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        public int UpdateNumber(int pkid, int type)
        {
            return dal.UpdateNumber(pkid, type);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.package GetModelById(int pk_id)
        {
            return dal.GetModelById(pk_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(DateTime dtime)
        {
            return dal.GetTable(dtime);
        }

        /// <summary>
        /// 查询培训套餐
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int a_id)
        {
            return dal.GetTable(a_id);
        }
        #endregion


    }
}