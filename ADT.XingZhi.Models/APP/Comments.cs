
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Comments
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Comments";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[c_id],[context],[m_id],[a_id],[type],[createtime],[modifytime],[userid],[muserid]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 c_id
        {
            get;
            set;
        }
        #endregion
        
        #region  评论内容
		/// <summary>
        /// 评论内容
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        #endregion
        
        #region  评论人id
		/// <summary>
        /// 评论人id
        /// </summary>
        public System.Int32 m_id
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
