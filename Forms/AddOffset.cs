using System;
using System.Net.Http;
using System.Windows.Forms;

namespace WindTrackCreator.Forms
{
    public partial class AddOffset : Form
    {
        public TimeSpan timeCodeOffset;
        private string _MPCconn;
        public AddOffset(string MPCconn)
        {
            _MPCconn = MPCconn;
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            bool save;
            try
            {
                timeCodeOffset = TimeSpan.Parse(tbTimeCode.Text);

                if(btnSign.Text == "-")
                {
                    timeCodeOffset = timeCodeOffset.Negate();
                }

                DialogResult = DialogResult.OK;
                save = true;
            }
            catch
            {
                MessageBox.Show("Invalid TimeCode Entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                save = false;
            }

            if(save)
            {
                Close();
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(btnSign.Text == "+")
            {
                btnSign.Text = "-";
            }
            else
            {
                btnSign.Text = "+";
            }
        }

        private void btnMPC_Click(object sender, EventArgs e)
        {
            try
            {
                string html;
                using (HttpClient httpClient = new HttpClient())
                {
                    html = httpClient.GetStringAsync($"http://{_MPCconn}/variables.html").Result;
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                string position = doc.GetElementbyId("position").InnerText;
                long positionMS = Int64.Parse(position);

                TimeSpan ts = TimeSpan.FromMilliseconds(positionMS);
                tbTimeCode.Text = ts.ToString("G").Substring(2, 12);
            }
            catch
            {
                MessageBox.Show(this, "Can't connect to MPC.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}