﻿using Common;
using Common.Dto;
using Common.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace DataTools.主页面
{
    public partial class SqlDataShow : Form
    {
        private DataTable dt { get; set; }
        public SqlDataShow()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

            //获取当前工作区宽度和高度（工作区不包含状态栏）
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            //计算窗体显示的坐标值，可以根据需要微调几个像素
            int x = ScreenWidth - this.Width - 5;
            int y = ScreenHeight - this.Height - 5;

            this.Location = new Point(x, y);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlUser"></param>
        public void BingData(string sql, SqlUserDto sqlUser)
        {
            int width = 0;
            if (!string.IsNullOrWhiteSpace(sql))
            {
                SqlHelper sqlHelper = new SqlHelper(sqlUser.Server, sqlUser.Uid, sqlUser.Pwd, sqlUser.DataBase, sqlUser.DatabaseType);
                this.查询结果集.DataBindings.Clear();
                dt = sqlHelper.GetDataTable(sql);
                this.查询结果集.DataSource = dt;

                //对于DataGridView的每一个列都调整
                for (int i = 0; i < this.查询结果集.Columns.Count; i++)
                {
                    //将每一列都调整为自动适应模式
                    this.查询结果集.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    //记录整个DataGridView的宽度
                    width += this.查询结果集.Columns[i].Width;
                }
                //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
                //则将DataGridView的列自动调整模式设置为显示的列即可，
                //如果是小于原来设定的宽度，将模式改为填充。
                if (width > this.查询结果集.Size.Width)
                {
                    this.查询结果集.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
                else
                {
                    this.查询结果集.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="fileUrl">保存位置</param>
        /// <param name="files">文件类型</param>
        public bool ExportFile(string fileUrl, string files)
        {
            if (dt == null && dt.Rows.Count > 0)
            {
                MessageCommon.ShowErr("结果集不能为空！");
            }
            if (files == FileEnum.JsonFiles)
            {
                JsonUtilities jsonUtilities = new JsonUtilities();
                return jsonUtilities.SaveJson(dt, fileUrl);
            }
            else if (files == FileEnum.ExcelFiles)
            {
                ExcelUtilities excelUtilities = new ExcelUtilities();
                return excelUtilities.ToExcel(dt, fileUrl);
            }
            else if (files == FileEnum.XMLFiles)
            {
                XmlUtilities xmlUtilities = new XmlUtilities();
                string xml = xmlUtilities.ConvertDataTableToXML(dt);
                return xmlUtilities.SaveXml(xml, fileUrl);
            }
            else
            {
                return false;
            }
        }
    }
}
