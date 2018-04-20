namespace UI.Desktop
{
    partial class DocentesCursosDesktop
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
            this.tlDocentesCursosDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAgregarDocente = new System.Windows.Forms.Button();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.txtDocente = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlDocentesCursosDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlDocentesCursosDesktop
            // 
            this.tlDocentesCursosDesktop.ColumnCount = 4;
            this.tlDocentesCursosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.Controls.Add(this.txtId, 2, 0);
            this.tlDocentesCursosDesktop.Controls.Add(this.lblId, 1, 0);
            this.tlDocentesCursosDesktop.Controls.Add(this.btnAgregarDocente, 0, 1);
            this.tlDocentesCursosDesktop.Controls.Add(this.cmbCargo, 2, 1);
            this.tlDocentesCursosDesktop.Controls.Add(this.txtDocente, 0, 2);
            this.tlDocentesCursosDesktop.Controls.Add(this.btnAceptar, 2, 3);
            this.tlDocentesCursosDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlDocentesCursosDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentesCursosDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlDocentesCursosDesktop.Name = "tlDocentesCursosDesktop";
            this.tlDocentesCursosDesktop.RowCount = 4;
            this.tlDocentesCursosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlDocentesCursosDesktop.Size = new System.Drawing.Size(468, 249);
            this.tlDocentesCursosDesktop.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(237, 21);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(213, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // btnAgregarDocente
            // 
            this.btnAgregarDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlDocentesCursosDesktop.SetColumnSpan(this.btnAgregarDocente, 2);
            this.btnAgregarDocente.Location = new System.Drawing.Point(64, 81);
            this.btnAgregarDocente.Name = "btnAgregarDocente";
            this.btnAgregarDocente.Size = new System.Drawing.Size(106, 23);
            this.btnAgregarDocente.TabIndex = 2;
            this.btnAgregarDocente.Text = "Agregar Docente";
            this.btnAgregarDocente.UseVisualStyleBackColor = true;
            this.btnAgregarDocente.Click += new System.EventHandler(this.btnAgregarDocente_Click);
            // 
            // cmbCargo
            // 
            this.cmbCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlDocentesCursosDesktop.SetColumnSpan(this.cmbCargo, 2);
            this.cmbCargo.Enabled = false;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(290, 82);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(121, 21);
            this.cmbCargo.TabIndex = 3;
            // 
            // txtDocente
            // 
            this.txtDocente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlDocentesCursosDesktop.SetColumnSpan(this.txtDocente, 2);
            this.txtDocente.Enabled = false;
            this.txtDocente.Location = new System.Drawing.Point(48, 145);
            this.txtDocente.Name = "txtDocente";
            this.txtDocente.ReadOnly = true;
            this.txtDocente.Size = new System.Drawing.Size(138, 20);
            this.txtDocente.TabIndex = 4;
            this.txtDocente.Text = "Docente no seleccionado";
            this.txtDocente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(273, 206);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(354, 206);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // DocentesCursosDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 249);
            this.Controls.Add(this.tlDocentesCursosDesktop);
            this.Name = "DocentesCursosDesktop";
            this.Text = "DocentesCursosDesktop";
            this.tlDocentesCursosDesktop.ResumeLayout(false);
            this.tlDocentesCursosDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlDocentesCursosDesktop;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnAgregarDocente;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.TextBox txtDocente;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}