﻿namespace UI.Desktop
{
    partial class Inscripciones
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
            this.tcInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_cursado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbInscribirse = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcInscripciones.ContentPanel.SuspendLayout();
            this.tcInscripciones.TopToolStripPanel.SuspendLayout();
            this.tcInscripciones.SuspendLayout();
            this.tlInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcInscripciones
            // 
            // 
            // tcInscripciones.ContentPanel
            // 
            this.tcInscripciones.ContentPanel.Controls.Add(this.tlInscripciones);
            this.tcInscripciones.ContentPanel.Size = new System.Drawing.Size(570, 351);
            this.tcInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcInscripciones.Name = "tcInscripciones";
            this.tcInscripciones.Size = new System.Drawing.Size(570, 376);
            this.tcInscripciones.TabIndex = 0;
            this.tcInscripciones.Text = "toolStripContainer1";
            // 
            // tcInscripciones.TopToolStripPanel
            // 
            this.tcInscripciones.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlInscripciones
            // 
            this.tlInscripciones.ColumnCount = 2;
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlInscripciones.Controls.Add(this.dgvInscripciones, 0, 0);
            this.tlInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlInscripciones.Name = "tlInscripciones";
            this.tlInscripciones.RowCount = 2;
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripciones.Size = new System.Drawing.Size(570, 351);
            this.tlInscripciones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(411, 325);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(492, 325);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia,
            this.comision,
            this.anio_cursado,
            this.nota,
            this.condicion});
            this.tlInscripciones.SetColumnSpan(this.dgvInscripciones, 2);
            this.dgvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.RowHeadersVisible = false;
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(564, 316);
            this.dgvInscripciones.TabIndex = 2;
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
            // anio_cursado
            // 
            this.anio_cursado.DataPropertyName = "anio_calendario";
            this.anio_cursado.HeaderText = "Año Cursado";
            this.anio_cursado.Name = "anio_cursado";
            this.anio_cursado.ReadOnly = true;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "nota";
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "condicion";
            this.condicion.HeaderText = "Condición";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInscribirse,
            this.tsbEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(89, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbInscribirse
            // 
            this.tsbInscribirse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInscribirse.Image = global::UI.Desktop.Properties.Resources.agregar;
            this.tsbInscribirse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInscribirse.Name = "tsbInscribirse";
            this.tsbInscribirse.Size = new System.Drawing.Size(23, 22);
            this.tsbInscribirse.Text = "Inscribirse";
            this.tsbInscribirse.Click += new System.EventHandler(this.tsbInscribirse_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.eliminar;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Inscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 376);
            this.Controls.Add(this.tcInscripciones);
            this.Name = "Inscripciones";
            this.Text = "Inscripciones";
            this.Load += new System.EventHandler(this.Inscripciones_Load);
            this.tcInscripciones.ContentPanel.ResumeLayout(false);
            this.tcInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tcInscripciones.TopToolStripPanel.PerformLayout();
            this.tcInscripciones.ResumeLayout(false);
            this.tcInscripciones.PerformLayout();
            this.tlInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlInscripciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbInscribirse;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_cursado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;

    }
}