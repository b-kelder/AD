namespace TestApp
{
    partial class UI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.testProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonStartDefaultTest = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.buttonStartCustomTest = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchingLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchingIterations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.searchingUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchingListBox = new System.Windows.Forms.CheckedListBox();
            this.sortingListBox = new System.Windows.Forms.CheckedListBox();
            this.listListBox = new System.Windows.Forms.CheckedListBox();
            this.hashListBox = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchingIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 454);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabMain.Controls.Add(this.testProgressBar);
            this.tabMain.Controls.Add(this.buttonAbort);
            this.tabMain.Controls.Add(this.buttonStartDefaultTest);
            this.tabMain.Controls.Add(this.btnClearLog);
            this.tabMain.Controls.Add(this.buttonStartCustomTest);
            this.tabMain.Controls.Add(this.logBox);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(476, 425);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // testProgressBar
            // 
            this.testProgressBar.Location = new System.Drawing.Point(8, 40);
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(458, 23);
            this.testProgressBar.TabIndex = 6;
            // 
            // buttonAbort
            // 
            this.buttonAbort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonAbort.FlatAppearance.BorderSize = 0;
            this.buttonAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbort.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAbort.Location = new System.Drawing.Point(284, 6);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(76, 28);
            this.buttonAbort.TabIndex = 5;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = false;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonStartDefaultTest
            // 
            this.buttonStartDefaultTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonStartDefaultTest.FlatAppearance.BorderSize = 0;
            this.buttonStartDefaultTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartDefaultTest.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStartDefaultTest.Location = new System.Drawing.Point(8, 6);
            this.buttonStartDefaultTest.Name = "buttonStartDefaultTest";
            this.buttonStartDefaultTest.Size = new System.Drawing.Size(132, 28);
            this.buttonStartDefaultTest.TabIndex = 4;
            this.buttonStartDefaultTest.Text = "Start Default Test";
            this.buttonStartDefaultTest.UseVisualStyleBackColor = false;
            this.buttonStartDefaultTest.Click += new System.EventHandler(this.buttonStartDefaultTest_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearLog.Location = new System.Drawing.Point(366, 6);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(102, 28);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // buttonStartCustomTest
            // 
            this.buttonStartCustomTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonStartCustomTest.FlatAppearance.BorderSize = 0;
            this.buttonStartCustomTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartCustomTest.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStartCustomTest.Location = new System.Drawing.Point(146, 6);
            this.buttonStartCustomTest.Name = "buttonStartCustomTest";
            this.buttonStartCustomTest.Size = new System.Drawing.Size(132, 28);
            this.buttonStartCustomTest.TabIndex = 2;
            this.buttonStartCustomTest.Text = "Start Custom Test";
            this.buttonStartCustomTest.UseVisualStyleBackColor = false;
            this.buttonStartCustomTest.Click += new System.EventHandler(this.buttonStartCustomTest_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.Enabled = false;
            this.logBox.ForeColor = System.Drawing.SystemColors.Control;
            this.logBox.Location = new System.Drawing.Point(8, 69);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(460, 347);
            this.logBox.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabSettings.Controls.Add(this.hashListBox);
            this.tabSettings.Controls.Add(this.groupBox3);
            this.tabSettings.Controls.Add(this.listListBox);
            this.tabSettings.Controls.Add(this.searchingListBox);
            this.tabSettings.Controls.Add(this.sortingListBox);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(476, 425);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.searchingLocation);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dataMethod);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.searchingIterations);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.searchingUpDown);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(320, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 406);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Item location";
            // 
            // searchingLocation
            // 
            this.searchingLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.searchingLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchingLocation.ForeColor = System.Drawing.SystemColors.Control;
            this.searchingLocation.FormattingEnabled = true;
            this.searchingLocation.Items.AddRange(new object[] {
            "Start",
            "Middle",
            "End",
            "Random"});
            this.searchingLocation.Location = new System.Drawing.Point(9, 167);
            this.searchingLocation.Name = "searchingLocation";
            this.searchingLocation.Size = new System.Drawing.Size(121, 24);
            this.searchingLocation.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Method";
            // 
            // dataMethod
            // 
            this.dataMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataMethod.ForeColor = System.Drawing.SystemColors.Control;
            this.dataMethod.FormattingEnabled = true;
            this.dataMethod.Items.AddRange(new object[] {
            "Random",
            "Ascending",
            "Descending"});
            this.dataMethod.Location = new System.Drawing.Point(9, 79);
            this.dataMethod.Name = "dataMethod";
            this.dataMethod.Size = new System.Drawing.Size(121, 24);
            this.dataMethod.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Iterations";
            // 
            // searchingIterations
            // 
            this.searchingIterations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.searchingIterations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchingIterations.ForeColor = System.Drawing.SystemColors.Control;
            this.searchingIterations.Location = new System.Drawing.Point(8, 126);
            this.searchingIterations.Name = "searchingIterations";
            this.searchingIterations.Size = new System.Drawing.Size(120, 18);
            this.searchingIterations.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Amount of items";
            // 
            // searchingUpDown
            // 
            this.searchingUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.searchingUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchingUpDown.ForeColor = System.Drawing.SystemColors.Control;
            this.searchingUpDown.Location = new System.Drawing.Point(10, 38);
            this.searchingUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.searchingUpDown.Name = "searchingUpDown";
            this.searchingUpDown.Size = new System.Drawing.Size(120, 18);
            this.searchingUpDown.TabIndex = 12;
            // 
            // searchingListBox
            // 
            this.searchingListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.searchingListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.searchingListBox.FormattingEnabled = true;
            this.searchingListBox.Location = new System.Drawing.Point(164, 211);
            this.searchingListBox.Name = "searchingListBox";
            this.searchingListBox.Size = new System.Drawing.Size(150, 208);
            this.searchingListBox.TabIndex = 6;
            // 
            // sortingListBox
            // 
            this.sortingListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.sortingListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.sortingListBox.FormattingEnabled = true;
            this.sortingListBox.Location = new System.Drawing.Point(164, 14);
            this.sortingListBox.Name = "sortingListBox";
            this.sortingListBox.Size = new System.Drawing.Size(150, 191);
            this.sortingListBox.TabIndex = 5;
            // 
            // listListBox
            // 
            this.listListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.listListBox.FormattingEnabled = true;
            this.listListBox.Location = new System.Drawing.Point(8, 13);
            this.listListBox.Name = "listListBox";
            this.listListBox.Size = new System.Drawing.Size(150, 191);
            this.listListBox.TabIndex = 7;
            // 
            // hashListBox
            // 
            this.hashListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hashListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.hashListBox.FormattingEnabled = true;
            this.hashListBox.Location = new System.Drawing.Point(8, 210);
            this.hashListBox.Name = "hashListBox";
            this.hashListBox.Size = new System.Drawing.Size(150, 208);
            this.hashListBox.TabIndex = 8;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(484, 454);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UI";
            this.Text = "UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchingIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown searchingUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dataMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown searchingIterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button buttonStartCustomTest;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button buttonStartDefaultTest;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.ProgressBar testProgressBar;
        private System.Windows.Forms.CheckedListBox sortingListBox;
        private System.Windows.Forms.CheckedListBox searchingListBox;
        private System.Windows.Forms.CheckedListBox listListBox;
        private System.Windows.Forms.CheckedListBox hashListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox searchingLocation;
    }
}