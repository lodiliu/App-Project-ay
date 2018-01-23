
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Application
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Application";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[ap_id],[a_id],[type],[state],[code],[m_id],[name],[phon],[sex],[age],[address],[professional],[company],[createtime],[modifytime],[userid],[muserid],[other],[pk_id],[amount]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 ap_id
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
        
        #region  状态（0、参加1.报名成功2、取消）
		/// <summary>
        /// 状态（0、参加1.报名成功2、取消）
        /// </summary>
        public System.Int32 state
        {
            get;
            set;
        }
        #endregion
        
        #region  报名成功验证
		/// <summary>
        /// 报名成功验证
        /// </summary>
        public System.String code
        {
            get;
            set;
        }
        #endregion
        
        #region  报名人id
		/// <summary>
        /// 报名人id
        /// </summary>
        public System.Int32 m_id
        {
            get;
            set;
        }
        #endregion
        
        #region  姓名
		/// <summary>
        /// 姓名
        /// </summary>
        public System.String name
        {
            get;
            set;
        }
        #endregion
        
        #region  电话
		/// <summary>
        /// 电话
        /// </summary>
        public System.String phon
        {
            get;
            set;
        }
        #endregion
        
        #region  性别
		/// <summary>
        /// 性别
        /// </summary>
        public System.String sex
        {
            get;
            set;
        }
        #endregion
        
        #region  年龄
		/// <summary>
        /// 年龄
        /// </summary>
        public System.Int32 age
        {
            get;
            set;
        }
        #endregion
        
        #region  地址
		/// <summary>
        /// 地址
        /// </summary>
        public System.String address
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.String professional
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.String company
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
        public System.String muserid
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 pk_id
        {
            get;
            set;
        }
        #endregion


        #region  交易金额
        /// <summary>
        /// 交易金额
        /// </summary>
        public System.Decimal amount
        {
            get;
            set;
        }
        #endregion
    }
}
