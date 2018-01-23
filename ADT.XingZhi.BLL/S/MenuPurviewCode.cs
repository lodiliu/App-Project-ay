using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;

namespace ADT.XingZhi.BLL.S
{
    public class MenuPurviewCode
    {
        private readonly IMenuPurviewCode dal = null;
        public MenuPurviewCode()
        {
            dal = DataAccess.CreateMenuPurviewCode();
        }
        #region  Method
        /// <summary>
        /// 保存一条数据
        /// </summary>
        public int Save(ADT.XingZhi.Models.S.MenuPurviewCode model)
        {
            return dal.Save(model);
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
        public ADT.XingZhi.Models.S.MenuPurviewCode GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        #endregion
    }
}
