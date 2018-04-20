namespace UI.Desktop
{
    partial class UsuariosDesktop
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
            this.tlUsuariosDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblConfirmarContrasena = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.chbxHabilitado = new System.Windows.Forms.CheckBox();
            this.btnSeleccionarPersonas = new System.Windows.Forms.Button();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvModulo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.consulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idbd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlUsuariosDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlUsuariosDesktop
            // 
            this.tlUsuariosDesktop.ColumnCount = 5;
            this.tlUsuariosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuariosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlUsuariosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlUsuariosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlUsuariosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuariosDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlUsuariosDesktop.Controls.Add(this.lblUsuario, 0, 1);
            this.tlUsuariosDesktop.Controls.Add(this.lblContrasena, 0, 2);
            this.tlUsuariosDesktop.Controls.Add(this.lblConfirmarContrasena, 0, 3);
            this.tlUsuariosDesktop.Controls.Add(this.txtId, 1, 0);
            this.tlUsuariosDesktop.Controls.Add(this.txtUsuario, 1, 1);
            this.tlUsuariosDesktop.Controls.Add(this.txtContrasena, 1, 2);
            this.tlUsuariosDesktop.Controls.Add(this.txtConfirmarContrasena, 1, 3);
            this.tlUsuariosDesktop.Controls.Add(this.chbxHabilitado, 3, 0);
            this.tlUsuariosDesktop.Controls.Add(this.btnSeleccionarPersonas, 3, 1);
            this.tlUsuariosDesktop.Controls.Add(this.txtPersona, 3, 2);
            this.tlUsuariosDesktop.Controls.Add(this.btnAceptar, 3, 5);
            this.tlUsuariosDesktop.Controls.Add(this.btnCancelar, 4, 5);
            this.tlUsuariosDesktop.Controls.Add(this.dgvModulo, 1, 4);
            this.tlUsuariosDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuariosDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlUsuariosDesktop.Name = "tlUsuariosDesktop";
            this.tlUsuariosDesktop.RowCount = 6;
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuariosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuariosDesktop.Size = new System.Drawing.Size(871, 408);
            this.tlUsuariosDesktop.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(3, 34);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            this.lblContrasena.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(3, 61);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblConfirmarContrasena
            // 
            this.lblConfirmarContrasena.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(3, 87);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(108, 13);
            this.lblConfirmarContrasena.TabIndex = 3;
            this.lblConfirmarContrasena.Text = "Confirmar Contraseña";
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.Location = new System.Drawing.Point(133, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(255, 20);
            this.txtId.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Location = new System.Drawing.Point(133, 29);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(255, 20);
            this.txtUsuario.TabIndex = 5;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContrasena.Location = new System.Drawing.Point(133, 58);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(255, 20);
            this.txtContrasena.TabIndex = 6;
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(133, 84);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '*';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(255, 20);
            this.txtConfirmarContrasena.TabIndex = 7;
            // 
            // chbxHabilitado
            // 
            this.chbxHabilitado.AutoSize = true;
            this.chbxHabilitado.Location = new System.Drawing.Point(481, 3);
            this.chbxHabilitado.Name = "chbxHabilitado";
            this.chbxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chbxHabilitado.TabIndex = 8;
            this.chbxHabilitado.Text = "Habilitado";
            this.chbxHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionarPersonas
            // 
            this.btnSeleccionarPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeleccionarPersonas.Location = new System.Drawing.Point(481, 29);
            this.btnSeleccionarPersonas.Name = "btnSeleccionarPersonas";
            this.btnSeleccionarPersonas.Size = new System.Drawing.Size(255, 23);
            this.btnSeleccionarPersonas.TabIndex = 9;
            this.btnSeleccionarPersonas.Text = "Seleccionar Persona";
            this.btnSeleccionarPersonas.UseVisualStyleBackColor = true;
            this.btnSeleccionarPersonas.Click += new System.EventHandler(this.btnSeleccionarPersonas_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPersona.Location = new System.Drawing.Point(481, 58);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(255, 20);
            this.txtPersona.TabIndex = 10;
            this.txtPersona.Text = "Persona no seleccionada";
            this.txtPersona.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(661, 382);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(742, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvModulo
            // 
            this.dgvModulo.AllowUserToAddRows = false;
            this.dgvModulo.AllowUserToDeleteRows = false;
            this.dgvModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.modulo,
            this.alta,
            this.baja,
            this.consulta,
            this.modificacion,
            this.idbd});
            this.tlUsuariosDesktop.SetColumnSpan(this.dgvModulo, 3);
            this.dgvModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulo.EnableHeadersVisualStyles = false;
            this.dgvModulo.Location = new System.Drawing.Point(133, 110);
            this.dgvModulo.Name = "dgvModulo";
            this.dgvModulo.RowHeadersVisible = false;
            this.dgvModulo.Size = new System.Drawing.Size(603, 266);
            this.dgvModulo.TabIndex = 13;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdModulo";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // modulo
            // 
            this.modulo.DataPropertyName = "DescripcionModulo";
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            // 
            // alta
            // 
            this.alta.DataPropertyName = "PermiteAlta";
            this.alta.HeaderText = "Alta";
            this.alta.Name = "alta";
            // 
            // baja
            // 
            this.baja.DataPropertyName = "PermiteBaja";
            this.baja.HeaderText = "Baja";
            this.baja.Name = "baja";
            // 
            // consulta
            // 
            this.consulta.DataPropertyName = "PermiteConsulta";
            this.consulta.HeaderText = "Consulta";
            this.consulta.Name = "consulta";
            // 
            // modificacion
            // 
            this.modificacion.DataPropertyName = "PermiteModificacion";
            this.modificacion.HeaderText = "Modificación";
            this.modificacion.Name = "modificacion";
            // 
            // idbd
            // 
            this.idbd.DataPropertyName = "ID";
            this.idbd.HeaderText = "idbd";
            this.idbd.Name = "idbd";
            this.idbd.Visible = false;
            // 
            // UsuariosDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 408);
            this.Controls.Add(this.tlUsuariosDesktop);
            this.Name = "UsuariosDesktop";
            this.Text = "UsuariosDesktop";
            this.Load += new System.EventHandler(this.UsuariosDesktop_Load);
            this.tlUsuariosDesktop.ResumeLayout(false);
            this.tlUsuariosDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlUsuariosDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblConfirmarContrasena;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.CheckBox chbxHabilitado;
        private System.Windows.Forms.Button btnSeleccionarPersonas;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consulta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn modificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbd;
    }
}