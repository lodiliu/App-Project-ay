
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    //[Serializable]
    public  class About
    {
		
        ///// <summary>
        /////表名
        ///// </summary>
        //public const string TABLE_NAME = "App_About";
		
        ///// <summary>
        ///// 表中所有字段集合
        ///// </summary>
        //public const string ALL = "[ab_id],[title],[context],[tp_id],[begintime],[contact],[phone],[praise],[number],[numberlimit],[age],[sex],[address],[province],[city],[district],[state],[specifictime],[createtime],[modifytime],[userid],[muserid],[pic],[other]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public int ab_id
        {
            get;
            set;
        }
        #endregion
        
        #region  标题
		/// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            get;
            set;
        }
        #endregion
        
        #region  内容
		/// <summary>
        /// 内容
        /// </summary>
        public string context
        {
            get;
            set;
        }
        #endregion
        
        #region  运动类型
		/// <summary>
        /// 运动类型
        /// </summary>
        public int tp_id
        {
            get;
            set;
        }
        #endregion
        
        #region  开始时间
		/// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? begintime
        {
            get;
            set;
        }
        #endregion
        
        #region  联系人
		/// <summary>
        /// 联系人
        /// </summary>
        public string contact
        {
            get;
            set;
        }
        #endregion
        
        #region  联系电话
		/// <summary>
        /// 联系电话
        /// </summary>
        public string phone
        {
            get;
            set;
        }
        #endregion
        
        #region  点赞量
		/// <summary>
        /// 点赞量
        /// </summary>
        public int praise
        {
            get;
            set;
        }
        #endregion
        
        #region  报名人数
		/// <summary>
        /// 报名人数
        /// </summary>
        public int number
        {
            get;
            set;
        }
        #endregion
        
        #region  人数限制（0、不限人数）
		/// <summary>
        /// 人数限制（0、不限人数）
        /// </summary>
        public int numberlimit
        {
            get;
            set;
        }
        #endregion
        
        #region  年龄限制（type表）
		/// <summary>
        /// 年龄限制（type表）
        /// </summary>
        public int age
        {
            get;
            set;
        }
        #endregion
        
        #region  性别（男、女、不限）
		/// <summary>
        /// 性别（男、女、不限）
        /// </summary>
        public string sex
        {
            get;
            set;
        }
        #endregion
        
        #region  地址
		/// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            get;
            set;
        }
        #endregion
        
        #region  省市
		/// <summary>
        /// 省市
        /// </summary>
        public int province
        {
            get;
            set;
        }
        #endregion
        
        #region  城市
		/// <summary>
        /// 城市
        /// </summary>
        public int city
        {
            get;
            set;
        }
        #endregion
        
        #region  区域
		/// <summary>
        /// 区域
        /// </summary>
        public int district
        {
            get;
            set;
        }
        #endregion
        
        #region  状态（0、已发布1、进行中2、已结束3、删除）
		/// <summary>
        /// 状态（0、已发布1、进行中2、已结束3、删除）
        /// </summary>
        public int state
        {
            get;
            set;
        }
        #endregion
        
        #region  具体时间
		/// <summary>
        /// 具体时间
        /// </summary>
        public string specifictime
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public DateTime? modifytime
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public int userid
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public int muserid
        {
            get;
            set;
        }
        #endregion
        
        #region  图片地址
		/// <summary>
        /// 图片地址
        /// </summary>
        public string pic
        {
            get;
            set;
        }
        #endregion
        
        #region  
		/// <summary>
        /// 
        /// </summary>
        public string other
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
