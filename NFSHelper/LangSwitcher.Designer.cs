namespace NFSHelper
{
    partial class LangSwitcher
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// </summary>
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
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_launch_sys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_launch_sys
            // 
            this.btn_launch_sys.Location = new System.Drawing.Point(149, 130);
            this.btn_launch_sys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_launch_sys.Name = "btn_launch_sys";
            this.btn_launch_sys.Size = new System.Drawing.Size(120, 30);
            this.btn_launch_sys.TabIndex = 2;
            this.btn_launch_sys.Text = "Use System code";
            this.btn_launch_sys.UseVisualStyleBackColor = true;
            this.btn_launch_sys.Click += new System.EventHandler(this.btn_sys_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is only intended for testing.\r\nLook for LangTest in Program.cs.\r\n\r\n1) Select" +
                " culture code from the list,\r\n2) Click \"Use selected code\" to test.";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(149, 210);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(74, 30);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "de-DE",
            "en-US",
            "es-CL",
            "es-ES",
            "fr-FR",
            "ko-KR",
            "lv-LV",
            "pl-PL",
            "pt-BR",
            "pt-PT",
            "ro-RO",
            "ru-RU",
            "th-TH",
            "tr-TR",
            "zh-CN",
            "zh-SG",
            "zh-TW"});
            this.listBox1.Location = new System.Drawing.Point(15, 130);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 109);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 1;
            // 
            // btn_launch
            // 
            this.btn_launch.Location = new System.Drawing.Point(149, 170);
            this.btn_launch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.Size = new System.Drawing.Size(120, 30);
            this.btn_launch.TabIndex = 3;
            this.btn_launch.Text = "Use &selected code";
            this.btn_launch.UseVisualStyleBackColor = true;
            this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
            // 
            // LangSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_launch);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_launch_sys);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LangSwitcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LangSwitcher";
            this.Load += new System.EventHandler(this.LangSwitcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_launch_sys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_launch;
    }
}