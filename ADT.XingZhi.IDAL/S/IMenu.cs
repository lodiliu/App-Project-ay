
using ADT.CMS.Utility; 
namespace ADT.XingZhi.IDAL.S
{
    public interface IMenu
    {
        #region  成员方法
        int Add(ADT.XingZhi.Models.S.Menu model);
        int Modify(ADT.XingZhi.Models.S.Menu model);
        int SetDisabled(int id, bool disabled);
        ADT.XingZhi.Models.S.Menu GetModelById(int id);
        int ChangeSort(int id, SortType sortType);
        #endregion  成员方法
    }
}
