using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utilities
{
    /// <summary>
    /// XML工具类
    /// </summary>
    public class XmlUtilities
    {
        /// <summary>
        /// DataTable转Xml
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        public string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                if (string.IsNullOrWhiteSpace(xmlDS.TableName))
                {
                    xmlDS.TableName = "data";
                }
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.UTF8);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        /// <summary>
        /// Xml转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public DataTable ConvertXMLToDataSet(string xmlurl)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlurl);
                var xml = doc.InnerXml;
                string xmlData = "<" + xml.Substring(xml.IndexOf('<') + 1);
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        /// <summary>

        /// 将xml转为Datable

        /// </summary>

        public static DataTable XmlToDataTable(string xmlStr)

        {

            if (!string.IsNullOrEmpty(xmlStr))

            {

                StringReader StrStream = null;

                XmlTextReader Xmlrdr = null;

                try

                {

                    DataSet ds = new DataSet();

                    //读取字符串中的信息  

                    StrStream = new StringReader(xmlStr);

                    //获取StrStream中的数据  

                    Xmlrdr = new XmlTextReader(StrStream);

                    //ds获取Xmlrdr中的数据                 

                    ds.ReadXml(Xmlrdr);

                    return ds.Tables[0];

                }

                catch (Exception e)

                {

                    return null;

                }

                finally

                {

                    //释放资源  

                    if (Xmlrdr != null)

                    {

                        Xmlrdr.Close();

                        StrStream.Close();

                        StrStream.Dispose();

                    }

                }

            }

            return null;

        }

        /// <summary>
        /// 保存xml文件
        /// </summary>
        /// <param name="xml">数据</param>
        /// <param name="saveUrl">保存地址</param>
        /// <returns></returns>
        public bool SaveXml(string xml, string saveUrl)
        {
            try
            {
                string fp = saveUrl + $"\\{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";
                if (xml.Contains("<?"))//去除XML HEADER
                {
                    int bb = xml.IndexOf('>');
                    xml = xml.Substring(bb + 1);
                }
                string xmlData = "<" + xml.Substring(xml.IndexOf('<') + 1);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);
                //设置xml生成样式
                XmlWriterSettings xmlSetting = new XmlWriterSettings();
                xmlSetting.Encoding = new UTF8Encoding(false);
                xmlSetting.Indent = true;

                //保存xml文件
                XmlWriter writer = XmlWriter.Create(fp, xmlSetting);
                doc.Save(writer);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        #region 公共方法
        private string Format(string xml)
        {
            return xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&gt;", ">").Replace("&amp;", "&").Replace("&apos;", "'").Replace("&quot;", "\"");
        }
        #endregion
    }
}
