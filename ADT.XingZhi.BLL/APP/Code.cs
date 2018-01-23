using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.DALFactory.APP;
using ADT.XingZhi.IDAL.APP;

namespace ADT.XingZhi.BLL.APP
{

    public class Code
    {
        private readonly ICode dal = null;
        public Code()
        {
            dal = DataAccess.CreateCode();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Code model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int code_id)
        {
            return dal.Delete(code_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Code model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Code GetModelById(int code_id)
        {
            return dal.GetModelById(code_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return dal.GetTable();
        }

        /// <summary>
        /// 根据手机号查询最新数据
        /// </summary>
        /// <returns></returns>
        public Models.APP.Code GetModel(string phon)
        {
            return dal.GetModel(phon);
        }
        #endregion


    }
}