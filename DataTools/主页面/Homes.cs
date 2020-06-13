using Common;
using Common.Dto;
using Common.Enum;
using DataTools.主页面;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace DataTools
{
    public partial class 结果集 : Form
    {
        /// <summary>
        /// 数据库链接集合
        /// </summary>
        private List<SqlUserDto> sqlUserDtos { get; set; }
        /// <summary>
        /// 结果集窗口
        /// </summary>
        public SqlDataShow sqlData = null;
        public 结果集()
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
            GetSqlUserJson();
            Bing();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void Bing()
        {
            数据库ID_Value.ValueMember = "DataBase";
            数据库ID_Value.DisplayMember = "Server";
            数据库ID_Value.DataSource = sqlUserDtos;
        }
        #endregion

        #region 文件模式

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

        #endregion

        #region 数据模式
        /// <summary>
        /// 获取历史用户数据
        /// </summary>
        private void GetSqlUserJson()
        {
            if (sqlUserDtos == null || sqlUserDtos.Count <= 0)
            {
                string jsonPath = @"../../SqlUser.json";
                JsonUtilities json = new JsonUtilities();
                sqlUserDtos = json.JsonToObjectList<SqlUserDto>(jsonPath);
            }
        }
        /// <summary>
        /// 保存用户账号数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 记住账号_CheckedChanged(object sender, EventArgs e)
        {
            var mi = (CheckBox)sender;
            if (mi.Checked)
            {
                // 判断是否重复数据
                var cous = sqlUserDtos.Where(m => m.Server == 数据库ID_Value.Text && m.DataBase == 数据库ID_Value.SelectedValue.ToString());
                if (cous.Count() > 0)
                {
                    MessageCommon.ShowInf("重复用户数据！");
                    return;
                }
                #region 添加新地址
                SqlUserDto sqlUsers = new SqlUserDto();
                sqlUsers.Server = 数据库ID_Value.Text;
                sqlUsers.DataBase = 库_Value.Text;
                sqlUsers.Uid = 用户名_Value.Text;
                sqlUsers.Pwd = EncryptionCommon.Encryption(密码_Value.Text);
                sqlUserDtos.Add(sqlUsers);
                #endregion
                JsonUtilities jsonUtilities = new JsonUtilities();
                // 转换json
                string json = jsonUtilities.JsonString<SqlUserDto>(sqlUserDtos);
                jsonUtilities.WipeFileContent(@"../../SqlUser.json", json);
            }
        }
        /// <summary>
        /// 选择数据id联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 数据库ID_Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            var thiss = (ComboBox)sender;
            var cous = sqlUserDtos.Where(m => m.Server == thiss.Text && m.DataBase == thiss.SelectedValue.ToString()).FirstOrDefault();
            if (cous != null)
            {
                库_Value.Text = cous.DataBase;
                用户名_Value.Text = cous.Uid;
                密码_Value.Text = EncryptionCommon.Decrypt(cous.Pwd);
            }
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 测试链接_Click(object sender, EventArgs e)
        {
            try
            {
                string sqls = string.Empty;
                // 获取用户选择控件
                foreach (Control c in 数据模式_数据类型.Controls)
                {
                    if (c is RadioButton && ((RadioButton)c).Checked == true)
                    {
                        sqls = ((RadioButton)c).Name;
                    }
                }
                if (string.IsNullOrWhiteSpace(数据库ID_Value.Text) || string.IsNullOrWhiteSpace(用户名_Value.Text) || string.IsNullOrWhiteSpace(密码_Value.Text) || string.IsNullOrWhiteSpace(库_Value.Text))
                {
                    MessageCommon.ShowInf("数据链接信息不能为空！");
                    return;
                }
                SqlHelper sqlHelper = sqlHelper = new SqlHelper(数据库ID_Value.Text, 用户名_Value.Text, 密码_Value.Text, 库_Value.Text, sqls);
                if (sqlHelper.SqlTestLink())
                {
                    MessageCommon.ShowInf("连接成功！");
                }
                else
                {
                    MessageCommon.ShowInf("连接失败！");
                }
            }
            catch (Exception ex)
            {

                MessageCommon.ShowInf("连接失败！");
            }
        }
        private void 保存位置_Click(object sender, EventArgs e)
        {
            FileUtilities file = new FileUtilities(FileEnum.JsonFiles, FileEnum.Folder);
            数据模式_保存位置.Text = file.SelectFile();
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(脚本语句_Value.Text))
            {
                MessageCommon.ShowErr("脚本语句不可为空！");
                return;
            }

            #region 绑定数据
            string sqls = string.Empty;
            // 获取用户选择控件
            foreach (Control c in 数据模式_数据类型.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked == true)
                {
                    sqls = ((RadioButton)c).Name;
                }
            }
            SqlUserDto sqlUsers = new SqlUserDto();
            sqlUsers.Server = 数据库ID_Value.Text;
            sqlUsers.DataBase = 库_Value.Text;
            sqlUsers.Uid = 用户名_Value.Text;
            sqlUsers.Pwd = 密码_Value.Text;
            sqlUsers.DatabaseType = sqls;           
            #endregion
            #region 判断窗体是否已打开     
            Form test = Application.OpenForms["SqlDataShow"];  //查找是否打开过about窗体  
            if ((test == null) || (test.IsDisposed)) //如果没有打开过
            {
                sqlData = new SqlDataShow();
                sqlData.BingData(脚本语句_Value.Text, sqlUsers);
                sqlData.Show();   //打开子窗体出来
            }
            else
            {
                sqlData.Activate(); //如果已经打开过就让其获得焦点                 
            }
            #endregion

        }

        private void 导出_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(数据模式_保存位置.Text))
            {
                MessageCommon.ShowErr("保存路径不能为空！");
                return;
            }
            string files = string.Empty;
            // 获取用户选择控件
            foreach (Control c in 数据模式_文件类型.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked == true)
                {
                    files = ((RadioButton)c).Name;
                }
            }
            if (sqlData.ExportFile(数据模式_保存位置.Text, files))
            {
                MessageCommon.ShowInf("导出成功！");
            }
            else
            {
                MessageCommon.ShowInf("导出失败！");
            }
        }
        #endregion

    }
}
