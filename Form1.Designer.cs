namespace SqlToFtp
{
    partial class Form1
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
            this.btnKerko = new System.Windows.Forms.Button();
            this.dataVGrid = new System.Windows.Forms.DataGridView();
            this.btnPastro = new System.Windows.Forms.Button();
            this.tbKerko = new System.Windows.Forms.TextBox();
            this.timerKerko = new System.Windows.Forms.Timer(this.components);
            this.conditionText = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnTTest = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkON = new System.Windows.Forms.CheckBox();
            this.checkOFF = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCloseDB = new System.Windows.Forms.Button();
            this.taskTest = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.resendButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataVGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKerko
            // 
            this.btnKerko.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKerko.Location = new System.Drawing.Point(166, 100);
            this.btnKerko.Name = "btnKerko";
            this.btnKerko.Size = new System.Drawing.Size(103, 39);
            this.btnKerko.TabIndex = 0;
            this.btnKerko.Text = "Kerko";
            this.btnKerko.UseVisualStyleBackColor = true;
            this.btnKerko.Click += new System.EventHandler(this.btnKerko_Click);
            // 
            // dataVGrid
            // 
            this.dataVGrid.AllowUserToAddRows = false;
            this.dataVGrid.AllowUserToOrderColumns = true;
            this.dataVGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataVGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskTest,
            this.resendButton});
            this.dataVGrid.Location = new System.Drawing.Point(3, 177);
            this.dataVGrid.Name = "dataVGrid";
            this.dataVGrid.Size = new System.Drawing.Size(621, 175);
            this.dataVGrid.TabIndex = 1;
            this.dataVGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataVGrid_CellClick);
            // 
            // btnPastro
            // 
            this.btnPastro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPastro.Location = new System.Drawing.Point(332, 100);
            this.btnPastro.Name = "btnPastro";
            this.btnPastro.Size = new System.Drawing.Size(108, 39);
            this.btnPastro.TabIndex = 2;
            this.btnPastro.Text = "Pastro";
            this.btnPastro.UseVisualStyleBackColor = true;
            this.btnPastro.Click += new System.EventHandler(this.btnPastro_Click);
            // 
            // tbKerko
            // 
            this.tbKerko.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKerko.Location = new System.Drawing.Point(123, 74);
            this.tbKerko.Name = "tbKerko";
            this.tbKerko.Size = new System.Drawing.Size(366, 20);
            this.tbKerko.TabIndex = 3;
            // 
            // timerKerko
            // 
            this.timerKerko.Interval = 5000;
            this.timerKerko.Tick += new System.EventHandler(this.timerKerko_Tick);
            // 
            // conditionText
            // 
            this.conditionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionText.AutoSize = true;
            this.conditionText.Location = new System.Drawing.Point(133, 37);
            this.conditionText.Name = "conditionText";
            this.conditionText.Size = new System.Drawing.Size(0, 13);
            this.conditionText.TabIndex = 4;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(24, 153);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(21, 13);
            this.ProgressLabel.TabIndex = 5;
            this.ProgressLabel.Text = "0%";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnTTest
            // 
            this.btnTTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTTest.Location = new System.Drawing.Point(540, 148);
            this.btnTTest.Name = "btnTTest";
            this.btnTTest.Size = new System.Drawing.Size(75, 23);
            this.btnTTest.TabIndex = 6;
            this.btnTTest.Text = "Database";
            this.btnTTest.UseVisualStyleBackColor = true;
            this.btnTTest.Click += new System.EventHandler(this.btnTTest_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(136, 148);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 23);
            this.progressBar.Step = 20;
            this.progressBar.TabIndex = 0;
            // 
            // checkON
            // 
            this.checkON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkON.AutoSize = true;
            this.checkON.Location = new System.Drawing.Point(540, 14);
            this.checkON.Name = "checkON";
            this.checkON.Size = new System.Drawing.Size(42, 17);
            this.checkON.TabIndex = 7;
            this.checkON.Text = "ON";
            this.checkON.UseVisualStyleBackColor = true;
            this.checkON.CheckedChanged += new System.EventHandler(this.checkON_CheckedChanged);
            // 
            // checkOFF
            // 
            this.checkOFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkOFF.AutoSize = true;
            this.checkOFF.Location = new System.Drawing.Point(492, 14);
            this.checkOFF.Name = "checkOFF";
            this.checkOFF.Size = new System.Drawing.Size(46, 17);
            this.checkOFF.TabIndex = 8;
            this.checkOFF.Text = "OFF";
            this.checkOFF.UseVisualStyleBackColor = true;
            this.checkOFF.CheckedChanged += new System.EventHandler(this.checkOFF_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Timer:";
            // 
            // tbTimer
            // 
            this.tbTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTimer.Location = new System.Drawing.Point(482, 37);
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.Size = new System.Drawing.Size(100, 20);
            this.tbTimer.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Duration";
            // 
            // btnCloseDB
            // 
            this.btnCloseDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDB.Location = new System.Drawing.Point(516, 148);
            this.btnCloseDB.Name = "btnCloseDB";
            this.btnCloseDB.Size = new System.Drawing.Size(22, 23);
            this.btnCloseDB.TabIndex = 13;
            this.btnCloseDB.Text = "^";
            this.btnCloseDB.UseVisualStyleBackColor = true;
            this.btnCloseDB.Visible = false;
            this.btnCloseDB.Click += new System.EventHandler(this.btnCloseDB_Click);
            // 
            // taskTest
            // 
            this.taskTest.HeaderText = "Completed";
            this.taskTest.Name = "taskTest";
            this.taskTest.ReadOnly = true;
            this.taskTest.Visible = false;
            // 
            // resendButton
            // 
            this.resendButton.FillWeight = 70F;
            this.resendButton.HeaderText = "Resend";
            this.resendButton.Name = "resendButton";
            this.resendButton.Text = "resend";
            this.resendButton.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(492, 148);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(22, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "🗘";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 355);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCloseDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkOFF);
            this.Controls.Add(this.checkON);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnTTest);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.conditionText);
            this.Controls.Add(this.tbKerko);
            this.Controls.Add(this.btnPastro);
            this.Controls.Add(this.dataVGrid);
            this.Controls.Add(this.btnKerko);
            this.Name = "Form1";
            this.Text = "Test Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataVGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKerko;
        private System.Windows.Forms.DataGridView dataVGrid;
        private System.Windows.Forms.Button btnPastro;
        private System.Windows.Forms.TextBox tbKerko;
        private System.Windows.Forms.Timer timerKerko;
        private System.Windows.Forms.Label conditionText;
        private System.Windows.Forms.Label ProgressLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnTTest;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkON;
        private System.Windows.Forms.CheckBox checkOFF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCloseDB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taskTest;
        private System.Windows.Forms.DataGridViewButtonColumn resendButton;
        private System.Windows.Forms.Button btnRefresh;
    }
}

