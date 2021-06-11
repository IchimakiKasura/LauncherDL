using LauncherDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#pragma warning disable IDE0056
#pragma warning disable IDE0044
#pragma warning disable IDE1006
namespace Launcher
{
    public partial class uVAD : Form
    {

        //readonly Regex Dlrg = new Regex(@"^\[download\] (?<percent>.*)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)$");
        //strings
        static readonly string Path_ = $"\"{Directory.GetCurrentDirectory()}\\ffmpeg\\ydl.bin\"";
        static readonly string ffmpeg = $"{Directory.GetCurrentDirectory()}\\ffmpeg";
        string FileFormatRegex = @"(.*)mp4([\s]*)(([0-9]+)x([0-9]+))";
        private List<string> videoFormatNumList = new List<string>();
        private List<string> videoFormatRes = new List<string>();
        private List<string> videoFormatSize = new List<string>();
        public static string Val = "";
        string scc;
        //bools
        private bool Txtf = false;
        bool FileFormats_ = false;
        bool FfUnavail = false;
        bool IsDownloading = false;
        //ints
        private int audioFormatNum;

        // Error Handler
        private string ErrorHandler(string errorName)
        {
            switch (errorName) {
                default:
                    return "lol";
                case "missing files":
                    return "ERROR: Cannot done the process because of missing files!\r\n" +
                    "   missing files:\r\n";

                case "missing format":
                    return "\r\n[STATE] ERROR" +
                            "\r\n[ERROR] Input some Format options!" +
                            "\r\n[WARN] No Format Settings set on FileType NONE" +
                            "\r\n[NOTE] FileType NONE only used when using Format settings!";

                case "No link":
                    return "\r\n[STATE] ERROR" +
                    "\r\n[ERROR] Link cannot be empty!" +
                    "\r\n[WARN] No Link Given! please put some link first!";

                case "Invalid link":
                    return "\r\n[STATE] ERROR" +
                    "\r\n[ERROR] Invalid link!" +
                    "\r\n[WARN] The link given was invalid";

                case "Invalid link 2":
                    return "\r\n[ERROR] File didn't downloaded properly, causes:" +
                    "\r\n      -Link given is Invalid" +
                    "\r\n      -Link itself has no Video or Audio present" +
                    "\r\n      -Poor internet connection" +
                    "\r\n      -If you're using \"Custom\" with options,\r\nRemember Video format code first before the audio [video+audio]";

                case "Failed Format":
                    return "\r\n[WARN] Link does not contain any Format options " +
                    "\r\n      -Link given is not yet available for format options" +
                    "\r\n[NOTE] You can still download the video using format \"best\" or go to the Video File type to download";
            }
        }


        // YDL options

        private void Ydl_update()
        {
            // lol
            var sc = $"-U";
            StartProcess(sc);
        }

        private void Ydl_file_format(string link)
        {
            //clears the remaining var from the strings
            videoFormatRes.Clear();
            videoFormatSize.Clear();
            videoFormatNumList.Clear();

            outputCom.AppendText("\r\n[SYSTEM] Loading FileFormat.");
            var sc = $"-F \"{link}\"";

            StartProcess(sc);
        }

        private void Ydl_download(string link, bool IsVideo, bool IsMP3)
        {
            var transformedSTR = FileName.Text.Replace(" ", "-");
            if (IsVideo)
            {
                string sc;
                if (FileName.Text == string.Empty)
                {
                    sc = $"-f best {link} -o output/Video/%(title)s.%(ext)s";
                }
                else
                {
                    sc = $"-f best {link} -o output/Video/{transformedSTR}.%(ext)s";
                }
                StartProcess(sc);
            }
            else
            {
                if (IsMP3)
                {
                    string sc;
                    if (FileName.Text == string.Empty)
                    {
                        sc = $"-x --audio-format mp3 {link} -o output/Audio/%(title)s.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
                    }
                    else
                    {
                        sc = $"-x --audio-format mp3 {link} -o output/Audio/{transformedSTR}.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
                    }

                    if (FfmpegCheck())
                    {
                        StartProcess(sc);
                    }
                }
                else
                {
                    string sc;
                    if (FileName.Text == string.Empty)
                    {
                        sc = $"-f m4a \"{link}\" -o output/Audio/%(title)s.%(ext)s\"";
                    }
                    else
                    {
                        sc = $"-f m4a \"{link}\" -o output/Audio/{transformedSTR}.%(ext)s\"";
                    }
                    StartProcess(sc);
                }
            }
        }

        private void Ydl_download_custom(string format, string link)
        {
            string sc;
            if (FileName.Text == string.Empty)
            {
                sc = $"-f {format} \"{link}\" -o output/formatted/%(ext)s/%(title)s.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
            }
            else
            {
                var transformedSTR = FileName.Text.Replace(" ", "-");
                sc = $"-f {format} \"{link}\" -o output/formatted/%(ext)s/{transformedSTR}.%(ext)s --ffmpeg-location \"{ffmpeg}\"";
            }
            if (FfmpegCheck())
            {
                StartProcess(sc);
            }
        }

