using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class Huanxin
    {

        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Huanxin";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[id],[mid],[pwd],[type],[state],[createtime],[modifytime],";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 id
        {
            get;
            set;
        }
        #endregion

        #region  帐号
        /// <summary>
        /// 帐号
        /// </summary>
        public System.String mid
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String pwd
        {
            get;
            set;
        }
        #endregion

        #region  0注册1修改密码
        /// <summary>
        /// 0注册1修改密码
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  0未处理1处理成功
        /// <summary>
        /// 0未处理1处理成功
        /// </summary>
        public System.Int32 state
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


    }
}
