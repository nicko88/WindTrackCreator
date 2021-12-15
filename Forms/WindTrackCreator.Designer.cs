namespace WindTrackCreator
{
    partial class WindTrackCreator
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindTrackCreator));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblCommandCount = new System.Windows.Forms.Label();
            this.gvCodes = new System.Windows.Forms.DataGridView();
            this.TimeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FanSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seek = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rbMPC = new System.Windows.Forms.RadioButton();
            this.rbKodi = new System.Windows.Forms.RadioButton();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnECO = new System.Windows.Forms.Button();
            this.btnLOW = new System.Windows.Forms.Button();
            this.btnMED = new System.Windows.Forms.Button();
            this.btnHIGH = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbHeader = new System.Windows.Forms.RichTextBox();
            this.cbAutosave = new System.Windows.Forms.CheckBox();
            this.cbHotkeys = new System.Windows.Forms.CheckBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFillHeader = new System.Windows.Forms.Button();
            this.cbDarkmode = new System.Windows.Forms.CheckBox();
            this.timerAutosave = new System.Windows.Forms.Timer(this.components);
            this.lblSaved = new System.Windows.Forms.Label();
            this.autosaveLabelUpdate = new System.ComponentModel.BackgroundWorker();
            this.rbBluray = new System.Windows.Forms.RadioButton();
            this.rbUHD = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSpinup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSpindown = new System.Windows.Forms.TextBox();
            this.btnFingerprint = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvCodes)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Wind Track Files|*.txt";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(12, 28);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 26);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(458, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(92, 24);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(360, 32);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCommandCount
            // 
            this.lblCommandCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCommandCount.AutoSize = true;
            this.lblCommandCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommandCount.Location = new System.Drawing.Point(9, 887);
            this.lblCommandCount.Name = "lblCommandCount";
            this.lblCommandCount.Size = new System.Drawing.Size(0, 16);
            this.lblCommandCount.TabIndex = 4;
            // 
            // gvCodes
            // 
            this.gvCodes.AllowUserToDeleteRows = false;
            this.gvCodes.AllowUserToResizeColumns = false;
            this.gvCodes.AllowUserToResizeRows = false;
            this.gvCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCodes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCodes.ColumnHeadersHeight = 25;
            this.gvCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeCode,
            this.FanSpeed,
            this.Seek,
            this.Delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCodes.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvCodes.EnableHeadersVisualStyles = false;
            this.gvCodes.Location = new System.Drawing.Point(12, 223);
            this.gvCodes.MultiSelect = false;
            this.gvCodes.Name = "gvCodes";
            this.gvCodes.RowHeadersVisible = false;
            this.gvCodes.Size = new System.Drawing.Size(523, 643);
            this.gvCodes.TabIndex = 5;
            this.gvCodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCodes_CellContentClick);
            this.gvCodes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCodes_CellEndEdit);
            this.gvCodes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvCodes_RowsAdded);
            // 
            // TimeCode
            // 
            this.TimeCode.DataPropertyName = "TimeCode";
            this.TimeCode.HeaderText = "Time Code";
            this.TimeCode.Name = "TimeCode";
            this.TimeCode.Width = 120;
            // 
            // FanSpeed
            // 
            this.FanSpeed.DataPropertyName = "FanSpeed";
            this.FanSpeed.HeaderText = "Fan Speed";
            this.FanSpeed.Name = "FanSpeed";
            // 
            // Seek
            // 
            this.Seek.DataPropertyName = "Seek";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Seek";
            this.Seek.DefaultCellStyle = dataGridViewCellStyle2;
            this.Seek.HeaderText = "Jump To Time";
            this.Seek.Name = "Seek";
            this.Seek.Text = "Seek";
            this.Seek.Width = 105;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Delete";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle3;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            // 
            // rbMPC
            // 
            this.rbMPC.AutoSize = true;
            this.rbMPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMPC.Location = new System.Drawing.Point(3, 4);
            this.rbMPC.Name = "rbMPC";
            this.rbMPC.Size = new System.Drawing.Size(100, 20);
            this.rbMPC.TabIndex = 6;
            this.rbMPC.Text = "MPC-HC/BE";
            this.rbMPC.UseVisualStyleBackColor = true;
            this.rbMPC.CheckedChanged += new System.EventHandler(this.rbMPC_CheckedChanged);
            // 
            // rbKodi
            // 
            this.rbKodi.AutoSize = true;
            this.rbKodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKodi.Location = new System.Drawing.Point(106, 4);
            this.rbKodi.Name = "rbKodi";
            this.rbKodi.Size = new System.Drawing.Size(53, 20);
            this.rbKodi.TabIndex = 7;
            this.rbKodi.Text = "Kodi";
            this.rbKodi.UseVisualStyleBackColor = true;
            this.rbKodi.CheckedChanged += new System.EventHandler(this.rbKodi_CheckedChanged);
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIP.Location = new System.Drawing.Point(199, 59);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 22);
            this.tbIP.TabIndex = 8;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(343, 59);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 22);
            this.tbPort.TabIndex = 9;
            this.tbPort.Text = "13579";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(176, 62);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(23, 16);
            this.lblIP.TabIndex = 10;
            this.lblIP.Text = "IP:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(308, 62);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 16);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "Port:";
            // 
            // btnOFF
            // 
            this.btnOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOFF.Location = new System.Drawing.Point(11, 119);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(100, 26);
            this.btnOFF.TabIndex = 12;
            this.btnOFF.Tag = "OFF";
            this.btnOFF.Text = "OFF (Num0)";
            this.btnOFF.UseVisualStyleBackColor = true;
            this.btnOFF.Click += new System.EventHandler(this.btnCMD_Click);
            // 
            // btnECO
            // 
            this.btnECO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnECO.Location = new System.Drawing.Point(117, 119);
            this.btnECO.Name = "btnECO";
            this.btnECO.Size = new System.Drawing.Size(100, 26);
            this.btnECO.TabIndex = 13;
            this.btnECO.Tag = "ECO";
            this.btnECO.Text = "ECO (Num5)";
            this.btnECO.UseVisualStyleBackColor = true;
            this.btnECO.Click += new System.EventHandler(this.btnCMD_Click);
            // 
            // btnLOW
            // 
            this.btnLOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLOW.Location = new System.Drawing.Point(223, 119);
            this.btnLOW.Name = "btnLOW";
            this.btnLOW.Size = new System.Drawing.Size(100, 26);
            this.btnLOW.TabIndex = 14;
            this.btnLOW.Tag = "LOW";
            this.btnLOW.Text = "LOW (Num1)";
            this.btnLOW.UseVisualStyleBackColor = true;
            this.btnLOW.Click += new System.EventHandler(this.btnCMD_Click);
            // 
            // btnMED
            // 
            this.btnMED.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMED.Location = new System.Drawing.Point(329, 119);
            this.btnMED.Name = "btnMED";
            this.btnMED.Size = new System.Drawing.Size(100, 26);
            this.btnMED.TabIndex = 15;
            this.btnMED.Tag = "MED";
            this.btnMED.Text = "MED (Num4)";
            this.btnMED.UseVisualStyleBackColor = true;
            this.btnMED.Click += new System.EventHandler(this.btnCMD_Click);
            // 
            // btnHIGH
            // 
            this.btnHIGH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHIGH.Location = new System.Drawing.Point(435, 119);
            this.btnHIGH.Name = "btnHIGH";
            this.btnHIGH.Size = new System.Drawing.Size(100, 26);
            this.btnHIGH.TabIndex = 16;
            this.btnHIGH.Tag = "HIGH";
            this.btnHIGH.Text = "HIGH (Num7)";
            this.btnHIGH.UseVisualStyleBackColor = true;
            this.btnHIGH.Click += new System.EventHandler(this.btnCMD_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "Wind Track Files|*.txt";
            // 
            // tbHeader
            // 
            this.tbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeader.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeader.Location = new System.Drawing.Point(12, 151);
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(523, 66);
            this.tbHeader.TabIndex = 17;
            this.tbHeader.Text = "";
            // 
            // cbAutosave
            // 
            this.cbAutosave.AutoSize = true;
            this.cbAutosave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutosave.Location = new System.Drawing.Point(448, 56);
            this.cbAutosave.Name = "cbAutosave";
            this.cbAutosave.Size = new System.Drawing.Size(84, 20);
            this.cbAutosave.TabIndex = 18;
            this.cbAutosave.Text = "Autosave";
            this.cbAutosave.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbAutosave.UseVisualStyleBackColor = true;
            this.cbAutosave.CheckedChanged += new System.EventHandler(this.cbAutosave_CheckedChanged);
            // 
            // cbHotkeys
            // 
            this.cbHotkeys.AutoSize = true;
            this.cbHotkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHotkeys.Location = new System.Drawing.Point(448, 97);
            this.cbHotkeys.Name = "cbHotkeys";
            this.cbHotkeys.Size = new System.Drawing.Size(77, 20);
            this.cbHotkeys.TabIndex = 19;
            this.cbHotkeys.Text = "Hotkeys";
            this.cbHotkeys.UseVisualStyleBackColor = true;
            this.cbHotkeys.CheckedChanged += new System.EventHandler(this.cbHotkeys_CheckedChanged);
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(86, 89);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(131, 22);
            this.tbUsername.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Coded By:";
            // 
            // btnFillHeader
            // 
            this.btnFillHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillHeader.Location = new System.Drawing.Point(329, 87);
            this.btnFillHeader.Name = "btnFillHeader";
            this.btnFillHeader.Size = new System.Drawing.Size(100, 26);
            this.btnFillHeader.TabIndex = 22;
            this.btnFillHeader.Tag = "";
            this.btnFillHeader.Text = "Fill Header";
            this.btnFillHeader.UseVisualStyleBackColor = true;
            this.btnFillHeader.Click += new System.EventHandler(this.btnFillHeader_Click);
            // 
            // cbDarkmode
            // 
            this.cbDarkmode.AutoSize = true;
            this.cbDarkmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDarkmode.Location = new System.Drawing.Point(448, 76);
            this.cbDarkmode.Name = "cbDarkmode";
            this.cbDarkmode.Size = new System.Drawing.Size(94, 20);
            this.cbDarkmode.TabIndex = 23;
            this.cbDarkmode.Text = "Dark Mode";
            this.cbDarkmode.UseVisualStyleBackColor = true;
            this.cbDarkmode.CheckedChanged += new System.EventHandler(this.cbDarkmode_CheckedChanged);
            // 
            // timerAutosave
            // 
            this.timerAutosave.Interval = 60000;
            this.timerAutosave.Tick += new System.EventHandler(this.timerAutosave_Tick);
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSaved.Location = new System.Drawing.Point(396, 57);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(51, 16);
            this.lblSaved.TabIndex = 24;
            this.lblSaved.Text = "Saved!";
            this.lblSaved.Visible = false;
            // 
            // autosaveLabelUpdate
            // 
            this.autosaveLabelUpdate.WorkerReportsProgress = true;
            this.autosaveLabelUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.autosaveLabelUpdate_DoWork);
            this.autosaveLabelUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.autosaveLabelUpdate_ProgressChanged);
            // 
            // rbBluray
            // 
            this.rbBluray.AutoSize = true;
            this.rbBluray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBluray.Location = new System.Drawing.Point(243, 82);
            this.rbBluray.Name = "rbBluray";
            this.rbBluray.Size = new System.Drawing.Size(68, 20);
            this.rbBluray.TabIndex = 25;
            this.rbBluray.Text = "Blu-ray";
            this.rbBluray.UseVisualStyleBackColor = true;
            this.rbBluray.CheckedChanged += new System.EventHandler(this.rbBluray_CheckedChanged);
            // 
            // rbUHD
            // 
            this.rbUHD.AutoSize = true;
            this.rbUHD.Checked = true;
            this.rbUHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUHD.Location = new System.Drawing.Point(243, 99);
            this.rbUHD.Name = "rbUHD";
            this.rbUHD.Size = new System.Drawing.Size(56, 20);
            this.rbUHD.TabIndex = 26;
            this.rbUHD.TabStop = true;
            this.rbUHD.Text = "UHD";
            this.rbUHD.UseVisualStyleBackColor = true;
            this.rbUHD.CheckedChanged += new System.EventHandler(this.rbUHD_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbMPC);
            this.panel1.Controls.Add(this.rbKodi);
            this.panel1.Location = new System.Drawing.Point(8, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 27);
            this.panel1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 869);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "Spinup Offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSpinup
            // 
            this.tbSpinup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpinup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpinup.Location = new System.Drawing.Point(377, 876);
            this.tbSpinup.Name = "tbSpinup";
            this.tbSpinup.Size = new System.Drawing.Size(38, 22);
            this.tbSpinup.TabIndex = 28;
            this.tbSpinup.Text = "1000";
            this.tbSpinup.TextChanged += new System.EventHandler(this.tbSpinup_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(421, 869);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 36);
            this.label3.TabIndex = 31;
            this.label3.Text = "Spindown Offset:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSpindown
            // 
            this.tbSpindown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpindown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpindown.Location = new System.Drawing.Point(497, 876);
            this.tbSpindown.Name = "tbSpindown";
            this.tbSpindown.Size = new System.Drawing.Size(38, 22);
            this.tbSpindown.TabIndex = 30;
            this.tbSpindown.Text = "250";
            this.tbSpindown.TextChanged += new System.EventHandler(this.tbSpindown_TextChanged);
            // 
            // btnFingerprint
            // 
            this.btnFingerprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFingerprint.Enabled = false;
            this.btnFingerprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFingerprint.Location = new System.Drawing.Point(167, 872);
            this.btnFingerprint.Name = "btnFingerprint";
            this.btnFingerprint.Size = new System.Drawing.Size(132, 33);
            this.btnFingerprint.TabIndex = 32;
            this.btnFingerprint.Text = "Create Fingerprints";
            this.btnFingerprint.UseVisualStyleBackColor = true;
            this.btnFingerprint.Click += new System.EventHandler(this.btnFingerprint_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(547, 24);
            this.menuStrip.TabIndex = 33;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOffsetToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // addOffsetToolStripMenuItem
            // 
            this.addOffsetToolStripMenuItem.Name = "addOffsetToolStripMenuItem";
            this.addOffsetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addOffsetToolStripMenuItem.Text = "Apply an Offset";
            this.addOffsetToolStripMenuItem.Click += new System.EventHandler(this.addOffsetToolStripMenuItem_Click);
            // 
            // WindTrackCreator
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 911);
            this.Controls.Add(this.btnFingerprint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSpindown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpinup);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbUHD);
            this.Controls.Add(this.rbBluray);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.cbDarkmode);
            this.Controls.Add(this.btnFillHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.cbHotkeys);
            this.Controls.Add(this.cbAutosave);
            this.Controls.Add(this.tbHeader);
            this.Controls.Add(this.btnHIGH);
            this.Controls.Add(this.btnMED);
            this.Controls.Add(this.btnLOW);
            this.Controls.Add(this.btnECO);
            this.Controls.Add(this.btnOFF);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.gvCodes);
            this.Controls.Add(this.lblCommandCount);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "WindTrackCreator";
            this.Text = "Wind Track Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindTrackCreator_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindTrackCreator_FormClosed);
            this.Load += new System.EventHandler(this.WindTrackCreator_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WindTrackCreator_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WindTrackCreator_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.gvCodes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblCommandCount;
        private System.Windows.Forms.DataGridView gvCodes;
        private System.Windows.Forms.RadioButton rbMPC;
        private System.Windows.Forms.RadioButton rbKodi;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnECO;
        private System.Windows.Forms.Button btnLOW;
        private System.Windows.Forms.Button btnMED;
        private System.Windows.Forms.Button btnHIGH;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox tbHeader;
        private System.Windows.Forms.CheckBox cbAutosave;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FanSpeed;
        private System.Windows.Forms.DataGridViewButtonColumn Seek;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.CheckBox cbHotkeys;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFillHeader;
        private System.Windows.Forms.CheckBox cbDarkmode;
        private System.Windows.Forms.Timer timerAutosave;
        private System.Windows.Forms.Label lblSaved;
        private System.ComponentModel.BackgroundWorker autosaveLabelUpdate;
        private System.Windows.Forms.RadioButton rbBluray;
        private System.Windows.Forms.RadioButton rbUHD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSpinup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSpindown;
        private System.Windows.Forms.Button btnFingerprint;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOffsetToolStripMenuItem;
    }
}

