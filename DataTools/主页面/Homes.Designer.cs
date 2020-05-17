namespace DataTools
{
    partial class Homes
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
            this.Json转Excel = new System.Windows.Forms.RadioButton();
            this.XML转Excel = new System.Windows.Forms.RadioButton();
            this.开始转换 = new System.Windows.Forms.Button();
            this.文件夹路径 = new System.Windows.Forms.Label();
            this.文件路径 = new System.Windows.Forms.Label();
            this.选择文件夹 = new System.Windows.Forms.Button();
            this.选择文件 = new System.Windows.Forms.Button();
            this.数据模式容器 = new System.Windows.Forms.GroupBox();
            this.打开文件 = new System.Windows.Forms.OpenFileDialog();
            this.保存文件 = new System.Windows.Forms.SaveFileDialog();
            this.打开文件夹 = new System.Windows.Forms.FolderBrowserDialog();
            this.Excel转Json = new System.Windows.Forms.RadioButton();
            this.Excel转XML = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.文件模式容器.SuspendLayout();
            this.文件模式_文件类型.SuspendLayout();
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
            this.文件模式ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.文件模式ToolStripMenuItem.Text = "文件模式";
            this.文件模式ToolStripMenuItem.Click += new System.EventHandler(this.文件模式ToolStripMenuItem_Click);
            // 
            // 数据模式ToolStripMenuItem
            // 
            this.数据模式ToolStripMenuItem.Name = "数据模式ToolStripMenuItem";
            this.数据模式ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
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
            // Json转Excel
            // 
            this.Json转Excel.AutoSize = true;
            this.Json转Excel.Checked = true;
            this.Json转Excel.Location = new System.Drawing.Point(19, 24);
            this.Json转Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Json转Excel.Name = "Json转Excel";
            this.Json转Excel.Size = new System.Drawing.Size(115, 19);
            this.Json转Excel.TabIndex = 0;
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
            this.数据模式容器.Location = new System.Drawing.Point(933, 12);
            this.数据模式容器.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.数据模式容器.Name = "数据模式容器";
            this.数据模式容器.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.数据模式容器.Size = new System.Drawing.Size(941, 565);
            this.数据模式容器.TabIndex = 2;
            this.数据模式容器.TabStop = false;
            this.数据模式容器.Text = "数据模式";
            this.数据模式容器.Visible = false;
            // 
            // 打开文件
            // 
            this.打开文件.FileName = "打开文件";
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
            // Homes
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
            this.Name = "Homes";
            this.Text = "主页面";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.文件模式容器.ResumeLayout(false);
            this.文件模式容器.PerformLayout();
            this.文件模式_文件类型.ResumeLayout(false);
            this.文件模式_文件类型.PerformLayout();
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
    }
}

