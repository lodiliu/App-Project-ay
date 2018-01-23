
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Praise
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Praise";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[pr_id],[m_id],[a_id],[type],[createtime]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 pr_id
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 m_id
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
        
        #region  评论类型（0、活动1、约吧）
		/// <summary>
        /// 评论类型（0、活动1、约吧）
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
        public System.DateTime createtime
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
