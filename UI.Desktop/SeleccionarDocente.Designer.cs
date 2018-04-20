namespace UI.Desktop
{
    partial class SeleccionarDocente
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
            this.tlSeleccionarDocente = new System.Windows.Forms.TableLayoutPanel();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvSeleccionarDocente = new System.Windows.Forms.DataGridView();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlSeleccionarDocente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarDocente)).BeginInit();
            this.SuspendLayout();
            // 
            // tlSeleccionarDocente
            // 
            this.tlSeleccionarDocente.ColumnCount = 2;
            this.tlSeleccionarDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlSeleccionarDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlSeleccionarDocente.Controls.Add(this.btnSeleccionar, 0, 1);
            this.tlSeleccionarDocente.Controls.Add(this.btnCancelar, 1, 1);
            this.tlSeleccionarDocente.Controls.Add(this.dgvSeleccionarDocente, 0, 0);
            this.tlSeleccionarDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlSeleccionarDocente.Location = new System.Drawing.Point(0, 0);
            this.tlSeleccionarDocente.Name = "tlSeleccionarDocente";
            this.tlSeleccionarDocente.RowCount = 2;
            this.tlSeleccionarDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlSeleccionarDocente.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlSeleccionarDocente.Size = new System.Drawing.Size(638, 447);
            this.tlSeleccionarDocente.TabIndex = 0;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.Location = new System.Drawing.Point(479, 421);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(560, 421);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvSeleccionarDocente
            // 
            this.dgvSeleccionarDocente.AllowUserToAddRows = false;
            this.dgvSeleccionarDocente.AllowUserToDeleteRows = false;
            this.dgvSeleccionarDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionarDocente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apellido,
            this.nombre,
            this.legajo,
            this.email,
            this.telefono});
            this.tlSeleccionarDocente.SetColumnSpan(this.dgvSeleccionarDocente, 2);
            this.dgvSeleccionarDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeleccionarDocente.Location = new System.Drawing.Point(3, 3);
            this.dgvSeleccionarDocente.Name = "dgvSeleccionarDocente";
            this.dgvSeleccionarDocente.ReadOnly = true;
            this.dgvSeleccionarDocente.RowHeadersVisible = false;
            this.dgvSeleccionarDocente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionarDocente.Size = new System.Drawing.Size(632, 412);
            this.dgvSeleccionarDocente.TabIndex = 2;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // legajo
            // 
            this.legajo.DataPropertyName = "legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            this.legajo.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // SeleccionarDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 447);
            this.Controls.Add(this.tlSeleccionarDocente);
            this.Name = "SeleccionarDocente";
            this.Text = "SeleccionarDocente";
            this.tlSeleccionarDocente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarDocente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlSeleccionarDocente;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvSeleccionarDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
    }
}