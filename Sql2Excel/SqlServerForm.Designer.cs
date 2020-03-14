namespace Sql2Excel
{
    partial class SqlServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.user_id_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.server_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.data_name_textbox = new System.Windows.Forms.TextBox();
            this.dave_setting_button = new System.Windows.Forms.Button();
            this.cancel_setting_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(59, 102);
            this.password_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(105, 23);
            this.password_textbox.TabIndex = 17;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "密码";
            // 
            // user_id_textbox
            // 
            this.user_id_textbox.Location = new System.Drawing.Point(59, 71);
            this.user_id_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_id_textbox.Name = "user_id_textbox";
            this.user_id_textbox.Size = new System.Drawing.Size(105, 23);
            this.user_id_textbox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "用户";
            // 
            // server_textbox
            // 
            this.server_textbox.Location = new System.Drawing.Point(59, 9);
            this.server_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.server_textbox.Name = "server_textbox";
            this.server_textbox.Size = new System.Drawing.Size(174, 23);
            this.server_textbox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "服务器";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "数据库";
            // 
            // data_name_textbox
            // 
            this.data_name_textbox.Location = new System.Drawing.Point(59, 40);
            this.data_name_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_name_textbox.Name = "data_name_textbox";
            this.data_name_textbox.Size = new System.Drawing.Size(174, 23);
            this.data_name_textbox.TabIndex = 21;
            // 
            // dave_setting_button
            // 
            this.dave_setting_button.Location = new System.Drawing.Point(59, 132);
            this.dave_setting_button.Name = "dave_setting_button";
            this.dave_setting_button.Size = new System.Drawing.Size(75, 23);
            this.dave_setting_button.TabIndex = 22;
            this.dave_setting_button.Text = "保存";
            this.dave_setting_button.UseVisualStyleBackColor = true;
            this.dave_setting_button.Click += new System.EventHandler(this.dave_setting_button_Click);
            // 
            // cancel_setting_button
            // 
            this.cancel_setting_button.Location = new System.Drawing.Point(140, 132);
            this.cancel_setting_button.Name = "cancel_setting_button";
            this.cancel_setting_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_setting_button.TabIndex = 23;
            this.cancel_setting_button.Text = "取消";
            this.cancel_setting_button.UseVisualStyleBackColor = true;
            this.cancel_setting_button.Click += new System.EventHandler(this.cancel_setting_button_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 161);
            this.Controls.Add(this.cancel_setting_button);
            this.Controls.Add(this.dave_setting_button);
            this.Controls.Add(this.data_name_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.user_id_textbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.server_textbox);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 200);
            this.Name = "ServerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器配置";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox user_id_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox server_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox data_name_textbox;
        private System.Windows.Forms.Button dave_setting_button;
        private System.Windows.Forms.Button cancel_setting_button;
    }
}