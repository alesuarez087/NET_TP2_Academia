using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class MainMenu : ApplicationForm
    {
        public Usuario UsuarioActual
        {
            get; set;
        }

        public List<ModuloUsuario> ModulosUsuarioActual
        {
            get;set;
        }

        public Persona PersonaActual
        {
            get;set;
        }
        public MainMenu(Usuario u)
        {
            InitializeComponent();
            UsuarioActual = u;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.Permisos();      
        }

        private void Permisos()
        {
            try
            {
                this.tsmiEspecialidades.Visible =
                this.tsmiUsuarios.Visible = 
                this.tsmiRegistrarNotas.Visible =
                this.tsmiInscripcionACurso.Visible=
                this.tsmiPlanes.Visible =
                this.tsmiMaterias.Visible =
                this.tsmiComisiones.Visible = 
                this.tsmiPersonas.Visible = 
                this.tsmiReportes.Visible = false;

                this.tsmiUsuarios.Text = "Usuarios";
                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                PersonaLogic pl = new PersonaLogic();
                ModulosUsuarioActual = mul.GetAll(UsuarioActual.ID);
                PersonaActual = pl.GetOne(UsuarioActual.IdPersona);


                if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    this.tsmiInscripcionACurso.Visible = true;
                    this.tsmiUsuarios.Text = "Cambiar Contraseña";
                }
                else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Profesor)
                {
                    this.tsmiRegistrarNotas.Visible = true;
                }
                else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
                {
                    this.tsmiReportes.Visible = true;
                }
                

                foreach (ModuloUsuario mu in ModulosUsuarioActual)
                {
                    if (mu.DescripcionModulo == "Usuarios")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiUsuarios.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Especialidades")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiEspecialidades.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Cursos")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiCursos.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Planes")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiPlanes.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Materias")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiMaterias.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Comisiones")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiComisiones.Visible = true;
                    }
                    else if (mu.DescripcionModulo == "Personas")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                            this.tsmiPersonas.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
            {
                Usuarios form = new Usuarios(UsuarioActual);
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                UsuariosDesktop form = new UsuariosDesktop(UsuarioActual.ID, ModoForm.Modificacion);
                form.MdiParent = this;
                form.Show();
            }
        }

        private void tsmiCerrarSesion_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
            }
            this.Visible = false;
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.UsuarioActual = login.UsuarioActual;
                this.Permisos();
                this.Visible = true;
            }
            else
            {
                this.Close();
            }

        }

        private void tsmiEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades form = new Especialidades(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiRegistrarNotas_Click(object sender, EventArgs e)
        {            
            CursoLogic cl = new CursoLogic();
            DataTable comisiones = cl.GetAll(PersonaActual.ID).Clone();
            foreach (DataRow row in cl.GetAll(PersonaActual.ID).Rows)
            {
                if ((int)row["cargo"] == 1)
                {
                    comisiones.ImportRow(row);
                }
            }
            if (comisiones.Rows.Count == 0)
            {
                this.Notificar("Advertencia", "No posee materias a su titularidad. No puede agregar notas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                RegistroNota form = new RegistroNota(PersonaActual, comisiones);
                form.MdiParent = this;
                form.Show();
            }
        }

        private void tsmiInscripcionACurso_Click(object sender, EventArgs e)
        {
            Inscripciones form = new Inscripciones(PersonaActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiCursos_Click(object sender, EventArgs e)
        {
            Cursos form = new Cursos(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiPlanes_Click(object sender, EventArgs e)
        {
            Planes form = new Planes(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiMaterias_Click(object sender, EventArgs e)
        {
            Materias form = new Materias(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiPersonas_Click(object sender, EventArgs e)
        {
            Personas form = new Personas(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiComisiones_Click(object sender, EventArgs e)
        {
            Comisiones form = new Comisiones(UsuarioActual);
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiReporteCursos_Click(object sender, EventArgs e)
        {
            ReporteCursos form = new ReporteCursos();
            form.MdiParent = this;
            form.Show();
        }

        private void tsmiReportePlanes_Click(object sender, EventArgs e)
        {
            ReportePlanes form = new ReportePlanes();
            form.MdiParent = this;
            form.Show();
        }
    }
}
