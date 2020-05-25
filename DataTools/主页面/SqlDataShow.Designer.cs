namespace DataTools.主页面
{
    partial class SqlDataShow
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
            this.查询结果集 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.查询结果集)).BeginInit();
            this.SuspendLayout();
            // 
            // 查询结果集
            // 
            this.查询结果集.AllowUserToAddRows = false;
            this.查询结果集.AllowUserToDeleteRows = false;
            this.查询结果集.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.查询结果集.Dock = System.Windows.Forms.DockStyle.Fill;
            this.查询结果集.Location = new System.Drawing.Point(0, 0);
            this.查询结果集.Name = "查询结果集";
            this.查询结果集.ReadOnly = true;
            this.查询结果集.RowHeadersWidth = 51;
            this.查询结果集.RowTemplate.Height = 27;
            this.查询结果集.Size = new System.Drawing.Size(1283, 608);
            this.查询结果集.TabIndex = 0;
            // 
            // SqlDataShow
            // 
            this.ClientSize = new System.Drawing.Size(1283, 608);
            this.Controls.Add(this.查询结果集);
            this.Name = "SqlDataShow";
            this.Text = "查询结果";
            ((System.ComponentModel.ISupportInitialize)(this.查询结果集)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView 查询结果集;
    }
}
