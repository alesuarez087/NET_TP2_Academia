namespace UI.Desktop
{
    partial class EspecialidadesDesktop
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
            this.tlEspecidalidadesDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlEspecidalidadesDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlEspecidalidadesDesktop
            // 
            this.tlEspecidalidadesDesktop.ColumnCount = 3;
            this.tlEspecidalidadesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlEspecidalidadesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEspecidalidadesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlEspecidalidadesDesktop.Controls.Add(this.lblId, 0, 0);
            this.tlEspecidalidadesDesktop.Controls.Add(this.lblEspecialidad, 0, 1);
            this.tlEspecidalidadesDesktop.Controls.Add(this.txtId, 1, 0);
            this.tlEspecidalidadesDesktop.Controls.Add(this.txtEspecialidad, 1, 1);
            this.tlEspecidalidadesDesktop.Controls.Add(this.btnAceptar, 1, 3);
            this.tlEspecidalidadesDesktop.Controls.Add(this.btnCancelar, 2, 3);
            this.tlEspecidalidadesDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEspecidalidadesDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlEspecidalidadesDesktop.Name = "tlEspecidalidadesDesktop";
            this.tlEspecidalidadesDesktop.RowCount = 4;
            this.tlEspecidalidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecidalidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecidalidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecidalidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlEspecidalidadesDesktop.Size = new System.Drawing.Size(429, 136);
            this.tlEspecidalidadesDesktop.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 11);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(3, 46);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(41, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Carrera";
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(50, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(295, 20);
            this.txtId.TabIndex = 4;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEspecialidad.Location = new System.Drawing.Point(50, 38);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(295, 20);
            this.txtEspecialidad.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(270, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(351, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EspecialidadesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 136);
            this.Controls.Add(this.tlEspecidalidadesDesktop);
            this.Name = "EspecialidadesDesktop";
            this.Text = "EspecialidadesDesktop";
            this.tlEspecidalidadesDesktop.ResumeLayout(false);
            this.tlEspecidalidadesDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlEspecidalidadesDesktop;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}