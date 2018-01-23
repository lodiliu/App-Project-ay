using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ADT.XingZhi.API.Package
{
    public class HXComm
    {
        //string reqUrlFormat = "https://a1.easemob.com/adinnet01/adinnet/";
        //string appName = "adinnet", orgName = "adinnet01";

        //string clientID = "YXA678up4EpMEeW67RsTzbLF1A"
        //    , clientSecret = "YXA6346u_euUBDVeJ-UzRBAl0neccOs";

        string reqUrlFormat = "https://a1.easemob.com/sportsapply/sportapply/";
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string appName { get; set; }
        public string orgName { get; set; }
        public string token { get; set; }
        public string easeMobUrl { get { return string.Format(reqUrlFormat, orgName, appName); } }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="easeAppClientID">client_id</param>
        /// <param name="easeAppClientSecret">client_secret</param>
        /// <param name="easeAppName">应用标识之应用名称</param>
        /// <param name="easeAppOrgName">应用标识之登录账号</param>
       // public HXComm(string easeAppClientID, string easeAppClientSecret, string easeAppName, string easeAppOrgName)
        public HXComm()
        {
            this.clientID = "YXA6MDbKcFhgEeWX1nUh_hpa5w";
            this.clientSecret = "YXA6wdcIznZprJqIOA56krIGZjKb-9g";
            this.appName = "sportapply";
            this.orgName = "sportsapply";
            this.token = QueryToken();
        }

        /// <summary>
        /// 使用app的client_id 和 client_secret登陆并获取授权token
        /// </summary>
        /// <returns></returns>
        string QueryToken()
        {
            if (string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(clientSecret)) { return string.Empty; }
            string cacheKey = clientID + clientSecret;
            if (System.Web.HttpRuntime.Cache.Get(cacheKey) != null &&
                System.Web.HttpRuntime.Cache.Get(cacheKey).ToString().Length > 0)
            {
                return System.Web.HttpRuntime.Cache.Get(cacheKey).ToString();
            }

            string postUrl = easeMobUrl + "token";
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"grant_type\": \"client_credentials\",\"client_id\": \"{0}\",\"client_secret\": \"{1}\"", clientID, clientSecret);
            _build.Append("}");

            string postResultStr = ReqUrl(postUrl, "POST", _build.ToString(), string.Empty);
            string token = string.Empty;
            int expireSeconds = 0;
            try
            {
                JObject jo = JObject.Parse(postResultStr);
                token = jo.GetValue("access_token").ToString();
                int.TryParse(jo.GetValue("expires_in").ToString(), out expireSeconds);
                //设置缓存
                if (!string.IsNullOrEmpty(token) && token.Length > 0 && expireSeconds > 0)
                {
                    System.Web.HttpRuntime.Cache.Insert(cacheKey, token, null, DateTime.Now.AddSeconds(expireSeconds), System.TimeSpan.Zero);
                }
            }
            catch { return postResultStr; }
            return token;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string userName, string password)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"username\": \"{0}\",\"password\": \"{1}\"", userName, password);
            _build.Append("}");

            return AccountCreate(_build.ToString());
        }

        /// <summary>
        /// 创建用户(可以批量创建)
        /// </summary>
        /// <param name="postData">创建账号JSON数组--可以一个，也可以多个</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string postData) { return ReqUrl(easeMobUrl + "users", "POST", postData, token); }

        /// <summary>
        /// 获取指定用户详情
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>会员JSON</returns>
        public string AccountGet(string userName) { return ReqUrl(easeMobUrl + "users/" + userName, "GET", string.Empty, token); }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>重置结果JSON(如：{ "action" : "set user password",  "timestamp" : 1404802674401,  "duration" : 90})</returns>
        public string AccountResetPwd(string userName, string newPassword) { return ReqUrl(easeMobUrl + "users/" + userName + "/password", "PUT", "{\"newpassword\" : \"" + newPassword + "\"}", token); }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDel(string userName) { return ReqUrl(easeMobUrl + "users/" + userName, "DELETE", string.Empty, token); }

        /// <summary>
        /// 用户的添加好友
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>创建成功的用户JSON</returns>
        public string FriendAdd(string userName, string friendname) { return ReqUrl(easeMobUrl + "users/" + userName + "/contacts/users/" + friendname, "POST", string.Empty, token); }

        /// <summary>
        /// 删除用户好友
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string FriendDel(string userName, string friendname) { return ReqUrl(easeMobUrl + "users/" + userName + "/contacts/users/" + friendname, "DELETE", string.Empty, token); }


        /// <summary>
        /// 创建群组
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>创建成功的用户JSON</returns>
        public string GroupsCreate(string postData) { return ReqUrl(easeMobUrl + "chatgroups", "POST", postData, token); }

        /// <summary>
        /// 修改群组
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>修改成功的用户JSON</returns>
        public string GroupsUpdate(string groupsid, string postData) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid, "PUT", postData, token); }

        /// <summary>
        /// 用户的添加群员
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>创建成功的用户JSON</returns>
        public string GroupsFriendAdd(string userName, string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid + "/users/" + userName, "POST", string.Empty, token); }


        /// <summary>
        /// 批量添加群员
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>创建成功的用户JSON</returns>
        public string GroupsFriendAdds(string postData, string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid + "/users/", "POST", postData, token); }

        /// <summary>
        /// 删除群员
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string GroupsFriendDel(string userName, string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid + "/users/" + userName, "DELETE", string.Empty, token); }

        /// <summary>
        /// 删除群组
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string GroupsDel(string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid, "DELETE", string.Empty, token); }

        /// <summary>
        /// 获取指定群组详情
        /// </summary>
        /// <param name="groupsid">账号</param>
        /// <returns>会员JSON</returns>
        public string GroupsGet(string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid, "GET", string.Empty, token); }

        /// <summary>
        /// 获取指定群组成员
        /// </summary>
        /// <param name="groupsid">账号</param>
        /// <returns>会员JSON</returns>
        public string GroupsMemberGet(string groupsid) { return ReqUrl(easeMobUrl + "chatgroups/" + groupsid + "/users", "GET", string.Empty, token); }

        public string ReqUrl(string reqUrl, string method, string paramData, string token)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                request.Method = method.ToUpperInvariant();

                if (!string.IsNullOrEmpty(token) && token.Length > 1) { request.Headers.Add("Authorization", "Bearer " + token); }
                if (request.Method.ToString() != "GET" && !string.IsNullOrEmpty(paramData) && paramData.Length > 0)
                {
                    request.ContentType = "application/json";
                    byte[] buffer = Encoding.UTF8.GetBytes(paramData);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        string result = stream.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); return ""; }
        }
    }

    public class SampleUse
    {
        /// <summary>
        /// 使用范例
        /// HXComm.SampleUse mySample = new HXComm.SampleUse();
        /// mySample.Test(appClientID, appClientSecret, appName, orgName);
        /// </summary>
        /// <param name="appClientID"></param>
        /// <param name="appClientSecret"></param>
        /// <param name="appName"></param>
        /// <param name="orgName"></param>
        public void Test(string appClientID, string appClientSecret, string appName, string orgName)
        {
          //  HXComm myEaseMobDemo = new HXComm(appClientID, appClientSecret, appName, orgName);
            HXComm myEaseMobDemo = new HXComm();
            string userName = "a001", password = "a001", newPassword = "a000000";//此处我们要进行加密处理，如果在实际项目中，建议加密

            Console.WriteLine("{0}", myEaseMobDemo.AccountCreate(userName, password));
            Console.WriteLine("{0}", myEaseMobDemo.AccountGet(password));
            Console.WriteLine("{0}", myEaseMobDemo.AccountResetPwd(userName, newPassword));
            Console.WriteLine("{0}", myEaseMobDemo.AccountDel(password));
        }

        /// <summary>
        /// 批量导入账号(txt文件)
        /// 内容格式为(用制表符或空格隔开即可)：账号 密码
        /// </summary>
        /// <param name="txtFile">文件保存地址</param>
        /// <param name="appClientID"></param>
        /// <param name="appClientSecret"></param>
        /// <param name="appName"></param>
        /// <param name="orgName"></param>
        public void ImportUserToHX(string txtFile, string appClientID, string appClientSecret, string appName, string orgName)
        {
            using (StreamReader sr = new StreamReader(txtFile))
            {
                string line = sr.ReadLine();
                //HXComm easeMob = new HXComm(appClientID, appClientSecret, appName, orgName);
                HXComm easeMob = new HXComm();
                System.Text.StringBuilder _build = new StringBuilder();
                while (line != null)
                {
                    string[] arr = line.Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr != null && arr.Length == 2)
                    {
                        string u = arr[0], p = arr[1];
                        string returnMsg = easeMob.AccountCreate(u, p);
                        _build.AppendFormat("{0}\r\n\r\n", returnMsg);
                        Console.WriteLine(returnMsg);
                    }
                    line = sr.ReadLine();
                }

                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log" + DateTime.Now.Ticks.ToString() + ".txt";
                using (StreamWriter sw = new StreamWriter(logPath, false, Encoding.UTF8))
                {
                    sw.Write(_build.ToString());
                    sw.Flush();
                }
            }
        }
    
    }
}