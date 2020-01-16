namespace SqltoExcel
{
    partial class IndexForm
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
            this.toexcel_button = new System.Windows.Forms.Button();
            this.preview_button = new System.Windows.Forms.Button();
            this.excel_background = new System.ComponentModel.BackgroundWorker();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.app_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.esc_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.setting_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.server_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.about_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.help_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.show_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.progress_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.percentage_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.save_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.command_textbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list_combobox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data_table = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sql_background = new System.ComponentModel.BackgroundWorker();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_table)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toexcel_button
            // 
            this.toexcel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toexcel_button.Location = new System.Drawing.Point(698, 252);
            this.toexcel_button.Name = "toexcel_button";
            this.toexcel_button.Size = new System.Drawing.Size(75, 25);
            this.toexcel_button.TabIndex = 2;
            this.toexcel_button.Text = "导出";
            this.toexcel_button.UseVisualStyleBackColor = true;
            this.toexcel_button.Click += new System.EventHandler(this.toexcel_button_Click);
            // 
            // preview_button
            // 
            this.preview_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.preview_button.Location = new System.Drawing.Point(617, 252);
            this.preview_button.Name = "preview_button";
            this.preview_button.Size = new System.Drawing.Size(75, 25);
            this.preview_button.TabIndex = 4;
            this.preview_button.Text = "生成";
            this.preview_button.UseVisualStyleBackColor = true;
            this.preview_button.Click += new System.EventHandler(this.preview_button_Click);
            // 
            // excel_background
            // 
            this.excel_background.WorkerReportsProgress = true;
            this.excel_background.WorkerSupportsCancellation = true;
            this.excel_background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excel_background_DoWork);
            this.excel_background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.excel_background_ProgressChanged);
            this.excel_background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excel_background_RunWorkerCompleted);
            // 
            // menu
            // 
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.app_menu,
            this.setting_menu,
            this.about_menu});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 25);
            this.menu.TabIndex = 12;
            this.menu.Text = "menu";
            // 
            // app_menu
            // 
            this.app_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esc_menu});
            this.app_menu.Name = "app_menu";
            this.app_menu.Size = new System.Drawing.Size(44, 21);
            this.app_menu.Text = "程序";
            // 
            // esc_menu
            // 
            this.esc_menu.Name = "esc_menu";
            this.esc_menu.Size = new System.Drawing.Size(100, 22);
            this.esc_menu.Text = "退出";
            this.esc_menu.Click += new System.EventHandler(this.esc_menu_Click);
            // 
            // setting_menu
            // 
            this.setting_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.server_menu});
            this.setting_menu.Name = "setting_menu";
            this.setting_menu.Size = new System.Drawing.Size(44, 21);
            this.setting_menu.Text = "设置";
            // 
            // server_menu
            // 
            this.server_menu.Name = "server_menu";
            this.server_menu.Size = new System.Drawing.Size(112, 22);
            this.server_menu.Text = "数据库";
            this.server_menu.Click += new System.EventHandler(this.server_menu_Click);
            // 
            // about_menu
            // 
            this.about_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help_menu,
            this.show_menu});
            this.about_menu.Name = "about_menu";
            this.about_menu.Size = new System.Drawing.Size(44, 21);
            this.about_menu.Text = "关于";
            // 
            // help_menu
            // 
            this.help_menu.Name = "help_menu";
            this.help_menu.Size = new System.Drawing.Size(100, 22);
            this.help_menu.Text = "帮助";
            this.help_menu.Click += new System.EventHandler(this.help_menu_Click);
            // 
            // show_menu
            // 
            this.show_menu.Name = "show_menu";
            this.show_menu.Size = new System.Drawing.Size(100, 22);
            this.show_menu.Text = "说明";
            this.show_menu.Click += new System.EventHandler(this.show_menu_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progress_label,
            this.progressbar,
            this.percentage_label});
            this.status.Location = new System.Drawing.Point(0, 539);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(784, 22);
            this.status.TabIndex = 13;
            this.status.Text = "status";
            // 
            // progress_label
            // 
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(56, 17);
            this.progress_label.Text = "等待操作";
            // 
            // progressbar
            // 
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(100, 16);
            // 
            // percentage_label
            // 
            this.percentage_label.Name = "percentage_label";
            this.percentage_label.Size = new System.Drawing.Size(19, 17);
            this.percentage_label.Text = "%";
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_button.Location = new System.Drawing.Point(584, 189);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(91, 25);
            this.save_button.TabIndex = 17;
            this.save_button.Text = "保存到列表";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_button.Location = new System.Drawing.Point(681, 189);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(91, 25);
            this.delete_button.TabIndex = 18;
            this.delete_button.Text = "从列表删除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // command_textbox
            // 
            this.command_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.command_textbox.Location = new System.Drawing.Point(10, 22);
            this.command_textbox.Multiline = true;
            this.command_textbox.Name = "command_textbox";
            this.command_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.command_textbox.Size = new System.Drawing.Size(760, 161);
            this.command_textbox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.list_combobox);
            this.groupBox1.Controls.Add(this.save_button);
            this.groupBox1.Controls.Add(this.delete_button);
            this.groupBox1.Controls.Add(this.command_textbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 222);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询语句";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "从列表选择";
            // 
            // list_combobox
            // 
            this.list_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.list_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_combobox.FormattingEnabled = true;
            this.list_combobox.Location = new System.Drawing.Point(278, 189);
            this.list_combobox.Name = "list_combobox";
            this.list_combobox.Size = new System.Drawing.Size(300, 25);
            this.list_combobox.TabIndex = 2;
            this.list_combobox.SelectedIndexChanged += new System.EventHandler(this.list_combobox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 1);
            this.panel1.TabIndex = 22;
            // 
            // data_table
            // 
            this.data_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.data_table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.data_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_table.Location = new System.Drawing.Point(0, 0);
            this.data_table.Name = "data_table";
            this.data_table.RowTemplate.Height = 23;
            this.data_table.Size = new System.Drawing.Size(761, 222);
            this.data_table.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toexcel_button);
            this.groupBox2.Controls.Add(this.preview_button);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 286);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.data_table);
            this.panel2.Location = new System.Drawing.Point(10, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 224);
            this.panel2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 26);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(780, 511);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 24;
            // 
            // sql_background
            // 
            this.sql_background.WorkerReportsProgress = true;
            this.sql_background.WorkerSupportsCancellation = true;
            this.sql_background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sql_background_DoWork);
            this.sql_background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sql_background_ProgressChanged);
            this.sql_background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sql_background_RunWorkerCompleted);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "IndexForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库导出表格工具";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_table)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button toexcel_button;
        private System.Windows.Forms.Button preview_button;
        private System.ComponentModel.BackgroundWorker excel_background;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem app_menu;
        private System.Windows.Forms.ToolStripMenuItem esc_menu;
        private System.Windows.Forms.ToolStripMenuItem setting_menu;
        private System.Windows.Forms.ToolStripMenuItem server_menu;
        private System.Windows.Forms.ToolStripMenuItem about_menu;
        private System.Windows.Forms.ToolStripMenuItem help_menu;
        private System.Windows.Forms.ToolStripMenuItem show_menu;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel progress_label;
        private System.Windows.Forms.ToolStripProgressBar progressbar;
        private System.Windows.Forms.ToolStripStatusLabel percentage_label;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TextBox command_textbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView data_table;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox list_combobox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker sql_background;
    }
}

