namespace UI.Desktop
{
    partial class ReporteCursos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvReporteCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet = new UI.Desktop.DataSet();
            this.CursosGetAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CursosGetAllTableAdapter = new UI.Desktop.DataSetTableAdapters.CursosGetAllTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosGetAllBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvReporteCursos
            // 
            this.rvReporteCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CursosGetAllBindingSource;
            this.rvReporteCursos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvReporteCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.BaseReporteCursos.rdlc";
            this.rvReporteCursos.Location = new System.Drawing.Point(0, 0);
            this.rvReporteCursos.Name = "rvReporteCursos";
            this.rvReporteCursos.Size = new System.Drawing.Size(791, 550);
            this.rvReporteCursos.TabIndex = 0;
            // 
            // DataSet
            // 
            this.DataSet.DataSetName = "DataSet";
            this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CursosGetAllBindingSource
            // 
            this.CursosGetAllBindingSource.DataMember = "CursosGetAll";
            this.CursosGetAllBindingSource.DataSource = this.DataSet;
            // 
            // CursosGetAllTableAdapter
            // 
            this.CursosGetAllTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 550);
            this.Controls.Add(this.rvReporteCursos);
            this.Name = "ReporteCursos";
            this.Text = "ReporteCursos";
            this.Load += new System.EventHandler(this.ReporteCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosGetAllBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReporteCursos;
        private System.Windows.Forms.BindingSource CursosGetAllBindingSource;
        private DataSet DataSet;
        private DataSetTableAdapters.CursosGetAllTableAdapter CursosGetAllTableAdapter;
    }
}