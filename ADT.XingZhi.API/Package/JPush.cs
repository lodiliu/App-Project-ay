using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;

namespace ADT.XingZhi.API.Package
{

    public class JPush
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static String TITLE = "推送标题（只支持Android）";
        public static String ALERT = "推送内容";
        public static String MSG_CONTENT = "Test from C# v3 sdk - msgContent";
        public static String REGISTRATION_ID = "010ed2b54e6";
        public static String TAG = "tag_api";

        public static String app_key = "9d8bd5c366d1a5f74f4ab091";// SettingConfig.JApp_Key;
        public static String master_secret = "eb8b4a37b8990c51d03605de";//SettingConfig.JMaster_Secret;


        /// <summary>
        /// 根据用户编号极光推送
        /// </summary>
        /// <param name="mid">用户编号</param>
        /// <param name="title">标题</param>
        /// <param name="alert">内容</param>
        /// <param name="extra">推送自定义参数（type：0-系统消息、1-邀请好友、2-二维码，value：值）</param>
        /// <returns></returns>
        public static MessageResult SendPushByMid(int mid, string title, string alert, Dictionary<string, object> extra)
        {
            try
            {
                //  Models.APP.Member model = new BLL.APP.Member().GetModelById(mid);
                //  if (model != null)                
                //  {
                //if (!string.IsNullOrEmpty(model.pushuserid))
                if (mid > 0)
                {
                    //Dictionary<string, object> extra = new Dictionary<string, object>();
                    //extra.Add("aid", "通知");
                    //extra.Add("type", "通知");
                    HashSet<string> alias = new HashSet<string>();//别名是用户mid
                    alias.Add(mid.ToString());
                    var result = new MessageResult();

                    result = SendPushJiGuang(title, alert, 0, extra, alias);

                    logger.Info("推送成功；用户编号：" + mid);
                    return result;
                }
                else
                {
                    logger.ErrorFormat("推送失败：该设备编号{0}不正确；用户编号为：{1}", mid, mid);
                    return null;
                }
                //  }

            }
            catch (APIRequestException e)
            {
                logger.ErrorFormat("推送失败：从jpush服务器错误响应。检查并修复它. <br>HTTP状态：{0}<br>错误代码：{1}<br>错误消息：{2}", e.Status, e.ErrorCode, e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                logger.Error("推送失败" + e.Message);
            }
            return null;
        }

        /// <summary>
        /// 极光推送主程序
        /// </summary>
        /// <param name="_app_key">极光app_key</param>
        /// <param name="_master_secret">极光master_secret</param>
        /// <param name="title">通知标题（只支持Android）</param>
        /// <param name="alert">通知内容</param>
        /// <param name="shebeitype">设备类型（0-Android，1-IOS）</param>
        /// <param name="extra">参数字典</param>
        /// <param name="registrationid">设备标识（为空则推送全部用户）</param>
        /// <returns></returns>
        public static MessageResult SendPushJiGuang(string title, string alert, int? shebeitype, Dictionary<string, object> extra, HashSet<string> alias)
        {
            //logger.Info("*****开始发送******");
            try
            {

                JPushClient client = new JPushClient(app_key, master_secret);
                PushPayload pushPayload = new PushPayload();
                pushPayload.platform = Platform.android_ios();
                if (alias != null && alias.Count() > 0)
                    pushPayload.audience = Audience.s_alias(alias);
                else
                    pushPayload.audience = Audience.all();
                var notification = new Notification().setAlert(alert);
                //if (shebeitype == 0)
                //{
                notification.AndroidNotification = new AndroidNotification();
                notification.AndroidNotification.setTitle(title);
                if (extra != null && extra.Count > 0)
                {
                    foreach (var item in extra)
                    {
                        notification.AndroidNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                }
                //}
                //else
                //{
                notification.IosNotification = new IosNotification();
                notification.IosNotification.disableBadge();
                notification.IosNotification.setBadge(0);
                notification.IosNotification.setSound("default");
                if (extra != null && extra.Count > 0)
                {
                    foreach (var item in extra)
                    {
                        notification.IosNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                }
                //}
                pushPayload.notification = notification.Check();
                var result = client.SendPush(pushPayload);
                return result;
            }
            catch (APIRequestException e)
            {
                logger.ErrorFormat("推送失败：从jpush服务器错误响应。检查并修复它. <br>HTTP状态：{0}<br>错误代码：{1}<br>错误消息：{2}", e.Status, e.ErrorCode, e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                logger.Error("推送失败" + e.Message);
            }
            return null;
        }
    }
}