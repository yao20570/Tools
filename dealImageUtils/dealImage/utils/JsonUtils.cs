using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace dealImage.utils
{
    public class JsonUtils
    {
        //从file读取string
        public static string getStrFormJsonFile(string fileFullName)
        {
            StreamReader sr = new StreamReader(fileFullName);
            string s = sr.ReadToEnd();
            sr.Close();
            return s;
        }

        //将string写入file
        public static void writeJsonStrToFile(JObject jsonObj, string fileFullName)
        {
            try
            {
                string str = getStrFromJsonObj(jsonObj);
                StreamWriter sw = new StreamWriter(fileFullName, false);
                sw.Write(str);
                sw.Close();
            }
            catch (Exception ex)
            {
                LogUtils.WriteLine("保存ui的json文件失败===>{0}", fileFullName);
            }

        }

        //string转化为JsonObject
        public static JObject getJsonObjFromString(string jsonText)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.Formatting = Formatting.Indented;
            JObject jsonObj = (JObject)JsonConvert.DeserializeObject(jsonText, setting);
            //JObject jsonObj = JObject.Parse(jsonText);
            return jsonObj;
        }

        //file转化为JsonObject
        public static JObject getJsonObjFromJsonFile(string fileFullName)
        {
            string strJson = getStrFormJsonFile(fileFullName);
            JObject jsonObj = getJsonObjFromString(strJson);
            return jsonObj;
        }

        //JsonObject转为string
        public static string getStrFromJsonObj(JObject jsonObj)
        {
            //string str = JsonConvert.SerializeObject(jsonObj);
            string str = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            return str;
        }       
    }
}
