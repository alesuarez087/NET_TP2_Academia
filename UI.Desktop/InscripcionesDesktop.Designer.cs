namespace UI.Desktop
{
    partial class InscripcionesDesktop
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
            this.tlInscripcionesDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.lblComisiones = new System.Windows.Forms.Label();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlInscripcionesDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // tlInscripcionesDesktop
            // 
            this.tlInscripcionesDesktop.ColumnCount = 3;
            this.tlInscripcionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlInscripcionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlInscripcionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlInscripcionesDesktop.Controls.Add(this.lblMaterias, 0, 0);
            this.tlInscripcionesDesktop.Controls.Add(this.lblComisiones, 2, 0);
            this.tlInscripcionesDesktop.Controls.Add(this.dgvMaterias, 0, 1);
            this.tlInscripcionesDesktop.Controls.Add(this.dgvComisiones, 2, 1);
            this.tlInscripcionesDesktop.Controls.Add(this.btnInscribirse, 1, 2);
            this.tlInscripcionesDesktop.Controls.Add(this.btnSalir, 2, 2);
            this.tlInscripcionesDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInscripcionesDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlInscripcionesDesktop.Name = "tlInscripcionesDesktop";
            this.tlInscripcionesDesktop.RowCount = 3;
            this.tlInscripcionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripcionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripcionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripcionesDesktop.Size = new System.Drawing.Size(651, 337);
            this.tlInscripcionesDesktop.TabIndex = 0;
            // 
            // lblMaterias
            // 
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Location = new System.Drawing.Point(3, 0);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(47, 13);
            this.lblMaterias.TabIndex = 0;
            this.lblMaterias.Text = "Materias";
            // 
            // lblComisiones
            // 
            this.lblComisiones.AutoSize = true;
            this.lblComisiones.Location = new System.Drawing.Point(392, 0);
            this.lblComisiones.Name = "lblComisiones";
            this.lblComisiones.Size = new System.Drawing.Size(60, 13);
            this.lblComisiones.TabIndex = 1;
            this.lblComisiones.Text = "Comisiones";
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.AllowUserToAddRows = false;
            this.dgvMaterias.AllowUserToDeleteRows = false;
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia});
            this.tlInscripcionesDesktop.SetColumnSpan(this.dgvMaterias, 2);
            this.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterias.Location = new System.Drawing.Point(3, 16);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.ReadOnly = true;
            this.dgvMaterias.RowHeadersVisible = false;
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(383, 289);
            this.dgvMaterias.TabIndex = 2;
            this.dgvMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellClick);
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.AllowUserToAddRows = false;
            this.dgvComisiones.AllowUserToDeleteRows = false;
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comision,
            this.anio_especialidad});
            this.dgvComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisiones.Location = new System.Drawing.Point(392, 16);
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.ReadOnly = true;
            this.dgvComisiones.RowHeadersVisible = false;
            this.dgvComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComisiones.Size = new System.Drawing.Size(256, 289);
            this.dgvComisiones.TabIndex = 3;
            // 
            // comision
            // 
            this.comision.DataPropertyName = "desc_comision";
            this.comision.HeaderText = "Comisión";
            this.comision.Name = "comision";
            this.comision.ReadOnly = true;
            // 
            // anio_especialidad
            // 
            this.anio_especialidad.DataPropertyName = "anio_especialidad";
            this.anio_especialidad.HeaderText = "Año Especialidad";
            this.anio_especialidad.Name = "anio_especialidad";
            this.anio_especialidad.ReadOnly = true;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInscribirse.Location = new System.Drawing.Point(311, 311);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(75, 23);
            this.btnInscribirse.TabIndex = 4;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.UseVisualStyleBackColor = true;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(392, 311);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // materia
            // 
            this.materia.DataPropertyName = "Descripcion";
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            // 
            // InscripcionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 337);
            this.Controls.Add(this.tlInscripcionesDesktop);
            this.Name = "InscripcionesDesktop";
            this.Text = "InscripcionesDesktop";
            this.tlInscripcionesDesktop.ResumeLayout(false);
            this.tlInscripcionesDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlInscripcionesDesktop;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.Label lblComisiones;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
    }
}