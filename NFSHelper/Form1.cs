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
using System.Threading;

namespace NFSHelper
{
    public partial class Form1 : Form
    {
        // define important strings
        string param_in = string.Empty;
        string nfs_url_ref = "?launch=NFSHelper";
        string nfs_url_host = "http://localhost/nfs_dev.html"; // for dev testing;
        //string nfs_url_host = "http://localhost/nfs_beta.html"; // deprecated
        //string nfs_url_host = "http://localhost/nfs_live.html"; // for release only
        string ver = "v108_dev";
        string locale = string.Join("",System.Threading.Thread.CurrentThread.CurrentCulture);
        string qq = "null";
        string qq_b64 = "";
        string zoneid = "null";

        string cfg_Consent = ""; // Terms and Conditions
        string cfg_FPSCounter = ""; // Frostbite built-in frame-rate counter
        string cfg_RenderResolution = ""; // Frostbite built-in resolution scale
        string cfg_AutoLog = ""; // skip the prompt and get directly into the game
        string cfg_CustomCDN = ""; // Change CDN address to custom string regardless of radio selection
        string cfg_Locale = ""; // Game language, en/ko/cn, associated with publisher
        string cfg_Publisher = ""; // Game publisher. tencent/nexon
        string cfg_SysLocale = ""; // Change NFSHelper UI language (if applicable)
        string cfg_ApiServer = ""; // Change game server address with custom string
        string cfg_AppendCommand = ""; // append custom string to command line parameter; needs a space
        string cfg_WriteLog = "";
        string cfg_Duplication = ""; // Duplication check (In case that NFSOL2.exe is another copy of NFSHelper)
        //public int qq_int = 0;
        
