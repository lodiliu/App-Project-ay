
namespace ADT.XingZhi.DALFactory.APP
{
    public class DataAccess : BaseDataAccess
    {
        /// <summary>
        /// 创建About数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IAbout CreateAbout()
        {
            string ClassNamespace = AssemblyPath + ".APP.About";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IAbout)objType;
        }
        /// <summary>
        /// 创建Account数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IAccount CreateAccount()
        {
            string ClassNamespace = AssemblyPath + ".APP.Account";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IAccount)objType;
        }
        /// <summary>
        /// 创建Accountitme数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IAccountitme CreateAccountitme()
        {
            string ClassNamespace = AssemblyPath + ".APP.Accountitme";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IAccountitme)objType;
        }
        /// <summary>
        /// 创建Activaty数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IActivaty CreateActivaty()
        {
            string ClassNamespace = AssemblyPath + ".APP.Activaty";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IActivaty)objType;
        }
        /// <summary>
        /// 创建Application数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IApplication CreateApplication()
        {
            string ClassNamespace = AssemblyPath + ".APP.Application";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IApplication)objType;
        }
        /// <summary>
        /// 创建Chat数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IChat CreateChat()
        {
            string ClassNamespace = AssemblyPath + ".APP.Chat";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IChat)objType;
        }
        /// <summary>
        /// 创建Collection数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.ICollection CreateCollection()
        {
            string ClassNamespace = AssemblyPath + ".APP.Collection";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.ICollection)objType;
        }
        /// <summary>
        /// 创建Comments数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IComments CreateComments()
        {
            string ClassNamespace = AssemblyPath + ".APP.Comments";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IComments)objType;
        }
        /// <summary>
        /// 创建Contact数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IContact CreateContact()
        {
            string ClassNamespace = AssemblyPath + ".APP.Contact";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IContact)objType;
        }
        /// <summary>
        /// 创建Feedback数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IFeedback CreateFeedback()
        {
            string ClassNamespace = AssemblyPath + ".APP.Feedback";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IFeedback)objType;
        }
        /// <summary>
        /// 创建Friends数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IFriends CreateFriends()
        {
            string ClassNamespace = AssemblyPath + ".APP.Friends";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IFriends)objType;
        }
        /// <summary>
        /// 创建Group数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IGroup CreateGroup()
        {
            string ClassNamespace = AssemblyPath + ".APP.Group";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IGroup)objType;
        }
        /// <summary>
        /// 创建GroupMember数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IGroupMember CreateGroupMember()
        {
            string ClassNamespace = AssemblyPath + ".APP.GroupMember";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IGroupMember)objType;
        }
        /// <summary>
        /// 创建Member数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IMember CreateMember()
        {
            string ClassNamespace = AssemblyPath + ".APP.Member";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IMember)objType;
        }
        /// <summary>
        /// 创建Message 数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IMessage CreateMessage()
        {
            string ClassNamespace = AssemblyPath + ".APP.Message";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IMessage)objType;
        }
        /// <summary>
        /// 创建package数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.Ipackage Createpackage()
        {
            string ClassNamespace = AssemblyPath + ".APP.package";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.Ipackage)objType;
        }
        /// <summary>
        /// 创建Pay数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IPay CreatePay()
        {
            string ClassNamespace = AssemblyPath + ".APP.Pay";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IPay)objType;
        }

        /// <summary>
        /// 创建Share数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IShare CreateShare()
        {
            string ClassNamespace = AssemblyPath + ".APP.Share";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IShare)objType;
        }
        /// <summary>
        /// 创建Type数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IType CreateType()
        {
            string ClassNamespace = AssemblyPath + ".APP.Type";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IType)objType;
        }

        /// <summary>
        /// 创建Code数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.ICode CreateCode()
        {
            string ClassNamespace = AssemblyPath + ".APP.Code";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.ICode)objType;
        }


        /// <summary>
        /// 创建Movement数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IMovement CreateMovement()
        {
            string ClassNamespace = AssemblyPath + ".APP.Movement";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IMovement)objType;
        }


        /// <summary>
        /// 创建Applicationitem数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IApplicationitem CreateApplicationitem()
        {
            string ClassNamespace = AssemblyPath + ".APP.Applicationitem";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IApplicationitem)objType;
        }


        /// <summary>
        /// 创建City数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.ICity CreateCity()
        {
            string ClassNamespace = AssemblyPath + ".APP.City";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.ICity)objType;
        }

        /// <summary>
        /// 创建District数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IDistrict CreateDistrict()
        {
            string ClassNamespace = AssemblyPath + ".APP.District";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IDistrict)objType;
        }

        /// <summary>
        /// 创建Evaluate数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IEvaluate CreateEvaluate()
        {
            string ClassNamespace = AssemblyPath + ".APP.Evaluate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IEvaluate)objType;
        }


        /// <summary>
        /// 创建Praise数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IPraise CreatePraise()
        {
            string ClassNamespace = AssemblyPath + ".APP.Praise";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IPraise)objType;
        }


        /// <summary>
        /// 创建Province数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IProvince CreateProvince()
        {
            string ClassNamespace = AssemblyPath + ".APP.Province";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IProvince)objType;
        }

        /// <summary>
        /// 创建Huanxin数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IHuanxin CreateHuanxin()
        {
            string ClassNamespace = AssemblyPath + ".APP.Huanxin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IHuanxin)objType;
        }

        /// <summary>
        /// 创建IPersonal数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IPersonal CreatePersonal()
        {
            string ClassNamespace = AssemblyPath + ".APP.Personal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IPersonal)objType;
        }


        /// <summary>
        /// 创建IVenues数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IVenues CreateVenues()
        {
            string ClassNamespace = AssemblyPath + ".APP.Venues";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IVenues)objType;
        }

        /// <summary>
        /// 创建File数据层接口。
        /// </summary>
        public static ADT.XingZhi.IDAL.APP.IFile CreateFile()
        {
            string ClassNamespace = AssemblyPath + ".APP.File";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ADT.XingZhi.IDAL.APP.IFile)objType;
        }
    }
}
