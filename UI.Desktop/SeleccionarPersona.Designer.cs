namespace UI.Desktop
{
    partial class SeleccionarPersona
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
            this.tlSeleccionarPersona = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tsPersona = new System.Windows.Forms.ToolStrip();
            this.tsbNuevaPersona = new System.Windows.Forms.ToolStripButton();
            this.tscmbTipo = new System.Windows.Forms.ToolStripComboBox();
            this.dgvSeleccionPersona = new System.Windows.Forms.DataGridView();
            this.id_persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlSeleccionarPersona.SuspendLayout();
            this.tsPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // tlSeleccionarPersona
            // 
            this.tlSeleccionarPersona.ColumnCount = 2;
            this.tlSeleccionarPersona.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlSeleccionarPersona.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlSeleccionarPersona.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlSeleccionarPersona.Controls.Add(this.btnCancelar, 1, 2);
            this.tlSeleccionarPersona.Controls.Add(this.btnAgregar, 0, 2);
            this.tlSeleccionarPersona.Controls.Add(this.tsPersona, 0, 0);
            this.tlSeleccionarPersona.Controls.Add(this.dgvSeleccionPersona, 0, 1);
            this.tlSeleccionarPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlSeleccionarPersona.Location = new System.Drawing.Point(0, 0);
            this.tlSeleccionarPersona.Name = "tlSeleccionarPersona";
            this.tlSeleccionarPersona.RowCount = 3;
            this.tlSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlSeleccionarPersona.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlSeleccionarPersona.Size = new System.Drawing.Size(640, 333);
            this.tlSeleccionarPersona.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(562, 307);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(481, 307);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tsPersona
            // 
            this.tsPersona.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevaPersona,
            this.tscmbTipo});
            this.tsPersona.Location = new System.Drawing.Point(0, 0);
            this.tsPersona.Name = "tsPersona";
            this.tsPersona.Size = new System.Drawing.Size(559, 25);
            this.tsPersona.TabIndex = 2;
            this.tsPersona.Text = "toolStrip1";
            // 
            // tsbNuevaPersona
            // 
            this.tsbNuevaPersona.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevaPersona.Image = global::UI.Desktop.Properties.Resources.agregar;
            this.tsbNuevaPersona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevaPersona.Name = "tsbNuevaPersona";
            this.tsbNuevaPersona.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevaPersona.Text = "Nueva Persona";
            this.tsbNuevaPersona.Click += new System.EventHandler(this.tsbNuevaPersona_Click);
            // 
            // tscmbTipo
            // 
            this.tscmbTipo.Name = "tscmbTipo";
            this.tscmbTipo.Size = new System.Drawing.Size(121, 25);
            this.tscmbTipo.SelectedIndexChanged += new System.EventHandler(this.tscmbTipo_SelectedIndexChanged);
            // 
            // dgvSeleccionPersona
            // 
            this.dgvSeleccionPersona.AllowUserToAddRows = false;
            this.dgvSeleccionPersona.AllowUserToDeleteRows = false;
            this.dgvSeleccionPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_persona,
            this.apellido,
            this.nombre,
            this.legajo,
            this.fecha_nac,
            this.telefono});
            this.tlSeleccionarPersona.SetColumnSpan(this.dgvSeleccionPersona, 2);
            this.dgvSeleccionPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeleccionPersona.Location = new System.Drawing.Point(3, 28);
            this.dgvSeleccionPersona.Name = "dgvSeleccionPersona";
            this.dgvSeleccionPersona.RowHeadersVisible = false;
            this.dgvSeleccionPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionPersona.Size = new System.Drawing.Size(634, 273);
            this.dgvSeleccionPersona.TabIndex = 3;
            // 
            // id_persona
            // 
            this.id_persona.DataPropertyName = "ID";
            this.id_persona.HeaderText = "ID";
            this.id_persona.Name = "id_persona";
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
            // legajo
            // 
            this.legajo.DataPropertyName = "legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            // 
            // fecha_nac
            // 
            this.fecha_nac.DataPropertyName = "fecha_nac";
            this.fecha_nac.HeaderText = "Fecha Nacimiento";
            this.fecha_nac.Name = "fecha_nac";
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            // 
            // SeleccionarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 333);
            this.Controls.Add(this.tlSeleccionarPersona);
            this.Name = "SeleccionarPersona";
            this.Text = "SeleccionarPersona";
            this.Load += new System.EventHandler(this.SeleccionarPersona_Load);
            this.tlSeleccionarPersona.ResumeLayout(false);
            this.tlSeleccionarPersona.PerformLayout();
            this.tsPersona.ResumeLayout(false);
            this.tsPersona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionPersona)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlSeleccionarPersona;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ToolStrip tsPersona;
        private System.Windows.Forms.DataGridView dgvSeleccionPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nac;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.ToolStripButton tsbNuevaPersona;
        private System.Windows.Forms.ToolStripComboBox tscmbTipo;
    }
}