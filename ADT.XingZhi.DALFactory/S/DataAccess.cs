
namespace ADT.XingZhi.DALFactory.S
{
    public class DataAccess : BaseDataAccess
    {
        /// <summary>
        /// 创建User数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IUser CreateUser()
        {
            string ClassNamespace = AssemblyPath + ".S.User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IUser)objType;
        }
        /// <summary>
        /// 创建LoginTimes数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.ILoginTimes CreateLoginTimes()
        {
            string ClassNamespace = AssemblyPath + ".S.LoginTimes";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.ILoginTimes)objType;
        }
        /// <summary>
        /// 创建Role数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IRole CreateRole()
        {
            string ClassNamespace = AssemblyPath + ".S.Role";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IRole)objType;
        }
        /// <summary>
        /// 创建UserRole数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IRoleUser CreateRoleUser()
        {
            string ClassNamespace = AssemblyPath + ".S.RoleUser";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IRoleUser)objType;
        }
        /// <summary>
        /// 创建S_ROLE_MENU_PURVIEWCODE数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IRoleMenuPurviewCode CreateRoleMenuPurviewCode()
        {
            string ClassNamespace = AssemblyPath + ".S.RoleMenuPurviewCode";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IRoleMenuPurviewCode)objType;
        }
        /// <summary>
        /// 创建S_MENU_PURVIEWCODE数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IMenuPurviewCode CreateMenuPurviewCode()
        {
            string ClassNamespace = AssemblyPath + ".S.MenuPurviewCode";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IMenuPurviewCode)objType;
        }
        /// <summary>
        /// 创建Menu数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IMenu CreateMenu()
        {
            string ClassNamespace = AssemblyPath + ".S.Menu";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IMenu)objType;
        }
        /// <summary>
        /// 创建LOG数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.ILog CreateLog()
        {
            string ClassNamespace = AssemblyPath + ".S.Log";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.ILog)objType;
        }
        /// <summary>
        /// 创建Config数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IConfig CreateConfig()
        {
            string ClassNamespace = AssemblyPath + ".S.Config";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IConfig)objType;
        }
        /// <summary>
        /// 创建File数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.S.IFile CreateFile()
        {
            string ClassNamespace = AssemblyPath + ".S.File";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.S.IFile)objType;
        }
    }
}
