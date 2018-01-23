
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class City
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_City";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[CityID],[CityName],[ProID],[CitySort]";
        
		
		
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
        public System.String CityName
        {
            get;
            set;
        }
        #endregion
        
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
        public System.Int32 CitySort
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
