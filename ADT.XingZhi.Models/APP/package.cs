
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class package
    {


        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[pk_id],[a_id],[title],[amount],[number],[numberlimit],[context],[bytime],[begintime],[endtime],[address],[city],[district],[longitude],[latitude],[modifytime],[userid],[muserid],[createtime],[ptype]";



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

        #region  套餐名
        /// <summary>
        /// 套餐名
        /// </summary>
        public System.String title
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

        #region  报名人数
        /// <summary>
        /// 报名人数
        /// </summary>
        public System.Int32 number
        {
            get;
            set;
        }
        #endregion

        #region  人数限制（0、不限人数）
        /// <summary>
        /// 人数限制（0、不限人数）
        /// </summary>
        public System.Int32 numberlimit
        {
            get;
            set;
        }
        #endregion

        #region  内容
        /// <summary>
        /// 内容
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        #endregion

        #region  截止时间
        /// <summary>
        /// 截止时间
        /// </summary>
        public System.DateTime? bytime
        {
            get;
            set;
        }
        #endregion

        #region  开始时间
        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime begintime
        {
            get;
            set;
        }
        #endregion

        #region  结束时间
        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime endtime
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

        #region  城市
        /// <summary>
        /// 城市
        /// </summary>
        public System.Int32 city
        {
            get;
            set;
        }
        #endregion

        #region  区域
        /// <summary>
        /// 区域
        /// </summary>
        public System.Int32 district
        {
            get;
            set;
        }
        #endregion

        #region  经度
        /// <summary>
        /// 经度
        /// </summary>
        public System.String longitude
        {
            get;
            set;
        }
        #endregion

        #region  纬度
        /// <summary>
        /// 纬度
        /// </summary>
        public System.String latitude
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

        #region  发布者id
        /// <summary>
        /// 发布者id
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

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? createtime
        {
            get;
            set;
        }

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ptype
        {
            get;
            set;
        }
        #endregion

        #endregion
        
		
    }
}
