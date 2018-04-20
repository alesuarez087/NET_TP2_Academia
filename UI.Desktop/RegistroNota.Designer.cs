namespace UI.Desktop
{
    partial class RegistroNota
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
            this.tlRegistroNotas = new System.Windows.Forms.TableLayoutPanel();
            this.lblComisiones = new System.Windows.Forms.Label();
            this.lblAlumnos = new System.Windows.Forms.Label();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.cmbNota = new System.Windows.Forms.ComboBox();
            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.btnBorrarNota = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.tlRegistroNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tlRegistroNotas
            // 
            this.tlRegistroNotas.ColumnCount = 4;
            this.tlRegistroNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlRegistroNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlRegistroNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlRegistroNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlRegistroNotas.Controls.Add(this.lblComisiones, 0, 0);
            this.tlRegistroNotas.Controls.Add(this.lblAlumnos, 1, 0);
            this.tlRegistroNotas.Controls.Add(this.dgvComisiones, 0, 1);
            this.tlRegistroNotas.Controls.Add(this.dgvAlumnos, 1, 1);
            this.tlRegistroNotas.Controls.Add(this.lblNota, 1, 3);
            this.tlRegistroNotas.Controls.Add(this.lblCondicion, 1, 4);
            this.tlRegistroNotas.Controls.Add(this.cmbNota, 2, 3);
            this.tlRegistroNotas.Controls.Add(this.cmbCondicion, 2, 4);
            this.tlRegistroNotas.Controls.Add(this.btnBorrarNota, 1, 5);
            this.tlRegistroNotas.Controls.Add(this.btnConfirmar, 2, 5);
            this.tlRegistroNotas.Controls.Add(this.btnFinalizar, 3, 6);
            this.tlRegistroNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRegistroNotas.Location = new System.Drawing.Point(0, 0);
            this.tlRegistroNotas.Name = "tlRegistroNotas";
            this.tlRegistroNotas.RowCount = 7;
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistroNotas.Size = new System.Drawing.Size(719, 348);
            this.tlRegistroNotas.TabIndex = 0;
            // 
            // lblComisiones
            // 
            this.lblComisiones.AutoSize = true;
            this.lblComisiones.Location = new System.Drawing.Point(3, 0);
            this.lblComisiones.Name = "lblComisiones";
            this.lblComisiones.Size = new System.Drawing.Size(60, 13);
            this.lblComisiones.TabIndex = 0;
            this.lblComisiones.Text = "Comisiones";
            // 
            // lblAlumnos
            // 
            this.lblAlumnos.AutoSize = true;
            this.lblAlumnos.Location = new System.Drawing.Point(309, 0);
            this.lblAlumnos.Name = "lblAlumnos";
            this.lblAlumnos.Size = new System.Drawing.Size(47, 13);
            this.lblAlumnos.TabIndex = 1;
            this.lblAlumnos.Text = "Alumnos";
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.AllowUserToAddRows = false;
            this.dgvComisiones.AllowUserToDeleteRows = false;
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia,
            this.comision});
            this.dgvComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisiones.Location = new System.Drawing.Point(3, 16);
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.ReadOnly = true;
            this.dgvComisiones.RowHeadersVisible = false;
            this.dgvComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComisiones.Size = new System.Drawing.Size(300, 217);
            this.dgvComisiones.TabIndex = 2;
            this.dgvComisiones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComisiones_CellClick);
            // 
            // materia
            // 
            this.materia.DataPropertyName = "desc_materia";
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            // 
            // comision
            // 
            this.comision.DataPropertyName = "desc_comision";
            this.comision.HeaderText = "Comisión";
            this.comision.Name = "comision";
            this.comision.ReadOnly = true;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellido,
            this.nombre,
            this.nota,
            this.condicion});
            this.tlRegistroNotas.SetColumnSpan(this.dgvAlumnos, 3);
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.Location = new System.Drawing.Point(309, 16);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(407, 217);
            this.dgvAlumnos.TabIndex = 3;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // nota
            // 
            this.nota.DataPropertyName = "nota";
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "condicion";
            this.condicion.HeaderText = "Condición";
            this.condicion.Name = "condicion";
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(477, 243);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Nota";
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(453, 270);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(54, 13);
            this.lblCondicion.TabIndex = 5;
            this.lblCondicion.Text = "Condición";
            // 
            // cmbNota
            // 
            this.cmbNota.FormattingEnabled = true;
            this.cmbNota.Location = new System.Drawing.Point(513, 239);
            this.cmbNota.Name = "cmbNota";
            this.cmbNota.Size = new System.Drawing.Size(121, 21);
            this.cmbNota.TabIndex = 6;
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Location = new System.Drawing.Point(513, 266);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(121, 21);
            this.cmbCondicion.TabIndex = 7;
            // 
            // btnBorrarNota
            // 
            this.btnBorrarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarNota.Location = new System.Drawing.Point(432, 293);
            this.btnBorrarNota.Name = "btnBorrarNota";
            this.btnBorrarNota.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarNota.TabIndex = 8;
            this.btnBorrarNota.Text = "Borrar Nota";
            this.btnBorrarNota.UseVisualStyleBackColor = true;
            this.btnBorrarNota.Click += new System.EventHandler(this.btnBorrarNota_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(513, 293);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(640, 322);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // RegistroNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 348);
            this.Controls.Add(this.tlRegistroNotas);
            this.Name = "RegistroNota";
            this.Text = "RegistroNota";
            this.Load += new System.EventHandler(this.RegistroNota_Load);
            this.tlRegistroNotas.ResumeLayout(false);
            this.tlRegistroNotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlRegistroNotas;
        private System.Windows.Forms.Label lblComisiones;
        private System.Windows.Forms.Label lblAlumnos;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.ComboBox cmbNota;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Button btnBorrarNota;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
    }
}