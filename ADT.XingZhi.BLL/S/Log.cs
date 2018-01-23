
using ADT.CMS.Utility;
using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System;

namespace ADT.XingZhi.BLL.S
{
    public class Log
    {
        private readonly ILog dal = null;
        public Log()
        {
            dal = DataAccess.CreateLog();
        }
        #region  Method
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public int Add(Models.S.Log model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            return dal.DeleteById(id);
        }
        /// <summary>
        /// 批量删除（以英文","隔开)
        /// </summary>
        /// <param name="ids">编号组</param>
        public int BatchDelete(string ids)
        {
            return dal.BatchDelete(ids);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.Log GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="link">链接</param>
        /// <param name="method">方式</param>
        /// <param name="data">数据</param>
        /// <param name="userId">用户编号</param>
        /// <param name="userName">用户名称</param>
        public void AddLog(string action, string link, string method, string data, int userId, string userName)
        {
            if (new BLL.S.Config().GetValuesByKeyAndGroupId("AdminLog", 2) == "1")
            {
                Models.S.Log model = new Models.S.Log();
                model.Action = action;
                model.Link = link;
                model.Method = method;
                model.Data = data;
                model.UserId = userId;
                model.UserName = userName;
                model.IP = RequestHelper.GetIP();
                model.Time = DateTime.Now;
                this.Add(model);
            }
        }
        #endregion
    }
}
