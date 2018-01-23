using System.Data;

namespace ADT.XingZhi.IDAL.S
{
    public interface IUser
    {
        #region  成员方法
        int Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT);
        int Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT);
        int SetDisabled(int id, bool disabled);
        ADT.XingZhi.Models.S.User GetModelById(int id);
        ADT.XingZhi.Models.S.User GetModelByUserName(string username);
        int UpdateByLogin(int uid, string ip);
        int ModifyInfo(Models.S.User model);
        int ModifyPwd(int id, string pwd, string encrypt);
        DataTable GetPermissionByUserId(int userId);
        string GetRoleByUserId(int userId);
        DataTable GetTable(string user);
        #endregion  成员方法
    }
}
