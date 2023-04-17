using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindTrackCreator.Forms
{
    public partial class CustomCommands : Form
    {
        private readonly string _rootPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        private WindTrackCreator _WTC;

        private Color _defaultBackColor;
        private Color _defaultForeColor;
        private Color _defaultBtnBackColor;
        private Color _defaultBtnForeColor;

        public CustomCommands(WindTrackCreator WTC)
        {
            _WTC = WTC;
            InitializeComponent();
            _defaultBackColor = BackColor;
            _defaultForeColor = ForeColor;
            _defaultBtnBackColor = btnCmd1.BackColor;
            _defaultBtnForeColor = btnCmd1.ForeColor;

            LoadCommands();
        }

        private void LoadCommands()
        {
            try
            {
                string[] cmds = File.ReadAllLines(Path.Combine(_rootPath, "CustomCommands.txt"));

                tbCmd1.Text = cmds[0].Split(',')[0];
                tbOffset1.Text = cmds[0].Split(',')[1];

                tbCmd2.Text = cmds[1].Split(',')[0];
                tbOffset2.Text = cmds[1].Split(',')[1];

                tbCmd3.Text = cmds[2].Split(',')[0];
                tbOffset3.Text = cmds[2].Split(',')[1];

                tbCmd4.Text = cmds[3].Split(',')[0];
                tbOffset4.Text = cmds[3].Split(',')[1];

                tbCmd5.Text = cmds[4].Split(',')[0];
                tbOffset5.Text = cmds[4].Split(',')[1];

                tbCmd6.Text = cmds[5].Split(',')[0];
                tbOffset6.Text = cmds[5].Split(',')[1];

                tbCmd7.Text = cmds[6].Split(',')[0];
                tbOffset7.Text = cmds[6].Split(',')[1];

                tbCmd8.Text = cmds[7].Split(',')[0];
                tbOffset8.Text = cmds[7].Split(',')[1];

                tbCmd9.Text = cmds[8].Split(',')[0];
                tbOffset9.Text = cmds[8].Split(',')[1];

                tbCmd10.Text = cmds[9].Split(',')[0];
                tbOffset10.Text = cmds[9].Split(',')[1];
            }
            catch { }
        }

        private void btnCmd1_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd1.Text, Convert.ToInt64(tbOffset1.Text));
        }

        private void btnCmd2_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd2.Text, Convert.ToInt64(tbOffset2.Text));
        }

        private void btnCmd3_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd3.Text, Convert.ToInt64(tbOffset3.Text));
        }

        private void btnCmd4_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd4.Text, Convert.ToInt64(tbOffset4.Text));
        }

        private void btnCmd5_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd5.Text, Convert.ToInt64(tbOffset5.Text));
        }

        private void btnCmd6_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd6.Text, Convert.ToInt64(tbOffset6.Text));
        }

        private void btnCmd7_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd7.Text, Convert.ToInt64(tbOffset7.Text));
        }

        private void btnCmd8_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd8.Text, Convert.ToInt64(tbOffset8.Text));
        }

        private void btnCmd9_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd9.Text, Convert.ToInt64(tbOffset9.Text));
        }

        private void btnCmd10_Click(object sender, EventArgs e)
        {
            _WTC.AddCode(tbCmd10.Text, Convert.ToInt64(tbOffset10.Text));
        }

        private void CustomCommands_FormClosing(object sender, FormClosingEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{tbCmd1.Text},{tbOffset1.Text}");
            sb.AppendLine($"{tbCmd2.Text},{tbOffset2.Text}");
            sb.AppendLine($"{tbCmd3.Text},{tbOffset3.Text}");
            sb.AppendLine($"{tbCmd4.Text},{tbOffset4.Text}");
            sb.AppendLine($"{tbCmd5.Text},{tbOffset5.Text}");
            sb.AppendLine($"{tbCmd6.Text},{tbOffset6.Text}");
            sb.AppendLine($"{tbCmd7.Text},{tbOffset7.Text}");
            sb.AppendLine($"{tbCmd8.Text},{tbOffset8.Text}");
            sb.AppendLine($"{tbCmd9.Text},{tbOffset9.Text}");
            sb.AppendLine($"{tbCmd10.Text},{tbOffset10.Text}");

            File.WriteAllText(Path.Combine(_rootPath, "CustomCommands.txt"), sb.ToString());
        }

        public void SetDarkMode()
        {
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.White;

            btnCmd1.BackColor = Color.Black;
            btnCmd1.ForeColor = Color.White;
            btnCmd2.BackColor = Color.Black;
            btnCmd2.ForeColor = Color.White;
            btnCmd3.BackColor = Color.Black;
            btnCmd3.ForeColor = Color.White;
            btnCmd4.BackColor = Color.Black;
            btnCmd4.ForeColor = Color.White;
            btnCmd5.BackColor = Color.Black;
            btnCmd5.ForeColor = Color.White;
            btnCmd6.BackColor = Color.Black;
            btnCmd6.ForeColor = Color.White;
            btnCmd7.BackColor = Color.Black;
            btnCmd7.ForeColor = Color.White;
            btnCmd8.BackColor = Color.Black;
            btnCmd8.ForeColor = Color.White;
            btnCmd9.BackColor = Color.Black;
            btnCmd9.ForeColor = Color.White;
            btnCmd10.BackColor = Color.Black;
            btnCmd10.ForeColor = Color.White;

            tbCmd1.BackColor = Color.Black;
            tbCmd1.ForeColor = Color.White;
            tbCmd2.BackColor = Color.Black;
            tbCmd2.ForeColor = Color.White;
            tbCmd3.BackColor = Color.Black;
            tbCmd3.ForeColor = Color.White;
            tbCmd4.BackColor = Color.Black;
            tbCmd4.ForeColor = Color.White;
            tbCmd5.BackColor = Color.Black;
            tbCmd5.ForeColor = Color.White;
            tbCmd6.BackColor = Color.Black;
            tbCmd6.ForeColor = Color.White;
            tbCmd7.BackColor = Color.Black;
            tbCmd7.ForeColor = Color.White;
            tbCmd8.BackColor = Color.Black;
            tbCmd8.ForeColor = Color.White;
            tbCmd9.BackColor = Color.Black;
            tbCmd9.ForeColor = Color.White;
            tbCmd10.BackColor = Color.Black;
            tbCmd10.ForeColor = Color.White;

            tbOffset1.BackColor = Color.Black;
            tbOffset1.ForeColor = Color.White;
            tbOffset2.BackColor = Color.Black;
            tbOffset2.ForeColor = Color.White;
            tbOffset3.BackColor = Color.Black;
            tbOffset3.ForeColor = Color.White;
            tbOffset4.BackColor = Color.Black;
            tbOffset4.ForeColor = Color.White;
            tbOffset5.BackColor = Color.Black;
            tbOffset5.ForeColor = Color.White;
            tbOffset6.BackColor = Color.Black;
            tbOffset6.ForeColor = Color.White;
            tbOffset7.BackColor = Color.Black;
            tbOffset7.ForeColor = Color.White;
            tbOffset8.BackColor = Color.Black;
            tbOffset8.ForeColor = Color.White;
            tbOffset9.BackColor = Color.Black;
            tbOffset9.ForeColor = Color.White;
            tbOffset10.BackColor = Color.Black;
            tbOffset10.ForeColor = Color.White;
        }

        public void SetLightMode()
        {
            BackColor = _defaultBackColor;
            ForeColor = _defaultForeColor;

            btnCmd1.BackColor = _defaultBtnBackColor;
            btnCmd1.ForeColor = _defaultBtnForeColor;
            btnCmd2.BackColor = _defaultBtnBackColor;
            btnCmd2.ForeColor = _defaultBtnForeColor;
            btnCmd3.BackColor = _defaultBtnBackColor;
            btnCmd3.ForeColor = _defaultBtnForeColor;
            btnCmd4.BackColor = _defaultBtnBackColor;
            btnCmd4.ForeColor = _defaultBtnForeColor;
            btnCmd5.BackColor = _defaultBtnBackColor;
            btnCmd5.ForeColor = _defaultBtnForeColor;
            btnCmd6.BackColor = _defaultBtnBackColor;
            btnCmd6.ForeColor = _defaultBtnForeColor;
            btnCmd7.BackColor = _defaultBtnBackColor;
            btnCmd7.ForeColor = _defaultBtnForeColor;
            btnCmd8.BackColor = _defaultBtnBackColor;
            btnCmd8.ForeColor = _defaultBtnForeColor;
            btnCmd9.BackColor = _defaultBtnBackColor;
            btnCmd9.ForeColor = _defaultBtnForeColor;
            btnCmd10.BackColor = _defaultBtnBackColor;
            btnCmd10.ForeColor = _defaultBtnForeColor;

            tbCmd1.BackColor = Color.White;
            tbCmd1.ForeColor = Color.Black;
            tbCmd2.BackColor = Color.White;
            tbCmd2.ForeColor = Color.Black;
            tbCmd3.BackColor = Color.White;
            tbCmd3.ForeColor = Color.Black;
            tbCmd4.BackColor = Color.White;
            tbCmd4.ForeColor = Color.Black;
            tbCmd5.BackColor = Color.White;
            tbCmd5.ForeColor = Color.Black;
            tbCmd6.BackColor = Color.White;
            tbCmd6.ForeColor = Color.Black;
            tbCmd7.BackColor = Color.White;
            tbCmd7.ForeColor = Color.Black;
            tbCmd8.BackColor = Color.White;
            tbCmd8.ForeColor = Color.Black;
            tbCmd9.BackColor = Color.White;
            tbCmd9.ForeColor = Color.Black;
            tbCmd10.BackColor = Color.White;
            tbCmd10.ForeColor = Color.Black;

            tbOffset1.BackColor = Color.White;
            tbOffset1.ForeColor = Color.Black;
            tbOffset2.BackColor = Color.White;
            tbOffset2.ForeColor = Color.Black;
            tbOffset3.BackColor = Color.White;
            tbOffset3.ForeColor = Color.Black;
            tbOffset4.BackColor = Color.White;
            tbOffset4.ForeColor = Color.Black;
            tbOffset5.BackColor = Color.White;
            tbOffset5.ForeColor = Color.Black;
            tbOffset6.BackColor = Color.White;
            tbOffset6.ForeColor = Color.Black;
            tbOffset7.BackColor = Color.White;
            tbOffset7.ForeColor = Color.Black;
            tbOffset8.BackColor = Color.White;
            tbOffset8.ForeColor = Color.Black;
            tbOffset9.BackColor = Color.White;
            tbOffset9.ForeColor = Color.Black;
            tbOffset10.BackColor = Color.White;
            tbOffset10.ForeColor = Color.Black;
        }
    }
}