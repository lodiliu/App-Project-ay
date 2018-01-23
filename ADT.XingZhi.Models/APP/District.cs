
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class District
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_District";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[Id],[DisName],[CityID],[DisSort]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 Id
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.String DisName
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 CityID
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 DisSort
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
