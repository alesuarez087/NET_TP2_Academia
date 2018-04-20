namespace UI.Desktop
{
    partial class ReporteCurso
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
            this.tlReporteCurso = new System.Windows.Forms.TableLayoutPanel();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblMateria = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.crvCurso = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tlReporteCurso.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlReporteCurso
            // 
            this.tlReporteCurso.ColumnCount = 5;
            this.tlReporteCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlReporteCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlReporteCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlReporteCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlReporteCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlReporteCurso.Controls.Add(this.lblEspecialidades, 0, 0);
            this.tlReporteCurso.Controls.Add(this.lblPlan, 1, 0);
            this.tlReporteCurso.Controls.Add(this.lblMateria, 2, 0);
            this.tlReporteCurso.Controls.Add(this.label4, 3, 0);
            this.tlReporteCurso.Controls.Add(this.lblAnio, 4, 0);
            this.tlReporteCurso.Controls.Add(this.cmbEspecialidad, 0, 1);
            this.tlReporteCurso.Controls.Add(this.cmbPlan, 1, 1);
            this.tlReporteCurso.Controls.Add(this.cmbMateria, 2, 1);
            this.tlReporteCurso.Controls.Add(this.cmbComision, 3, 1);
            this.tlReporteCurso.Controls.Add(this.cmbAnio, 4, 1);
            this.tlReporteCurso.Controls.Add(this.btnGenerar, 2, 2);
            this.tlReporteCurso.Controls.Add(this.crvCurso, 0, 3);
            this.tlReporteCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlReporteCurso.Location = new System.Drawing.Point(0, 0);
            this.tlReporteCurso.Name = "tlReporteCurso";
            this.tlReporteCurso.RowCount = 4;
            this.tlReporteCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlReporteCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlReporteCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlReporteCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlReporteCurso.Size = new System.Drawing.Size(733, 408);
            this.tlReporteCurso.TabIndex = 0;
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Location = new System.Drawing.Point(3, 0);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(78, 13);
            this.lblEspecialidades.TabIndex = 0;
            this.lblEspecialidades.Text = "Especialidades";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(149, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 1;
            this.lblPlan.Text = "Plan";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(295, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 2;
            this.lblMateria.Text = "Materia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Comisión";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(587, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(79, 13);
            this.lblAnio.TabIndex = 4;
            this.lblAnio.Text = "Año Calendario";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(3, 16);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(140, 21);
            this.cmbEspecialidad.TabIndex = 5;
            this.cmbEspecialidad.SelectionChangeCommitted += new System.EventHandler(this.cmbEspecialidad_SelectionChangeCommitted);
            // 
            // cmbPlan
            // 
            this.cmbPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPlan.Enabled = false;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(149, 16);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(140, 21);
            this.cmbPlan.TabIndex = 6;
            this.cmbPlan.SelectionChangeCommitted += new System.EventHandler(this.cmbPlan_SelectionChangeCommitted);
            // 
            // cmbMateria
            // 
            this.cmbMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(295, 16);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(140, 21);
            this.cmbMateria.TabIndex = 7;
            this.cmbMateria.SelectionChangeCommitted += new System.EventHandler(this.cmbMateria_SelectionChangeCommitted);
            // 
            // cmbComision
            // 
            this.cmbComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbComision.Enabled = false;
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(441, 16);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(140, 21);
            this.cmbComision.TabIndex = 8;
            this.cmbComision.SelectionChangeCommitted += new System.EventHandler(this.cmbComision_SelectionChangeCommitted);
            // 
            // cmbAnio
            // 
            this.cmbAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAnio.Enabled = false;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(587, 16);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(143, 21);
            this.cmbAnio.TabIndex = 9;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerar.Location = new System.Drawing.Point(295, 43);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(140, 23);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar Informe";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // crvCurso
            // 
            this.crvCurso.ActiveViewIndex = -1;
            this.crvCurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCurso.CachedPageNumberPerDoc = 10;
            this.tlReporteCurso.SetColumnSpan(this.crvCurso, 5);
            this.crvCurso.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCurso.Location = new System.Drawing.Point(3, 72);
            this.crvCurso.Name = "crvCurso";
            this.crvCurso.Size = new System.Drawing.Size(727, 333);
            this.crvCurso.TabIndex = 11;
            // 
            // ReporteCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 408);
            this.Controls.Add(this.tlReporteCurso);
            this.Name = "ReporteCurso";
            this.Text = "Informe Curso";
            this.Load += new System.EventHandler(this.ReporteCurso_Load);
            this.tlReporteCurso.ResumeLayout(false);
            this.tlReporteCurso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlReporteCurso;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Button btnGenerar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCurso;
    }
}