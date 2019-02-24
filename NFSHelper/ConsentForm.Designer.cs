namespace NFSHelper
{
    partial class ConsentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsentForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_agree = new System.Windows.Forms.Button();
            this.btn_disagree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // btn_agree
            // 
            resources.ApplyResources(this.btn_agree, "btn_agree");
            this.btn_agree.Name = "btn_agree";
            this.btn_agree.UseVisualStyleBackColor = true;
            this.btn_agree.Click += new System.EventHandler(this.btn_agree_Click);
            // 
            // btn_disagree
            // 
            resources.ApplyResources(this.btn_disagree, "btn_disagree");
            this.btn_disagree.Name = "btn_disagree";
            this.btn_disagree.UseVisualStyleBackColor = true;
            this.btn_disagree.Click += new System.EventHandler(this.btn_disagree_Click);
            // 
            // ConsentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_disagree);
            this.Controls.Add(this.btn_agree);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsentForm";
            this.Load += new System.EventHandler(this.ConsentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_agree;
        private System.Windows.Forms.Button btn_disagree;
    }
}