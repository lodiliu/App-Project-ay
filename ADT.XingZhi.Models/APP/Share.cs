
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Share
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Share";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[s_id],[a_id],[type],[m_id],[createtime],[modifytime],[userid],[muserid]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 s_id
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
        
        #region  类型（0、活动1、约吧）
		/// <summary>
        /// 类型（0、活动1、约吧）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion
        
        #region  分享人id
		/// <summary>
        /// 分享人id
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
        public System.DateTime createtime
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.DateTime modifytime
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
