using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADT.XingZhi.API.Package
{
    #region 建群环信返回参数实体
    /// <summary>
    /// 建群环信返回参数实体
    /// </summary>
    [Serializable]
    public class Huanxin
    {
        /// <summary>
        /// 
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uri { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public int timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<IMember> entities { get; set; }
        /// <summary>
        /// 群成员
        /// </summary>
        public HuanxinGroup data { get; set; }
    }
    public class HuanxinGroup
    {
        public string groupid { get; set; }
    }

     #endregion 建群环信返回参数实体

    #region 添加评论参数实体
    /// <summary>
    /// 添加评论参数实体
    /// </summary>
    public class InsertComments
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }      
        /// <summary>
        /// 活动编号
        /// </summary>
        public int acid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 类型编号(0活动/1培训/2约吧)
        /// </summary>
        public int typeid { get; set; }
    }
    #endregion 添加评论参数实体

    #region 搜索我的好友参数实体
    /// <summary>
    /// 搜索我的好友参数实体
    /// </summary>
    public class Friends
    {
      
        /// <summary>
        /// 内容
        /// </summary>
        public string username { get; set; }
       
    }
    #endregion 搜索我的好友参数实体

    #region 添加好友参数实体
    /// <summary>
    /// 添加好友参数实体
    /// </summary>
    public class InsertFriends
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 好友编号
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 消息提示编号
        /// </summary>
        public int meid { get; set; }     
    }
    #endregion 添加好友参数实体

    #region 创建群参数实体
    /// <summary>
    /// 创建群参数实体
    /// </summary>
    public class InsertGroups
    {
        /// <summary>
        ///群组名称
        /// </summary>
        public string groupname { get; set; }
        /// <summary>
        /// 群组描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 群组成员最大数(包括群主)
        /// </summary>
        public int maxusers { get; set; }
        /// <summary>
        /// 加入公开群是否需要批准
        /// </summary>
        public string approval { get; set; }
        /// <summary>
        ///是否是公开群
        /// </summary>
        public string publi { get; set; }
        /// <summary>
        /// 群组的管理员
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 群组成员
        /// </summary>
        public string members { get; set; }
    }


    /// <summary>
    /// 创建群参数实体
    /// </summary>
    public class GroupsMember
    {
        /// <summary>
        /// 群成员id
        /// </summary>
        public string mid { get; set; }

    }
    #endregion 创建群参数实体

      #region 修改群参数实体
    /// <summary>
    /// 修改群参数实体
    /// </summary>
    public class UpdateGroups
    {
        /// <summary>
        ///群组名称
        /// </summary>
        public string groupname { get; set; }
        /// <summary>
        /// 群id
        /// </summary>
        public string gid { get; set; }
        /// <summary>
        /// 群组描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 群组成员最大数(包括群主)
        /// </summary>
        public int maxusers { get; set; }
    }
      #endregion 修改群参数实体
    #region 添加群成员参数实体
    /// <summary>
    /// 添加群成员参数实体
    /// </summary>
    public class InsertGroupsMember
    {
        /// <summary>
        /// 成员id
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 群id
        /// </summary>
        public string groupsid { get; set; }      

    }
    #endregion 添加群成员参数实体

    //#region 删除群组
    ///// <summary>
    ///// 删除群组
    ///// </summary>
    //public class DeleteGroup
    //{
    //    /// <summary>
    //    /// 手机号
    //    /// </summary>
    //    public string groupsid { get; set; }
      
    //}
    //#endregion 删除群组

    #region 添加星级评论参数实体
    /// <summary>
    /// 添加星级评论参数实体
    /// </summary>
    public class InsertEvaluate
    {
        /// <summary>
        /// 被评论用户编号
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int myid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 星评分数
        /// </summary>
        public int star { get; set; }
    }
    #endregion 添加星级评论参数实体

    #region 添加收藏参数实体
    /// <summary>
    /// 添加收藏参数实体
    /// </summary>
    public class InsertCollection
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 类型编号(0活动/1培训/2约吧)
        /// </summary>
        public int typeid { get; set; }
       
    }
    #endregion 添加收藏参数实体

    #region 添加点赞参数实体
    /// <summary>
    /// 添加点赞参数实体
    /// </summary>
    public class InsertPraise
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 类型编号(0活动/1培训/2约吧)
        /// </summary>
        public int typeid { get; set; }

    }
    #endregion 添加点赞参数实体

    #region 注册参数实体
    /// <summary>
    /// 注册参数实体
    /// </summary>
    public class Register
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phon { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string qrpwd { get; set; }

        /// <summary>
        /// 设备类型（0-Android、1-IOS）
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 设备标识
        /// </summary>
        public string pushuserid
        {
            get;
            set;
        }
        //private string _headpic = String.Empty;

        ///// <summary>
        ///// 头像图片地址
        ///// </summary>
        //public string headpic
        //{
        //    get { return _headpic; }
        //    set { _headpic = value; }
        //}
        //private string _pushuserid = "baidu";
        ///// <summary>
        ///// 设备标识
        ///// </summary>
        //public string pushuserid
        //{
        //    get { return _pushuserid; }
        //    set { _pushuserid = value; }
        //}
        //private string _pushchannelid = "baidu";
        ///// <summary>
        ///// 通知标识
        ///// </summary>
        //public string pushchannelid
        //{
        //    get { return _pushchannelid; }
        //    set { _pushchannelid = value; }
        //}
    }
    #endregion 注册参数实体

    #region 获取手机验证码参数实体
    /// <summary>
    /// 注册参数实体
    /// </summary>
    public class Code
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phon { get; set; }
       
    }
    #endregion 获取手机验证码参数实体

    #region 完善资料参数实体
    /// <summary>
    /// 完善资料参数实体
    /// </summary>
    public class RegisterPerfect
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }      
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int city { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public int district { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 职业id
        /// </summary>
        public int tp_pfid { get; set; }
        /// <summary>
        /// 身份标签id
        /// </summary>
        public int tp_id { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string  phon { get; set; }
        /// <summary>
        /// 年龄等级
        /// </summary>
        public int age { get; set; }

        public string pic { get; set; }
        //private string _pic = String.Empty;
        ///// <summary>
        ///// 头像地址
        ///// </summary>
        //public string pic
        //{
        //    get { return _pic; }
        //    set { _pic = value; }
        //}
    }
    #endregion 完善资料参数实体

    #region 发布约吧参数实体
    /// <summary>
    /// 发布约吧参数实体
    /// </summary>
    public class InsertAbout
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 运动类型
        /// </summary>
        public int tp_id { get; set; }
        /// <summary>
        /// 年龄限制
        /// </summary>
        public int age { get; set; }
        /// <summary>
        /// 人数限制（0、不限人数）
        /// </summary>
        public int numberlimit { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 性别（男、女、不限）
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int city { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public int district { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime begintime { get; set; }
        /// <summary>
        /// 具体时间
        /// </summary>
        public string specifictime { get; set; }
    }
    #endregion 发布约吧参数实体

 
    #region 约吧报名
    /// <summary>
    /// 约吧报名
    /// </summary>
    public class InsertAboutApplication
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public int aid { get; set; }      
    }
    #endregion 约吧报名

    #region 添加运动类型
    /// <summary>
    /// 添加运动类型
    /// </summary>
    public class InsertMovementType
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public int tid { get; set; }
        ///// <summary>
        ///// 排序编号
        ///// </summary>
        //public int sort { get; set; } 
    }
    #endregion 添加运动类型

    #region 运动类型排序
    /// <summary>
    /// 运动类型排序
    /// </summary>
    public class MovementTypeSort
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public string tids { get; set; }
        ///// <summary>
        ///// 排序编号
        ///// </summary>
        //public int sort { get; set; } 
    }
    public class TypeSort
    {
        /// <summary>
        /// 类型编号
        /// </summary>
        public int tid { get; set; }
        ///// <summary>
        ///// 排序编号
        ///// </summary>
        //public int sort { get; set; } 
    }

    #endregion 运动类型排序

    #region  赛事报名
    /// <summary>
    /// 赛事 报名
    /// </summary>
    public class InsertActivatyApplicationitme
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string title { get; set; }
    }
    #endregion  赛事报名
    #region 赛事报名参数实体
    /// <summary>
    /// 赛事报名参数实体
    /// </summary>
    public class InsertActivatyApplication
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        public int aid { get; set; }

        /// <summary>
        /// 培训套餐编号
        /// </summary>
        public int pkid { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }     
        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string professional { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 性别（男、女）
        /// </summary>
        public string sex { get; set; }
      
        /// <summary>
        /// 其他字段
        /// </summary>
        public string data { get; set; }
     
    }
    #endregion 赛事报名参数实体

    #region 消息删除参数实体
    /// <summary>
    /// 消息参数实体
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }      
        /// <summary>
        ///活动编号
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 类型（0、系统消息1、活动邀请2、二维码）
        /// </summary>
        public int type { get; set; }
       
    }
    #endregion 消息删除参数实体

    #region 我的发布删除参数实体
    /// <summary>
    /// 赛事参数实体
    /// </summary>
    public class Activaty
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }      
        /// <summary>
        /// 赛事编号
        /// </summary>
        public int aid { get; set; }
       
    }
    #endregion 赛事删除参数实体

    #region 我参加赛事/培训删除参数实体
    /// <summary>
    /// 赛事参数实体
    /// </summary>
    public class ParticipateActivaty
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 报名编号
        /// </summary>
        public int ap_id { get; set; }
        /// <summary>
        /// 0赛事1培训2约吧
        /// </summary>
        public int type { get; set; }

    }
    #endregion 赛事删除参数实体

    #region 赛事发布参数实体
    /// <summary>
    /// 赛事发布参数实体
    /// </summary>
    public class InsertActivatyitme
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public string title { get; set; }

    }
    #endregion 赛事发布参数实体

    #region 赛事发布参数实体
    /// <summary>
    /// 赛事发布参数实体
    /// </summary>
    public class InsertActivaty
    {
        /// <summary>
        /// 活动编号
        /// </summary>
        public int aid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public System.String title
        {
            get;
            set;
        }
        /// <summary>
        /// 运动类型编号
        /// </summary>
        public System.Int32 tp_id
        {
            get;
            set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public System.String context
        {
            get;
            set;
        }
        ///// <summary>
        ///// (1官方/2民间)
        ///// </summary>
        //public System.Int32 type
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// 截止时间
        /// </summary>
        public System.DateTime bytime
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime begintime
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime endtime
        {
            get;
            set;
        }
        ///// <summary>
        ///// 主办方
        ///// </summary>
        //public System.String organizers
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// 联系人
        /// </summary>
        public System.String contact
        {
            get;
            set;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public System.String phone
        {
            get;
            set;
        }
        ///// <summary>
        ///// 点赞量
        ///// </summary>
        //public System.Int32 praise
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 人数限制（0、不限人数）
        /// </summary>
        public System.Int32 numberlimit
        {
            get;
            set;
        }
        /// <summary>
        /// 报名费
        /// </summary>
        public System.Decimal money
        {
            get;
            set;
        }
        /// <summary>
        /// 支付类型（0、免费1、线上支付2、线下支付）
        /// </summary>
        public System.Int32 ptype
        {
            get;
            set;
        }
        ///// <summary>
        ///// 状态（0、未审核1、审核通过2、审核未通过3、取消活动4、取消活动结束5、已结束-1删除
        ///// </summary>
        //public System.Int32 state
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// 地址
        /// </summary>
        public System.String address
        {
            get;
            set;
        }
        /// <summary>
        /// 城市
        /// </summary>
        public System.String city
        {
            get;
            set;
        }

        /// <summary>
        /// 区域
        /// </summary>
        public System.String district
        {
            get;
            set;
        }
     
        /// <summary>
        /// 发布者id
        /// </summary>
        public System.Int32 userid
        {
            get;
            set;
        }
        /// <summary>
        /// 具体时间
        /// </summary>
        public System.String specifictime
        {
            get;
            set;
        }
        /// <summary>
        /// 具体时间
        /// </summary>
        public System.String endspecifictime
        {
            get;
            set;
        }
        /// <summary>
        /// 经度
        /// </summary>
        public System.String longitude
        {
            get;
            set;
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public System.String latitude
        {
            get;
            set;
        }
        /// <summary>
        /// 我的图片
        /// </summary>
        public System.String mypic
        {
            get;
            set;
        }

        /// <summary>
        /// 报名付选项
        /// </summary>
        public string data { get; set; }
     

    }
    #endregion 赛事发布参数实体

    #region 邀请好友参数实体
    /// <summary>
    /// 邀请好友参数实体
    /// </summary>
    public class InviteFriends
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 赛事编号
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 好友编号
        /// </summary>
        public string fid { get; set; }

    }
    #endregion 邀请好友参数实体

    #region 第三方登陆填写用户名和邮箱参数实体
    /// <summary>
    /// 第三方登陆填写用户名和邮箱参数实体
    /// </summary>
    public class InsertOpenInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? mid { get; set; }
        /// <summary>
        /// 用户令牌
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string email { get; set; }
    }
    #endregion 第三方登陆填写用户名和邮箱参数实体


    #region 添加反馈参数实体
    /// <summary>
    /// 添加反馈参数实体
    /// </summary>
    public class InsertFeedback
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mid { get; set; }      
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string context { get; set; }
    }
    #endregion 添加反馈参数实体


    #region 修改密码参数实体
    /// <summary>
    /// 修改密码参数实体
    /// </summary>
    public class UpdatePwd
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? mid { get; set; }
        /// <summary>
        /// 用户令牌
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string newpwd { get; set; }
    }
    #endregion 修改密码参数实体
       




    //获取订单号输出参数
    public class APP_CREAT_TRADE_NO_Model
    {
        //主键订单号
        public int RECORD_ID { get; set; }
        //--用户id
        public int RECORD_USERID { get; set; }
        //交易金额
        public String RECORD_TOTAL_FEE { get; set; }

        //	  --支付类型(支付宝充值)                           	       
        public String RECORD_PAYMENT_TYPE { get; set; }
        //	  --交易状态                                       	       
        public String RECORD_TRADE_STATUS { get; set; }
        //	  --支付宝交易号                                   	       
        public String RECORD_TRADE_NO { get; set; }
        //	    --买家支付宝账号对应的支付宝唯一用户号         	       
        public String RECORD_BUYER_ID { get; set; }
        //	   --买家支付宝账号                                	       
        public String RECORD_BUYER_EMAIL { get; set; }
        //	   --处理日期                                      	       
        public String RECORD_GMT_PAYMENT { get; set; }
        //	  --创建日期                                       	       
        public String RECORD_DATE { get; set; }
        //	   --创建者                                        	       
        public String RECORD_CREATERUSER { get; set; }
        //	   --消费描述                                      	       
        public String RECORD_DESC { get; set; }


        public APP_CREAT_TRADE_NO_Model()
        {
            RECORD_ID = 0;
            RECORD_USERID = 0;
            RECORD_TOTAL_FEE = "0";
            RECORD_PAYMENT_TYPE = "";
            RECORD_TRADE_STATUS = "";
            RECORD_TRADE_NO = "";
            RECORD_BUYER_ID = "";
            RECORD_BUYER_EMAIL = "";
            RECORD_GMT_PAYMENT = "";
            RECORD_DATE = "";
            RECORD_CREATERUSER = "";
            RECORD_DESC = "";
        }
    }

     //交易信息：
    public class AlipayInfo
    {
        //商户订单号
        public string out_trade_no { get; set; }
        ////支付宝交易号
        public string trade_no { get; set; }
        ////交易状态
        public string trade_status { get; set; }
        ////交易金额
        public string total_fee { get; set; }
        ////买家支付宝账号
        public string buyer_email { get; set; }
        ////买家唯一用户号
        public string buyer_id { get; set; }
        ////卖家唯一用户号
        public string seller_id { get; set; }
        ////通知时间
        public string notify_time { get; set; }
        ////通知时间
        public string AlipayMark { get; set; }
        public AlipayInfo()
        {
            //商户订单号
            out_trade_no = "";
            ////支付宝交易号
            trade_no = "";
            ////交易状态
            trade_status = "";
            ////交易金额
            total_fee = "";
            ////买家支付宝账号
            buyer_email = "";
            ////买家唯一用户号
            buyer_id = "";
            ////卖家唯一用户号
            seller_id = "";
            ////通知时间
            notify_time = "";
            //消费信息
            AlipayMark = "";
        }
    }
}