namespace Excel2Mysql
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btSelectAll = new System.Windows.Forms.Button();
            this.btImport = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.configs = new System.Windows.Forms.ComboBox();
            this.list = new System.Windows.Forms.CheckedListBox();
            this.btInverse = new System.Windows.Forms.Button();
            this.desc = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(204, 209);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(85, 45);
            this.btSelectAll.TabIndex = 0;
            this.btSelectAll.Text = "全    选";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(204, 347);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(85, 45);
            this.btImport.TabIndex = 0;
            this.btImport.Text = "导    入";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // configs
            // 
            this.configs.DisplayMember = "1";
            this.configs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.configs.FormattingEnabled = true;
            this.configs.Location = new System.Drawing.Point(5, 404);
            this.configs.Name = "configs";
            this.configs.Size = new System.Drawing.Size(294, 24);
            this.configs.Sorted = true;
            this.configs.TabIndex = 2;
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(5, 5);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(180, 388);
            this.list.TabIndex = 3;
            // 
            // btInverse
            // 
            this.btInverse.Location = new System.Drawing.Point(204, 278);
            this.btInverse.Name = "btInverse";
            this.btInverse.Size = new System.Drawing.Size(85, 45);
            this.btInverse.TabIndex = 0;
            this.btInverse.Text = "反    选";
            this.btInverse.UseVisualStyleBackColor = true;
            this.btInverse.Click += new System.EventHandler(this.btInverse_Click);
            // 
            // desc
            // 
            this.desc.BackColor = System.Drawing.SystemColors.MenuBar;
            this.desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.desc.Enabled = false;
            this.desc.Location = new System.Drawing.Point(190, 8);
            this.desc.Name = "desc";
            this.desc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.desc.Size = new System.Drawing.Size(116, 195);
            this.desc.TabIndex = 5;
            this.desc.Text = "\nMysql导表工具v1.0\n\n拖拽多个Excel文件\n\n批量导入Mysql\n\n自动执行hookUrl\n\nhambut@qq.com";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 437);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.list);
            this.Controls.Add(this.configs);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btInverse);
            this.Controls.Add(this.btSelectAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel2Mysql";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExeclDragDrop);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.Button btImport;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox configs;
        private System.Windows.Forms.CheckedListBox list;
        private System.Windows.Forms.Button btInverse;
        private System.Windows.Forms.RichTextBox desc;


    }
}

