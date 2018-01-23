using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ADT.XingZhi.FineManage.Package
{
    public class Common
    {
        /// <summary>
        /// 字符串替换方法
        /// </summary>
        /// <param name="myStr">需要替换的字符串</param>
        /// <param name="displaceA">需要替换的字符</param>
        /// <param name="displaceB">将替换为</param>
        /// <returns></returns>
        public static string displace(string myStr, string displaceA, string displaceB)
        {
            string str = myStr;
            str = str.Replace(displaceA, displaceB);
            return str;
        }

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="typeid"></param>    
        /// <returns></returns>
        public static string Ptype(string typeid)
        {
            string str = typeid;
            switch (str)
           {
               case "0":
                   str="免费";
               break;
               case "1":
                    str="线上支付";
               break;
               case "2":
                    str="线下支付";
               break;
           }
            return str;
        }

        /// <summary>
        /// 活动状态
        /// </summary>
        /// <param name="typeid"></param>    
        /// <returns></returns>
        public static string Atype(int type)
        {
            string str = type.ToString();
            switch (str)
            {
                case "0":
                    str = "审核中";
                    break;
                case "1":
                    str = "审核成功";
                    break;
                case "2":
                    str = "审核失败";
                    break;
                case "3":
                    str = "取消中";
                    break;
                case "4":
                    str = "取消成功";
                    break;
                case "5":
                    str = "已结束";
                    break;
                case "-1":
                    str = "删除";
                    break;
                case "-2":
                    str = "删除取消";
                    break;
                case "-3":
                    str = "未提交";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public static string Url = ConfigurationManager.AppSettings["url"];
    }
}