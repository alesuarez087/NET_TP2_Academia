namespace UI.Desktop
{
    partial class Docentes
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
            this.tscDocentes = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocentes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tsDocentes = new System.Windows.Forms.ToolStrip();
            this.txtBuscador = new System.Windows.Forms.ToolStripTextBox();
            this.tscDocentes.ContentPanel.SuspendLayout();
            this.tscDocentes.TopToolStripPanel.SuspendLayout();
            this.tscDocentes.SuspendLayout();
            this.tlDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).BeginInit();
            this.tsDocentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscDocentes
            // 
            // 
            // tscDocentes.ContentPanel
            // 
            this.tscDocentes.ContentPanel.Controls.Add(this.tlDocentes);
            this.tscDocentes.ContentPanel.Size = new System.Drawing.Size(526, 349);
            this.tscDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscDocentes.Location = new System.Drawing.Point(0, 0);
            this.tscDocentes.Name = "tscDocentes";
            this.tscDocentes.Size = new System.Drawing.Size(526, 374);
            this.tscDocentes.TabIndex = 0;
            this.tscDocentes.Text = "toolStripContainer1";
            // 
            // tscDocentes.TopToolStripPanel
            // 
            this.tscDocentes.TopToolStripPanel.Controls.Add(this.tsDocentes);
            // 
            // tlDocentes
            // 
            this.tlDocentes.ColumnCount = 2;
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentes.Controls.Add(this.dgvDocentes, 0, 0);
            this.tlDocentes.Controls.Add(this.btnRegistrar, 0, 1);
            this.tlDocentes.Controls.Add(this.btnCancelar, 1, 1);
            this.tlDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentes.Location = new System.Drawing.Point(0, 0);
            this.tlDocentes.Name = "tlDocentes";
            this.tlDocentes.RowCount = 2;
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentes.Size = new System.Drawing.Size(526, 349);
            this.tlDocentes.TabIndex = 0;
            // 
            // dgvDocentes
            // 
            this.dgvDocentes.AllowUserToAddRows = false;
            this.dgvDocentes.AllowUserToDeleteRows = false;
            this.dgvDocentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Legajo,
            this.Apellido,
            this.Nombre});
            this.tlDocentes.SetColumnSpan(this.dgvDocentes, 2);
            this.dgvDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentes.Location = new System.Drawing.Point(3, 3);
            this.dgvDocentes.MultiSelect = false;
            this.dgvDocentes.Name = "dgvDocentes";
            this.dgvDocentes.ReadOnly = true;
            this.dgvDocentes.RowHeadersVisible = false;
            this.dgvDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocentes.Size = new System.Drawing.Size(520, 314);
            this.dgvDocentes.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            this.Legajo.Width = 64;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 69;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(351, 323);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(83, 23);
            this.btnRegistrar.TabIndex = 1;
            this.btnRegistrar.Text = "Registrar Nota";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(440, 323);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // tsDocentes
            // 
            this.tsDocentes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtBuscador});
            this.tsDocentes.Location = new System.Drawing.Point(3, 0);
            this.tsDocentes.Name = "tsDocentes";
            this.tsDocentes.Size = new System.Drawing.Size(114, 25);
            this.tsDocentes.TabIndex = 0;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(100, 25);
            this.txtBuscador.Tag = "";
            this.txtBuscador.Text = "Buscar";
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // Docentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 374);
            this.Controls.Add(this.tscDocentes);
            this.Name = "Docentes";
            this.Text = "Docentes";
            this.tscDocentes.ContentPanel.ResumeLayout(false);
            this.tscDocentes.TopToolStripPanel.ResumeLayout(false);
            this.tscDocentes.TopToolStripPanel.PerformLayout();
            this.tscDocentes.ResumeLayout(false);
            this.tscDocentes.PerformLayout();
            this.tlDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).EndInit();
            this.tsDocentes.ResumeLayout(false);
            this.tsDocentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscDocentes;
        private System.Windows.Forms.TableLayoutPanel tlDocentes;
        private System.Windows.Forms.DataGridView dgvDocentes;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolStrip tsDocentes;
        private System.Windows.Forms.ToolStripTextBox txtBuscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;


    }
}