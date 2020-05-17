using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    }
}
