namespace NFSHelper
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_disclaimer = new System.Windows.Forms.Label();
            this.btn_launch = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grp_language = new System.Windows.Forms.GroupBox();
            this.chk_locale = new System.Windows.Forms.CheckBox();
            this.rdo_cdn_frankfurt_ru = new System.Windows.Forms.RadioButton();
            this.rdo_cdn_siliconvalley_es = new System.Windows.Forms.RadioButton();
            this.rdo_cdn_siliconvalley_en = new System.Windows.Forms.RadioButton();
            this.lbl_language_tips = new System.Windows.Forms.Label();
            this.rdo_cdn_hongkong_en = new System.Windows.Forms.RadioButton();
            this.rdo_cdn_none = new System.Windows.Forms.RadioButton();
            this.rdo_cdn_frankfurt_en = new System.Windows.Forms.RadioButton();
            this.grp_server = new System.Windows.Forms.GroupBox();
            this.lbl_server_tips = new System.Windows.Forms.Label();
            this.label_srv = new System.Windows.Forms.Label();
            this.grp_resolution = new System.Windows.Forms.GroupBox();
            this.rdo_res_100 = new System.Windows.Forms.RadioButton();
            this.rdo_res_75 = new System.Windows.Forms.RadioButton();
            this.rdo_res_50 = new System.Windows.Forms.RadioButton();
            this.chk_drawfps = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.grp_language.SuspendLayout();
            this.grp_server.SuspendLayout();
            this.grp_resolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_disclaimer
            // 
            resources.ApplyResources(this.lbl_disclaimer, "lbl_disclaimer");
            this.lbl_disclaimer.Name = "lbl_disclaimer";
            // 
            // btn_launch
            // 
            resources.ApplyResources(this.btn_launch, "btn_launch");
            this.btn_launch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.UseVisualStyleBackColor = true;
            this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
            // 
            // btn_about
            // 
            resources.ApplyResources(this.btn_about, "btn_about");
            this.btn_about.Name = "btn_about";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grp_language
            // 
            this.grp_language.Controls.Add(this.chk_locale);
            this.grp_language.Controls.Add(this.rdo_cdn_siliconvalley_en);
            this.grp_language.Controls.Add(this.lbl_language_tips);
            this.grp_language.Controls.Add(this.rdo_cdn_hongkong_en);
            this.grp_language.Controls.Add(this.rdo_cdn_none);
            this.grp_language.Controls.Add(this.rdo_cdn_frankfurt_en);
            resources.ApplyResources(this.grp_language, "grp_language");
            this.grp_language.Name = "grp_language";
            this.grp_language.TabStop = false;
            // 
            // chk_locale
            // 
            resources.ApplyResources(this.chk_locale, "chk_locale");
            this.chk_locale.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chk_locale.Name = "chk_locale";
            this.chk_locale.UseVisualStyleBackColor = true;
            // 
            // rdo_cdn_frankfurt_ru
            // 
            resources.ApplyResources(this.rdo_cdn_frankfurt_ru, "rdo_cdn_frankfurt_ru");
            this.rdo_cdn_frankfurt_ru.Name = "rdo_cdn_frankfurt_ru";
            this.rdo_cdn_frankfurt_ru.TabStop = true;
            this.rdo_cdn_frankfurt_ru.UseVisualStyleBackColor = true;
            // 
            // rdo_cdn_siliconvalley_es
            // 
            resources.ApplyResources(this.rdo_cdn_siliconvalley_es, "rdo_cdn_siliconvalley_es");
            this.rdo_cdn_siliconvalley_es.Name = "rdo_cdn_siliconvalley_es";
            this.rdo_cdn_siliconvalley_es.TabStop = true;
            this.rdo_cdn_siliconvalley_es.UseVisualStyleBackColor = true;
            // 
            // rdo_cdn_siliconvalley_en
            // 
            resources.ApplyResources(this.rdo_cdn_siliconvalley_en, "rdo_cdn_siliconvalley_en");
            this.rdo_cdn_siliconvalley_en.Name = "rdo_cdn_siliconvalley_en";
            this.rdo_cdn_siliconvalley_en.TabStop = true;
            this.rdo_cdn_siliconvalley_en.UseVisualStyleBackColor = true;
            // 
            // lbl_language_tips
            // 
            resources.ApplyResources(this.lbl_language_tips, "lbl_language_tips");
            this.lbl_language_tips.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbl_language_tips.Name = "lbl_language_tips";
            // 
            // rdo_cdn_hongkong_en
            // 
            resources.ApplyResources(this.rdo_cdn_hongkong_en, "rdo_cdn_hongkong_en");
            this.rdo_cdn_hongkong_en.Name = "rdo_cdn_hongkong_en";
            this.rdo_cdn_hongkong_en.TabStop = true;
            this.rdo_cdn_hongkong_en.UseVisualStyleBackColor = true;
            // 
            // rdo_cdn_none
            // 
            resources.ApplyResources(this.rdo_cdn_none, "rdo_cdn_none");
            this.rdo_cdn_none.Name = "rdo_cdn_none";
            this.rdo_cdn_none.TabStop = true;
            this.rdo_cdn_none.UseVisualStyleBackColor = true;
            // 
            // rdo_cdn_frankfurt_en
            // 
            resources.ApplyResources(this.rdo_cdn_frankfurt_en, "rdo_cdn_frankfurt_en");
            this.rdo_cdn_frankfurt_en.Name = "rdo_cdn_frankfurt_en";
            this.rdo_cdn_frankfurt_en.TabStop = true;
            this.rdo_cdn_frankfurt_en.UseVisualStyleBackColor = true;
            // 
            // grp_server
            // 
            this.grp_server.Controls.Add(this.lbl_server_tips);
            this.grp_server.Controls.Add(this.label_srv);
            resources.ApplyResources(this.grp_server, "grp_server");
            this.grp_server.Name = "grp_server";
            this.grp_server.TabStop = false;
            // 
            // lbl_server_tips
            // 
            resources.ApplyResources(this.lbl_server_tips, "lbl_server_tips");
            this.lbl_server_tips.Name = "lbl_server_tips";
            // 
            // label_srv
            // 
            resources.ApplyResources(this.label_srv, "label_srv");
            this.label_srv.ForeColor = System.Drawing.Color.Red;
            this.label_srv.Name = "label_srv";
            // 
            // grp_resolution
            // 
            this.grp_resolution.Controls.Add(this.rdo_res_100);
            this.grp_resolution.Controls.Add(this.rdo_res_75);
            this.grp_resolution.Controls.Add(this.rdo_res_50);
            resources.ApplyResources(this.grp_resolution, "grp_resolution");
            this.grp_resolution.Name = "grp_resolution";
            this.grp_resolution.TabStop = false;
            // 
            // rdo_res_100
            // 
            resources.ApplyResources(this.rdo_res_100, "rdo_res_100");
            this.rdo_res_100.Name = "rdo_res_100";
            this.rdo_res_100.TabStop = true;
            this.rdo_res_100.UseVisualStyleBackColor = true;
            // 
            // rdo_res_75
            // 
            resources.ApplyResources(this.rdo_res_75, "rdo_res_75");
            this.rdo_res_75.Name = "rdo_res_75";
            this.rdo_res_75.TabStop = true;
            this.rdo_res_75.UseVisualStyleBackColor = true;
            // 
            // rdo_res_50
            // 
            resources.ApplyResources(this.rdo_res_50, "rdo_res_50");
            this.rdo_res_50.Name = "rdo_res_50";
            this.rdo_res_50.TabStop = true;
            this.rdo_res_50.UseVisualStyleBackColor = true;
            // 
            // chk_drawfps
            // 
            resources.ApplyResources(this.chk_drawfps, "chk_drawfps");
            this.chk_drawfps.Name = "chk_drawfps";
            this.chk_drawfps.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grp_language);
            this.Controls.Add(this.rdo_cdn_frankfurt_ru);
            this.Controls.Add(this.rdo_cdn_siliconvalley_es);
            this.Controls.Add(this.chk_drawfps);
            this.Controls.Add(this.grp_resolution);
            this.Controls.Add(this.grp_server);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lbl_disclaimer);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_launch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_language.ResumeLayout(false);
            this.grp_language.PerformLayout();
            this.grp_server.ResumeLayout(false);
            this.grp_server.PerformLayout();
            this.grp_resolution.ResumeLayout(false);
            this.grp_resolution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_launch;
        private System.Windows.Forms.Label lbl_disclaimer;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grp_language;
        private System.Windows.Forms.GroupBox grp_server;
        private System.Windows.Forms.Label label_srv;
        private System.Windows.Forms.Label lbl_server_tips;
        private System.Windows.Forms.Label lbl_language_tips;
        private System.Windows.Forms.GroupBox grp_resolution;
        private System.Windows.Forms.RadioButton rdo_res_100;
        private System.Windows.Forms.RadioButton rdo_res_75;
        private System.Windows.Forms.RadioButton rdo_res_50;
        private System.Windows.Forms.CheckBox chk_drawfps;
        private System.Windows.Forms.RadioButton rdo_cdn_siliconvalley_en;
        private System.Windows.Forms.RadioButton rdo_cdn_hongkong_en;
        private System.Windows.Forms.RadioButton rdo_cdn_frankfurt_en;
        private System.Windows.Forms.RadioButton rdo_cdn_none;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RadioButton rdo_cdn_frankfurt_ru;
        private System.Windows.Forms.RadioButton rdo_cdn_siliconvalley_es;
        private System.Windows.Forms.CheckBox chk_locale;
    }
}

