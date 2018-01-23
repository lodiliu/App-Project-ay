
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Province
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Province";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[ProID],[ProName],[ProSort],[ProRemark]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 ProID
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.String ProName
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 ProSort
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.String ProRemark
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
