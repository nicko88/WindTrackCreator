using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindTrackCreator
{
    public partial class WindTrackCreator : Form
    {
        private KeyboardHook _hookNum0;
        private KeyboardHook _hookNum1;
        private KeyboardHook _hookNum4;
        private KeyboardHook _hookNum5;
        private KeyboardHook _hookNum7;

        private bool _saved = true;
        private string _videoLength;
        private string _videoPath;

        private Color _backColor;
        private Color _foreColor;
        private Color _btnBackColor;
        private Color _btnForeColor;
        private Color _gvBackColor;
        private Color _gvHeaderBackColor;
        private FlatStyle _gvBtnStyle;

        public WindTrackCreator()
        {
            Util.ConfigHelper.EnableMPCBEWebAPI();
            Util.ConfigHelper.EnableMPCBEChapterMarkers();

            InitializeComponent();

            SaveDefaultColor();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd(new char[] { '.', '0' });
            Text += " v" + version;

            DataTable fanTable = new DataTable();
            fanTable.Columns.Add("TimeCode");
            fanTable.Columns.Add("FanSpeed");
            fanTable.Columns.Add("Seek");
            fanTable.Columns.Add("Delete");

            gvCodes.DataSource = fanTable;

            gvCodes.Sort(gvCodes.Columns["TimeCode"], ListSortDirection.Ascending);
            gvCodes.Columns["TimeCode"].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCodes.Columns["FanSpeed"].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCodes.Columns["Seek"].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCodes.Columns["Delete"].SortMode = DataGridViewColumnSortMode.NotSortable;

            _saved = true;
        }

        private void SaveDefaultColor()
        {
            _backColor = BackColor;
            _foreColor = ForeColor;
            _btnBackColor = btnOpen.BackColor;
            _btnForeColor = btnOpen.ForeColor;
            _gvBackColor = gvCodes.BackgroundColor;
            _gvHeaderBackColor = gvCodes.ColumnHeadersDefaultCellStyle.BackColor;

            DataGridViewButtonColumn seek = (DataGridViewButtonColumn)gvCodes.Columns["Seek"];
            _gvBtnStyle = seek.FlatStyle;
        }

        private async void WindTrackCreator_Load(object sender, EventArgs e)
        {
            _hookNum0 = new KeyboardHook(Constants.NOMOD, Keys.NumPad0, this);
            _hookNum1 = new KeyboardHook(Constants.NOMOD, Keys.NumPad1, this);
            _hookNum4 = new KeyboardHook(Constants.NOMOD, Keys.NumPad4, this);
            _hookNum5 = new KeyboardHook(Constants.NOMOD, Keys.NumPad5, this);
            _hookNum7 = new KeyboardHook(Constants.NOMOD, Keys.NumPad7, this);

            LoadProgramSettings();

            _saved = true;

            await CheckNewVersion();
        }

        private void RegisterKeys()
        {
            _hookNum0.Register();
            _hookNum1.Register();
            _hookNum4.Register();
            _hookNum5.Register();
            _hookNum7.Register();
        }

        private void UnregisterKeys()
        {
            _hookNum0.Unregister();
            _hookNum1.Unregister();
            _hookNum4.Unregister();
            _hookNum5.Unregister();
            _hookNum7.Unregister();
        }

        private void LoadProgramSettings()
        {
            string mediaPlayer = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "MediaPlayer");

            if(mediaPlayer == "MPC")
            {
                rbMPC.Checked = true;
            }
            else if(mediaPlayer == "Kodi")
            {
                rbKodi.Checked = true;
            }

            string IP = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "IP");
            string Port = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "Port");

            if(!string.IsNullOrEmpty(IP))
            {
                tbIP.Text = IP;
            }
            if (!string.IsNullOrEmpty(Port))
            {
                tbPort.Text = Port;
            }

            string username = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "Username");
            if (!string.IsNullOrEmpty(username))
            {
                tbUsername.Text = username;
            }

            string ECOSpinup = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "ECOSpinUp");
            if (!string.IsNullOrEmpty(ECOSpinup))
            {
                tbECOSpinup.Text = ECOSpinup;
            }

            string LOWSpinup = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "LOWSpinUp");
            if (!string.IsNullOrEmpty(LOWSpinup))
            {
                tbLOWSpinup.Text = LOWSpinup;
            }

            string MEDSpinup = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "MEDSpinUp");
            if (!string.IsNullOrEmpty(MEDSpinup))
            {
                tbMEDSpinup.Text = MEDSpinup;
            }

            string HIGHSpinup = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "HIGHSpinUp");
            if (!string.IsNullOrEmpty(HIGHSpinup))
            {
                tbHIGHSpinup.Text = HIGHSpinup;
            }

            string spindown = Util.WinRegistry.GetRegKey("SOFTWARE\\WindTrackCreator", "Spindown");
            if (!string.IsNullOrEmpty(spindown))
            {
                tbSpindown.Text = spindown;
            }

            cbDarkmode.Checked = Util.WinRegistry.CheckRegKey("SOFTWARE\\WindTrackCreator", "DarkMode");
        }

        private void SaveProgramSettings()
        {
            string mediaPlayer = "";
            if (rbMPC.Checked)
            {
                mediaPlayer = "MPC";
            }
            else if (rbKodi.Checked)
            {
                mediaPlayer = "Kodi";
            }

            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("MediaPlayer", mediaPlayer);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("IP", tbIP.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("Port", tbPort.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("Username", tbUsername.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("ECOSpinUp", tbECOSpinup.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("LOWSpinUp", tbLOWSpinup.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("MEDSpinUp", tbMEDSpinup.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("HIGHSpinUp", tbHIGHSpinup.Text);

            key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
            key.SetValue("Spindown", tbSpindown.Text);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                string fanSpeed = "";
                switch (GetKey(m.LParam))
                {
                    case Keys.NumPad0:
                        fanSpeed = "OFF";
                        break;
                    case Keys.NumPad1:
                        fanSpeed = "LOW";
                        break;
                    case Keys.NumPad4:
                        fanSpeed = "MED";
                        break;
                    case Keys.NumPad5:
                        fanSpeed = "ECO";
                        break;
                    case Keys.NumPad7:
                        fanSpeed = "HIGH";
                        break;
                }

                AddCode(fanSpeed);
                gvCodes.Sort(gvCodes.Columns["TimeCode"], ListSortDirection.Ascending);
            }

            base.WndProc(ref m);
        }

        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        private async Task CheckNewVersion()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".netapp");
                    string releaseJSON = await httpClient.GetStringAsync("https://api.github.com/repos/nicko88/windtrackcreator/releases/latest");
                    JObject data = JObject.Parse(releaseJSON);
                    string latest = (string)data["tag_name"];

                    string version = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd(new char[] { '.', '0' });

                    if (version != latest)
                    {
                        lnkNewVersion.Text = latest;
                        lnkNewVersion.Visible = true;
                        lblNewVersion.Visible = true;
                    }
                }
                catch { }
            }
        }

        private void AddCode(string fanSpeed)
        {
            string time = GetTime(true);
            if (!string.IsNullOrEmpty(time))
            {
                DataTable dT = (DataTable)gvCodes.DataSource;
                for(int i = 0; i < dT.Rows.Count; i++)
                {
                    DataRow row = dT.Rows[i];
                    if (row["TimeCode"].ToString() == time)
                    {
                        dT.Rows.Remove(row);
                    }
                }

                dT.Rows.Add(time, fanSpeed, "Seek", "Delete");

                for(int i = 0; i < gvCodes.Rows.Count; i++)
                {
                    DataGridViewRow row = gvCodes.Rows[i];
                    if (row.Cells["TimeCode"].Value != null)
                    {
                        if (row.Cells["TimeCode"].Value.ToString() == time)
                        {
                            try
                            {
                                gvCodes.CurrentCell = gvCodes.Rows[i - 1].Cells[0];
                            }
                            catch { }
                            gvCodes.CurrentCell = gvCodes.Rows[i].Cells[0];
                        }
                    }
                }

                _saved = false;
            }

            ColorGrid();
            UpdateCodeCount();
        }

        private string GetTime(bool showError)
        {
            if (rbMPC.Checked)
            {
                try
                {
                    string html;
                    using (HttpClient httpClient = new HttpClient())
                    {
                        html = httpClient.GetStringAsync($"http://{tbIP.Text}:{tbPort.Text}/variables.html").Result;
                    }

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    string position = doc.GetElementbyId("position").InnerText;
                    long positionMS = Int64.Parse(position);

                    string filename = doc.GetElementbyId("file").InnerText;
                    FileInfo file = new FileInfo(filename);
                    saveFileDialog.FileName = file.Name.Replace(file.Extension, ".txt");

                    _videoPath = doc.GetElementbyId("filepath").InnerText;

                    _videoLength = doc.GetElementbyId("durationstring").InnerText;

                    TimeSpan t = TimeSpan.FromMilliseconds(positionMS);
                    return t.ToString("G").Substring(2, 12);
                }
                catch
                {
                    if (showError)
                    {
                        MessageBox.Show(this, "Can't connect to MPC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return null;
                }
            }
            else if(rbKodi.Checked)
            {
                try
                {
                    string timeJSONRequest = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetProperties"", ""params"": {""properties"": [""time"", ""speed""], ""playerid"": 1}, ""id"": 1}";
                    string filenameJSONRequest = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetItem"", ""params"": {""properties"": [""file""], ""playerid"": 1}, ""id"": 1 }";
                    string runtimeJSONRequest = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetItem"", ""params"": { ""properties"": [""runtime""], ""playerid"": 1 }, ""id"": 0 }";

                    string timeJSONResponse;
                    string filenameJSONResponse;
                    string runtimeJSONRespoonse;

                    using (HttpClient httpClient = new HttpClient())
                    {
                        StringContent jsonContent = new StringContent(timeJSONRequest, Encoding.UTF8, "application/json");
                        timeJSONResponse = httpClient.PostAsync($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", jsonContent).Result.Content.ReadAsStringAsync().Result;

                        jsonContent = new StringContent(filenameJSONRequest, Encoding.UTF8, "application/json");
                        filenameJSONResponse = httpClient.PostAsync($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", jsonContent).Result.Content.ReadAsStringAsync().Result;

                        jsonContent = new StringContent(runtimeJSONRequest, Encoding.UTF8, "application/json");
                        runtimeJSONRespoonse = httpClient.PostAsync($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", jsonContent).Result.Content.ReadAsStringAsync().Result;
                    }

                    JObject time = JObject.Parse(timeJSONResponse);
                    long hours = Convert.ToInt64(time["result"]["time"]["hours"]);
                    long minutes = Convert.ToInt64(time["result"]["time"]["minutes"]);
                    long seconds = Convert.ToInt64(time["result"]["time"]["seconds"]);
                    long milliseconds = Convert.ToInt64(time["result"]["time"]["milliseconds"]);

                    long positionMS = (hours * 3600000) + (minutes * 60000) + (seconds * 1000) + milliseconds;

                    JObject fileinfo = JObject.Parse(filenameJSONResponse);
                    string filepath = (string)fileinfo["result"]["item"]["file"];
                    filepath = filepath.Replace("smb:", "");
                    FileInfo file = new FileInfo(filepath);
                    saveFileDialog.FileName = file.Name.Replace(file.Extension, ".txt");

                    JObject runtimeinfo = JObject.Parse(runtimeJSONRespoonse);
                    string runtimeSeconds = (string)runtimeinfo["result"]["item"]["runtime"];

                    _videoLength = TimeSpan.FromSeconds(Convert.ToDouble(runtimeSeconds)).ToString();

                    TimeSpan t = TimeSpan.FromMilliseconds(positionMS);
                    return t.ToString("G").Substring(2, 12);
                }
                catch
                {
                    if (showError)
                    {
                        MessageBox.Show(this, "Can't connect to Kodi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return null;
                }
            }

            return null;
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            gvCodes.Enabled = false;
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog.FileName;
                LoadFile(openFileDialog.FileName);
            }

            await Task.Delay(1000);
            gvCodes.Enabled = true;
        }

        private void LoadFile(string filePath)
        {
            tbHeader.Clear();
            string[] lines = File.ReadAllLines(filePath);

            DataTable fanTable = new DataTable();
            fanTable.Columns.Add("TimeCode");
            fanTable.Columns.Add("FanSpeed");
            fanTable.Columns.Add("Seek");
            fanTable.Columns.Add("Delete");

            foreach (string s in lines)
            {
                if (s.StartsWith("#"))
                {
                    tbHeader.Text += s.TrimStart(new[] { '#', ' ' }) + Environment.NewLine;
                }
                else
                {
                    string[] vals = s.Split(',');
                    if (vals.Count() > 1)
                    {
                        fanTable.Rows.Add(vals[0], vals[1], "Seek", "Delete");
                    }
                }
            }

            gvCodes.DataSource = fanTable;
            gvCodes.Sort(gvCodes.Columns["TimeCode"], ListSortDirection.Ascending);
            _saved = true;

            ColorGrid();

            btnFingerprint.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        private bool SaveFile(bool silent)
        {
            try
            {
                List<string> header = new List<string>();
                foreach(string line in tbHeader.Lines)
                {
                    if (line.Length > 0)
                    {
                        header.Add("# " + line);
                    }
                }
                header.Add("");

                List<string> codes = new List<string>();
                foreach(DataGridViewRow row in gvCodes.Rows)
                {
                    if (row.Cells["TimeCode"].Value != null)
                    {
                        if (!string.IsNullOrEmpty(row.Cells["TimeCode"].Value.ToString()))
                        {
                            codes.Add(row.Cells["TimeCode"].Value + "," + row.Cells["FanSpeed"].Value);
                        }
                    }
                }

                codes.Sort();
                header.AddRange(codes);

                if(string.IsNullOrEmpty(lblFilePath.Text))
                {
                    DialogResult result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        lblFilePath.Text = saveFileDialog.FileName;
                    }
                }

                File.WriteAllLines(lblFilePath.Text, header);

                if(!silent)
                { 
                    MessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _saved = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error, not saved.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void WindTrackCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterKeys();

            SaveProgramSettings();
        }

        private void btnFillHeader_Click(object sender, EventArgs e)
        {
            string time = GetTime(true);

            if(time != null)
            {
                FillHeader();
            }
        }

        private void FillHeader()
        {
            tbHeader.Text = $"{Path.GetFileNameWithoutExtension(saveFileDialog.FileName)}\n";
            if (rbUHD.Checked)
            {
                tbHeader.Text += $"4K Ultra HD Blu-ray ({_videoLength})\n";
            }
            else
            {
                tbHeader.Text += $"HD Blu-ray ({_videoLength})\n";
            }
            tbHeader.Text += $"Coded by: {tbUsername.Text}";
        }

        private void WindTrackCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_saved)
            {
                DialogResult result = MessageBox.Show(this, "File not saved, do you want to save?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    SaveFile(false);
                    e.Cancel = true;
                }
            }
        }

        private void gvCodes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = gvCodes.Rows[e.RowIndex];

                if (senderGrid.Columns[e.ColumnIndex].Name == "Delete")
                {
                    try
                    {
                        gvCodes.Rows.RemoveAt(e.RowIndex);
                        _saved = false;
                        UpdateCodeCount();
                    }
                    catch { }

                    ColorGrid();
                }
                else
                {
                    SeekPlayer(row.Cells["TimeCode"].Value.ToString());
                }
            }
        }

        private void SeekPlayer(string timeCode)
        {
            if (rbMPC.Checked)
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        StringContent postContent = new StringContent($"wm_command=-1&position={timeCode}", Encoding.UTF8, "application/x-www-form-urlencoded");
                        _ = httpClient.PostAsync($"http://{tbIP.Text}:{tbPort.Text}/command.html", postContent).Result;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "Can't connect to MPC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rbKodi.Checked)
            {
                try
                {
                    string postData = $@"{{""jsonrpc"": ""2.0"", ""method"": ""Player.Seek"", ""params"": {{ ""playerid"": 1, ""value"": {{ ""time"": {{ ""hours"": {TimeSpan.Parse(timeCode).Hours}, ""minutes"": {TimeSpan.Parse(timeCode).Minutes}, ""seconds"": {TimeSpan.Parse(timeCode).Seconds}, ""milliseconds"": {TimeSpan.Parse(timeCode).Milliseconds} }} }} }}, ""id"": 1}}";

                    using (HttpClient httpClient = new HttpClient())
                    {
                        StringContent jsonContent = new StringContent(postData, Encoding.UTF8, "application/json");
                        _ = httpClient.PostAsync($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", jsonContent).Result;
                    }
                }
                catch
                {
                    MessageBox.Show(this, "Can't connect to Kodi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ColorGrid()
        {
            double prevTime = -500;
            string prevCMD = "";

            int ECOSpinup = 0;
            int LOWSpinup = 0;
            int MEDSpinup = 0;
            int HIGHSpinup = 0;
            int spindown = 0;

            try
            {
                ECOSpinup = Convert.ToInt32(tbECOSpinup.Text);
            }
            catch { }

            try
            {
                LOWSpinup = Convert.ToInt32(tbLOWSpinup.Text);
            }
            catch { }

            try
            {
                MEDSpinup = Convert.ToInt32(tbMEDSpinup.Text);
            }
            catch { }

            try
            {
                HIGHSpinup = Convert.ToInt32(tbHIGHSpinup.Text);
            }
            catch { }

            try
            {
                spindown = Convert.ToInt32(tbSpindown.Text);
            }
            catch { }

            foreach (DataGridViewRow row in gvCodes.Rows)
            {
                if(cbDarkmode.Checked)
                {
                    row.DefaultCellStyle.BackColor = Color.Black;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                try
                {
                    if (row.Cells["TimeCode"].Value != null)
                    {
                        double time = TimeSpan.Parse(row.Cells["TimeCode"].Value.ToString()).TotalMilliseconds;
                        string CMD = row.Cells["FanSpeed"].Value.ToString();

                        if (prevCMD == "OFF")
                        {
                            if (CMD == "ECO" && time - prevTime < ECOSpinup + 500)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }

                            if (CMD == "LOW" && time - prevTime < LOWSpinup + 500)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }

                            if (CMD == "MED" && time - prevTime < MEDSpinup + 500)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }

                            if (CMD == "HIGH" && time - prevTime < HIGHSpinup + 500)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }

                        if (CMD == "OFF")
                        {
                            if (time - prevTime < spindown + 500)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }

                        if (time - prevTime < 500)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }

                        prevCMD = CMD;
                        prevTime = time;
                    }
                }
                catch { }
            }
        }

        private void WindTrackCreator_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void WindTrackCreator_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (fileList.Length > 0 && fileList[0].EndsWith(".txt"))
            {
                LoadFile(fileList[0]);
                lblFilePath.Text = fileList[0];
            }
        }

        private void rbMPC_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMPC.Checked)
            {
                rbKodi.Checked = false;
                tbPort.Text = "13579";
            }
        }

        private void rbKodi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKodi.Checked)
            {
                rbMPC.Checked = false;
                tbPort.Text = "8080";
            }
        }

        private void rbBluray_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBluray.Checked)
            {
                rbUHD.Checked = false;
            }
        }

        private void rbUHD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUHD.Checked)
            {
                rbBluray.Checked = false;
            }
        }

        private void btnCMD_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AddCode(btn.Tag.ToString());
        }

        private void gvCodes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _saved = false;
            UpdateCodeCount();
        }

        private void gvCodes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _saved = false;
            ColorGrid();
            UpdateCodeCount();
        }

        private void UpdateCodeCount()
        {
            lblCommandCount.Text = "Total Commands: " + (gvCodes.Rows.Count - 1).ToString();
        }

        private void cbDarkmode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDarkmode.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WindTrackCreator", true);
                key.SetValue("DarkMode", true);

                SetDarkMode();
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\WindTrackCreator", true);
                key.DeleteValue("DarkMode", false);

                SetLightMode();
            }

            ColorGrid();
        }

        private void cbAutosave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutosave.Checked)
            {
                bool success = SaveFile(true);

                if (success)
                {
                    timerAutosave.Enabled = true;
                    timerAutosave.Start();
                }
                else
                {
                    cbAutosave.Checked = false;
                }
            }
            else
            {
                timerAutosave.Enabled = false;
                timerAutosave.Stop();
            }
        }

        private void cbHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHotkeys.Checked)
            {
                RegisterKeys();
            }
            else
            {
                UnregisterKeys();
            }
        }

        private void timerAutosave_Tick(object sender, EventArgs e)
        {
            bool success = SaveFile(true);

            if (success)
            {
                autosaveLabelUpdate.RunWorkerAsync();
            }
            else
            {
                cbAutosave.Checked = false;
            }
        }

        private void autosaveLabelUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            autosaveLabelUpdate.ReportProgress(0, true);
            Thread.Sleep(3000);
            autosaveLabelUpdate.ReportProgress(0, false);
        }

        private void autosaveLabelUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblSaved.Visible = (bool)e.UserState;
        }

        private void tbSpinup_TextChanged(object sender, EventArgs e)
        {
            ColorGrid();
        }

        private void btnFingerprint_Click(object sender, EventArgs e)
        {
            try
            {
                GetTime(false);
            }
            catch { }

            try
            {
                SaveFile(true);
            }
            catch { }

            AudioFingerprintCreator audioFingerprintCreator = new AudioFingerprintCreator(lblFilePath.Text, _videoPath, tbUsername.Text);
            DialogResult dialogResult = audioFingerprintCreator.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show(this, "Package created successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblFilePath.Text = saveFileDialog.FileName;
                SaveFile(false);
            }
        }

        private void addOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvCodes.Sort(gvCodes.Columns["Delete"], ListSortDirection.Ascending);

            List<string> errorCodes = new List<string>();

            Forms.AddOffset offset = new Forms.AddOffset($"{tbIP.Text}:{tbPort.Text}");
            DialogResult offestResult = offset.ShowDialog();

            if (offestResult == DialogResult.OK)
            {
                foreach (DataGridViewRow row in gvCodes.Rows)
                {
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(row.Cells[0].Value.ToString()).Add(offset.timeCodeOffset);

                        if (ts < TimeSpan.Zero)
                        {
                            errorCodes.Add(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString());
                            row.Cells[0].Value = "00:00:00.000";
                        }
                        else
                        {
                            row.Cells[0].Value = ts.ToString("G").Substring(2, 12);
                        }
                    }
                    catch { }
                }

                if (errorCodes.Count > 0)
                {
                    string errorValues = "";

                    foreach (string s in errorCodes)
                    {
                        errorValues += s + Environment.NewLine;
                    }

                    MessageBox.Show("With your selected Offset, the following TimeCodes have become less than 00:00:00.000" + "\n\n" + errorValues + "\n\n" + "They will now be removed.", "Errors Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    for (int i = 0; i < gvCodes.Rows.Count; i++)
                    {
                        try
                        {
                            if (gvCodes.Rows[i].Cells[0].Value.ToString() == "00:00:00.000")
                            {
                                gvCodes.Rows.RemoveAt(i);
                                _saved = false;
                                i--;
                            }
                        }
                        catch { }
                    }

                    UpdateCodeCount();
                }
            }

            gvCodes.Sort(gvCodes.Columns["TimeCode"], ListSortDirection.Ascending);
            ColorGrid();
        }

        private void SetDarkMode()
        {
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.White;

            btnOpen.BackColor = Color.Black;
            btnOpen.ForeColor = Color.White;

            btnSave.BackColor = Color.Black;
            btnSave.ForeColor = Color.White;

            btnOFF.BackColor = Color.Black;
            btnOFF.ForeColor = Color.White;

            btnECO.BackColor = Color.Black;
            btnECO.ForeColor = Color.White;

            btnLOW.BackColor = Color.Black;
            btnLOW.ForeColor = Color.White;

            btnMED.BackColor = Color.Black;
            btnMED.ForeColor = Color.White;

            btnHIGH.BackColor = Color.Black;
            btnHIGH.ForeColor = Color.White;

            btnFillHeader.BackColor = Color.Black;
            btnFillHeader.ForeColor = Color.White;

            btnFingerprint.BackColor = Color.FromArgb(45, 45, 45);
            btnFingerprint.ForeColor = Color.White;

            tbIP.BackColor = Color.Black;
            tbIP.ForeColor = Color.White;

            tbPort.BackColor = Color.Black;
            tbPort.ForeColor = Color.White;

            tbUsername.BackColor = Color.Black;
            tbUsername.ForeColor = Color.White;

            tbECOSpinup.BackColor = Color.Black;
            tbECOSpinup.ForeColor = Color.White;

            tbLOWSpinup.BackColor = Color.Black;
            tbLOWSpinup.ForeColor = Color.White;

            tbMEDSpinup.BackColor = Color.Black;
            tbMEDSpinup.ForeColor = Color.White;

            tbHIGHSpinup.BackColor = Color.Black;
            tbHIGHSpinup.ForeColor = Color.White;

            tbSpindown.BackColor = Color.Black;
            tbSpindown.ForeColor = Color.White;

            gbOffsets.ForeColor = Color.White;

            tbHeader.BackColor = Color.Black;
            tbHeader.ForeColor = Color.White;

            gvCodes.BackgroundColor = Color.FromArgb(36, 36, 36);
            gvCodes.DefaultCellStyle.BackColor = Color.Black;
            gvCodes.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gvCodes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewButtonColumn seek = (DataGridViewButtonColumn)gvCodes.Columns["Seek"];
            seek.FlatStyle = FlatStyle.Popup;

            DataGridViewButtonColumn delete = (DataGridViewButtonColumn)gvCodes.Columns["Delete"];
            delete.FlatStyle = FlatStyle.Popup;

            menuStrip.BackColor = Color.FromArgb(45, 45, 45);
            menuStrip.ForeColor = Color.White;
        }

        private void SetLightMode()
        {
            BackColor = _backColor;
            ForeColor = _foreColor;

            btnOpen.BackColor = _btnBackColor;
            btnOpen.ForeColor = _btnForeColor;

            btnSave.BackColor = _btnBackColor;
            btnSave.ForeColor = _btnForeColor;

            btnOFF.BackColor = _btnBackColor;
            btnOFF.ForeColor = _btnForeColor;

            btnECO.BackColor = _btnBackColor;
            btnECO.ForeColor = _btnForeColor;

            btnLOW.BackColor = _btnBackColor;
            btnLOW.ForeColor = _btnForeColor;

            btnMED.BackColor = _btnBackColor;
            btnMED.ForeColor = _btnForeColor;

            btnHIGH.BackColor = _btnBackColor;
            btnHIGH.ForeColor = _btnForeColor;

            btnFillHeader.BackColor = _btnBackColor;
            btnFillHeader.ForeColor = _btnForeColor;

            btnFingerprint.BackColor = _btnBackColor;
            btnFingerprint.ForeColor = _btnForeColor;

            tbIP.BackColor = Color.White;
            tbIP.ForeColor = Color.Black;

            tbPort.BackColor = Color.White;
            tbPort.ForeColor = Color.Black;

            tbUsername.BackColor = Color.White;
            tbUsername.ForeColor = Color.Black;

            tbECOSpinup.BackColor = Color.White;
            tbECOSpinup.ForeColor = Color.Black;

            tbLOWSpinup.BackColor = Color.White;
            tbLOWSpinup.ForeColor = Color.Black;

            tbMEDSpinup.BackColor = Color.White;
            tbMEDSpinup.ForeColor = Color.Black;

            tbHIGHSpinup.BackColor = Color.White;
            tbHIGHSpinup.ForeColor = Color.Black;

            tbSpindown.BackColor = Color.White;
            tbSpindown.ForeColor = Color.Black;

            gbOffsets.ForeColor = Color.Black;

            tbHeader.BackColor = Color.White;
            tbHeader.ForeColor = Color.Black;

            gvCodes.BackgroundColor = _gvBackColor;
            gvCodes.DefaultCellStyle.BackColor = Color.White;
            gvCodes.ColumnHeadersDefaultCellStyle.BackColor = _gvHeaderBackColor;
            gvCodes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            DataGridViewButtonColumn seek = (DataGridViewButtonColumn)gvCodes.Columns["Seek"];
            seek.FlatStyle = _gvBtnStyle;

            DataGridViewButtonColumn delete = (DataGridViewButtonColumn)gvCodes.Columns["Delete"];
            delete.FlatStyle = _gvBtnStyle;

            menuStrip.BackColor = _backColor;
            menuStrip.ForeColor = Color.Black;
        }

        private void lnkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://github.com/nicko88/WindTrackCreator/releases/latest");
        }
    }
}