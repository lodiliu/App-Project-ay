
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Type
    {
		
        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Type";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[t_id],[text],[Anpic],[AnIsHomepic],[AnHomepic],[AnWhitepic],[AnOrangepic],[AnIsAllpic],[AnAllpic],[Anpicguanfang],[Anpicminjian],[Iospic],[IosIsHomepic],[IosHomepic],[IosWhitepic],[IosOrangepic],[IosIsAllpic],[IosAllpic],[Iospicguanfang],[Iospicminjian],[type],[sort],[createtime],[modifytime],[userid],[muserid],[tdisabled]";



        #region
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 t_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String text
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String Anpic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String AnIsHomepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String AnHomepic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String AnWhitepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String AnOrangepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String AnIsAllpic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String AnAllpic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String Anpicguanfang
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String Anpicminjian
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String Iospic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String IosIsHomepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String IosHomepic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String IosWhitepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String IosOrangepic
        {
            get;
            set;
        }
        #endregion

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String IosIsAllpic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String IosAllpic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String Iospicguanfang
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String Iospicminjian
        {
            get;
            set;
        }
        #endregion

        #region  类型（0、运动类型1、职业2、身份标签3、年龄段）
        /// <summary>
        /// 类型（0、运动类型1、职业2、身份标签3、年龄段）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  排序
        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32 sort
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
        
         #region
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean tdisabled
        {
            get;
            set;
        }
        #endregion
		
    }
}
