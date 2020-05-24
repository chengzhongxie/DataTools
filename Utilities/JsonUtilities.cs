using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public class JsonUtilities : Utilities
    {
        /// <summary>
        /// Json文件转换为DataTable
        /// </summary>
        /// <param name="jsonUrl"></param>
        /// <returns></returns>
        public DataTable JsonToData(string jsonUrl)
        {
            using (StreamReader r = new StreamReader(jsonUrl))
            {
                string json = r.ReadToEnd();
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                return dt;
            }
        }

        /// <summary>
        /// Json文件转换为Object
        /// </summary>
        /// <param name="jsonUrl"></param>
        /// <returns></returns>
        public T JsonToObject<T>(string jsonUrl)
        {
            using (StreamReader r = new StreamReader(jsonUrl))
            {
                string json = r.ReadToEnd();
                T dt = JsonConvert.DeserializeObject<T>(json);
                return dt;
            }
        }
        /// <summary>
        /// Json文件转换为List<T>
        /// </summary>
        /// <param name="jsonUrl"></param>
        /// <returns></returns>
        public List<T> JsonToObjectList<T>(string jsonUrl)
        {
            using (StreamReader r = new StreamReader(jsonUrl))
            {
                string json = r.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                return new List<T>();
            }
        }
        /// <summary>
        /// 生成json串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public string JsonString<T>(List<T> ts)
        {
            return JsonConvert.SerializeObject(ts);
        }
        /// <summary>
        /// 生成json文件保存
        /// </summary>
        /// <param name="data"></param>
        /// <param name="saveUrl"></param>
        public bool SaveJson(DataTable data, string saveUrl)
        {
            try
            {
                string result = JsonConvert.SerializeObject(data, new DataTableConverter());
                // 获取当前程序所在路径，并将要创建的文件命名为info.json 
                string fp = saveUrl + $"\\{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";
                File.WriteAllText(fp, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// 重新写入内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        public void WipeFileContent(string url, string json)
        {
            using (var stream = new System.IO.StreamWriter(url, false))
            {
                stream.Write(json);
            }
        }
    }
}
