
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class GroupMember
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_GroupMember";


        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[gm_id],[m_id],[g_id],[type],[createtime],[modifytime],[userid],[muserid]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 gm_id
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

        #region  0成员1管理员
        /// <summary>
        /// 0成员1管理员
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
