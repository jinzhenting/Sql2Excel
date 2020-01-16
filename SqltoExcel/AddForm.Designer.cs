namespace SqltoExcel
{
    partial class AddForm
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
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.ok_add_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(12, 12);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(260, 21);
            this.name_textbox.TabIndex = 0;
            // 
            // ok_add_button
            // 
            this.ok_add_button.Location = new System.Drawing.Point(197, 39);
            this.ok_add_button.Name = "ok_add_button";
            this.ok_add_button.Size = new System.Drawing.Size(75, 23);
            this.ok_add_button.TabIndex = 1;
            this.ok_add_button.Text = "确定";
            this.ok_add_button.UseVisualStyleBackColor = true;
            this.ok_add_button.Click += new System.EventHandler(this.ok_add_button_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 71);
            this.Controls.Add(this.ok_add_button);
            this.Controls.Add(this.name_textbox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 110);
            this.Name = "AddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "输入名称";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Button ok_add_button;
    }
}