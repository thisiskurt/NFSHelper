using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/*
 * Check the LangTest in Program.cs
 * Check nfs_url_host in Form1.cs
 * Check ver in Form1.cs
 * Compile
 * Check and modify the config file
 * Test
 * Obfuscate if needed
 * Release
*/

namespace NFSHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string param = string.Empty;
            param = string.Join(" ", args);

            // auto choose locale
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            string locale = string.Join("", System.Threading.Thread.CurrentThread.CurrentUICulture);

            // in case of no param (not launched normally)

            /*string guide_ko = "사용방법:\n\n"+
                "1. 중국 니드포스피드 엣지가 설치되어 있는 경로를 찾습니다.\n"+
                "2. NFSOL.exe을 찾고 NFSOL2.exe로 이름을 변경합니다.\n"+
                "3. 압축해제한 파일중 NFSOL.exe, ko파일과 NFSOL.exe.config를 복사후 중국 엣지가 설치되어있는곳에 넣고,파일의.\n"+
                "4. 이제 로그인후 게임을 실행시켜주게되면 헬퍼파일이 실행이됩니다.실행이된 헬퍼에서 한국어를 선택후 게임실행 버튼을 눌러주시면 완료됩니다.\n\n" +
                "PS: 이작업은 게임이 업데이트 될때마다 반복해주어야합니다.";*/

            string guide_en = "If you are seeing this, something went wrong\n"+
                "\nRead the guide below to learn more\n\n"+
                "How To Use:\n\n"+
                "1. Locate NFSOL.exe in root directory of EDGE, rename it to NFSOL2.exe\n"+
                "2. Copy and paste this program and other file(s) to the same folder\n"+
                "3. Log in the game as usual. DO NOT double-click and launch this program.\n"+
                "4. Whenever the game gets updated, you must manually" +
                "\n   delete NFSOL2.exe"+
                "\n   AND repeat all the steps above.";

            bool LangTest = true; // don't touch this. only change the bool value from below.
            LangTest = true;

            if (LangTest == false & param == "") // unintended launch by user
            {
                if (locale == "ko-KR")
                { System.Diagnostics.Process.Start("http://www.needforspeedonline.com/download_kormod.html"); }
                
                else // English or whatever
                { 
                    MessageBox.Show(guide_en,"Incorrect Launch Attempt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //System.Diagnostics.Process.Start("http://www.needforspeedonline.com/download.html");
                }
                
                System.Environment.Exit(0);
            }

            if (LangTest == true & param == "") // dev testing
            {
                // check and set Consent value
                if (File.Exists(@System.AppDomain.CurrentDomain.FriendlyName + ".config"))
                {
                    Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (config.AppSettings.Settings["Consent"] != null)
                    {
                        string cfg_Consent = config.AppSettings.Settings["Consent"].Value;
                        if (cfg_Consent != "true")
                        { Application.Run(new ConsentForm(args)); }
                    }
                    else { Application.Run(new ConsentForm(args)); }
                }
                Application.Run(new LangSwitcher(args));
            }

            if (LangTest == true & param != "") // meant to be dev testing but used as in Live environment
            {
                MessageBox.Show("Check LangTest variable! This must not be released!", "LangTest is true", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (LangTest == false & param != "") // normal launch or user messing up. i am too lazy for writing try catch.
            {
                // check and set Consent value
                if (File.Exists(@System.AppDomain.CurrentDomain.FriendlyName + ".config"))
                {
                    Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (config.AppSettings.Settings["Consent"] != null)
                    {
                        string cfg_Consent = config.AppSettings.Settings["Consent"].Value;
                        if (cfg_Consent != "true")
                        { Application.Run(new ConsentForm(args)); }
                    }
                    else { Application.Run(new ConsentForm(args)); }
                }
                // now we run Form1, let itself determine whether to continue.
                Application.Run(new Form1(args));
            }

        }
    }
}
