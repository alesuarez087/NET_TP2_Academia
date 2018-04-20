namespace UI.Desktop
{
    partial class ReportePlanes
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
            this.rvReportePlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvReportePlanes
            // 
            this.rvReportePlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReportePlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.BaseReportePlanes.rdlc";
            this.rvReportePlanes.Location = new System.Drawing.Point(0, 0);
            this.rvReportePlanes.Name = "rvReportePlanes";
            this.rvReportePlanes.Size = new System.Drawing.Size(819, 425);
            this.rvReportePlanes.TabIndex = 0;
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 425);
            this.Controls.Add(this.rvReportePlanes);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReportePlanes;
    }
}