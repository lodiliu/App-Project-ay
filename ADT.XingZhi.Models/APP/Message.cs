
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Message
    {
        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Message";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[me_id],[m_id],[a_id],[pic],[title],[context],[type],[isread],[createtime],[modifytime],[userid],[muserid],[isactivaty]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 me_id
        {
            get;
            set;
        }
        #endregion

        #region  接受人
        /// <summary>
        /// 接受人
        /// </summary>
        public System.String m_id
        {
            get;
            set;
        }
        #endregion

        #region  活动id
        /// <summary>
        /// 活动id
        /// </summary>
        public System.Int32 a_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String pic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String title
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        #endregion

        #region  类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）
        /// <summary>
        /// 类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  0未读1已读
        /// <summary>
        /// 0未读1已读
        /// </summary>
        public System.Int32 isread
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? createtime
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? modifytime
        {
            get;
            set;
        }
        #endregion

        #region  发送人
        /// <summary>
        /// 发送人
        /// </summary>
        public System.String userid
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String muserid
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// -1、其他0、赛事1培训2约吧
        /// </summary>
        public System.Int32 isactivaty
        {
            get;
            set;
        }
        #endregion
		
    }
}
