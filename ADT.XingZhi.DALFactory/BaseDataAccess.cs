using ADT.CMS.Utility;
using System.Reflection;

namespace ADT.XingZhi.DALFactory
{
    public class BaseDataAccess
    {
        /// <summary>
        /// DAL程序集路径
        /// </summary>
        public static string AssemblyPath
        {
            get
            {
                object cache = CacheHelper.Get("DAL_ASSEMBLY_PATH");  //从缓存中取入值
                if (cache == null)
                {
                    cache = AppSettingsHelper.GetString("DAL", "ADT.XingZhi.DAL");
                    CacheHelper.Insert("DAL_ASSEMBLY_PATH", cache);  //写入缓存中
                }
                return cache.ToString();
            }
        }
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = CacheHelper.Get(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    CacheHelper.Insert(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
    }
}
