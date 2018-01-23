
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class Code
    {

        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Code";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[code_id],[phon],[code],[senddate],[expiretime],[status],[type]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 code_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String phon
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String code
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime senddate
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime expiretime
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 status
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion
        

    }
}
