
namespace WindTrackCreator
{
    partial class AudioFingerprintCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioFingerprintCreator));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFFmpeg = new System.Windows.Forms.Label();
            this.lnkFFmpeg = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTrackname = new System.Windows.Forms.Label();
            this.tbWindtrackName = new System.Windows.Forms.TextBox();
            this.tbVideoPath = new System.Windows.Forms.RichTextBox();
            this.tbWorkingPath = new System.Windows.Forms.RichTextBox();
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.lblWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Video Files|*.mkv;*.mp4;*.m4v;*.m2ts;*.ts;*.vob;*.avi|All files|*.*";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 26);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open Video";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblFFmpeg
            // 
            this.lblFFmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFFmpeg.AutoSize = true;
            this.lblFFmpeg.Location = new System.Drawing.Point(454, 9);
            this.lblFFmpeg.Name = "lblFFmpeg";
            this.lblFFmpeg.Size = new System.Drawing.Size(78, 13);
            this.lblFFmpeg.TabIndex = 6;
            this.lblFFmpeg.Text = "FFmpeg Status";
            // 
            // lnkFFmpeg
            // 
            this.lnkFFmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFFmpeg.AutoSize = true;
            this.lnkFFmpeg.Location = new System.Drawing.Point(454, 25);
            this.lnkFFmpeg.Name = "lnkFFmpeg";
            this.lnkFFmpeg.Size = new System.Drawing.Size(104, 13);
            this.lnkFFmpeg.TabIndex = 7;
            this.lnkFFmpeg.TabStop = true;
            this.lnkFFmpeg.Text = "Click here to install...";
            this.lnkFFmpeg.Visible = false;
            this.lnkFFmpeg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFFmpeg_LinkClicked);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Temp folder:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFolder.Location = new System.Drawing.Point(12, 93);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(105, 26);
            this.btnChangeFolder.TabIndex = 10;
            this.btnChangeFolder.Text = "Change Folder";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lblTrackname
            // 
            this.lblTrackname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackname.Location = new System.Drawing.Point(4, 133);
            this.lblTrackname.Name = "lblTrackname";
            this.lblTrackname.Size = new System.Drawing.Size(113, 32);
            this.lblTrackname.TabIndex = 11;
            this.lblTrackname.Text = "Windtrack Package Name:";
            this.lblTrackname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbWindtrackName
            // 
            this.tbWindtrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWindtrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWindtrackName.Location = new System.Drawing.Point(129, 138);
            this.tbWindtrackName.Name = "tbWindtrackName";
            this.tbWindtrackName.Size = new System.Drawing.Size(425, 22);
            this.tbWindtrackName.TabIndex = 12;
            // 
            // tbVideoPath
            // 
            this.tbVideoPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoPath.Location = new System.Drawing.Point(129, 12);
            this.tbVideoPath.Name = "tbVideoPath";
            this.tbVideoPath.ReadOnly = true;
            this.tbVideoPath.Size = new System.Drawing.Size(319, 43);
            this.tbVideoPath.TabIndex = 13;
            this.tbVideoPath.Text = "";
            // 
            // tbWorkingPath
            // 
            this.tbWorkingPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkingPath.Location = new System.Drawing.Point(129, 76);
            this.tbWorkingPath.Name = "tbWorkingPath";
            this.tbWorkingPath.ReadOnly = true;
            this.tbWorkingPath.Size = new System.Drawing.Size(425, 43);
            this.tbWorkingPath.TabIndex = 14;
            this.tbWorkingPath.Text = "";
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePackage.Location = new System.Drawing.Point(217, 166);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(144, 56);
            this.btnCreatePackage.TabIndex = 15;
            this.btnCreatePackage.Text = "Create Windtrack/Fingerprint Zip Package";
            this.btnCreatePackage.UseVisualStyleBackColor = true;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // lblWait
            // 
            this.lblWait.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.Red;
            this.lblWait.Location = new System.Drawing.Point(383, 179);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(159, 25);
            this.lblWait.TabIndex = 16;
            this.lblWait.Text = "Please Wait...";
            this.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWait.Visible = false;
            // 
            // AudioFingerprintCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 228);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.btnCreatePackage);
            this.Controls.Add(this.tbWorkingPath);
            this.Controls.Add(this.tbVideoPath);
            this.Controls.Add(this.tbWindtrackName);
            this.Controls.Add(this.lblTrackname);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkFFmpeg);
            this.Controls.Add(this.lblFFmpeg);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AudioFingerprintCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audio Fingerprint Creator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AudioFingerprintCreator_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFFmpeg;
        private System.Windows.Forms.LinkLabel lnkFFmpeg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label lblTrackname;
        private System.Windows.Forms.TextBox tbWindtrackName;
        private System.Windows.Forms.RichTextBox tbVideoPath;
        private System.Windows.Forms.RichTextBox tbWorkingPath;
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Label lblWait;
    }
}