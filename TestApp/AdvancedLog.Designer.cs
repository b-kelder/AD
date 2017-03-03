namespace TestApp
{
    partial class AdvancedLog
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
            this.unsortedLog = new System.Windows.Forms.TextBox();
            this.sortedLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // unsortedLog
            // 
            this.unsortedLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.unsortedLog.Location = new System.Drawing.Point(0, 0);
            this.unsortedLog.MaxLength = 110000000;
            this.unsortedLog.Multiline = true;
            this.unsortedLog.Name = "unsortedLog";
            this.unsortedLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.unsortedLog.Size = new System.Drawing.Size(338, 759);
            this.unsortedLog.TabIndex = 0;
            this.unsortedLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sortedLog
            // 
            this.sortedLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.sortedLog.Location = new System.Drawing.Point(344, 0);
            this.sortedLog.MaxLength = 110000000;
            this.sortedLog.Multiline = true;
            this.sortedLog.Name = "sortedLog";
            this.sortedLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sortedLog.Size = new System.Drawing.Size(317, 759);
            this.sortedLog.TabIndex = 1;
            this.sortedLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AdvancedLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 759);
            this.Controls.Add(this.sortedLog);
            this.Controls.Add(this.unsortedLog);
            this.Name = "AdvancedLog";
            this.Text = "AdvancedLog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox unsortedLog;
        private System.Windows.Forms.TextBox sortedLog;
    }
}