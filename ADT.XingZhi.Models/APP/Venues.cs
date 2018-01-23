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
    public partial class Venues
    {

        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Venues";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[Id],[title],[pic],[address],[province],[city],[district],[longitude],[latitude],[context],[type],[environmentType],[openness],[state],[createtime],[modifytime],[userid],[muserid]";



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

        #region  标题
        /// <summary>
        /// 标题
        /// </summary>
        public System.String title
        {
            get;
            set;
        }
        #endregion

        #region  图片
        /// <summary>
        /// 图片
        /// </summary>
        public System.String pic
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

        #region  省
        /// <summary>
        /// 省
        /// </summary>
        public System.Int32 province
        {
            get;
            set;
        }
        #endregion

        #region  市
        /// <summary>
        /// 市
        /// </summary>
        public System.Int32 city
        {
            get;
            set;
        }
        #endregion

        #region  区
        /// <summary>
        /// 区
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
        public System.Double longitude
        {
            get;
            set;
        }
        #endregion

        #region  纬度
        /// <summary>
        /// 纬度
        /// </summary>
        public System.Double latitude
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

        #region  场地类型
        /// <summary>
        /// 场地类型
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  环境类型
        /// <summary>
        /// 环境类型
        /// </summary>
        public System.Int32 environmentType
        {
            get;
            set;
        }
        #endregion

        #region  开放度
        /// <summary>
        /// 开放度
        /// </summary>
        public System.Int32 openness
        {
            get;
            set;
        }
        #endregion

        #region  状态
        /// <summary>
        /// 状态
        /// </summary>
        public System.Boolean state
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
