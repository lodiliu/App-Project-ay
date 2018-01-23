using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.XingZhi.IDAL.S
{
    public interface IMenuPurviewCode
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Save(ADT.XingZhi.Models.S.MenuPurviewCode model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int SetDisabled(int id, bool disabled);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ADT.XingZhi.Models.S.MenuPurviewCode GetModelById(int id);

        #endregion  成员方法
    }
}
