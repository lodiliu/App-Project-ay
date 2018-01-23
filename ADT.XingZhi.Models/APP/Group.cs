
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Group
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Group";



        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[g_id],[m_id],[name],[type],[a_id],[context],[createtime],[modifytime],[userid],[muserid]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String g_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String m_id
        {
            get;
            set;
        }
        #endregion

        #region  群名称
        /// <summary>
        /// 群名称
        /// </summary>
        public System.String name
        {
            get;
            set;
        }
        #endregion

        #region  类型（0，活动群1、自建群）
        /// <summary>
        /// 类型（0，活动群1、自建群）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
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
        public System.String context
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

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 userid
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 muserid
        {
            get;
            set;
        }
        #endregion
		
    }
}
