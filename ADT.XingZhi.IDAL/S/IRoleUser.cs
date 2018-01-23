using System.Data;

namespace ADT.XingZhi.IDAL.S
{
    public interface IRoleUser
    {
        #region  成员方法
        int BatchSave(DataTable dt);
        int Delete(int roleId, int userId);
        int BatchDelete(int roleId, string ids);
        #endregion  成员方法
    }
}
