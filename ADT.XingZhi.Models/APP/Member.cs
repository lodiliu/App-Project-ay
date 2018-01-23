
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
	[Serializable]
    public partial class Member
    {
		
		/// <summary>
        ///表名
        /// </summary>
		public const string TABLE_NAME = "App_Member";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[m_id],[username],[account],[pwd],[pic],[name],[phon],[sex],[age],[city],[district],[address],[tp_pfid],[tp_id],[context],[isopen],[type],[ip],[logintype],[loginnum],[logintime],[openid],[opentype],[datum],[signnum],[sharenum],[pushuserid],[pushchannelid],[m_valid],[createtime],[modifytime]";



        #region  用户编号
        /// <summary>
        /// 用户编号
        /// </summary>
        public System.Int32 m_id
        {
            get;
            set;
        }
        #endregion

        #region  用户名
        /// <summary>
        /// 用户名
        /// </summary>
        public System.String username
        {
            get;
            set;
        }
        #endregion

        #region  帐号
        /// <summary>
        /// 帐号
        /// </summary>
        public System.String account
        {
            get;
            set;
        }
        #endregion

        #region  登陆密码
        /// <summary>
        /// 登陆密码
        /// </summary>
        public System.String pwd
        {
            get;
            set;
        }
        #endregion

        #region  头像图片地址
        /// <summary>
        /// 头像图片地址
        /// </summary>
        public System.String pic
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

        #region  职业（id）
        /// <summary>
        /// 职业（id）
        /// </summary>
        public System.Int32 tp_pfid
        {
            get;
            set;
        }
        #endregion

        #region  身份标签（id）
        /// <summary>
        /// 身份标签（id）
        /// </summary>
        public System.Int32 tp_id
        {
            get;
            set;
        }
        #endregion

        #region  个性签名
        /// <summary>
        /// 个性签名
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        #endregion

        #region  是否开放（0、开放1、不开放）
        /// <summary>
        /// 是否开放（0、开放1、不开放）
        /// </summary>
        public System.Int32 isopen
        {
            get;
            set;
        }
        #endregion

        #region  类型（0-Android、1-IOS、2后台管理）
        /// <summary>
        /// 类型（0-Android、1-IOS、2后台管理）
        /// </summary>
        public System.Int32 type
        {
            get;
            set;
        }
        #endregion

        #region  注册或登陆IP
        /// <summary>
        /// 注册或登陆IP
        /// </summary>
        public System.String ip
        {
            get;
            set;
        }
        #endregion

        #region  登陆类型（0-Android、1-IOS）
        /// <summary>
        /// 登陆类型（0-Android、1-IOS）
        /// </summary>
        public System.Int32 logintype
        {
            get;
            set;
        }
        #endregion

        #region  登陆次数
        /// <summary>
        /// 登陆次数
        /// </summary>
        public System.Int32 loginnum
        {
            get;
            set;
        }
        #endregion

        #region  最后登陆时间
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public System.DateTime logintime
        {
            get;
            set;
        }
        #endregion

        #region  第三方OpenId
        /// <summary>
        /// 第三方OpenId
        /// </summary>
        public System.String openid
        {
            get;
            set;
        }
        #endregion

        #region  注册类型（0-普通注册、1-新浪、2-QQ3-微信）
        /// <summary>
        /// 注册类型（0-普通注册、1-新浪、2-QQ3-微信）
        /// </summary>
        public System.Int32 opentype
        {
            get;
            set;
        }
        #endregion

        #region  资料是否完整（0-不完整、1-完整）
        /// <summary>
        /// 资料是否完整（0-不完整、1-完整）
        /// </summary>
        public System.Int32 datum
        {
            get;
            set;
        }
        #endregion

        #region  签到总数
        /// <summary>
        /// 签到总数
        /// </summary>
        public System.Int32 signnum
        {
            get;
            set;
        }
        #endregion

        #region  分享总数
        /// <summary>
        /// 分享总数
        /// </summary>
        public System.Int32 sharenum
        {
            get;
            set;
        }
        #endregion

        #region  设备标识
        /// <summary>
        /// 设备标识
        /// </summary>
        public System.String pushuserid
        {
            get;
            set;
        }
        #endregion

        #region  通知标识
        /// <summary>
        /// 通知标识
        /// </summary>
        public System.String pushchannelid
        {
            get;
            set;
        }
        #endregion

        #region  是否正在使用（T-是、F-否）
        /// <summary>
        /// 是否正在使用（T-是、F-否）
        /// </summary>
        public System.String m_valid
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
    }
}
