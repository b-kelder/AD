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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.buttonTestCollections = new System.Windows.Forms.Button();
            this.testProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonStartAllTest = new System.Windows.Forms.Button();
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
            this.testIterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.testDataAmountUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchingListBox = new System.Windows.Forms.CheckedListBox();
            this.sortingListBox = new System.Windows.Forms.CheckedListBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkShowArray = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testIterationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataAmountUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 324);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabMain.Controls.Add(this.buttonTestCollections);
            this.tabMain.Controls.Add(this.testProgressBar);
            this.tabMain.Controls.Add(this.buttonAbort);
            this.tabMain.Controls.Add(this.buttonStartAllTest);
            this.tabMain.Controls.Add(this.btnClearLog);
            this.tabMain.Controls.Add(this.buttonStartCustomTest);
            this.tabMain.Controls.Add(this.logBox);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(2);
            this.tabMain.Size = new System.Drawing.Size(456, 298);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // buttonTestCollections
            // 
            this.buttonTestCollections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonTestCollections.FlatAppearance.BorderSize = 0;
            this.buttonTestCollections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestCollections.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonTestCollections.Location = new System.Drawing.Point(212, 5);
            this.buttonTestCollections.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestCollections.Name = "buttonTestCollections";
            this.buttonTestCollections.Size = new System.Drawing.Size(96, 23);
            this.buttonTestCollections.TabIndex = 7;
            this.buttonTestCollections.Text = "Test Collections";
            this.buttonTestCollections.UseVisualStyleBackColor = false;
            this.buttonTestCollections.Click += new System.EventHandler(this.buttonTestCollections_Click);
            // 
            // testProgressBar
            // 
            this.testProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testProgressBar.Location = new System.Drawing.Point(6, 32);
            this.testProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(445, 19);
            this.testProgressBar.TabIndex = 6;
            // 
            // buttonAbort
            // 
            this.buttonAbort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonAbort.FlatAppearance.BorderSize = 0;
            this.buttonAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbort.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAbort.Location = new System.Drawing.Point(312, 5);
            this.buttonAbort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(57, 23);
            this.buttonAbort.TabIndex = 5;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = false;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonStartAllTest
            // 
            this.buttonStartAllTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonStartAllTest.FlatAppearance.BorderSize = 0;
            this.buttonStartAllTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartAllTest.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStartAllTest.Location = new System.Drawing.Point(6, 5);
            this.buttonStartAllTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartAllTest.Name = "buttonStartAllTest";
            this.buttonStartAllTest.Size = new System.Drawing.Size(99, 23);
            this.buttonStartAllTest.TabIndex = 4;
            this.buttonStartAllTest.Text = "Start All Tests";
            this.buttonStartAllTest.UseVisualStyleBackColor = false;
            this.buttonStartAllTest.Click += new System.EventHandler(this.buttonStartDefaultTest_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearLog.Location = new System.Drawing.Point(373, 5);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(76, 23);
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
            this.buttonStartCustomTest.Location = new System.Drawing.Point(109, 5);
            this.buttonStartCustomTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartCustomTest.Name = "buttonStartCustomTest";
            this.buttonStartCustomTest.Size = new System.Drawing.Size(99, 23);
            this.buttonStartCustomTest.TabIndex = 2;
            this.buttonStartCustomTest.Text = "Start Custom Test";
            this.buttonStartCustomTest.UseVisualStyleBackColor = false;
            this.buttonStartCustomTest.Click += new System.EventHandler(this.buttonStartCustomTest_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.ForeColor = System.Drawing.SystemColors.Control;
            this.logBox.Location = new System.Drawing.Point(6, 56);
            this.logBox.Margin = new System.Windows.Forms.Padding(2);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(446, 238);
            this.logBox.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabSettings.Controls.Add(this.groupBox3);
            this.tabSettings.Controls.Add(this.searchingListBox);
            this.tabSettings.Controls.Add(this.sortingListBox);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tabSettings.Size = new System.Drawing.Size(456, 298);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.groupBox3.Controls.Add(this.checkShowArray);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.searchingLocation);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dataMethod);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.testIterationsUpDown);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.testDataAmountUpDown);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(341, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(112, 285);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
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
            this.searchingLocation.Location = new System.Drawing.Point(7, 136);
            this.searchingLocation.Margin = new System.Windows.Forms.Padding(2);
            this.searchingLocation.Name = "searchingLocation";
            this.searchingLocation.Size = new System.Drawing.Size(92, 21);
            this.searchingLocation.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
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
            this.dataMethod.Location = new System.Drawing.Point(7, 64);
            this.dataMethod.Margin = new System.Windows.Forms.Padding(2);
            this.dataMethod.Name = "dataMethod";
            this.dataMethod.Size = new System.Drawing.Size(92, 21);
            this.dataMethod.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Iterations";
            // 
            // testIterationsUpDown
            // 
            this.testIterationsUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.testIterationsUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testIterationsUpDown.ForeColor = System.Drawing.SystemColors.Control;
            this.testIterationsUpDown.Location = new System.Drawing.Point(6, 102);
            this.testIterationsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.testIterationsUpDown.Name = "testIterationsUpDown";
            this.testIterationsUpDown.Size = new System.Drawing.Size(90, 16);
            this.testIterationsUpDown.TabIndex = 14;
            this.testIterationsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Amount of items";
            // 
            // testDataAmountUpDown
            // 
            this.testDataAmountUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.testDataAmountUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testDataAmountUpDown.ForeColor = System.Drawing.SystemColors.Control;
            this.testDataAmountUpDown.Location = new System.Drawing.Point(8, 31);
            this.testDataAmountUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.testDataAmountUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.testDataAmountUpDown.Name = "testDataAmountUpDown";
            this.testDataAmountUpDown.Size = new System.Drawing.Size(90, 16);
            this.testDataAmountUpDown.TabIndex = 12;
            this.testDataAmountUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // searchingListBox
            // 
            this.searchingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.searchingListBox.CheckOnClick = true;
            this.searchingListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.searchingListBox.FormattingEnabled = true;
            this.searchingListBox.Location = new System.Drawing.Point(4, 171);
            this.searchingListBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchingListBox.Name = "searchingListBox";
            this.searchingListBox.Size = new System.Drawing.Size(334, 124);
            this.searchingListBox.TabIndex = 6;
            // 
            // sortingListBox
            // 
            this.sortingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortingListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.sortingListBox.CheckOnClick = true;
            this.sortingListBox.ForeColor = System.Drawing.SystemColors.Control;
            this.sortingListBox.FormattingEnabled = true;
            this.sortingListBox.Location = new System.Drawing.Point(4, 11);
            this.sortingListBox.Margin = new System.Windows.Forms.Padding(2);
            this.sortingListBox.Name = "sortingListBox";
            this.sortingListBox.Size = new System.Drawing.Size(334, 154);
            this.sortingListBox.TabIndex = 5;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportLogToolStripMenuItem
            // 
            this.exportLogToolStripMenuItem.Name = "exportLogToolStripMenuItem";
            this.exportLogToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exportLogToolStripMenuItem.Text = "Export log";
            this.exportLogToolStripMenuItem.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // checkShowArray
            // 
            this.checkShowArray.AutoSize = true;
            this.checkShowArray.Location = new System.Drawing.Point(8, 162);
            this.checkShowArray.Name = "checkShowArray";
            this.checkShowArray.Size = new System.Drawing.Size(79, 17);
            this.checkShowArray.TabIndex = 20;
            this.checkShowArray.Text = "Show array";
            this.checkShowArray.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(464, 348);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(384, 387);
            this.Name = "UI";
            this.Text = "UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testIterationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataAmountUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown testDataAmountUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dataMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown testIterationsUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button buttonStartCustomTest;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button buttonStartAllTest;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.ProgressBar testProgressBar;
        private System.Windows.Forms.CheckedListBox sortingListBox;
        private System.Windows.Forms.CheckedListBox searchingListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox searchingLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonTestCollections;
        private System.Windows.Forms.CheckBox checkShowArray;
    }
}