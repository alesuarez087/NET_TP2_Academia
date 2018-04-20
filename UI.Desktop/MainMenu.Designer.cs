namespace UI.Desktop
{
    partial class MainMenu
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegistrarNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInscripcionACurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReporteCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportePlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo,
            this.tsmiModulos});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(619, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCerrarSesion});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmiArchivo.Text = "&Archivo";
            // 
            // tsmiCerrarSesion
            // 
            this.tsmiCerrarSesion.Name = "tsmiCerrarSesion";
            this.tsmiCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.tsmiCerrarSesion.Text = "Cerrar Sesión";
            this.tsmiCerrarSesion.Click += new System.EventHandler(this.tsmiCerrarSesion_Click);
            // 
            // tsmiModulos
            // 
            this.tsmiModulos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuarios,
            this.tsmiEspecialidades,
            this.tsmiRegistrarNotas,
            this.tsmiInscripcionACurso,
            this.tsmiCursos,
            this.tsmiPlanes,
            this.tsmiMaterias,
            this.tsmiComisiones,
            this.tsmiPersonas,
            this.tsmiReportes});
            this.tsmiModulos.Name = "tsmiModulos";
            this.tsmiModulos.Size = new System.Drawing.Size(66, 20);
            this.tsmiModulos.Text = "&Modulos";
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.Size = new System.Drawing.Size(175, 22);
            this.tsmiUsuarios.Text = "Usuarios";
            this.tsmiUsuarios.Click += new System.EventHandler(this.tsmiUsuarios_Click);
            // 
            // tsmiEspecialidades
            // 
            this.tsmiEspecialidades.Name = "tsmiEspecialidades";
            this.tsmiEspecialidades.Size = new System.Drawing.Size(175, 22);
            this.tsmiEspecialidades.Text = "Especialidades";
            this.tsmiEspecialidades.Click += new System.EventHandler(this.tsmiEspecialidades_Click);
            // 
            // tsmiRegistrarNotas
            // 
            this.tsmiRegistrarNotas.Name = "tsmiRegistrarNotas";
            this.tsmiRegistrarNotas.Size = new System.Drawing.Size(175, 22);
            this.tsmiRegistrarNotas.Text = "Registrar Notas";
            this.tsmiRegistrarNotas.Click += new System.EventHandler(this.tsmiRegistrarNotas_Click);
            // 
            // tsmiInscripcionACurso
            // 
            this.tsmiInscripcionACurso.Name = "tsmiInscripcionACurso";
            this.tsmiInscripcionACurso.Size = new System.Drawing.Size(175, 22);
            this.tsmiInscripcionACurso.Text = "Inscripcion a Curso";
            this.tsmiInscripcionACurso.Click += new System.EventHandler(this.tsmiInscripcionACurso_Click);
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(175, 22);
            this.tsmiCursos.Text = "Cursos";
            this.tsmiCursos.Click += new System.EventHandler(this.tsmiCursos_Click);
            // 
            // tsmiPlanes
            // 
            this.tsmiPlanes.Name = "tsmiPlanes";
            this.tsmiPlanes.Size = new System.Drawing.Size(175, 22);
            this.tsmiPlanes.Text = "Planes";
            this.tsmiPlanes.Click += new System.EventHandler(this.tsmiPlanes_Click);
            // 
            // tsmiMaterias
            // 
            this.tsmiMaterias.Name = "tsmiMaterias";
            this.tsmiMaterias.Size = new System.Drawing.Size(175, 22);
            this.tsmiMaterias.Text = "Materias";
            this.tsmiMaterias.Click += new System.EventHandler(this.tsmiMaterias_Click);
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(175, 22);
            this.tsmiComisiones.Text = "Comisiones";
            this.tsmiComisiones.Click += new System.EventHandler(this.tsmiComisiones_Click);
            // 
            // tsmiPersonas
            // 
            this.tsmiPersonas.Name = "tsmiPersonas";
            this.tsmiPersonas.Size = new System.Drawing.Size(175, 22);
            this.tsmiPersonas.Text = "Personas";
            this.tsmiPersonas.Click += new System.EventHandler(this.tsmiPersonas_Click);
            // 
            // tsmiReportes
            // 
            this.tsmiReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReporteCursos,
            this.tsmiReportePlanes});
            this.tsmiReportes.Name = "tsmiReportes";
            this.tsmiReportes.Size = new System.Drawing.Size(175, 22);
            this.tsmiReportes.Text = "Reportes";
            // 
            // tsmiReporteCursos
            // 
            this.tsmiReporteCursos.Name = "tsmiReporteCursos";
            this.tsmiReporteCursos.Size = new System.Drawing.Size(152, 22);
            this.tsmiReporteCursos.Text = "Cursos";
            this.tsmiReporteCursos.Click += new System.EventHandler(this.tsmiReporteCursos_Click);
            // 
            // tsmiReportePlanes
            // 
            this.tsmiReportePlanes.Name = "tsmiReportePlanes";
            this.tsmiReportePlanes.Size = new System.Drawing.Size(152, 22);
            this.tsmiReportePlanes.Text = "Planes";
            this.tsmiReportePlanes.Click += new System.EventHandler(this.tsmiReportePlanes_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 362);
            this.Controls.Add(this.msMainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiModulos;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegistrarNotas;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscripcionACurso;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonas;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportes;
        private System.Windows.Forms.ToolStripMenuItem tsmiReporteCursos;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportePlanes;

    }
}