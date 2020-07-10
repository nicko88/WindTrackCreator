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
            this.cbDarkMode = new System.Windows.Forms.CheckBox();
            this.TimeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FanSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seek = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvCodes)).BeginInit();
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
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
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
            this.btnSave.Location = new System.Drawing.Point(458, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(92, 18);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 16);
            this.lblFilePath.TabIndex = 3;
            // 
            // lblCommandCount
            // 
            this.lblCommandCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCommandCount.AutoSize = true;
            this.lblCommandCount.Location = new System.Drawing.Point(9, 893);
            this.lblCommandCount.Name = "lblCommandCount";
            this.lblCommandCount.Size = new System.Drawing.Size(0, 13);
            this.lblCommandCount.TabIndex = 4;
            // 
            // gvCodes
            // 
            this.gvCodes.AllowUserToDeleteRows = false;
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
            this.gvCodes.Location = new System.Drawing.Point(12, 174);
            this.gvCodes.MultiSelect = false;
            this.gvCodes.Name = "gvCodes";
            this.gvCodes.RowHeadersVisible = false;
            this.gvCodes.Size = new System.Drawing.Size(523, 713);
            this.gvCodes.TabIndex = 5;
            this.gvCodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCodes_CellContentClick);
            this.gvCodes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCodes_CellEndEdit);
            this.gvCodes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvCodes_RowsAdded);
            // 
            // rbMPC
            // 
            this.rbMPC.AutoSize = true;
            this.rbMPC.Checked = true;
            this.rbMPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMPC.Location = new System.Drawing.Point(13, 44);
            this.rbMPC.Name = "rbMPC";
            this.rbMPC.Size = new System.Drawing.Size(100, 20);
            this.rbMPC.TabIndex = 6;
            this.rbMPC.TabStop = true;
            this.rbMPC.Text = "MPC-HC/BE";
            this.rbMPC.UseVisualStyleBackColor = true;
            this.rbMPC.CheckedChanged += new System.EventHandler(this.rbMPC_CheckedChanged);
            // 
            // rbKodi
            // 
            this.rbKodi.AutoSize = true;
            this.rbKodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKodi.Location = new System.Drawing.Point(116, 44);
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
            this.tbIP.Location = new System.Drawing.Point(199, 43);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 22);
            this.tbIP.TabIndex = 8;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(343, 43);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 22);
            this.tbPort.TabIndex = 9;
            this.tbPort.Text = "13579";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(176, 46);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(23, 16);
            this.lblIP.TabIndex = 10;
            this.lblIP.Text = "IP:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(308, 46);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 16);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "Port:";
            // 
            // btnOFF
            // 
            this.btnOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOFF.Location = new System.Drawing.Point(12, 70);
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
            this.btnECO.Location = new System.Drawing.Point(118, 70);
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
            this.btnLOW.Location = new System.Drawing.Point(224, 70);
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
            this.btnMED.Location = new System.Drawing.Point(330, 70);
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
            this.btnHIGH.Location = new System.Drawing.Point(436, 70);
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
            this.tbHeader.Location = new System.Drawing.Point(12, 102);
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(523, 66);
            this.tbHeader.TabIndex = 17;
            this.tbHeader.Text = "";
            // 
            // cbDarkMode
            // 
            this.cbDarkMode.AutoSize = true;
            this.cbDarkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDarkMode.Location = new System.Drawing.Point(436, 45);
            this.cbDarkMode.Name = "cbDarkMode";
            this.cbDarkMode.Size = new System.Drawing.Size(94, 20);
            this.cbDarkMode.TabIndex = 18;
            this.cbDarkMode.Text = "Dark Mode";
            this.cbDarkMode.UseVisualStyleBackColor = true;
            this.cbDarkMode.CheckedChanged += new System.EventHandler(this.cbDarkMode_CheckedChanged);
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
            // WindTrackCreator
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 911);
            this.Controls.Add(this.cbDarkMode);
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
            this.Controls.Add(this.rbKodi);
            this.Controls.Add(this.rbMPC);
            this.Controls.Add(this.gvCodes);
            this.Controls.Add(this.lblCommandCount);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindTrackCreator";
            this.Text = "Wind Track Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindTrackCreator_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindTrackCreator_FormClosed);
            this.Load += new System.EventHandler(this.WindTrackCreator_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WindTrackCreator_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WindTrackCreator_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.gvCodes)).EndInit();
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
        private System.Windows.Forms.CheckBox cbDarkMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FanSpeed;
        private System.Windows.Forms.DataGridViewButtonColumn Seek;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

