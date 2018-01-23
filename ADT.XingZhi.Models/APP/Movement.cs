
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class Movement
    {

        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Movement";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[mo_id],[m_id],[tp_id],[createtime],[userid],[type],[sort]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 mo_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 m_id
        {
            get;
            set;
        }
        #endregion

        #region  运动类型id（type表内）
        /// <summary>
        /// 运动类型id（type表内）
        /// </summary>
        public System.Int32 tp_id
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
        public System.Int32 userid
        {
            get;
            set;
        }
        #endregion

        #region  0系统推送1、自己添加
        /// <summary>
        /// 0系统推送1、自己添加
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
        public System.Int32 sort
        {
            get;
            set;
        }
        #endregion


    }
}

