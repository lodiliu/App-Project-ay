
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Applicationitem
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Applicationitem";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[api_id],[m_id],[a_id],[type],[tilte],[p_id]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 api_id
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
        public System.Int32 a_id
        {
            get;
            set;
        }
        #endregion
        
        #region  类型（0、添加字段1、报名信息）
		/// <summary>
        /// 类型（0、添加字段1、报名信息）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion
        
        #region  添加的字段名称或内容
		/// <summary>
        /// 添加的字段名称或内容
        /// </summary>
        public System.String tilte
        {
            get;
            set;
        }
        #endregion
        
        #region  对应字段id
		/// <summary>
        /// 对应字段id
        /// </summary>
        public System.Int32 p_id
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