        public Form1(string[] args)
        {
            //MessageBox.Show("public Form1. Current locale: " + locale);

            // get param string from nfsollauncher
            string param_temp = string.Join(" ", args);
            SetParam(param_temp);

            // get -qqnumber and -zoneid from the param
            if (param_temp != "")
            {
                SetQQ(Cutter(param_temp,"-qqnumber "," -zoneid"));
                byte[] qq_bytes = Encoding.Default.GetBytes(qq);
                qq_b64 = Convert.ToBase64String(qq_bytes);

                zoneid = Cutter(param_temp,"-zoneid "," -locale");
            }

            // default code
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // zoneid restriction; deprecated
            // ------------------------zoneid restriction starts------------------------
            /*if (zoneid != "7005")
            { MessageBox.Show("This version of NFSHelper is experimental. Please update as soon as there's new version!"); 
            this.Dispose();
            this.Close();
            System.Environment.Exit(0);
            }*/
            // ------------------------zoneid restriction ends------------------------

            // check Consent and other config values

            if (File.Exists(@System.AppDomain.CurrentDomain.FriendlyName + ".config"))
            {
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Set or add all config entries (in case that any entry is missing)

                if (config.AppSettings.Settings["Consent"] != null)
                { cfg_Consent = config.AppSettings.Settings["Consent"].Value; }
                else { cfg_Consent = "null"; } // Does this really happen at all...?

                if (config.AppSettings.Settings["FPSCounter"] != null)
                { cfg_FPSCounter = config.AppSettings.Settings["FPSCounter"].Value; }
                else { cfg_FPSCounter = ""; }

                if (config.AppSettings.Settings["RenderResolution"] != null)
                { cfg_RenderResolution = config.AppSettings.Settings["RenderResolution"].Value; }
                else { cfg_RenderResolution = ""; }

                if (config.AppSettings.Settings["AutoLog"] != null)
                { cfg_AutoLog = config.AppSettings.Settings["AutoLog"].Value; }
                else { cfg_AutoLog = ""; }

                if (config.AppSettings.Settings["CustomCDN"] != null)
                { cfg_CustomCDN = config.AppSettings.Settings["CustomCDN"].Value; }
                else { cfg_CustomCDN = ""; }

                if (config.AppSettings.Settings["Locale"] != null)
                { cfg_Locale = config.AppSettings.Settings["Locale"].Value; }
                else { cfg_Locale = ""; }

                if (config.AppSettings.Settings["SysLocale"] != null)
                { cfg_SysLocale = config.AppSettings.Settings["SysLocale"].Value; }
                else { cfg_SysLocale = ""; }

                if (config.AppSettings.Settings["Publisher"] != null)
                { cfg_Publisher = config.AppSettings.Settings["Publisher"].Value; }
                else { cfg_Publisher = ""; }

                if (config.AppSettings.Settings["ApiServer"] != null)
                { cfg_ApiServer = config.AppSettings.Settings["ApiServer"].Value; }
                else { cfg_ApiServer = ""; }

                if (config.AppSettings.Settings["AppendCommand"] != null)
                { cfg_AppendCommand = config.AppSettings.Settings["AppendCommand"].Value; }
                else { cfg_AppendCommand = ""; }

                if (config.AppSettings.Settings["WriteLog"] != null)
                { cfg_WriteLog = config.AppSettings.Settings["WriteLog"].Value; }
                else { cfg_WriteLog = ""; }

                if (config.AppSettings.Settings["Duplication"] != null)
                { cfg_Duplication = config.AppSettings.Settings["Duplication"].Value; }
                else { cfg_Duplication = ""; }
            }
            else 
            {
                cfg_Consent = "null";
                cfg_FPSCounter = "";
                cfg_RenderResolution = "";
                cfg_AutoLog = "";
                cfg_CustomCDN = "";
                cfg_Locale = "";
                cfg_Publisher = "";
                cfg_SysLocale = "";
                cfg_ApiServer = "";
                cfg_AppendCommand = "";
                cfg_WriteLog = "";
                cfg_Duplication = "";
            }
            
            // checking config

            if (cfg_Duplication != "")
            { 
                MessageBox.Show("This seems like a duplicated copy of NFSHelper you are launching."
                    +"\n\nYou may have mistakenly renamed NFSHelper as your NFSOL2.exe"
                    +"-- which will result in an infinite loop while attempting to launch EDGE."
                    +"\n\nYour default browser will open soon after you close NFSHelper;"
                    +"\nPlease check #questions channel in our Discord server for further help."
                    +"\n\nAborting now...","Duplicated Instance",MessageBoxButtons.OK,MessageBoxIcon.Error);
                System.Diagnostics.Process.Start("https://discord.gg/RFSUhRh");
                Environment.Exit(0);
            }

            if (cfg_SysLocale != "")
            { locale = cfg_SysLocale; }

            if (cfg_Consent == "null")
            {
                string temp_warning = "- NFSHelper is free for your personal and non-commercial use.\n" +
                    "- Knightmare is not affiliated or endorsed by Electronic Arts, Spearhead, Tencent or Nexon.\n" +
                    "- You may not modify, reverse engineer, create derivative works from, or sell any information, software, products or services obtained from NFSHelper.\n" +
                    "- Knightmare is not responsible for any and all problems, consequences and losses related to your use of NFSHelper.\n" +
                    "- Knigtmare may collect usage information  (program version number, UID, etc) for nonprofit purposes including but not limited to statistics and maintenance.";
                MessageBox.Show(temp_warning, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cfg_Consent != "true")
                { System.Environment.Exit(0); }
            }

            // ------------------------DateTime surprises start------------------------

            DateTime dateTime = DateTime.UtcNow.Date;
            //MessageBox.Show(dateTime.ToString("dd/MM"));

            // April Fools' Day prank

            if (dateTime.ToString("dd/MM") == "01/04")
            { MessageBox.Show("Your trial of NFSHelper has expired!"
                +"\n\nIn order to continue using NFSHelper, please"
                +"\npurchase a license key for $49.99\n\n\n\n(Happy April Fools Day!)","Trial Expired (oh no!)", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            // ------------------------DateTime surprises end------------------------

            // initialize selections

            if (cfg_FPSCounter == "true")
            { chk_drawfps.Checked = true; }

            switch (cfg_RenderResolution)// Just leave the choice to the user
            {
                default: rdo_res_100.Checked = true; break; // nothing happens
                case "75": rdo_res_75.Checked = true; break;
                case "50": rdo_res_50.Checked = true; break;
            }

            // change title texts
            this.Text += " " + ver + " " + locale;

            rdo_cdn_none.Checked = true;

            if (zoneid != "null") { Localization_Reset(); Localization_Refresh(); Localization_Apply(); }// change localization

            else /* param is empty.*/ {label_srv.Text = "(Server Name)"; /* 16 letters at max*/ }

            // collect user statistics
            /*
            nfs_url_ref += "&ver=" + ver + "&lang=" + locale + "&zoneid=" + zoneid + "&uid=" + qq_b64;
            webBrowser1.Navigate(nfs_url_host + nfs_url_ref);
            */

            if (cfg_AutoLog == "true")
            { btn_launch_Click(btn_launch,null); }

        }

        // Helper Fuctions

        public void Duplication_Check()
        { 
            // What the hell is this supposed to do? I don't remember why I had this at all...
        }

        public void SetQQ(string param)
        {
            qq = param;
            //qq_int = int.Parse(param);
        }

        public void SetLocale(string desigLocale) // I don't remember what is this for.
        {
            locale = desigLocale;
        }

        public void SetParam(string param)
        {
            param_in = param;
        }

        public string GetParam()
        {
            return param_in;
        }

        public string Cutter(string param,string a,string b) // should have used s.Substring(start,length) instead?
            {
                int LenofA = a.Length;
                int IndexofA = param.IndexOf(a);
                int IndexofB = param.IndexOf(b);
                return (param.Substring(IndexofA + LenofA, IndexofB - IndexofA - LenofA));
            }

        // buttons

        private void btn_about_Click(object sender, EventArgs e)
        {
            About myAbout = new About();
            myAbout.ver = ver;
            myAbout.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // nothing here...
        }

        // finalizing stuff when LAUNCH button is pressed
        private void btn_launch_Click(object sender, EventArgs e)
        {
            string NFSOL_exe = "NFSOL2.exe";
            //string NFSEDGE_exe = "NFSEdge2.exe"; // deprecated
            string Execute_exe = "";
            string param_out = GetParam();
            string CDN = Cutter(param_out, "-cdn ", " -logApiServer");
            System.Diagnostics.Process ps = new System.Diagnostics.Process();

            // game exe existence check
            if (File.Exists(@NFSOL_exe) != true)
            {
                if (locale == "ko-KR")
                { MessageBox.Show("누락 된 파일 !"); }
                else if (locale == "pl-PL")
                { MessageBox.Show("Brakujący plik!" + "!\nProszę skonfigurować klienta gry zgodnie z instrukcjami!\n\nWyjdź teraz ..."); }
                else
                { MessageBox.Show("Missing game exe!" + "!\nPlease configure the game client as instructed!\n\nAbort Now...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Dispose();
                this.Close();
                System.Environment.Exit(0);
            }
            else
            // Chinese client.
            { Execute_exe = NFSOL_exe; }

            if (cfg_Locale != "")
            { 
                string temp_locale = ("-locale " + cfg_Locale);
                param_out = param_out.Replace("-locale cn", temp_locale); 
            }

            if (cfg_Publisher!= "")
            {
                string tgt_publisher = ("-publisher " + cfg_Publisher);
                param_out = param_out.Replace("-publisher tencent", tgt_publisher); 
            }

            if (cfg_CustomCDN == "")
            {
                string tgt_locale = "";

                // l10n server and custom locale info (first 2 chars of culture code)
                if (rdo_cdn_none.Checked == true)
                { }
                else if (rdo_cdn_frankfurt_en.Checked == true)
                { param_out = param_out.Replace(CDN, "http://nfshelper-ff.localhost/OB/"); tgt_locale = "en"; }
                else if (rdo_cdn_hongkong_en.Checked == true)
                { param_out = param_out.Replace(CDN, "http://nfshelper-hk.localhost/OB/"); tgt_locale = "en"; }
                else if (rdo_cdn_siliconvalley_en.Checked == true)
                { param_out = param_out.Replace(CDN, "http://nfshelper-sv.localhost/OB/"); tgt_locale = "en"; }
                /*
                else if (rdo_cdn_frankfurt_ru.Checked == true)
                { param_out = param_out.Replace(CDN, "http://nfshelper-ff-ru.localhost/OB/"); tgt_locale = "ru"; }
                else if (rdo_cdn_siliconvalley_es.Checked == true)
                { param_out = param_out.Replace(CDN, "http://nfshelper-sv-es.localhost/OB/"); tgt_locale = "es"; }
                */

                if ((cfg_Locale == "") && (cfg_Publisher == "") && (chk_locale.Checked == true) && (tgt_locale != ""))
                {
                    if (param_out.Contains("-publisher tencent"))
                    { param_out = param_out.Replace("-publisher tencent", "-publisher nexon"); }
                    else
                    { param_out += " -publisher nexon"; }

                    if (param_out.Contains("-locale cn"))
                    { param_out = param_out.Replace("-locale cn", "-locale " + tgt_locale); }
                    else
                    { param_out += " -locale " + tgt_locale; }
                }
            }
            else { param_out = param_out.Replace(CDN, cfg_CustomCDN); }

            // Render Resolution
            if (rdo_res_50.Checked == true)
            { param_out += " -Render.ResolutionScale 0.5"; }
            else if (rdo_res_75.Checked == true)
            { param_out += " -Render.ResolutionScale 0.75"; }

            // fps indicator
            if (chk_drawfps.Checked == true)
            { param_out += " -PerfOverlay.DrawFPS 1"; }

            // change zoneid
            if (cfg_ApiServer != "")
            { param_out = param_out.Replace(zoneid, cfg_ApiServer); }

            // append extra command
            if (cfg_AppendCommand != "")
            { param_out += cfg_AppendCommand; }

            // DON'T DO THIS. It messes with the game. v104 crashes game because of this.
            /*
            duplication check solution candidate (eg: when NFSOL2.exe is another copy of NFSHelper)
            param_out += " -NFSHelper_"+ver; // Modified Execution Code
            */

            // launch nfsol2.exe
            ps.StartInfo.FileName = Execute_exe;
            ps.StartInfo.Arguments = param_out;
            ps.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (this.WindowState != FormWindowState.Minimized)
            { this.WindowState = FormWindowState.Minimized; }

            if (cfg_WriteLog == "true")
            {
                StreamWriter sw = new StreamWriter("NFSHelper_Log", true);
                sw.WriteLine(DateTime.Now.ToString("yyyyMMddhhmmss"));
                sw.WriteLine(Convert.ToBase64String(Encoding.Default.GetBytes(param_out)));
                sw.Close();
            }

            ps.Start();
            notifyIcon1.ShowBalloonTip(1000, "EDGE Launched", l10n.game_launched_desc, ToolTipIcon.Info);

            ps.WaitForExit();
            notifyIcon1.ShowBalloonTip(1000, "EDGE Ended", l10n.game_ended_desc, ToolTipIcon.Info);
            this.Dispose();
            this.Close();
            //Application.ExitThread();
            System.Environment.Exit(0);
        }
        
        // New Localization Implementation

        private void Localization_Reset()
        {
            l10n.desc_btn_about = "&About";
            l10n.desc_btn_launch = "&Launch";
            l10n.desc_chk_drawfps = "FPS Counter";
            l10n.desc_grp_language = "Language";
            l10n.desc_grp_server = "Game Server";
            l10n.desc_grp_resolution = "Render Resolution";
            l10n.desc_lbl_server_tips = "You will log onto:";
            l10n.desc_lbl_language_tips = "Select the region closest to you";
            l10n.desc_chk_locale = "Force enable Non-English Characters";
            l10n.desc_rdo_cdn_none = "Chinese - Asia";
            l10n.desc_rdo_frankfurt = "English - Europe";
            l10n.desc_rdo_cdn_siliconvalley_en = "English - Americas";
            l10n.desc_rdo_cdn_hongkong_en = "English - Asia";
            l10n.desc_rdo_res_100 = "Normal";
            l10n.desc_rdo_res_75 = "Low";
            l10n.desc_rdo_res_50 = "Very Low";
        }

        private void Localization_Apply()
        {
            //this.Text = "NFSKorMod"; // title. only korean user will see a different title. so don't change it.
            btn_about.Text = l10n.desc_btn_about;
            btn_launch.Text = l10n.desc_btn_launch;
            chk_drawfps.Text = l10n.desc_chk_drawfps;
            grp_language.Text = l10n.desc_grp_language;
            grp_server.Text = l10n.desc_grp_server;
            grp_resolution.Text = l10n.desc_grp_resolution;
            lbl_server_tips.Text = l10n.desc_lbl_server_tips;
            chk_locale.Text = l10n.desc_chk_locale;
            lbl_language_tips.Text = l10n.desc_lbl_language_tips;
            rdo_cdn_none.Text = l10n.desc_rdo_cdn_none;
            rdo_cdn_frankfurt_en.Text = l10n.desc_rdo_frankfurt;
            rdo_cdn_siliconvalley_en.Text = l10n.desc_rdo_cdn_siliconvalley_en;
            rdo_cdn_hongkong_en.Text = l10n.desc_rdo_cdn_hongkong_en;
            rdo_res_100.Text = l10n.desc_rdo_res_100;
            rdo_res_75.Text = l10n.desc_rdo_res_75;
            rdo_res_50.Text = l10n.desc_rdo_res_50;
        }

        private void Localization_Refresh()
        {
            if (locale == "ko-KR")
            {
                //this.Text = "NFSKorMod"; // title. only korean user will see a different title. so don't change it.
                l10n.desc_btn_about = "제품 정보";
                l10n.desc_btn_launch = "게임 실행";
                l10n.desc_chk_drawfps = "프레임 보이기";
                l10n.desc_grp_language = "게임 언어";
                l10n.desc_grp_server = "게임 서버";
                l10n.desc_grp_resolution = "게임 렌더링 해상도";
                l10n.desc_lbl_server_tips = "선택한 서버의 이름";
                l10n.desc_chk_locale = "영어 이외의 문자 강제 사용";
                l10n.desc_lbl_language_tips = "https://goo.gl/s4RG8E";
                l10n.desc_rdo_cdn_none = "중국어 간체";
                l10n.desc_rdo_frankfurt = "영어 - 중부 유럽";
                l10n.desc_rdo_cdn_siliconvalley_en = "영어 - 미국 서부";
                l10n.desc_rdo_cdn_hongkong_en = "영어 - 홍콩";
                l10n.desc_rdo_res_100 = "정상";
                l10n.desc_rdo_res_75 = "낮은";
                l10n.desc_rdo_res_50 = "매우 낮은";

                switch (zoneid)
                {
                    default: label_srv.Text = "(알 수 없는)"; break;
                    case "1001": label_srv.Text = "자유로"; break;
                    case "1002": label_srv.Text = "알피노"; break;
                    case "1003": label_srv.Text = "붉은 협곡"; break;
                    case "1004": label_srv.Text = "물안개호수"; break;
                    case "1005": label_srv.Text = "눈바람 내리막길"; break;
                    case "8006": label_srv.Text = "대회서버"; break;
                }
            }
            else // English and other languages
            {
                switch (zoneid) // All English
                {
                    default: label_srv.Text = "(Unknown)"; break;
                    case "1001": label_srv.Text = "Freeway"; break;
                    case "1002": label_srv.Text = "Alpine"; break;
                    case "1003": label_srv.Text = "Crimson Canyon"; break;
                    case "1004": label_srv.Text = "Fogged Lake"; break;
                    case "1005": label_srv.Text = "Snow Valley"; break;
                    case "8006": label_srv.Text = "Contest Server"; break;
                }

                if (locale.Contains("de-")) // German
                {
                    l10n.desc_btn_about = "Über";
                    l10n.desc_btn_launch = "Start";
                    l10n.desc_chk_drawfps = "FPS Anzeige";
                    l10n.desc_grp_language = "Sprache";
                    l10n.desc_grp_server = "Spieleserver";
                    l10n.desc_grp_resolution = "Renderauflösung";
                    l10n.desc_lbl_server_tips = "Name";
                    l10n.desc_rdo_frankfurt = "Englisch - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Englisch - Amerika";
                    l10n.desc_rdo_cdn_hongkong_en = "Englisch - Asien";
                    l10n.desc_lbl_language_tips = "Wählen Sie die nächstgelegene Region";
                    l10n.desc_rdo_cdn_none = "Chinesisch - Asien";
                    l10n.desc_rdo_res_100 = "Hoch";
                    l10n.desc_rdo_res_75 = "Mittel";
                    l10n.desc_rdo_res_50 = "Niedrig";
                    // Kurt
                }

                if (locale.Contains("es-")) // Spanish (Chile or more)
                {
                    l10n.desc_btn_about = "Dev Info";
                    l10n.desc_btn_launch = "Iniciar";
                    l10n.desc_chk_drawfps = "Ver FPS";
                    l10n.desc_grp_language = "Idioma";
                    l10n.desc_grp_server = "Servidor del juego";
                    l10n.desc_grp_resolution = "Resolución";
                    l10n.desc_lbl_server_tips = "Iniciarás sesión en:";
                    l10n.desc_chk_locale = "Fuerza habilita caracteres no ingleses";
                    l10n.desc_rdo_frankfurt = "Inglés - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Inglés - América";
                    l10n.desc_rdo_cdn_hongkong_en = "Inglés - Asia";
                    l10n.desc_lbl_language_tips = "Selecciona la región más cercana a ti";
                    l10n.desc_rdo_cdn_none = "Chino - Asia";
                    l10n.desc_rdo_res_100 = "Normal";
                    l10n.desc_rdo_res_75 = "Bajo";
                    l10n.desc_rdo_res_50 = "Muy bajo";
                    // X1PROCL - Discord Comunidad (as the contributor of this localization, optional)
                }

                if (locale == "fr-FR") // French
                {
                    l10n.desc_btn_about = "À propos";
                    l10n.desc_btn_launch = "Lancer";
                    l10n.desc_chk_drawfps = "Afficher les FPS";
                    l10n.desc_grp_language = "Langue";
                    l10n.desc_grp_server = "Serveur";
                    l10n.desc_grp_resolution = "Résolution";
                    l10n.desc_lbl_server_tips = "Vous avez choisi:";
                    l10n.desc_chk_locale = "Forcer activer les caractères non anglais";
                    l10n.desc_rdo_frankfurt = "Anglais - Europe";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Anglais - Etats-Unis";
                    l10n.desc_rdo_cdn_hongkong_en = "Anglais - Asie";
                    l10n.desc_lbl_language_tips = "Sélectionnez la région la plus proche";
                    l10n.desc_rdo_cdn_none = "Chinois - Asie";
                    l10n.desc_rdo_res_100 = "Normal";
                    l10n.desc_rdo_res_75 = "Faible";
                    l10n.desc_rdo_res_50 = "Très Faible";
                    // Eymiks
                }
                if (locale == "lv-LV") // Latvian
                {
                    l10n.desc_btn_about = "Par Programmu";
                    l10n.desc_btn_launch = "Startet";
                    l10n.desc_chk_drawfps = "FPS Raditajs";
                    l10n.desc_grp_language = "Valoda";
                    l10n.desc_grp_server = "Speles Serveris";
                    l10n.desc_grp_resolution = "Render Rezolucija";
                    l10n.desc_lbl_server_tips = "Ielogosies serveri:";
                    l10n.desc_rdo_frankfurt = "Anglu - Eiropa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Anglu - ASV";
                    l10n.desc_rdo_cdn_hongkong_en = "Anglu - Azija";
                    l10n.desc_lbl_language_tips = "Izveleties Sev vis tuvaku regionu";
                    l10n.desc_rdo_cdn_none = "Ķīniešu - Azija";
                    l10n.desc_rdo_res_100 = "Normals";
                    l10n.desc_rdo_res_75 = "Zems";
                    l10n.desc_rdo_res_50 = "Viss zemakais";
                    // Eternal_god
                }
                if (locale == "pl-PL") // Polish
                {
                    l10n.desc_btn_about = "Informacje";
                    l10n.desc_btn_launch = "Rozpocznij";
                    l10n.desc_chk_drawfps = "Licznik FPS";
                    l10n.desc_grp_language = "Serwer translacji";
                    l10n.desc_grp_server = "Serwer gier";
                    l10n.desc_grp_resolution = "Rozdzielczość renderowania";
                    l10n.desc_lbl_server_tips = "Wybrałeś";
                    l10n.desc_rdo_frankfurt = "Angielskie - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Angielskie - Ameryka";
                    l10n.desc_rdo_cdn_hongkong_en = "Angielskie - Azja";
                    l10n.desc_lbl_language_tips = "Wybierz region najbliżej Ciebie";
                    l10n.desc_rdo_cdn_none = "Urzędnik";
                    l10n.desc_rdo_res_100 = "Normalna";
                    l10n.desc_rdo_res_75 = "Niska";
                    l10n.desc_rdo_res_50 = "Bardzo niska";
                    // Google Translate
                }
                if (locale == "pt-BR")
                {
                    l10n.desc_btn_about = "Sobre";
                    l10n.desc_btn_launch = "Iniciar";
                    l10n.desc_chk_drawfps = "Contador de FPS";
                    l10n.desc_grp_language = "Linguagem";
                    l10n.desc_grp_server = "Servidor de Jogo";
                    l10n.desc_grp_resolution = "Resolução de Renderização";
                    l10n.desc_lbl_server_tips = "Você vai logar em:";
                    l10n.desc_rdo_frankfurt = "Inglês - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Inglês - Americas";
                    l10n.desc_rdo_cdn_hongkong_en = "Inglês - Asia";
                    l10n.desc_lbl_language_tips = "Selecione a região mais próxima de você";
                    l10n.desc_rdo_cdn_none = "Chinês - Asia";
                    l10n.desc_rdo_res_100 = "Normal";
                    l10n.desc_rdo_res_75 = "Low";
                    l10n.desc_rdo_res_50 = "Very Low";
                    // meganinj4
                }
                if (locale == "pt-PT") // Portuguese - Portugal
                {
                    l10n.desc_btn_about = "Sobre";
                    l10n.desc_btn_launch = "Iniciar";
                    l10n.desc_chk_drawfps = "Mostrar FPS";
                    l10n.desc_grp_language = "Linguagem";
                    l10n.desc_grp_server = "Servidor do jogo";
                    l10n.desc_grp_resolution = "Resolução de Renderização";
                    l10n.desc_lbl_server_tips = "Vais entrar em:";
                    l10n.desc_rdo_frankfurt = "Inglês - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Inglês - America";
                    l10n.desc_rdo_cdn_hongkong_en = "Inglês - Asia";
                    l10n.desc_lbl_language_tips = "Seleciona a região mais próxima";
                    l10n.desc_rdo_cdn_none = "Chinês - Asia";
                    l10n.desc_rdo_res_100 = "Normal";
                    l10n.desc_rdo_res_75 = "Baixo";
                    l10n.desc_rdo_res_50 = "Muito Baixo";
                    lbl_disclaimer.Text = "Knightmare não está relacionada nem ligada de\n qualquer forma com a Electronic Arts ou Tencent";
                    // vItas
                }
                if (locale == "ro-RO") // Romanian
                {
                    l10n.desc_btn_about = "Despre";
                    l10n.desc_btn_launch = "Porneste";
                    l10n.desc_chk_drawfps = "FPS";
                    l10n.desc_grp_language = "Limba";
                    l10n.desc_grp_server = "Serverul Jocului";
                    l10n.desc_grp_resolution = "Rezolutia";
                    l10n.desc_lbl_server_tips = "Te vei loga pe:";
                    l10n.desc_rdo_frankfurt = "Engleza - Europa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Engleza - America";
                    l10n.desc_rdo_cdn_hongkong_en = "Engleza - Asia";
                    l10n.desc_lbl_language_tips = "Alege regiunea apropiata de tine";
                    l10n.desc_rdo_cdn_none = "Chineza - Asia";
                    l10n.desc_rdo_res_100 = "Normala";
                    l10n.desc_rdo_res_75 = "Joasa";
                    l10n.desc_rdo_res_50 = "Minim";
                    // (Obey) 𝕷𝖆𝖚𝖗𝖊𝖓𝖙𝖟𝖎𝖚#7582
                }
                if (locale.Contains("ru-")) // Russian(s?)
                {
                    l10n.desc_btn_about = "Инфо";
                    l10n.desc_btn_launch = "Запуск";
                    l10n.desc_chk_drawfps = "Счетчик ФПС";
                    l10n.desc_grp_language = "Язык";
                    l10n.desc_grp_server = "Игровой сервер";
                    l10n.desc_grp_resolution = "Разрешение текстур";
                    l10n.desc_lbl_server_tips = "Выбранный сервер:";
                    l10n.desc_chk_locale = "использовать компактный шрифт";
                    l10n.desc_rdo_frankfurt = "Английский-Европа";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Англ-Америка";
                    l10n.desc_rdo_cdn_hongkong_en = "Англ-Азия";
                    l10n.desc_lbl_language_tips = "Выберите ближайший к вам регион";
                    l10n.desc_rdo_cdn_none = "Китайский-Азия";
                    l10n.desc_rdo_res_100 = "Обычное";
                    l10n.desc_rdo_res_75 = "Низкое";
                    l10n.desc_rdo_res_50 = "Оч. низкое";
                    // Ларрза
                }
                if (locale == "th-TH")
                {
                    l10n.desc_btn_about = "ยกเลิก";
                    l10n.desc_btn_launch = "เริ่ม";
                    l10n.desc_chk_drawfps = "เปิดดู FPS";
                    l10n.desc_grp_language = "ภาษา";
                    l10n.desc_grp_server = "เซิฟเวอร์เกม";
                    l10n.desc_grp_resolution = "การประมวลผลของภาพ";
                    l10n.desc_lbl_server_tips = "คุณกำลังจะเข้าร่วมใน:";
                    l10n.desc_rdo_frankfurt = "อังกฤษ - ยุโรป";
                    l10n.desc_rdo_cdn_siliconvalley_en = "อังกฤษ - อเมริกา";
                    l10n.desc_rdo_cdn_hongkong_en = "อังกฤษ - เอเชีย";
                    l10n.desc_lbl_language_tips = "เลือกภูมิภาคที่อยู่ใกล้กับคุณมากที่สุด";
                    l10n.desc_rdo_cdn_none = "จีน - เอเชีย";
                    l10n.desc_rdo_res_100 = "ธรรมดา";
                    l10n.desc_rdo_res_75 = "ต่ำ";
                    l10n.desc_rdo_res_50 = "ต่ำมาก";
                    // Chicpizz209
                }
                if (locale == "tr-TR") // Turkish
                {
                    l10n.desc_btn_about = "Hakkinda";
                    l10n.desc_btn_launch = "Baslat";
                    l10n.desc_chk_drawfps = "FPS Sayaci";
                    l10n.desc_grp_language = "Dil";
                    l10n.desc_grp_server = "Oyun Sunucusu";
                    l10n.desc_grp_resolution = "Render Cozunurlugu";
                    l10n.desc_lbl_server_tips = "Buraya baglan:";
                    l10n.desc_rdo_frankfurt = "Ingilizce - Avrupa";
                    l10n.desc_rdo_cdn_siliconvalley_en = "Ingilizce - Amerika";
                    l10n.desc_rdo_cdn_hongkong_en = "Ingilizce - Asya";
                    l10n.desc_lbl_language_tips = "Size en yakin bolgeyi secin";
                    l10n.desc_rdo_cdn_none = "Cince - Asya";
                    l10n.desc_rdo_res_100 = "Normal";
                    l10n.desc_rdo_res_75 = "Dusuk";
                    l10n.desc_rdo_res_50 = "Cok Dusuk";
                    // Derd
                }
                if ((locale == "zh-CN") || (locale == "zh-SG")) // Simplefied Chinese
                {
                    l10n.desc_btn_about = "关于";
                    l10n.desc_btn_launch = "启动";
                    l10n.desc_chk_drawfps = "显示帧数";
                    l10n.desc_grp_language = "语言";
                    l10n.desc_grp_server = "游戏服务器";
                    l10n.desc_grp_resolution = "渲染分辨率";
                    l10n.desc_lbl_server_tips = "你将登录到:";
                    l10n.desc_rdo_frankfurt = "英文 - 欧洲节点";
                    l10n.desc_rdo_cdn_siliconvalley_en = "英文 - 美洲节点";
                    l10n.desc_rdo_cdn_hongkong_en = "英文 - 亚洲节点";
                    l10n.desc_lbl_language_tips = "选择距离你最近的节点";
                    l10n.desc_rdo_cdn_none = "中文 - 内地";
                    l10n.desc_rdo_res_100 = "正常";
                    l10n.desc_rdo_res_75 = "低";
                    l10n.desc_rdo_res_50 = "非常低";
                    // Kurt
                    switch (zoneid) // All English
                    {
                        default: label_srv.Text = "(未知)"; break;
                        case "1001": label_srv.Text = "自由之路"; break;
                        case "1002": label_srv.Text = "阿尔匹诺"; break;
                        case "1003": label_srv.Text = "绯红峡谷"; break;
                        case "1004": label_srv.Text = "迷雾湖畔"; break;
                        case "1005": label_srv.Text = "风雪山谷"; break;
                        case "8006": label_srv.Text = "车神比赛服"; break;
                    }
                }
                if ((locale != "zh-CN") && (locale != "zh-SG") && (locale.Contains("zh") == true)) // Traditional Chinese
                {
                    l10n.desc_btn_about = "關於";
                    l10n.desc_btn_launch = "啟動";
                    l10n.desc_chk_drawfps = "顯示幀數";
                    l10n.desc_grp_language = "語言";
                    l10n.desc_grp_server = "遊戲伺服器";
                    l10n.desc_grp_resolution = "渲染解析度";
                    l10n.desc_lbl_server_tips = "你將登錄到:";
                    l10n.desc_rdo_frankfurt = "英文 - 歐洲";
                    l10n.desc_rdo_cdn_siliconvalley_en = "英文 - 美洲";
                    l10n.desc_rdo_cdn_hongkong_en = "英文 - 亞洲";
                    l10n.desc_lbl_language_tips = "選擇距離最近的語言伺服器";
                    l10n.desc_rdo_cdn_none = "中文 - 內地";
                    l10n.desc_rdo_res_100 = "正常";
                    l10n.desc_rdo_res_75 = "低";
                    l10n.desc_rdo_res_50 = "非常低";
                    // Google Translate
                }
            }
        }
    }

    public partial class l10n
    {
        public static string desc_btn_about = "&About";
        public static string desc_btn_launch = "&Launch";
        public static string desc_chk_drawfps = "FPS &Counter";
        public static string desc_grp_language = "Language";
        public static string desc_grp_server = "Game Server";
        public static string desc_grp_resolution = "Render Resolution";
        public static string desc_lbl_server_tips = "You will log onto:";
        public static string desc_lbl_language_tips = "Select the region closest to you";
        public static string desc_chk_locale = "&Force enable Non-English Characters";
        public static string desc_rdo_cdn_none = "Chinese - Asia";
        public static string desc_rdo_frankfurt = "English - Europe";
        public static string desc_rdo_cdn_siliconvalley_en = "English - Americas";
        public static string desc_rdo_cdn_hongkong_en = "English - Asia";
        public static string desc_rdo_res_100 = "&Normal";
        public static string desc_rdo_res_75 = "L&ow";
        public static string desc_rdo_res_50 = "&Very Low";

        public static string game_launched_desc = "NFSHelper will stay open to keep WeGame tunneling working";
        public static string game_ended_desc = "See you next time";
    }
}
