using System.Data;

namespace ADT.XingZhi.IDAL.S
{
    public interface IRoleMenuPurviewCode
    { 
        int BatchSave(DataTable dt, int roleId);
        DataTable GetPurviewCodeListByRoleId(int roleId);
    }
}
