using Microsoft.Win32;
using SoundFingerprinting.Builder;
using SoundFingerprinting.Data;
using SoundFingerprinting.Emy;
using SoundFingerprinting.InMemory;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace WindTrackCreator
{
    public partial class AudioFingerprintCreator : Form
    {
        private bool saveTmpDir = false;
        private string _windtrackPath;
        private string _creatorName;

        private readonly string _rootPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private readonly string _FFmpegDownloadLink = "https://raw.githubusercontent.com/nicko88/WindTrackCreator/master/ffmpeg/ffmpeg-n4.4.1-2-gcc33e73618-win64-gpl-shared-4.4.zip";

        public AudioFingerprintCreator(string windtrackPath, string videoPath, string creatorName)
        {
            InitializeComponent();

            _windtrackPath = windtrackPath;
            _creatorName = creatorName;

            if(!string.IsNullOrEmpty(videoPath))
            {
                tbVideoPath.Text = videoPath;
            }

            Setup();
        }

        private void Setup()
        {
            if (!Directory.Exists($@"{_rootPath}\windtracks"))
            {
                Directory.CreateDirectory($@"{_rootPath}\windtracks");
            }

            tbWorkingPath.Text = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "WorkingPath");
            if(string.IsNullOrEmpty(tbWorkingPath.Text))
            {
                tbWorkingPath.Text = $@"{_rootPath}\tmp";
            }

            tbWindtrackName.Text = Path.GetFileNameWithoutExtension(_windtrackPath);

            CheckFFmpeg();
        }

        private void CheckFFmpeg()
        {
            if (File.Exists($@"{_rootPath}\FFmpeg\bin\x64\ffmpeg.exe"))
            {
                lblFFmpeg.Text = "FFmpeg Installed";
                lblFFmpeg.ForeColor = Color.Black;
                lnkFFmpeg.Visible = false;
                btnCreatePackage.Enabled = true;
            }
            else
            {
                lblFFmpeg.Text = "FFmpeg Missing!";
                lblFFmpeg.ForeColor = Color.Red;
                lnkFFmpeg.Visible = true;
                btnCreatePackage.Enabled = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbVideoPath.Text = openFileDialog.FileName;
            }
        }

        private void lnkFFmpeg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(_FFmpegDownloadLink, $@"{_rootPath}\ffmpeg.zip");

                    using (ZipArchive archive = ZipFile.OpenRead($@"{_rootPath}\ffmpeg.zip"))
                    {
                        Directory.CreateDirectory(@"FFmpeg\bin\x64");

                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if(entry.FullName.StartsWith("ffmpeg-n4.4.1-2-gcc33e73618-win64-gpl-shared-4.4/bin/") && !string.IsNullOrEmpty(entry.Name))
                            {
                                entry.ExtractToFile($@"FFmpeg\bin\x64\{entry.Name}", true);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error installing FFmpeg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            File.Delete($@"{_rootPath}\ffmpeg.zip");

            CheckFFmpeg();
        }

        private void AudioFingerprintCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (saveTmpDir)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
                key.SetValue("WorkingPath", tbWorkingPath.Text);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                saveTmpDir = true;
                tbWorkingPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async void btnCreatePackage_Click(object sender, EventArgs e)
        {
            bool error = false;
            lblWait.Visible = true;

            ClearDir();

            try
            {
                Directory.CreateDirectory($@"{tbWorkingPath.Text}\zip");

                //downmix
                string downmixCMD = $@"-i ""{tbVideoPath.Text}"" -f wav -acodec pcm_s16le -ac 2 -af ""pan=stereo|FL=FC+FL+0.50*BL|FR=FC+FR+0.50*BR"" ""{tbWorkingPath.Text}\downmix.wav""";
                ProcessStartInfo downmixProcessInfo = new ProcessStartInfo(@"FFmpeg\bin\x64\ffmpeg.exe");
                downmixProcessInfo.Arguments = downmixCMD;
                Process downmixProcess = Process.Start(downmixProcessInfo);
                downmixProcess.WaitForExit();

                //clip 5 minutes
                string clipCMD = $@"-ss 0 -i ""{tbWorkingPath.Text}\downmix.wav"" -t 300 ""{tbWorkingPath.Text}\clip.wav""";
                ProcessStartInfo clipProcessInfo = new ProcessStartInfo(@"FFmpeg\bin\x64\ffmpeg.exe");
                clipProcessInfo.Arguments = clipCMD;
                Process clipProcess = Process.Start(clipProcessInfo);
                clipProcess.WaitForExit();

                Guid guid = Guid.NewGuid();

                CreateFingerprints($@"{tbWorkingPath.Text}\downmix.wav", guid.ToString(), tbWindtrackName.Text, _creatorName, $@"{tbWorkingPath.Text}\zip\full.fingerprints");
                CreateFingerprints($@"{tbWorkingPath.Text}\clip.wav", guid.ToString(), tbWindtrackName.Text, _creatorName, $@"{tbWorkingPath.Text}\zip\intro.fingerprints");

                File.Copy(_windtrackPath, $@"{tbWorkingPath.Text}\zip\commands.txt", true);

                ZipFile.CreateFromDirectory($@"{tbWorkingPath.Text}\zip", $@"{_rootPath}\windtracks\{tbWindtrackName.Text}.zip");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException, "Error Creating Windtrack/Fingerprint Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

            ClearDir();

            lblWait.Visible = false;
            if (!error)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ClearDir()
        {
            try
            {
                DirectoryInfo tmp = new DirectoryInfo(tbWorkingPath.Text);
                foreach (FileInfo file in tmp.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in tmp.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch { }
        }

        private void CreateFingerprints(string audioPath, string ID, string name, string artist, string fingerprintPath)
        {
            TrackInfo track = new TrackInfo(ID, name, artist);

            FFmpegAudioService audioService = new FFmpegAudioService();
            Hashes hashedFingerprints = FingerprintCommandBuilder.Instance.BuildFingerprintCommand().From(audioPath).UsingServices(audioService).Hash().Result;

            InMemoryModelService modelService = new InMemoryModelService();
            modelService.Insert(track, hashedFingerprints);
            modelService.Snapshot(fingerprintPath);
        }
    }
}