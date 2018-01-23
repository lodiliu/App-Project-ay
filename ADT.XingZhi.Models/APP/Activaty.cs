
using System;

namespace ADT.XingZhi.Models.APP
{
    /// <summary>
    /// 实体类
    /// </summary>
    [Serializable]
    public partial class Activaty
    {
        /// <summary>
        ///表名
        /// </summary>
        public const string TABLE_NAME = "App_Activaty";

        /// <summary>
        /// 表中所有字段集合
        /// </summary>
        public const string ALL = "[a_id],[tp_id],[title],[context],[type],[bytime],[begintime],[endtime],[organizers],[contact],[phone],[praise],[number],[numberlimit],[money],[ptype],[state],[address],[isactivaty],[city],[district],[createtime],[modifytime],[userid],[muserid],[pic],[specifictime],[endspecifictime],[other],[longitude],[latitude],[mypic],[g_id],[duserid]";



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

        #region  运动类型编号
        /// <summary>
        /// 运动类型编号
        /// </summary>
        public System.Int32 tp_id
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

        #region  (1官方/2民间)
        /// <summary>
        /// (1官方/2民间)
        /// </summary>
        public System.Int32 type
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
        public System.DateTime? begintime
        {
            get;
            set;
        }
        #endregion

        #region  结束时间
        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime? endtime
        {
            get;
            set;
        }
        #endregion

        #region  主办方
        /// <summary>
        /// 主办方
        /// </summary>
        public System.String organizers
        {
            get;
            set;
        }
        #endregion

        #region  联系人
        /// <summary>
        /// 联系人
        /// </summary>
        public System.String contact
        {
            get;
            set;
        }
        #endregion

        #region  联系电话
        /// <summary>
        /// 联系电话
        /// </summary>
        public System.String phone
        {
            get;
            set;
        }
        #endregion

        #region  点赞量
        /// <summary>
        /// 点赞量
        /// </summary>
        public System.Int32 praise
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

        #region  报名费
        /// <summary>
        /// 报名费
        /// </summary>
        public System.Decimal money
        {
            get;
            set;
        }
        #endregion

        #region  支付类型（0、免费1、线上支付2、线下支付）
        /// <summary>
        /// 支付类型（0、免费1、线上支付2、线下支付）
        /// </summary>
        public System.Int32 ptype
        {
            get;
            set;
        }
        #endregion

        #region  状态（0、未审核1、审核通过2、审核未通过3、取消活动4、取消活动结束5、已结束-1删除
        /// <summary>
        /// 状态（0、未审核1、审核通过2、审核未通过3、取消活动4、取消活动结束5、已结束-1删除
        /// </summary>
        public System.Int32 state
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

        #region  (0赛事/1培训)
        /// <summary>
        /// (0赛事/1培训)
        /// </summary>
        public System.Int32 isactivaty
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

        #region  发布者id
        /// <summary>
        /// 发布者id
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

        #region  图片路径
        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String pic
        {
            get;
            set;
        }
        #endregion

        #region  具体时间
        /// <summary>
        /// 具体时间
        /// </summary>
        public System.String specifictime
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String endspecifictime
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String other
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

        #region
        /// <summary>
        /// 
        /// </summary>
        public System.String mypic
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 群id
        /// </summary>
        public System.String g_id
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// 代发id
        /// </summary>
        public System.String duserid
        {
            get;
            set;
        }
        #endregion
    }
}