        //FFmpeg file checker
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
                outputCom.Text += ErrorHandler("missing files") +
                    $"{MissingFiles}\r\n";
                    
                return false;
            }

            return true;
        }

        ///////////////////////////////////////////////////////////////
        //
        // cut the line here
        //
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
            progressBar1.Visible = false;
        }

        ///////////////////////////////////////////////////////////////

        private void Hidden(object sender, EventArgs e)
        {
            MessageBox.Show("LauncherDL buildver4.5\n\nFixed some errors and bugs nothing much\n\n\n Created by Kasura.", "huzuaah!", MessageBoxButtons.OK);
        }
        private void download_Click(object sender, EventArgs e)
        {
            download.Enabled = false;
            checkBox1.Enabled = false;
            update.Enabled = false;
            fileFormat.Enabled = false;
            link.Enabled = false;
            format.Enabled = false;
            Ftype.Enabled = false;
            FileName.Enabled = false;

            var _link = link.Text;

            if (_link.Contains("&list"))
            {
                var _s = MessageBox.Show("You're going to download a whole playlist", "uh u sure about dat?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (_s == DialogResult.Cancel)
                {
                    download.Enabled = true;
                    update.Enabled = true;
                    fileFormat.Enabled = true;
                    link.Enabled = true;
                    Ftype.Enabled = true;
                    FileName.Enabled = true;
                    checkBox1.Enabled = true;
                    if (!FfUnavail)
                    {
                        format.Enabled = true;
                    }
                    return;
                }
            }

            string FormatTXT;
            if (format.SelectedIndex == -1)
            {
                FormatTXT = format.Text;
            }
            else
            {
                try
                {
                    if (audioFormatNum != 0)
                        FormatTXT = $"{videoFormatNumList[format.SelectedIndex]}+{audioFormatNum}";
                    else
                        FormatTXT = videoFormatNumList[format.SelectedIndex];
                }
                catch
                {
                    //idk it always go error above wtf
                    FormatTXT = format.Text;
                }
            }
            outputCom.AppendText("\r\n[STATE] Checking" +
                "\r\n[         ] -------------------------------------------" +
                $"\r\n[         ] FileType:      {Ftype.Text}" +
                $"\r\n[         ] MP3:           {checkBox1.Checked}" +
                $"\r\n[         ] Link:          {link.Text}" +
                $"\r\n[         ] Format:        {FormatTXT ?? "None"}" +
                $"\r\n[         ] Custom Name:   {FileName.Text ?? "None"}" +
                "\r\n[         ] -------------------------------------------");
            Regex _reg = new Regex(@"https://");
            if (_link != "")
            {
                if (_reg.IsMatch(_link))
                {
                    if (Ftype.SelectedIndex == 0)
                    {
                        if (format.Text == "")
                        {
                            MessageBox.Show("Input some Format options", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            outputCom.AppendText(ErrorHandler("missing format"));
                            download.Enabled = true;
                            update.Enabled = true;
                            fileFormat.Enabled = true;
                            link.Enabled = true;
                            Ftype.Enabled = true;
                            FileName.Enabled = true;
                            checkBox1.Enabled = true;
                            if (!FfUnavail)
                            {
                                format.Enabled = true;
                            }
                        }
                        else
                        {
                            outputCom.AppendText(
                            "\r\n[STATE] Downloading with customized format" +
                            "\r\n[] Please wait until it finished downloading...\r\n");
                            Ydl_download_custom(FormatTXT.Trim(), _link);
                        }
                    }
                    if (Ftype.SelectedIndex == 1)
                    {
                        outputCom.AppendText(
                        "\r\n[STATE] Downloading Video" +
                        "\r\n[] Please wait until it finished downloading...\r\n\r\n");
                        Ydl_download(_link, true, false);
                    }
                    if (Ftype.SelectedIndex == 2)
                    {
                        outputCom.AppendText(
                        "\r\n[STATE] Downloading Audio" +
                        "\r\n[] Please wait until it finished downloading...\r\n\r\n");
                        Ydl_download(_link, false, checkBox1.Checked);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid link!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    outputCom.AppendText(ErrorHandler("Invalid link"));
                    download.Enabled = true;
                    update.Enabled = true;
                    fileFormat.Enabled = true;
                    link.Enabled = true;
                    checkBox1.Enabled = true;
                    FileName.Enabled = true;
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
                outputCom.AppendText(ErrorHandler("No link"));
                download.Enabled = true;
                update.Enabled = true;
                fileFormat.Enabled = true;
                link.Enabled = true;
                FileName.Enabled = true;
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
            FileName.Enabled = false;
            checkBox1.Enabled = false;
            outputCom.AppendText("\r\n[STATE] Updating...");
            Ydl_update();
        }
        private void fileFormat_Click(object sender, EventArgs e)
        {
            /*if (((Formats)Application.OpenForms["Formats"]).Visible)
            {
                MessageBox.Show("Current File Format window is open!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            download.Enabled = false;
            update.Enabled = false;
            fileFormat.Enabled = false;
            link.Enabled = false;
            format.Enabled = false;
            FileName.Enabled = false;
            checkBox1.Enabled = false;
            Ftype.Enabled = false;
            var _link = link.Text;
            Regex _reg = new Regex(@"https://");
            if (_link != "")
            {
                if (_reg.IsMatch(_link))
                {
                    FileFormats_ = true;
                    Ydl_file_format(link.Text);
                }
                else
                {
                    MessageBox.Show("Invalid link!", "Megumin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    outputCom.AppendText(ErrorHandler("Invalid link"));
                    download.Enabled = true;
                    update.Enabled = true;
                    fileFormat.Enabled = true;
                    link.Enabled = true;
                    Ftype.Enabled = true;
                    FileName.Enabled = true;
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
                outputCom.AppendText(ErrorHandler("No link"));
                download.Enabled = true;
                update.Enabled = true;
                fileFormat.Enabled = true;
                link.Enabled = true;
                Ftype.Enabled = true;
                FileName.Enabled = true;
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
        private void Ftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ftype.SelectedIndex != 0)
            {
                format.Enabled = false;
                FfUnavail = true;
                format.Text = "Unavailable";

            }
            else
            {
                format.Enabled = true;
                FfUnavail = false;
                format.Text = "best";
                outputCom.AppendText("\r\n[SYSTEM] Changed FileType to \"Custom\"");
            }

            if (Ftype.SelectedIndex == 2)
            {
                checkBox1.Visible = true;
                outputCom.AppendText("\r\n[SYSTEM] Changed FileType to \"Audio\"");
            }
            else
            {
                checkBox1.Visible = false;
                checkBox1.Checked = false;
            }

            if (Ftype.SelectedIndex == 1)
            {
                outputCom.AppendText("\r\n[SYSTEM] Changed FileType to \"Video\"");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Directory.GetCurrentDirectory();
            Process.Start("explorer.exe", $@"{path}\output");
        }

        private void StartProcess(string sc)
        {
            if (sc != "-U")
            {
                progressBar1.Visible = true;
            }

            scc = sc;
            dlWorker.RunWorkerAsync();
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
                    // outputCom.Lines[outputCom.Lines.Length - 2] # for test or debug purpose
                    // real-time output from cmd's output
                    // in-short output from cmd goes to textbox realtime
                    var str = e.Data ?? string.Empty;
                    if (str.Contains(@"[download]"))
                        str = e.Data.Replace("[download]", "[PROGRESS]");

                    if (str.Contains(@"[ffmpeg]"))
                        str = string.Empty;

                    if (str.Contains("youtube-dl"))
                        str = e.Data.Replace("youtube-dl", "ydl.bin");

                    if (str.Contains("Deleting original file"))
                        str = string.Empty;
                    var st = e.Data ?? "none";

                    if (Regex.IsMatch(st, @"^\[download\] (?<percent>.*)\.(.*)%"))
                        progressBar1.Value = int.Parse(Regex.Match(e.Data, @"^\[download\] (?<percent>.*)\.(.*)%").Groups["percent"].Value);

                    if (str != string.Empty)
                        // see if it matches a "[download]" on the given string
                        if (Regex.IsMatch(outputCom.Lines[outputCom.Lines.Length - 1], @"\[PROGRESS\]"))
                        {
                            //gets the textbox whole line array with text
                            string[] line = outputCom.Lines;
                            //change the text of that specific text from the array
                            line[outputCom.Lines.Length - 1] = str.Trim();
                            //give it to the textbox array again to overwrite
                            outputCom.Lines = line;
                            //scrolls to the bottom automatically
                            outputCom.ScrollToCaret();
                        }
                        outputCom.AppendText($"\r\n{str}");
                }
            }
            else
            {
                var str = e.Data ?? string.Empty;
                if (str.Contains("format code"))
                {
                    Txtf = true;
                }
                if (str.Contains("[download]"))
                {
                    Txtf = false;
                }
                if (Txtf)
                {
                    if (Regex.IsMatch(str, @"(.*)m4a(.*)audio only tiny"))
                        audioFormatNum = Convert.ToInt32(Regex.Match(str, @"(?<formatCode>.*)m4a(.*)audio only tiny").Groups["formatCode"].Value.Trim());
                    else
                        audioFormatNum = 0;
                    if (Regex.IsMatch(str, FileFormatRegex))
                    {
                        var FFR = @"(?<formatCode>.*)mp4([\s]*)(?<videoRes>([0-9]+)x([0-9]+))([\s]*)(?<resolution>[0-9]+p)(.*)video only, (?<size>([0-9]+(.*)))";
                        var Otherwebsites = @"(?<formatCode>.*)mp4([\s]*)(([0-9]+)x(?<resolution>[0-9]+))(?=([\s]+)(?<bitrate1>[0-9]+k)|([\s]+)(DASH video (?<bitrate2>.*k)))";
                        if (Regex.IsMatch(str, FFR))
                        {
                            videoFormatNumList.Add(Regex.Match(str, FFR).Groups["formatCode"].Value.Trim());
                            videoFormatRes.Add(Regex.Match(str, FFR).Groups["resolution"].Value.Trim());
                            videoFormatSize.Add(Regex.Match(str, FFR).Groups["size"].Value.Trim());
                        }
                        else
                        {
                            videoFormatNumList.Add(Regex.Match(str, Otherwebsites).Groups["formatCode"].Value.Trim());
                            videoFormatRes.Add(Regex.Match(str, Otherwebsites).Groups["resolution"].Value.Trim());
                            var x = Regex.Match(str, Otherwebsites).Groups["bitrate1"].Value.Trim();
                            if (x != "" || x != string.Empty)
                                videoFormatSize.Add(Regex.Match(str, Otherwebsites).Groups["bitrate1"].Value.Trim());
                            else
                                videoFormatSize.Add(Regex.Match(str, Otherwebsites).Groups["bitrate2"].Value.Trim());

                        }
                    }
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
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                var proc = new Process();
                IsDownloading = true;
                proc.EnableRaisingEvents = true;
                proc.StartInfo = dl;
                proc.OutputDataReceived += OutputHandler;
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
            }
            else
            {
                ProcessStartInfo dl = new ProcessStartInfo(Path_, sc)
                {
                    UseShellExecute = false,
                    ErrorDialog = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                var proc = new Process() { StartInfo = dl };
                proc.OutputDataReceived += OutputHandler;
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
            }
        }

        private void dlWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Regex.IsMatch(outputCom.Lines[outputCom.Lines.Length - 1], @"Downloading webpage"))
            {
                outputCom.AppendText(ErrorHandler("Invalid Link 2"));
            }

            if (Regex.IsMatch(outputCom.Lines[outputCom.Lines.Length - 1], @"\[PROGRESS\] 100% of (.*) in (.*)$"))
            {
                string[] line = outputCom.Lines;
                var regex = @"\[PROGRESS\].100%.of.(?<size>.*).in.(?<eta>.*)$";
                var DataSize = Regex.Match(line[outputCom.Lines.Length - 1], regex, RegexOptions.IgnoreCase).Groups["size"].Value;
                var DataETA = Regex.Match(line[outputCom.Lines.Length - 1], regex, RegexOptions.IgnoreCase).Groups["eta"].Value.Trim();
                line[outputCom.Lines.Length - 1] = $"\r\n[COMPLETE] Downloaded file in {DataETA} with a size of {DataSize}\r\n";
                outputCom.Lines = line;
                outputCom.ScrollToCaret();
            }

            Txtf = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;

            if (FileFormats_)
            {
                format.Items.Clear();
                outputCom.AppendText("\r\n[SYSTEM] Opening new window.");
                Formats frm = new Formats();
                frm.Show();
                frm.ShowInTaskbar = true;
                for (int i = 0; i < videoFormatRes.Count; ++i)
                {
                    //outputCom.AppendText($"\r\nres: {videoFormatRes[i]}; bit/size: {videoFormatSize[i]}");
                    if (videoFormatRes[i] != string.Empty)
                    {
                        if (videoFormatSize[i].Contains("iB"))
                            format.Items.AddRange(new object[] { $"{videoFormatRes[i]} ({videoFormatSize[i]} + audio size)" });
                        else
                            format.Items.AddRange(new object[] { $"{videoFormatRes[i]}p (bitrate: {videoFormatSize[i]})" });

                    }
                }

                if (Val == string.Empty)
                {
                    outputCom.AppendText(ErrorHandler("Failed Format"));
                }
                Val = string.Empty;
            }

            IsDownloading = false;
            if (!button1.Visible && Directory.Exists($"{Directory.GetCurrentDirectory()}\\output"))
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
            FileName.Enabled = true;
        }

        private void outputCom_TextChanged(object sender, EventArgs e)
        {
            outputCom.SelectionStart = outputCom.Text.Length;
            outputCom.ScrollToCaret();
        }

        private void uVAD_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"./ffmpeg/ydl.bin"))
            {
                MessageBox.Show("the file \"ydl.bin\" isn't found on the ffmpeg folder! please reinstall", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
