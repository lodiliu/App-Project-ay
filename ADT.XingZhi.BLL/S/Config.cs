using ADT.XingZhi.DALFactory.S;
using ADT.XingZhi.IDAL.S;
using System.Collections.Generic;
using System.Data;
using ADTC = ADT.CMS.Utility.CacheHelper;

namespace ADT.XingZhi.BLL.S
{
    public class Config
    {
        private readonly IConfig dal = null;
        public Config()
        {
            dal = DataAccess.CreateConfig();
        }
        /// <summary>
        /// 根据表添加数据
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="groupId">组编号</param>
        public int BatchSave(DataTable dt, int groupId)
        {
            return dal.BatchSave(dt, groupId);
        }
        /// <summary>
        /// 根据组编号获取配置信息
        /// </summary>
        /// <param name="groupId">类型名称,若需要获取所有的，则groupId=0</param>
        /// <returns></returns>
        public Dictionary<string, string> GetConfigByGroupId(int groupId)
        {
            return dal.GetConfigByGroupId(groupId);
        }
        /// <summary>
        /// 根据键名和组名获取键值
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="groupId">组名编号</param>
        /// <returns></returns>
        public string GetValuesByKeyAndGroupId(string keyName, int groupId)
        {
            object obj = ADTC.Get("Config_" + groupId + "_" + keyName);
            if (obj == null)
            {
                obj = dal.GetValuesByKeyAndGroupId(keyName, groupId);
                ADTC.Insert("Config_" + groupId + "_" + keyName, obj, 0xe10 * 2); //写入缓存中
            }
            return obj.ToString();
        }
    }
}
