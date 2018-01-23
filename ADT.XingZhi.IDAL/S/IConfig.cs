using System.Collections.Generic;
using System.Data;

namespace ADT.XingZhi.IDAL.S
{
    public interface IConfig
    {
        int BatchSave(DataTable dt, int groupId);
        Dictionary<string, string> GetConfigByGroupId(int groupId);
        string GetValuesByKeyAndGroupId(string keyName, int groupId);
    }
}
