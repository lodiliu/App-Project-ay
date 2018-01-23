
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Account
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Account";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
		public const string ALL = "[ac_id],[m_id],[total],[amount],[consum],[createtime],[modifytime],[userid],[muserid]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 ac_id
        {
            get;
            set;
        }
        #endregion
        
        #region  用户编号
		/// <summary>
        /// 用户编号
        /// </summary>
        public System.Int32 m_id
        {
            get;
            set;
        }
        #endregion
        
        #region  总金额
		/// <summary>
        /// 总金额
        /// </summary>
        public System.Decimal total
        {
            get;
            set;
        }
        #endregion
        
        #region  金额
		/// <summary>
        /// 金额
        /// </summary>
        public System.Decimal amount
        {
            get;
            set;
        }
        #endregion
        
        #region  消费金额
		/// <summary>
        /// 消费金额
        /// </summary>
        public System.Decimal consum
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
