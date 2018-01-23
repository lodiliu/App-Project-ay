using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;

namespace ADT.XingZhi.BLL.S
{
    public class LoginTimes
    {
        private readonly ILoginTimes dal = null;
        public LoginTimes()
        {
            dal = DataAccess.CreateLoginTimes();
        }
        #region  Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        public int Add(ADT.XingZhi.Models.S.LoginTimes model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ADT.XingZhi.Models.S.LoginTimes model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string userName, bool isAdmin)
        {
            return dal.Delete(userName, isAdmin);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.LoginTimes GetModel(string userName, bool isAdmin)
        {
            return dal.GetModel(userName, isAdmin);
        }
        #endregion
    }
}
