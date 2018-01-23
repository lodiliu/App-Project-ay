
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class Personal
    {

        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Personal";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[p_id],[m_id],[name],[phon],[sex],[age],[company],[createtime],[modifytime],[professional]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 p_id
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

        #region  公司
        /// <summary>
        /// 公司
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

        #region  职业professional
        /// <summary>
        /// 职业
        /// </summary>
        public System.String professional
        {
            get;
            set;
        }
        #endregion
    }
}

