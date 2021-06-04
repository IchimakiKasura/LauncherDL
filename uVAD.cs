using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Http;
using LauncherDL;
using System.ComponentModel;

namespace Launcher
{
    public partial class uVAD : Form
    {

        static readonly string Path_ = $"\"{Directory.GetCurrentDirectory()}\\ffmpeg\\ydl.bin\"";
        static readonly string ffmpeg = $"{Directory.GetCurrentDirectory()}\\ffmpeg";
        //readonly Regex Dlrg = new Regex(@"^\[download\] (?<percent>.*)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)$");
        bool FileFormats_ = false;
        bool FfUnavail = false;
        bool IsDownloading = false;
        public static string Val;
        public static string title;
        private int Txtf;
        string scc;

        private void Ydl_update()
        {
            var sc = $"-U";
            StartProcess(sc);
        }

        private void Ydl_file_format(string link)
        {
            outputCom.AppendText("[SYSTEM] Loading FileFormat.\r\n");
            var sc = $"-F \"{link}\"";
            StartProcess(sc);
        }

        private void Ydl_download(string link, bool IsVideo, bool IsMP3)
        {
            if (IsVideo)
            {
                var sc = $"-f best {link} -o output/Video/%(title)s.%(ext)s";
                StartProcess(sc);
            }
            else
            {
                if (IsMP3)
                {
                    var sc = $"-x --audio-format mp3 {link} -o output/Audio/%(title)s.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
                    if (FfmpegCheck())
                    {
                        StartProcess(sc);
                    }
                }
                else
                {
                    var sc = $"-f m4a \"{link}\" -o output/Audio/%(title)s.%(ext)s\"";
                    StartProcess(sc);
                }
            }
        }

        private void Ydl_download_custom(string format, string link)
        {
            var sc = $"-f {format} {link} -o output/formatted/%(title)s.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
            if (FfmpegCheck())
            {
                StartProcess(sc);
            }
        }

        private bool FfmpegCheck()
        {
            string[] Files_ = { "avcodec-58.dll", "avdevice-58.dll", "avfilter-7.dll", "avformat-58.dll", "avutil-56.dll", "ffmpeg.exe", "ffplay.exe", "ffprobe.exe", "postproc-55.dll", "swresample-3.dll", "swscale-5.dll" };
            string MissingFiles = "";
            for (var i = 0; i < Files_.Length; i++)
            {
                if (!File.Exists($"{ffmpeg}\\{Files_[i]}"))
                {
                    MissingFiles += $"{ Files_[i]}\n";
                }
            }

            if (MissingFiles != "")
            {
                outputCom.Text +=
                    "ERROR: Cannot done the process because of missing files!\r\n" +
                    "   missing files:\r\n" +
                    $"{MissingFiles}\r\n";
                return false;
            }

            return true;
        }

        ///////////////////////////////////////////////////////////////

        public uVAD()
        {
            InitializeComponent();
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\output"))
            {
                button1.Visible = false;
            }
            Ftype.SelectedIndex = 0;
            checkBox1.Visible = false;
        }

