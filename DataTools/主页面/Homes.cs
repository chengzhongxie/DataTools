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

        /// <summary>
        /// 选择需要转换的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 选择文件_Click(object sender, EventArgs e)
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
            // 打开文件
            FileUtilities file = new FileUtilities(jsonFiles, FileEnum.Files);
            文件路径.Text = file.SelectFile();
        }
        /// <summary>
        /// 结果保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 选择文件夹_Click(object sender, EventArgs e)
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
            // 打开文件
            FileUtilities file = new FileUtilities(jsonFiles, FileEnum.Folder);
            文件夹路径.Text = file.SelectFile();
        }

        private void 文件类型选择_Click(object sender, EventArgs e)
        {
            文件夹路径.Text = "无";
            文件路径.Text = "无";
        }
    }
}
