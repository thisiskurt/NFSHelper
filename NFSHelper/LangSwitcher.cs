using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// this thing is only intended for testing localizations. --add comment slash for code in Program.cs before release-- NOW change LangTest bool value to use.

namespace NFSHelper
{
    public partial class LangSwitcher : Form
    {
        string param = "-super layout.toc -edge -level Levels/EDGE_Lighthouse2/EDGE_Lighthouse2 -Online.ClientIsPresenceEnabled false -RenderDevice.FullscreenOutputIndex 0 -Core.DisplayAsserts false -Core.DisplayScreenAsserts false -Render.DebugRendererEnable true -Core.AssertLimit 1 -apiServer https://set1003.gateway.nfsol.qq.com:443 -cdn http://res.nfsol.qq.com/OB/ -logApiServer http://set1003.clog.nfsol.qq.com:5000 -token 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 -netbar -qqnumber 1234567890 -zoneid 1003 -locale cn -publisher tencent -launcherPId 1337";

        public LangSwitcher(string[] args)
        {
            InitializeComponent();
            //MessageBox.Show("Do not distribute.\n배포하지 마라", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listBox1.SelectedItem = "en-US";
        }

        private void btn_sys_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            string[] args2 = { param };
            Form1 myForm1 = new Form1(args2);
            myForm1.ShowDialog();
        }

        private void LangSwitcher_Load(object sender, EventArgs e)
        {
            // 123
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btn_launch_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(listBox1.SelectedItem.ToString());
            string[] args2 = { param };
            Form1 myForm1 = new Form1(args2);
            myForm1.SetLocale(listBox1.SelectedItem.ToString());
            myForm1.ShowDialog();
        }


    }
}
