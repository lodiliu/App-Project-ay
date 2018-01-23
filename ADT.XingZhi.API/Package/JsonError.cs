using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ADT.XingZhi.API.Package
{
    public class JsonError
    {
        public static StringBuilder ErrorList()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer js = new JsonSerializer();
                jw.WriteStartObject();
                jw.WritePropertyName("IsSuccess");
                jw.WriteValue(false);
                jw.WritePropertyName("Msg");
                jw.WriteValue("服务器无响应");
                jw.WritePropertyName("Code");
                jw.WriteValue(500);
                jw.WritePropertyName("Total");
                jw.WriteValue(0);
                jw.WritePropertyName("List");
                jw.WriteStartArray();
                jw.WriteEndArray();
                jw.WriteEndObject();
                sw.Close();
                jw.Close();
            }
            return sb;
        }
        public static StringBuilder ErrorInfo()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer js = new JsonSerializer();
                jw.WriteStartObject();
                jw.WritePropertyName("IsSuccess");
                jw.WriteValue(false);
                jw.WritePropertyName("Msg");
                jw.WriteValue("服务器无响应");
                jw.WritePropertyName("Code");
                jw.WriteValue(500);
                sw.Close();
                jw.Close();
            }
            return sb;
        }
    }
}