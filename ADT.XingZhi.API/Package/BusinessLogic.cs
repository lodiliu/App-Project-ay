
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using ADT.CMS.Utility.Db;

namespace ADT.XingZhi.API.Package
{
    public class BusinessLogic
    {
        //处理充值业务
        public bool PayProcess(AlipayInfo AlipayInfo, int apid,int aid,string mid)
        {
            try
            {
                ADT.XingZhi.BLL.APP.Huanxin bllMsg = new BLL.APP.Huanxin();
                ADT.XingZhi.Models.APP.Huanxin modelMsg = new Models.APP.Huanxin();
                modelMsg.createtime = DateTime.Now;
                modelMsg.type = -1;

                modelMsg.pwd = "二维码";
                bllMsg.Add(modelMsg);

                Models.APP.Activaty activa = new BLL.APP.Activaty().GetModelById(aid);
                Models.APP.Application model = new BLL.APP.Application().GetModelById(apid);
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE; //  support different mode

                qrCodeEncoder.QRCodeScale = 3;
                qrCodeEncoder.QRCodeVersion = 0;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M; // support different mode

                string qrCodeContent = "活动id:" + activa.a_id + "\n姓名：" + model.name + "\n活动名称：" + activa.title + "\n报名费用：" + AlipayInfo.total_fee + "\n联系电话：" + model.phon;
                
                Bitmap img = qrCodeEncoder.Encode(qrCodeContent, Encoding.UTF8);
                string root = HttpContext.Current.Server.MapPath(SettingConfig.CodeUrl);
                String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                string filePath = root + newFileName + ".png";// support different image format

                img.Save(filePath);

               
              
                //获取数值---------------------------------------------------------------
                modelMsg.pwd = "二维码" + filePath;
                bllMsg.Add(modelMsg);

                if (!string.IsNullOrEmpty(activa.g_id))//环信群组
                {

                    HXComm easeMob = new HXComm();
                    var i = easeMob.GroupsFriendAdd(mid, activa.g_id);

                    if (i == null)
                    {
                        Models.APP.Huanxin huan = new Models.APP.Huanxin();
                        huan.mid = mid;
                        huan.pwd = activa.g_id;
                        huan.type = 3;
                        huan.createtime = DateTime.Now;
                    }
                    else
                    {
                        if (new BLL.APP.GroupMember().GetModelById(activa.g_id, mid) == null)
                        {
                            Models.APP.GroupMember gmember = new Models.APP.GroupMember();
                            gmember.m_id = mid;
                            gmember.g_id = activa.g_id;
                            gmember.createtime = DateTime.Now;
                            gmember.type = 0;
                            new BLL.APP.GroupMember().Add(gmember);
                        }
                    }

                }

                List<String> SQLStringList = new List<string>();

                //处理业务（更新支付处理状态）--更新
                string SQLUpdatePay = " update APP_Pay Set ";
                SQLUpdatePay = SQLUpdatePay + "state =1 ,";
                SQLUpdatePay = SQLUpdatePay + "trade_no ='" + AlipayInfo.trade_no + "' ,";
                SQLUpdatePay = SQLUpdatePay + "context ='" + AlipayInfo.AlipayMark + "' ,";
                SQLUpdatePay = SQLUpdatePay + "buyer_email ='" + AlipayInfo.buyer_email + "' ,";
                SQLUpdatePay = SQLUpdatePay + "modifytime ='" + AlipayInfo.notify_time + "' ";
                SQLUpdatePay = SQLUpdatePay + "Where  out_trade_no =" + AlipayInfo.out_trade_no;
                //更新报名人数
                string SQLUpdateActivaty = " update App_Activaty Set ";
                SQLUpdateActivaty = SQLUpdateActivaty + "[number]=[number]+1 ";
                SQLUpdateActivaty = SQLUpdateActivaty + "Where  a_id =" + aid;

                if (activa.isactivaty == 1)
                {
                    SQLUpdateActivaty = SQLUpdateActivaty + " update App_package Set ";
                    SQLUpdateActivaty = SQLUpdateActivaty + "[number]=[number]+1 ";
                    SQLUpdateActivaty = SQLUpdateActivaty + "Where  pk_id =" +  model.pk_id;
                }

                //更新报名状态
                string SQLUpdateApplication = "update App_Application Set ";
                SQLUpdateApplication = SQLUpdateApplication + " state = 1,";
                SQLUpdateApplication = SQLUpdateApplication + "modifytime ='" + DateTime.Now + "' ";
                SQLUpdateApplication = SQLUpdateApplication + " Where ap_id=" + apid;

                //系统通知消息
                string SQLInsertMessage = "Insert Into App_Message (m_id,a_id, pic,title,context,type,isread,createtime  ) values (";
                //用户id
                SQLInsertMessage = SQLInsertMessage + mid + " ,";
                //活动id
                SQLInsertMessage = SQLInsertMessage + "" + aid + " ,";
                //图片
                SQLInsertMessage = SQLInsertMessage + "'" + activa.mypic + "' ,";
                //标题
                SQLInsertMessage = SQLInsertMessage + "'" + activa.title + "' ,";
                //内容
                SQLInsertMessage = SQLInsertMessage + "'" + SettingConfig.CodeUrl + newFileName + ".png ', ";
                SQLInsertMessage = SQLInsertMessage + "2,0,'" + DateTime.Now + "')";

                Dictionary<string, object> extra = new Dictionary<string, object>();
                extra.Add("aid", activa.a_id);
                extra.Add("type", "0");

                if (activa.type == 2)
                {
                    SQLInsertMessage =SQLInsertMessage+ "Insert Into App_Message (m_id,a_id, pic,title,context,type,isread,createtime  ) values (";
                    //用户id
                    SQLInsertMessage = SQLInsertMessage + activa.userid + " ,";
                    //活动id
                    SQLInsertMessage = SQLInsertMessage + "" + aid + " ,";
                    //图片
                    SQLInsertMessage = SQLInsertMessage + "'" + activa.mypic + "' ,";
                    //标题
                    SQLInsertMessage = SQLInsertMessage + "'" + activa.title + "' ,";
                    //内容
                    SQLInsertMessage = SQLInsertMessage + "'" +"关于" + activa.title + "赛事，" + model.name + "已报名', ";
                    SQLInsertMessage = SQLInsertMessage + "0,0,'" + DateTime.Now + "')";

                    //极光推送

                    JPush.SendPushByMid(Convert.ToInt32(activa.userid), activa.title, model.name + "已报名", extra);
                 //   new BLL.APP.Message().Add(message);

                    if (activa.numberlimit != 0 && activa.number + 1 == activa.numberlimit)
                    {
                        SQLInsertMessage = SQLInsertMessage + "Insert Into App_Message (m_id,a_id, pic,title,context,type,isread,createtime  ) values (";
                        //用户id
                        SQLInsertMessage = SQLInsertMessage + activa.userid + " ,";
                        //活动id
                        SQLInsertMessage = SQLInsertMessage + "" + aid + " ,";
                        //图片
                        SQLInsertMessage = SQLInsertMessage + "'" + activa.mypic + "' ,";
                        //标题
                        SQLInsertMessage = SQLInsertMessage + "'" + activa.title + "' ,";
                        //内容
                        SQLInsertMessage = SQLInsertMessage + "'" +"关于" + activa.title + "赛事，人员已满！', ";
                        SQLInsertMessage = SQLInsertMessage + "0,0,'" + DateTime.Now + "')";

                        //极光推送
                        //Dictionary<string, object> extra = new Dictionary<string, object>();
                        //extra.Add("aid", activa.a_id);
                        //extra.Add("type", "0");
                        JPush.SendPushByMid(Convert.ToInt32(activa.userid), activa.title, "人员已满", extra);
                      
                    }
                }
                //处理业务
                SQLStringList.Add(SQLUpdatePay);
                //更新报名人数
                SQLStringList.Add(SQLUpdateActivaty);
                //更新报名状态
                SQLStringList.Add(SQLUpdateApplication);
                //系统通知消息
                SQLStringList.Add(SQLInsertMessage);

           ExecuteSqlTran(SQLStringList);
         //  extra.Add("type", "2");
           JPush.SendPushByMid(Convert.ToInt32(mid), activa.title, "报名成功", extra);
               // SqlPagerHelper.
            }
            catch
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(DefaultConnection.ConnectionStringByDefaultDB))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
    }
}