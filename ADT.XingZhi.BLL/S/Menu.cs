using ADT.CMS.Utility;
using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;

namespace ADT.XingZhi.BLL.S
{
    public class Menu
    {
        private readonly IMenu dal = null;
        public Menu()
        {
            dal = DataAccess.CreateMenu();
        }
        #region  Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model">Model</param>
        public int Add(ADT.XingZhi.Models.S.Menu model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model">Model</param>
        public int Modify(ADT.XingZhi.Models.S.Menu model)
        {
            return dal.Modify(model);
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
        /// <param name="id">编号</param>
        public ADT.XingZhi.Models.S.Menu GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
        /// <summary>
        /// 改变一条数据排序
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="sortType">排序类型</param>
        /// <returns></returns>
        public int ChangeSort(int id, SortType sortType)
        {
            return dal.ChangeSort(id, sortType);
        }
        #endregion
    }
}
