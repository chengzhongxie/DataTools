namespace DataTools
{
    partial class 结果集
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件模式容器 = new System.Windows.Forms.GroupBox();
            this.文件模式_文件类型 = new System.Windows.Forms.GroupBox();
            this.Excel转XML = new System.Windows.Forms.RadioButton();
            this.Excel转Json = new System.Windows.Forms.RadioButton();
            this.Json转Excel = new System.Windows.Forms.RadioButton();
            this.XML转Excel = new System.Windows.Forms.RadioButton();
            this.开始转换 = new System.Windows.Forms.Button();
            this.文件夹路径 = new System.Windows.Forms.Label();
            this.文件路径 = new System.Windows.Forms.Label();
            this.选择文件夹 = new System.Windows.Forms.Button();
            this.选择文件 = new System.Windows.Forms.Button();
            this.数据模式容器 = new System.Windows.Forms.GroupBox();
            this.查询 = new System.Windows.Forms.Button();
            this.脚本语句 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.数据库ID_Value = new System.Windows.Forms.ComboBox();
            this.测试链接 = new System.Windows.Forms.Button();
            this.记住账号 = new System.Windows.Forms.CheckBox();
            this.数据模式_数据类型 = new System.Windows.Forms.GroupBox();
            this.Oracle = new System.Windows.Forms.RadioButton();
            this.MySql = new System.Windows.Forms.RadioButton();
            this.SqlService = new System.Windows.Forms.RadioButton();
            this.密码_Value = new System.Windows.Forms.TextBox();
            this.密码 = new System.Windows.Forms.Label();
            this.用户名_Value = new System.Windows.Forms.TextBox();
            this.用户名 = new System.Windows.Forms.Label();
            this.数据库ID = new System.Windows.Forms.Label();
            this.数据模式_文件类型 = new System.Windows.Forms.GroupBox();
            this.XML文件 = new System.Windows.Forms.RadioButton();
            this.Json文件 = new System.Windows.Forms.RadioButton();
            this.Excel文件 = new System.Windows.Forms.RadioButton();
            this.打开文件 = new System.Windows.Forms.OpenFileDialog();
            this.保存文件 = new System.Windows.Forms.SaveFileDialog();
            this.打开文件夹 = new System.Windows.Forms.FolderBrowserDialog();
            this.导出 = new System.Windows.Forms.Button();
            this.库_Value = new System.Windows.Forms.TextBox();
            this.库 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.文件模式容器.SuspendLayout();
            this.文件模式_文件类型.SuspendLayout();
            this.数据模式容器.SuspendLayout();
            this.数据模式_数据类型.SuspendLayout();
            this.数据模式_文件类型.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件模式ToolStripMenuItem,
            this.数据模式ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(965, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件模式ToolStripMenuItem
            // 
            this.文件模式ToolStripMenuItem.Name = "文件模式ToolStripMenuItem";
            this.文件模式ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.文件模式ToolStripMenuItem.Text = "文件模式";
            this.文件模式ToolStripMenuItem.Click += new System.EventHandler(this.文件模式ToolStripMenuItem_Click);
            // 
            // 数据模式ToolStripMenuItem
            // 
            this.数据模式ToolStripMenuItem.Name = "数据模式ToolStripMenuItem";
            this.数据模式ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据模式ToolStripMenuItem.Text = "数据模式";
            this.数据模式ToolStripMenuItem.Click += new System.EventHandler(this.数据模式ToolStripMenuItem_Click);
            // 
            // 文件模式容器
            // 
            this.文件模式容器.Controls.Add(this.文件模式_文件类型);
            this.文件模式容器.Controls.Add(this.开始转换);
            this.文件模式容器.Controls.Add(this.文件夹路径);
            this.文件模式容器.Controls.Add(this.文件路径);
            this.文件模式容器.Controls.Add(this.选择文件夹);
            this.文件模式容器.Controls.Add(this.选择文件);
            this.文件模式容器.Location = new System.Drawing.Point(12, 31);
            this.文件模式容器.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.文件模式容器.Name = "文件模式容器";
            this.文件模式容器.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.文件模式容器.Size = new System.Drawing.Size(941, 565);
            this.文件模式容器.TabIndex = 1;
            this.文件模式容器.TabStop = false;
            this.文件模式容器.Text = "文件模式";
            this.文件模式容器.Visible = false;
            // 
            // 文件模式_文件类型
            // 
            this.文件模式_文件类型.Controls.Add(this.Excel转XML);
            this.文件模式_文件类型.Controls.Add(this.Excel转Json);
            this.文件模式_文件类型.Controls.Add(this.Json转Excel);
            this.文件模式_文件类型.Controls.Add(this.XML转Excel);
            this.文件模式_文件类型.Location = new System.Drawing.Point(5, 15);
            this.文件模式_文件类型.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.文件模式_文件类型.Name = "文件模式_文件类型";
            this.文件模式_文件类型.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.文件模式_文件类型.Size = new System.Drawing.Size(304, 87);
            this.文件模式_文件类型.TabIndex = 7;
            this.文件模式_文件类型.TabStop = false;
            // 
            // Excel转XML
            // 
            this.Excel转XML.AutoSize = true;
            this.Excel转XML.Location = new System.Drawing.Point(163, 56);
            this.Excel转XML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Excel转XML.Name = "Excel转XML";
            this.Excel转XML.Size = new System.Drawing.Size(107, 19);
            this.Excel转XML.TabIndex = 3;
            this.Excel转XML.Text = "Excel转XML";
            this.Excel转XML.UseVisualStyleBackColor = true;
            // 
            // Excel转Json
            // 
            this.Excel转Json.AutoSize = true;
            this.Excel转Json.Location = new System.Drawing.Point(19, 56);
            this.Excel转Json.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Excel转Json.Name = "Excel转Json";
            this.Excel转Json.Size = new System.Drawing.Size(115, 19);
            this.Excel转Json.TabIndex = 2;
            this.Excel转Json.Text = "Excel转Json";
            this.Excel转Json.UseVisualStyleBackColor = true;
            this.Excel转Json.Click += new System.EventHandler(this.文件类型选择_Click);
            // 
            // Json转Excel
            // 
            this.Json转Excel.AutoSize = true;
            this.Json转Excel.Checked = true;
            this.Json转Excel.Location = new System.Drawing.Point(19, 24);
            this.Json转Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Json转Excel.Name = "Json转Excel";
            this.Json转Excel.Size = new System.Drawing.Size(115, 19);
            this.Json转Excel.TabIndex = 0;
            this.Json转Excel.TabStop = true;
            this.Json转Excel.Text = "Json转Excel";
            this.Json转Excel.UseVisualStyleBackColor = true;
            this.Json转Excel.Click += new System.EventHandler(this.文件类型选择_Click);
            // 
            // XML转Excel
            // 
            this.XML转Excel.AutoSize = true;
            this.XML转Excel.Location = new System.Drawing.Point(163, 24);
            this.XML转Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XML转Excel.Name = "XML转Excel";
            this.XML转Excel.Size = new System.Drawing.Size(107, 19);
            this.XML转Excel.TabIndex = 1;
            this.XML转Excel.Text = "XML转Excel";
            this.XML转Excel.UseVisualStyleBackColor = true;
            this.XML转Excel.Click += new System.EventHandler(this.文件类型选择_Click);
            // 
            // 开始转换
            // 
            this.开始转换.Location = new System.Drawing.Point(388, 423);
            this.开始转换.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.开始转换.Name = "开始转换";
            this.开始转换.Size = new System.Drawing.Size(119, 88);
            this.开始转换.TabIndex = 6;
            this.开始转换.Text = "开始";
            this.开始转换.UseVisualStyleBackColor = true;
            this.开始转换.Click += new System.EventHandler(this.开始转换_Click);
            // 
            // 文件夹路径
            // 
            this.文件夹路径.AutoSize = true;
            this.文件夹路径.ForeColor = System.Drawing.Color.Lime;
            this.文件夹路径.Location = new System.Drawing.Point(141, 304);
            this.文件夹路径.Name = "文件夹路径";
            this.文件夹路径.Size = new System.Drawing.Size(22, 15);
            this.文件夹路径.TabIndex = 5;
            this.文件夹路径.Text = "无";
            // 
            // 文件路径
            // 
            this.文件路径.AutoSize = true;
            this.文件路径.ForeColor = System.Drawing.Color.Lime;
            this.文件路径.Location = new System.Drawing.Point(141, 226);
            this.文件路径.Name = "文件路径";
            this.文件路径.Size = new System.Drawing.Size(22, 15);
            this.文件路径.TabIndex = 4;
            this.文件路径.Text = "无";
            // 
            // 选择文件夹
            // 
            this.选择文件夹.Location = new System.Drawing.Point(24, 295);
            this.选择文件夹.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.选择文件夹.Name = "选择文件夹";
            this.选择文件夹.Size = new System.Drawing.Size(101, 32);
            this.选择文件夹.TabIndex = 3;
            this.选择文件夹.Text = "保存路径";
            this.选择文件夹.UseVisualStyleBackColor = true;
            this.选择文件夹.Click += new System.EventHandler(this.选择文件夹_Click);
            // 
            // 选择文件
            // 
            this.选择文件.Location = new System.Drawing.Point(24, 216);
            this.选择文件.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.选择文件.Name = "选择文件";
            this.选择文件.Size = new System.Drawing.Size(101, 32);
            this.选择文件.TabIndex = 2;
            this.选择文件.Text = "选择文件";
            this.选择文件.UseVisualStyleBackColor = true;
            this.选择文件.Click += new System.EventHandler(this.选择文件_Click);
            // 
            // 数据模式容器
            // 
            this.数据模式容器.Controls.Add(this.库_Value);
            this.数据模式容器.Controls.Add(this.库);
            this.数据模式容器.Controls.Add(this.导出);
            this.数据模式容器.Controls.Add(this.查询);
            this.数据模式容器.Controls.Add(this.脚本语句);
            this.数据模式容器.Controls.Add(this.richTextBox1);
            this.数据模式容器.Controls.Add(this.数据库ID_Value);
            this.数据模式容器.Controls.Add(this.测试链接);
            this.数据模式容器.Controls.Add(this.记住账号);
            this.数据模式容器.Controls.Add(this.数据模式_数据类型);
            this.数据模式容器.Controls.Add(this.密码_Value);
            this.数据模式容器.Controls.Add(this.密码);
            this.数据模式容器.Controls.Add(this.用户名_Value);
            this.数据模式容器.Controls.Add(this.用户名);
            this.数据模式容器.Controls.Add(this.数据库ID);
            this.数据模式容器.Controls.Add(this.数据模式_文件类型);
            this.数据模式容器.Location = new System.Drawing.Point(12, 32);
            this.数据模式容器.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.数据模式容器.Name = "数据模式容器";
            this.数据模式容器.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.数据模式容器.Size = new System.Drawing.Size(941, 565);
            this.数据模式容器.TabIndex = 2;
            this.数据模式容器.TabStop = false;
            this.数据模式容器.Text = "数据模式";
            this.数据模式容器.Visible = false;
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(388, 519);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(180, 35);
            this.查询.TabIndex = 13;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            // 
            // 脚本语句
            // 
            this.脚本语句.AutoSize = true;
            this.脚本语句.Location = new System.Drawing.Point(281, 25);
            this.脚本语句.Name = "脚本语句";
            this.脚本语句.Size = new System.Drawing.Size(82, 15);
            this.脚本语句.TabIndex = 12;
            this.脚本语句.Text = "脚本语句：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(281, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(644, 470);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // 数据库ID_Value
            // 
            this.数据库ID_Value.FormattingEnabled = true;
            this.数据库ID_Value.Location = new System.Drawing.Point(24, 249);
            this.数据库ID_Value.Name = "数据库ID_Value";
            this.数据库ID_Value.Size = new System.Drawing.Size(235, 23);
            this.数据库ID_Value.TabIndex = 10;
            // 
            // 测试链接
            // 
            this.测试链接.Location = new System.Drawing.Point(43, 511);
            this.测试链接.Name = "测试链接";
            this.测试链接.Size = new System.Drawing.Size(180, 35);
            this.测试链接.TabIndex = 9;
            this.测试链接.Text = "测试链接";
            this.测试链接.UseVisualStyleBackColor = true;
            // 
            // 记住账号
            // 
            this.记住账号.AutoSize = true;
            this.记住账号.Checked = true;
            this.记住账号.CheckState = System.Windows.Forms.CheckState.Checked;
            this.记住账号.Location = new System.Drawing.Point(22, 472);
            this.记住账号.Name = "记住账号";
            this.记住账号.Size = new System.Drawing.Size(89, 19);
            this.记住账号.TabIndex = 8;
            this.记住账号.Text = "记住账号";
            this.记住账号.UseVisualStyleBackColor = true;
            // 
            // 数据模式_数据类型
            // 
            this.数据模式_数据类型.Controls.Add(this.Oracle);
            this.数据模式_数据类型.Controls.Add(this.MySql);
            this.数据模式_数据类型.Controls.Add(this.SqlService);
            this.数据模式_数据类型.Location = new System.Drawing.Point(24, 121);
            this.数据模式_数据类型.Name = "数据模式_数据类型";
            this.数据模式_数据类型.Size = new System.Drawing.Size(238, 89);
            this.数据模式_数据类型.TabIndex = 7;
            this.数据模式_数据类型.TabStop = false;
            // 
            // Oracle
            // 
            this.Oracle.AutoSize = true;
            this.Oracle.Location = new System.Drawing.Point(144, 20);
            this.Oracle.Name = "Oracle";
            this.Oracle.Size = new System.Drawing.Size(76, 19);
            this.Oracle.TabIndex = 2;
            this.Oracle.Text = "Oracle";
            this.Oracle.UseVisualStyleBackColor = true;
            // 
            // MySql
            // 
            this.MySql.AutoSize = true;
            this.MySql.Location = new System.Drawing.Point(19, 53);
            this.MySql.Name = "MySql";
            this.MySql.Size = new System.Drawing.Size(76, 19);
            this.MySql.TabIndex = 1;
            this.MySql.Text = "My Sql";
            this.MySql.UseVisualStyleBackColor = true;
            // 
            // SqlService
            // 
            this.SqlService.AutoSize = true;
            this.SqlService.Checked = true;
            this.SqlService.Location = new System.Drawing.Point(19, 20);
            this.SqlService.Name = "SqlService";
            this.SqlService.Size = new System.Drawing.Size(116, 19);
            this.SqlService.TabIndex = 0;
            this.SqlService.TabStop = true;
            this.SqlService.Text = "Sql Service";
            this.SqlService.UseVisualStyleBackColor = true;
            // 
            // 密码_Value
            // 
            this.密码_Value.Location = new System.Drawing.Point(22, 432);
            this.密码_Value.Name = "密码_Value";
            this.密码_Value.Size = new System.Drawing.Size(237, 25);
            this.密码_Value.TabIndex = 6;
            // 
            // 密码
            // 
            this.密码.AutoSize = true;
            this.密码.Location = new System.Drawing.Point(21, 405);
            this.密码.Name = "密码";
            this.密码.Size = new System.Drawing.Size(52, 15);
            this.密码.TabIndex = 5;
            this.密码.Text = "密码：";
            // 
            // 用户名_Value
            // 
            this.用户名_Value.Location = new System.Drawing.Point(22, 370);
            this.用户名_Value.Name = "用户名_Value";
            this.用户名_Value.Size = new System.Drawing.Size(237, 25);
            this.用户名_Value.TabIndex = 4;
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Location = new System.Drawing.Point(21, 343);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(67, 15);
            this.用户名.TabIndex = 3;
            this.用户名.Text = "用户名：";
            // 
            // 数据库ID
            // 
            this.数据库ID.AutoSize = true;
            this.数据库ID.Location = new System.Drawing.Point(21, 225);
            this.数据库ID.Name = "数据库ID";
            this.数据库ID.Size = new System.Drawing.Size(83, 15);
            this.数据库ID.TabIndex = 1;
            this.数据库ID.Text = "数据库ID：";
            // 
            // 数据模式_文件类型
            // 
            this.数据模式_文件类型.Controls.Add(this.XML文件);
            this.数据模式_文件类型.Controls.Add(this.Json文件);
            this.数据模式_文件类型.Controls.Add(this.Excel文件);
            this.数据模式_文件类型.Location = new System.Drawing.Point(24, 23);
            this.数据模式_文件类型.Name = "数据模式_文件类型";
            this.数据模式_文件类型.Size = new System.Drawing.Size(238, 92);
            this.数据模式_文件类型.TabIndex = 0;
            this.数据模式_文件类型.TabStop = false;
            // 
            // XML文件
            // 
            this.XML文件.AutoSize = true;
            this.XML文件.Location = new System.Drawing.Point(19, 54);
            this.XML文件.Name = "XML文件";
            this.XML文件.Size = new System.Drawing.Size(82, 19);
            this.XML文件.TabIndex = 2;
            this.XML文件.Text = "XML文件";
            this.XML文件.UseVisualStyleBackColor = true;
            // 
            // Json文件
            // 
            this.Json文件.AutoSize = true;
            this.Json文件.Location = new System.Drawing.Point(123, 19);
            this.Json文件.Name = "Json文件";
            this.Json文件.Size = new System.Drawing.Size(90, 19);
            this.Json文件.TabIndex = 1;
            this.Json文件.Text = "Json文件";
            this.Json文件.UseVisualStyleBackColor = true;
            // 
            // Excel文件
            // 
            this.Excel文件.AutoSize = true;
            this.Excel文件.Checked = true;
            this.Excel文件.Location = new System.Drawing.Point(19, 19);
            this.Excel文件.Name = "Excel文件";
            this.Excel文件.Size = new System.Drawing.Size(98, 19);
            this.Excel文件.TabIndex = 0;
            this.Excel文件.TabStop = true;
            this.Excel文件.Text = "Excel文件";
            this.Excel文件.UseVisualStyleBackColor = true;
            // 
            // 打开文件
            // 
            this.打开文件.FileName = "打开文件";
            // 
            // 导出
            // 
            this.导出.Location = new System.Drawing.Point(618, 519);
            this.导出.Name = "导出";
            this.导出.Size = new System.Drawing.Size(180, 35);
            this.导出.TabIndex = 14;
            this.导出.Text = "导出";
            this.导出.UseVisualStyleBackColor = true;
            // 
            // 库_Value
            // 
            this.库_Value.Location = new System.Drawing.Point(22, 309);
            this.库_Value.Name = "库_Value";
            this.库_Value.Size = new System.Drawing.Size(237, 25);
            this.库_Value.TabIndex = 16;
            // 
            // 库
            // 
            this.库.AutoSize = true;
            this.库.Location = new System.Drawing.Point(21, 282);
            this.库.Name = "库";
            this.库.Size = new System.Drawing.Size(37, 15);
            this.库.TabIndex = 15;
            this.库.Text = "库：";
            // 
            // 结果集
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 608);
            this.Controls.Add(this.数据模式容器);
            this.Controls.Add(this.文件模式容器);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "结果集";
            this.Text = "主页面";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.文件模式容器.ResumeLayout(false);
            this.文件模式容器.PerformLayout();
            this.文件模式_文件类型.ResumeLayout(false);
            this.文件模式_文件类型.PerformLayout();
            this.数据模式容器.ResumeLayout(false);
            this.数据模式容器.PerformLayout();
            this.数据模式_数据类型.ResumeLayout(false);
            this.数据模式_数据类型.PerformLayout();
            this.数据模式_文件类型.ResumeLayout(false);
            this.数据模式_文件类型.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据模式ToolStripMenuItem;
        private System.Windows.Forms.GroupBox 文件模式容器;
        private System.Windows.Forms.GroupBox 数据模式容器;
        private System.Windows.Forms.RadioButton Json转Excel;
        private System.Windows.Forms.RadioButton XML转Excel;
        private System.Windows.Forms.OpenFileDialog 打开文件;
        private System.Windows.Forms.SaveFileDialog 保存文件;
        private System.Windows.Forms.FolderBrowserDialog 打开文件夹;
        private System.Windows.Forms.Button 选择文件夹;
        private System.Windows.Forms.Button 选择文件;
        private System.Windows.Forms.Label 文件夹路径;
        private System.Windows.Forms.Label 文件路径;
        private System.Windows.Forms.Button 开始转换;
        private System.Windows.Forms.GroupBox 文件模式_文件类型;
        private System.Windows.Forms.RadioButton Excel转Json;
        private System.Windows.Forms.RadioButton Excel转XML;
        private System.Windows.Forms.GroupBox 数据模式_文件类型;
        private System.Windows.Forms.Label 数据库ID;
        private System.Windows.Forms.RadioButton XML文件;
        private System.Windows.Forms.RadioButton Json文件;
        private System.Windows.Forms.RadioButton Excel文件;
        private System.Windows.Forms.TextBox 密码_Value;
        private System.Windows.Forms.Label 密码;
        private System.Windows.Forms.TextBox 用户名_Value;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.GroupBox 数据模式_数据类型;
        private System.Windows.Forms.RadioButton SqlService;
        private System.Windows.Forms.CheckBox 记住账号;
        private System.Windows.Forms.RadioButton Oracle;
        private System.Windows.Forms.RadioButton MySql;
        private System.Windows.Forms.Button 测试链接;
        private System.Windows.Forms.ComboBox 数据库ID_Value;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.Label 脚本语句;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button 导出;
        private System.Windows.Forms.TextBox 库_Value;
        private System.Windows.Forms.Label 库;
    }
}

