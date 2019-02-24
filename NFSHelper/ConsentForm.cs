using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFSHelper
{
    public partial class ConsentForm : Form
    {
        string[] args2 = { };
        public ConsentForm(string[] args)
        {
            string param_temp = string.Join(" ", args);
            string[] args2 = { param_temp };
            InitializeComponent();
        }

        private void btn_disagree_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            //Form1 myForm1 = new Form1(args2);
            if (File.Exists(@System.AppDomain.CurrentDomain.FriendlyName + ".config"))
            {
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["Consent"] != null)
                {
                    config.AppSettings.Settings["Consent"].Value = "true";
                }
                else
                {
                    config.AppSettings.Settings.Add("Consent", "true");
                } 
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            { }
            
            this.Dispose();
        }

        private void ConsentForm_Load(object sender, EventArgs e) {}
    }
}
