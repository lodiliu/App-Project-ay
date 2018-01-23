
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Pay
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "APP_Pay";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[p_id],[out_trade_no],[ap_id],[a_id],[amount],[trade_no],[buyer_email],[context],[state],[type],[paytype],[createtime],[modifytime],[userid],[muserid]";



        #region  id
        /// <summary>
        /// id
        /// </summary>
        public System.Int32 p_id
        {
            get;
            set;
        }
        #endregion

        #region  商户订单号
        /// <summary>
        /// 商户订单号
        /// </summary>
        public System.String out_trade_no
        {
            get;
            set;
        }
        #endregion

        #region  报名表id
        /// <summary>
        /// 报名表id
        /// </summary>
        public System.Int32 ap_id
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

        #region  支付宝交易号
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public System.String trade_no
        {
            get;
            set;
        }
        #endregion

        #region  买家帐号
        /// <summary>
        /// 买家帐号
        /// </summary>
        public System.String buyer_email
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

        #region  支付状态（0-支付中、1-支付完成2、支付失败）
        /// <summary>
        /// 支付状态（0-支付中、1-支付完成2、支付失败）
        /// </summary>
        public System.Int32 state
        {
            get;
            set;
        }
        #endregion

        #region  支付类型（0-支付宝、1-微信）
        /// <summary>
        /// 支付类型（0-支付宝、1-微信）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  类型（0、支付1、退款2、转出）
        /// <summary>
        /// 类型（0、支付1、退款2、转出）
        /// </summary>
        public System.Int32 paytype
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
        public System.String userid
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
    }
}
