using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFSHelper
{
    public partial class About : Form
    {
        public string ver = ""; // ver defined in btn_about_Click in Form1.cs
        string locale = string.Empty;
        public About()
        {
            InitializeComponent();

            // regarding locale
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            locale = string.Join("", System.Threading.Thread.CurrentThread.CurrentUICulture);

            // decide what the button shows
            if (locale == "ko-KR")
            {
                button1.Text = "엣지 톡방에서 함께하세요"; // kakaotalk
                button2.Text = "엣지 카페에서 함께하세요"; // cafe
                label_author.Text = "by Knightmare";
                label_title.Text = "NFSHelper";
                label_title2.Text = "(Need For Speed ONLINE 지원 프로그램)";
                btn_update.Text = "업데이트 확인";
            }
            else
            {
                if (locale == "pl-PL")
                {
                    button1.Text = "Dołącz do nas"; // Discord
                    button2.Text = "Oficjalna strona NFSOL"; // nfsol.qq.com
                    btn_update.Text = "Aktualizuj";
                    richTextBox1.Text =" - Każda uwolniona wersja NFSHelper jest / była przeznaczona dla klienta gry EDGE w określonym czasie. Starsze wersje NFSHelper mogą nie działać już dla przyszłego klienta. Proszę zawsze pobrać i używać najnowszej wersji z naszego serwera Discord.";
                }
                else
                {
                    button1.Text = "Join us on Discord!"; // Discord
                    button2.Text = "NFSOL official site"; // nfsol.qq.com
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (locale == "ko-KR")
            { System.Diagnostics.Process.Start("https://open.kakao.com/o/g6Necrh"); }
            else
            {
                if (locale == "pl-PL")
                { System.Diagnostics.Process.Start("https://discord.gg/VfnFntA"); }
                else
                { System.Diagnostics.Process.Start("https://discord.gg/RFSUhRh"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (locale == "ko-KR")
            { System.Diagnostics.Process.Start("http://cafe.naver.com/nfsinfo"); }
            else
            { System.Diagnostics.Process.Start("http://needforspeedonline.qq.com/main.shtml"); }
        }

        private void About_Load(object sender, EventArgs e)
        {
            label_ver.Text = ver;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.needforspeedonline.com/download.html");
        }

    }
}
