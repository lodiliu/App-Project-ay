
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Contact
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Contact";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[co_id],[title],[context],[type],[createtime],[modifytime],[userid],[muserid]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 co_id
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
        
        #region  消息类型（0-关于我们、1-联系我们）
		/// <summary>
        /// 消息类型（0-关于我们、1-联系我们）
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
