using Common;
using Common.Dto;
using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace DataTools
{
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            文件模式容器.Visible = true;// 默认显示文件模式容器
        }

        #region 窗口显示控制
        /// <summary>
        /// 显示文件模式容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文件模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            文件模式容器.Visible = true;// 显示文件模式容器
            数据模式容器.Visible = false;// 隐藏数据模式容器
        }
        /// <summary>
        /// 显示数据模式容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 数据模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            文件模式容器.Visible = false;// 隐藏文件模式容器
            数据模式容器.Visible = true;// 显示数据模式容器
        }
        #endregion

        #region 文件/文件夹选择控制
        /// <summary>
        /// 选择需要转换的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 选择文件_Click(object sender, EventArgs e)
        {
            var fileMode = GetFileMode();// 获取转换模式
            // 打开文件
            FileUtilities file = new FileUtilities(fileMode.FileClass, FileEnum.Files);
            文件路径.Text = file.SelectFile();
        }
        /// <summary>
        /// 结果保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 选择文件夹_Click(object sender, EventArgs e)
        {
            var fileMode = GetFileMode();// 获取转换模式
            // 打开文件
            FileUtilities file = new FileUtilities(fileMode.FileClass, FileEnum.Folder);
            文件夹路径.Text = file.SelectFile();
        }

        /// <summary>
        /// 选择文件类型清空文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文件类型选择_Click(object sender, EventArgs e)
        {
            文件夹路径.Text = "无";
            文件路径.Text = "无";
        }
        #endregion

        #region 开始转换
        /// <summary>
        /// 开始换文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开始转换_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(文件夹路径.Text) || 文件夹路径.Text == "无" || string.IsNullOrWhiteSpace(文件路径.Text) || 文件路径.Text == "无")
            {
                MessageCommon.ShowWar("请选择文件路径！！");
            }
            var fileMode = GetFileMode();// 获取转换模式
            if (fileMode.FileMode == FileEnum.JsonToExcel)// json转Excel
            {
                JsonToExcels();
            }
            else if (fileMode.FileMode == FileEnum.ExcelToJson)// Excel转Json
            {
                ExcelToJsons();
            }
            else if (fileMode.FileMode == FileEnum.XMLToExcel)// Xml转Excel
            {
                XmlToExcels();
            }
            else if (fileMode.FileMode == FileEnum.ExcelToXML)// Excel转Xml
            {
                ExcelToXmls();
            }
        }
        /// <summary>
        /// json转Excel操作
        /// </summary>
        private void JsonToExcels()
        {
            JsonUtilities jsonUtilities = new JsonUtilities();
            var dataTale = jsonUtilities.JsonToData(文件路径.Text);
            if (dataTale != null && dataTale.Rows.Count > 0)
            {
                ExcelUtilities excelUtilities = new ExcelUtilities();
                if (excelUtilities.ToExcel(dataTale, 文件夹路径.Text))
                {
                    MessageCommon.ShowInf("转换成功");
                }
                else
                {
                    MessageCommon.ShowErr("转换失败");
                }
            }
        }
        /// <summary>
        /// Excel转Json操作
        /// </summary>
        private void ExcelToJsons()
        {
            ExcelUtilities excelUtilities = new ExcelUtilities();
            var data = excelUtilities.ExcelToDataTable(文件路径.Text);
            if (data != null && data.Rows.Count > 0)
            {
                JsonUtilities jsonUtilities = new JsonUtilities();
                jsonUtilities.SaveJson(data, 文件夹路径.Text);
                if (jsonUtilities.SaveJson(data, 文件夹路径.Text))
                {
                    MessageCommon.ShowInf("转换成功");
                }
                else
                {
                    MessageCommon.ShowErr("转换失败");
                }
            }
        }
        /// <summary>
        /// Xml转Excel操作
        /// </summary>
        private void XmlToExcels()
        {
            XmlUtilities xmlUtilities = new XmlUtilities();
            var data = xmlUtilities.ConvertXMLToDataSet(文件路径.Text);
            if (data != null && data.Rows.Count > 0)
            {
                ExcelUtilities excelUtilities = new ExcelUtilities();
                if (excelUtilities.ToExcel(data, 文件夹路径.Text))
                {
                    MessageCommon.ShowInf("转换成功");
                }
                else
                {
                    MessageCommon.ShowErr("转换失败");
                }
            }
        }
        /// <summary>
        /// Excel转Json操作
        /// </summary>
        private void ExcelToXmls()
        {
            ExcelUtilities excelUtilities = new ExcelUtilities();
            var data = excelUtilities.ExcelToDataTable(文件路径.Text);
            if (data != null && data.Rows.Count > 0)
            {
                XmlUtilities xmlUtilities = new XmlUtilities();
                string xml = xmlUtilities.ConvertDataTableToXML(data);
                if (xmlUtilities.SaveXml(xml, 文件夹路径.Text))
                {
                    MessageCommon.ShowInf("转换成功");
                }
                else
                {
                    MessageCommon.ShowErr("转换失败");
                }
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取转换模式
        /// </summary>
        /// <returns></returns>
        private FileDto GetFileMode()
        {
            string files = string.Empty;
            string jsonFiles = string.Empty;
            // 获取用户选择控件
            foreach (Control c in 文件模式_文件类型.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked == true)
                {
                    files = ((RadioButton)c).Name;
                }
            }
            // 判断文件转换类型
            if (files == FileEnum.JsonToExcel)
            {
                jsonFiles = FileEnum.JsonFiles;
            }
            else if (files == FileEnum.XMLToExcel)
            {
                jsonFiles = FileEnum.XMLFiles;
            }
            else if (files == FileEnum.ExcelToJson || files == FileEnum.ExcelToXML)
            {
                jsonFiles = FileEnum.ExcelFiles;
            }
            return new FileDto() { FileClass = jsonFiles, FileMode = files };
        }
        #endregion
    }
}
