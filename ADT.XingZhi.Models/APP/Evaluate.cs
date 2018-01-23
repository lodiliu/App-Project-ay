
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Evaluate
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Evaluate";
		
		/// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[ev_id],[m_id],[userid],[star],[context],[type],[createtime]";
        
		
		
        #region  
		/// <summary>
        /// 
        /// </summary>
        public System.Int32 ev_id
        {
            get;
            set;
        }
        #endregion
        
        #region  被评论人id
		/// <summary>
        /// 被评论人id
        /// </summary>
        public System.Int32 m_id
        {
            get;
            set;
        }
        #endregion
        
        #region  评论人id
		/// <summary>
        /// 评论人id
        /// </summary>
        public System.Int32 userid
        {
            get;
            set;
        }
        #endregion

        #region  星级分数
        /// <summary>
        /// 星级分数
        /// </summary>
        public System.Int32 star
        {
            get;
            set;
        }
        #endregion

        #region  评论内容
		/// <summary>
        /// 评论内容
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        #endregion
        
        #region  评论类型（0、活动1、培训）
		/// <summary>
        /// 评论类型（0、活动1、培训）
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
        public System.DateTime createtime
        {
            get;
            set;
        }
        #endregion
        
		
    }
}
