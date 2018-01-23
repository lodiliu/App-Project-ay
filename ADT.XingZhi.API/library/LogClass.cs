using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ADT.XingZhi.API.library
{
    public class LogClass
    {
        /**/
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public void WriteLogFile(string type, string input)
        {
            /**/
            ///指定日志文件的目录
            string fname = AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt";
            //string fname = HttpContext.Current.Server.MapPath("LogFile.txt");
            /**/
            ///定义文件信息对象

            FileInfo finfo = new FileInfo(fname);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }

            ///创建只写文件流

            using (FileStream fs = finfo.OpenWrite())
            {
                /**/
                ///根据上面创建的文件流创建写数据流
                StreamWriter w = new StreamWriter(fs);

                /**/
                ///设置写数据流的起始位置为文件流的末尾
                w.BaseStream.Seek(0, SeekOrigin.End);

                /**/
                ///写入“Log Entry : ”
                w.Write("\n\rLog Entry : ");

                /**/
                ///写入当前系统时间并换行
                w.Write("{0} {1} \n\r", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

                /**/
                ///写入日志内容并换行
                w.Write(type + " : " + input + "\n\r");

                /**/
                ///写入------------------------------------“并换行
                w.Write("------------------------------------\n\r");

                /**/
                ///清空缓冲区内容，并把缓冲区内容写入基础流
                w.Flush();

                /**/
                ///关闭写数据流
                w.Close();
            }

        }
    }
}