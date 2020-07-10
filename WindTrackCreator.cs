using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
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

        private bool saved = true;

        Color _backColor;
        Color _foreColor;
        Color _btnBackColor;
        Color _btnForeColor;
        Color _gvBackColor;
        Color _gvHeaderBackColor;
        Color _gvBtnBackColor;
        Color _gvBtnForeColor;
        FlatStyle _gvBtnStyle;

        public WindTrackCreator()
        {
            InitializeComponent();

            SaveDefaultColor();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3).Replace(".0", "");
            Text += " v" + version;

            DataTable fanTable = new DataTable();
            fanTable.Columns.Add("TimeCode");
            fanTable.Columns.Add("FanSpeed");
            fanTable.Columns.Add("Seek");
            fanTable.Columns.Add("Delete");

            gvCodes.DataSource = fanTable;

            gvCodes.Sort(gvCodes.Columns["TimeCode"], System.ComponentModel.ListSortDirection.Ascending);
            saved = true;
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
            _gvBtnBackColor = seek.DefaultCellStyle.BackColor;
            _gvBtnForeColor = seek.DefaultCellStyle.ForeColor;
        }

        private void WindTrackCreator_Load(object sender, EventArgs e)
        {
            _hookNum0 = new KeyboardHook(Constants.NOMOD, Keys.NumPad0, this);
            _hookNum1 = new KeyboardHook(Constants.NOMOD, Keys.NumPad1, this);
            _hookNum4 = new KeyboardHook(Constants.NOMOD, Keys.NumPad4, this);
            _hookNum5 = new KeyboardHook(Constants.NOMOD, Keys.NumPad5, this);
            _hookNum7 = new KeyboardHook(Constants.NOMOD, Keys.NumPad7, this);

            _hookNum0.Register();
            _hookNum1.Register();
            _hookNum4.Register();
            _hookNum5.Register();
            _hookNum7.Register();

            LoadProgramSettings();
            saved = true;
        }

        private void LoadProgramSettings()
        {
            string mediaPlayer = GetRegKey("SOFTWARE\\WindTrackCreator", "MediaPlayer");

            if(mediaPlayer == "MPC")
            {
                rbMPC.Checked = true;
            }
            else if(mediaPlayer == "Kodi")
            {
                rbKodi.Checked = true;
            }

            string IP = GetRegKey("SOFTWARE\\WindTrackCreator", "IP");
            string Port = GetRegKey("SOFTWARE\\WindTrackCreator", "Port");

            if(!string.IsNullOrEmpty(IP))
            {
                tbIP.Text = IP;
            }

            if (!string.IsNullOrEmpty(Port))
            {
                tbPort.Text = Port;
            }

            cbDarkMode.Checked = CheckRegKey("SOFTWARE\\WindTrackCreator", "DarkMode");
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
                gvCodes.Sort(gvCodes.Columns["TimeCode"], System.ComponentModel.ListSortDirection.Ascending);
            }

            base.WndProc(ref m);
        }

        private void AddCode(string fanSpeed)
        {
            string time = GetTime();
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

                saved = false;
            }

            UpdateCodeCount();
        }

        private string GetTime()
        {
            if (rbMPC.Checked)
            {
                try
                {
                    string html;
                    using (var client = new WebClient())
                    {
                        html = client.DownloadString($"http://{tbIP.Text}:{tbPort.Text}/variables.html");
                    }

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    string position = doc.GetElementbyId("position").InnerText;
                    long positionMS = Int64.Parse(position);

                    string filename = doc.GetElementbyId("file").InnerText;
                    FileInfo file = new FileInfo(filename);
                    saveFileDialog.FileName = file.Name.Replace(file.Extension, ".txt");

                    TimeSpan t = TimeSpan.FromMilliseconds(positionMS);
                    return t.ToString("G").Substring(2, 12);
                }
                catch
                {
                    MessageBox.Show(this, "Can't connect to MPC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else if(rbKodi.Checked)
            {
                try
                {
                    string timeJSONRequest = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetProperties"", ""params"": {""properties"": [""time"", ""speed""], ""playerid"": 1}, ""id"": 1}";
                    string filenameJSONRequest = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetItem"", ""params"": {""properties"": [""file""], ""playerid"": 1}, ""id"": 1 }";
                    string timeJSONResponse;
                    string filenameJSONResponse;

                    using (var webClient = new WebClient())
                    {
                        timeJSONResponse = webClient.UploadString($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", "POST", timeJSONRequest);
                        filenameJSONResponse = webClient.UploadString($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc", "POST", filenameJSONRequest);
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

                    TimeSpan t = TimeSpan.FromMilliseconds(positionMS);
                    return t.ToString("G").Substring(2, 12);
                }
                catch
                {
                    MessageBox.Show(this, "Can't connect to Kodi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return null;
        }

        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog.FileName;
                LoadFile(openFileDialog.FileName);
            }
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
            gvCodes.Sort(gvCodes.Columns["TimeCode"], System.ComponentModel.ListSortDirection.Ascending);
            saved = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
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

                MessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error, not saved.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WindTrackCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            _hookNum0.Unregister();
            _hookNum1.Unregister();
            _hookNum4.Unregister();
            _hookNum5.Unregister();
            _hookNum7.Unregister();

            SaveProgramSettings();
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
        }

        private void WindTrackCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!saved)
            {
                DialogResult result = MessageBox.Show(this, "File not saved, do you want to save?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    SaveFile();
                    e.Cancel = true;
                }
            }
        }

        private void gvCodes_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        saved = false;
                        UpdateCodeCount();
                    }
                    catch { }
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
                    WebRequest request = WebRequest.Create($"http://{tbIP.Text}:{tbPort.Text}/command.html");
                    string postData = "wm_command=-1&position=" + timeCode;

                    byte[] data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
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
                    WebRequest request = WebRequest.Create($"http://{tbIP.Text}:{tbPort.Text}/jsonrpc");
                    string postData = $@"{{""jsonrpc"":""2.0"", ""method"":""Player.Seek"", ""params"": {{ ""playerid"":1, ""value"":{{ ""hours"": {TimeSpan.Parse(timeCode).Hours}, ""minutes"": {TimeSpan.Parse(timeCode).Minutes}, ""seconds"": {TimeSpan.Parse(timeCode).Seconds}, ""milliseconds"": {TimeSpan.Parse(timeCode).Milliseconds} }} }}, ""id"":1}}";

                    byte[] data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = data.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch
                {
                    MessageBox.Show(this, "Can't connect to Kodi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if (fileList.Length > 0)
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

        private void btnCMD_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AddCode(btn.Tag.ToString());
        }

        private void gvCodes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            saved = false;
            UpdateCodeCount();
        }

        private void gvCodes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            saved = false;
            UpdateCodeCount();
        }

        public string GetRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return regKey.GetValue(key).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool CheckRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return (regKey.GetValueNames().Contains(key));
            }
            catch
            {
                return false;
            }
        }

        private void UpdateCodeCount()
        {
            lblCommandCount.Text = "Total Commands: " + (gvCodes.Rows.Count - 1).ToString();
        }

        private void cbDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDarkMode.Checked)
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
        }

        private void SetDarkMode()
        {
            BackColor = ColorTranslator.FromHtml("#2d2d2d");
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

            tbIP.BackColor = Color.Black;
            tbIP.ForeColor = Color.White;

            tbPort.BackColor = Color.Black;
            tbPort.ForeColor = Color.White;

            tbHeader.BackColor = Color.Black;
            tbHeader.ForeColor = Color.White;

            gvCodes.BackgroundColor = ColorTranslator.FromHtml("#242424");
            gvCodes.DefaultCellStyle.BackColor = Color.Black;
            gvCodes.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gvCodes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewButtonColumn seek = (DataGridViewButtonColumn)gvCodes.Columns["Seek"];
            seek.FlatStyle = FlatStyle.Popup;
            seek.DefaultCellStyle.BackColor = Color.Black;
            seek.DefaultCellStyle.ForeColor = Color.White;

            DataGridViewButtonColumn delete = (DataGridViewButtonColumn)gvCodes.Columns["Delete"];
            delete.FlatStyle = FlatStyle.Popup;
            delete.DefaultCellStyle.BackColor = Color.Black;
            delete.DefaultCellStyle.ForeColor = Color.White;
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

            tbIP.BackColor = Color.White;
            tbIP.ForeColor = Color.Black;

            tbPort.BackColor = Color.White;
            tbPort.ForeColor = Color.Black;

            tbHeader.BackColor = Color.White;
            tbHeader.ForeColor = Color.Black;

            gvCodes.BackgroundColor = _gvBackColor;
            gvCodes.DefaultCellStyle.BackColor = Color.White;
            gvCodes.ColumnHeadersDefaultCellStyle.BackColor = _gvHeaderBackColor;
            gvCodes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            DataGridViewButtonColumn seek = (DataGridViewButtonColumn)gvCodes.Columns["Seek"];
            seek.FlatStyle = _gvBtnStyle;
            seek.DefaultCellStyle.BackColor = _gvBtnBackColor;
            seek.DefaultCellStyle.ForeColor = _gvBtnForeColor;

            DataGridViewButtonColumn delete = (DataGridViewButtonColumn)gvCodes.Columns["Delete"];
            delete.FlatStyle = _gvBtnStyle;
            delete.DefaultCellStyle.BackColor = _gvBtnBackColor;
            delete.DefaultCellStyle.ForeColor = _gvBtnForeColor;
        }
    }
}