        private void uVAD_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (!File.Exists(@"./ffmpeg/ydl.bin"))
            {
                MessageBox.Show("the file \"ydl.bin\" isn't found on the ffmpeg folder! please reinstall","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void Hidden(object sender, EventArgs e)
        {
            MessageBox.Show("LauncherDL buildver3.0\n\nNice many things changed and added!\n\n\n Created by Kasura.", "huzuaah!", MessageBoxButtons.OK);
        }
        private async void download_Click(object sender, EventArgs e)
        {
            download.Enabled = false;
            checkBox1.Enabled = false;
            update.Enabled = false;
            fileFormat.Enabled = false;
            link.Enabled = false;
            format.Enabled = false;
            Ftype.Enabled = false;
            var _link = link.Text;
            var httpClient = new HttpClient();
            outputCom.AppendText("[STATE] Checking\r\n" +
                "[]-------------------------------------------\r\n" +
                $"[] FileType:  {Ftype.Text}\r\n" +
                $"[] MP3:       {checkBox1.Checked}\r\n" +
                $"[] Link:      {_link}\r\n" +
                $"[] Format:    {format.Text}\r\n" +
                "[]-------------------------------------------\r\n");
            Regex _reg = new Regex(@"https://");
            if (_link != "")
            {
                if (_reg.IsMatch(_link))
                {
                    var html = await httpClient.GetStringAsync(_link);
                    title = Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                    title = title.Replace(" - YouTube","");
                    if (Ftype.SelectedIndex == 0)
                    {
                        if (format.Text == "")
                        {
                            MessageBox.Show("Input some Format options", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            outputCom.AppendText(
                            "[STATE] ERROR\r\n" +
                            "[Error] Input some Format options!\r\n" +
                            "[WARN] No Format Settings set on FileType NONE\r\n" +
                            "[NOTE] FileType NONE only used when using Format settings!\r\n");
                            download.Enabled = true;
                            update.Enabled = true;
                            fileFormat.Enabled = true;
                            link.Enabled = true;
                            Ftype.Enabled = true;
                            checkBox1.Enabled = true;
                            if (!FfUnavail)
                            {
                                format.Enabled = true;
                            }
                        }
                        else
                        {
                            outputCom.AppendText(
                            "[STATE] Downloading with customized format\r\n" +
                            $"[]Downloading the \"{title}\"\r\n" +
                            "[]Please wait until it finished downloading...\r\n");
                            Ydl_download_custom(format.Text, _link);
                        }
                    }
                    if (Ftype.SelectedIndex == 1)
                    {
                        outputCom.AppendText(
                        "[STATE] Downloading Video\r\n" +
                        $"[]Downloading the \"{title}\" as a Video\r\n" +
                        "[]Please wait until it finished downloading...\r\n");
                        Ydl_download(_link, true, false);
                    }
                    if (Ftype.SelectedIndex == 2)
                    {
                        outputCom.AppendText(
                        "[STATE] Downloading Audio\r\n" +
                        $"[]Downloading the \"{title}\" as a Audio\r\n" +
                        "[]Please wait until it finished downloading...\r\n");
                        Ydl_download(_link, false, checkBox1.Checked);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid link!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    outputCom.AppendText(
                    "[STATE] ERROR\r\n" +
                    "[Error] Invalid link!\r\n" +
                    "[WARN] The link given was invalid\r\n");
                    download.Enabled = true;
                    update.Enabled = true;
                    fileFormat.Enabled = true;
                    link.Enabled = true;
                    checkBox1.Enabled = true;
                    Ftype.Enabled = true;
                    if (!FfUnavail)
                    {
                        format.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Link cannot be empty!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                outputCom.AppendText(
                "[STATE] ERROR\r\n" +
                "[Error] Link cannot be empty!\r\n" +
                "[WARN] No Link Given! please put some link first!\r\n" +
                "[NOTE] FileType NONE only used when using Format settings!\r\n");
                download.Enabled = true;
                update.Enabled = true;
                fileFormat.Enabled = true;
                link.Enabled = true;
                checkBox1.Enabled = true;
                if (!FfUnavail)
                {
                    format.Enabled = true;
                }
                Ftype.Enabled = true;
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            download.Enabled = false;
            update.Enabled = false;
            fileFormat.Enabled = false;
            link.Enabled = false;
            format.Enabled = false;
            Ftype.Enabled = false;
            checkBox1.Enabled = false;
            outputCom.AppendText("[STATE] Updating...\r\n");
            Ydl_update();
        }
        private async void fileFormat_Click(object sender, EventArgs e)
        {
            download.Enabled = false;
            update.Enabled = false;
            fileFormat.Enabled = false;
            link.Enabled = false;
            format.Enabled = false;
            checkBox1.Enabled = false;
            Ftype.Enabled = false;
            var _link = link.Text;
            var httpClient = new HttpClient();
            Regex _reg = new Regex(@"https://");
            if (_link != "")
            {
                if (_reg.IsMatch(_link))
                {
                    var html = await httpClient.GetStringAsync(_link);
                    title = Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                    title = title.Replace(" - YouTube", "");
                    FileFormats_ = true;
                    Ydl_file_format(link.Text);
                }
                else
                {
                    MessageBox.Show("Invalid link!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    outputCom.AppendText(
                    "[STATE] ERROR\r\n" +
                    "[Error] Invalid link!\r\n" +
                    "[WARN] The link given was invalid\r\n");
                    download.Enabled = true;
                    update.Enabled = true;
                    fileFormat.Enabled = true;
                    link.Enabled = true;
                    Ftype.Enabled = true;
                    checkBox1.Enabled = true;
                    if (!FfUnavail)
                    {
                        format.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Link cannot be empty!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                outputCom.AppendText(
                "[STATE] ERROR\r\n" +
                "[Error] Link cannot be empty!\r\n" +
                "[WARN] No Link Given! please put some link first!\r\n");
                download.Enabled = true;
                update.Enabled = true;
                fileFormat.Enabled = true;
                link.Enabled = true;
                Ftype.Enabled = true;
                checkBox1.Enabled = true;
                if (!FfUnavail)
                {
                    format.Enabled = true;
                }
            }
        }

        ///////////////////////////////////////////////////////////////
        //
        // uh idk cut the line here
        //
        ///////////////////////////////////////////////////////////////
        private void LinkLabel_Click(object sender, EventArgs e)
        {

        }
        private void link_TextChanged(object sender, EventArgs e)
        {

        }
        private void format_TextChanged(object sender, EventArgs e)
        {

        }
        private void outputCom_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            outputCom.AppendText("[SYSTEM] Prefered MP3 selected!\r\n");
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        ///////////////////////////////////////////////////////////////

        private void Ftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ftype.SelectedIndex != 0)
            {
                format.Enabled = false;
                FfUnavail = true;
                format.PlaceholderText = "Unavailable";

            }
            else
            {
                format.Enabled = true;
                FfUnavail = false;
                format.PlaceholderText = "Format settings";
                outputCom.AppendText("[SYSTEM] Changed FileType to \"None\"\r\n");
            }

            if (Ftype.SelectedIndex == 2)
            {
                checkBox1.Visible = true;
                outputCom.AppendText("[SYSTEM] Changed FileType to \"Audio\"\r\n");
            }
            else
            {
                checkBox1.Visible = false;
                checkBox1.Checked = false;
            }

            if(Ftype.SelectedIndex == 1)
            {
                outputCom.AppendText("[SYSTEM] Changed FileType to \"Video\"\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Directory.GetCurrentDirectory();
            Process.Start("explorer.exe", $@"{path}\output");
        }

        private void StartProcess(string sc)
        {
            if(sc != "-U")
            {
                progressBar1.Visible = true;
            }

            scc = sc;
            dlWorker.RunWorkerAsync();

            /*if (!File.Exists(Path_))
            {
                MessageBox.Show("ydl.bin is missing!", "Error!");
                outputCom.AppendText("[ERROR] ydl.bin is missing!.\r\n");
                outputCom.AppendText("[SYSTEM] Aborting download.\r\n");
                IsDownloading = false;
                if (!button1.Visible || Directory.Exists($"{Directory.GetCurrentDirectory()}\\output"))
                {
                    button1.Visible = true;
                }
                download.Enabled = true;
                update.Enabled = true;
                fileFormat.Enabled = true;
                link.Enabled = true;
                FileFormats_ = false;
                checkBox1.Enabled = true;
                if (!FfUnavail)
                {
                    format.Enabled = true;
                }
                Ftype.Enabled = true;
                return;
            }*/
        }

        // TextBox Output !!
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs e)
        {
            if (!FileFormats_)
            {
                if (outputCom.InvokeRequired)
                {
                    outputCom.BeginInvoke(new DataReceivedEventHandler(OutputHandler), new[] { sendingProcess, e });
                }
                else
                {
                    //outputCom.Lines[outputCom.Lines.Length - 2]
                    // real-time output from cmd's output
                    // in-short output from cmd goes to textbox realtime
                    var str = e.Data ?? string.Empty;
                    if (str.Contains(@"[download]"))
                    {
                        str = e.Data.Replace("[download]", "[]");
                    }
                    if (str.Contains("youtube-dl"))
                    {
                        str = e.Data.Replace("youtube-dl", "ydl.bin");
                    }
                    var st = e.Data ?? "none";
                    if (Regex.IsMatch(st, @"^\[download\] (?<percent>.*)\.(.*)%"))
                    {
                        progressBar1.Value = int.Parse(Regex.Match(e.Data, @"^\[download\] (?<percent>.*)\.(.*)%").Groups["percent"].Value);
                    }
                    outputCom.AppendText(str);
                    outputCom.AppendText("\r\n");
                }
            }
            else
            {
                Txtf--;
                if(Txtf < 0)
                {
                    Val += $"{e.Data ?? string.Empty}\r\n\r\n";
                }
            }

        }

        private void uVAD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDownloading)
            {
                var window = MessageBox.Show(
                    "Hey! You can't close me while downloading! ಠ_ಠ",
                    "Megumin",
                    MessageBoxButtons.OK);

                e.Cancel = (window == DialogResult.OK);
            }
        }

        private void dlWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string sc = scc;
            if (!FileFormats_)
            {
                ProcessStartInfo dl = new ProcessStartInfo(Path_, sc)
                {
                    UseShellExecute = false,
                    ErrorDialog = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                var proc = new Process();
                IsDownloading = true;
                proc.EnableRaisingEvents = true;
                proc.StartInfo = dl;
                proc.OutputDataReceived += OutputHandler;
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
            }
            else
            {
                ProcessStartInfo dl = new ProcessStartInfo(Path_, sc)
                {
                    UseShellExecute = false,
                    ErrorDialog = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                var proc = new Process();
                proc.StartInfo = dl;
                Txtf = 3;
                proc.OutputDataReceived += OutputHandler;
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
            }
        }

        private void dlWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            if (FileFormats_)
            {
                outputCom.AppendText("[SYSTEM] Opening new window.\r\n");
                Formats frm = new Formats();
                frm.Show();
                Val = string.Empty;
            }
            IsDownloading = false;
            if (!button1.Visible || Directory.Exists($"{Directory.GetCurrentDirectory()}\\output"))
            {
                button1.Visible = true;
            }
            download.Enabled = true;
            update.Enabled = true;
            fileFormat.Enabled = true;
            link.Enabled = true;
            FileFormats_ = false;
            checkBox1.Enabled = true;
            if (!FfUnavail)
            {
                format.Enabled = true;
            }
            Ftype.Enabled = true;
        }

    }
}
