using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Usuario UsuarioActual
        {
            get;set;
        }

        public Cursos(Usuario u)
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            UsuarioActual = u;
        }

        private void Listar()
        {
            this.dgvCursos.AutoGenerateColumns = false;
            CursoLogic cl = new CursoLogic();
            dgvCursos.DataSource = cl.GetAll();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach (ModuloUsuario mu in mul.GetPermisos(UsuarioActual.ID))
            {
                if (mu.DescripcionModulo == "Cursos")
                {
                    this.dgvCursos.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop form = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((DataRowView)this.dgvCursos.SelectedRows[0].DataBoundItem)["id_curso"].ToString());
            CursosDesktop form = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea Eliminar el Curso?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(((DataRowView)this.dgvCursos.SelectedRows[0].DataBoundItem)["id_curso"].ToString());
                CursosDesktop form = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);
                form.ShowDialog();
                this.Listar();
            }
        }

        private void tsbAgregarDocente_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((DataRowView)this.dgvCursos.SelectedRows[0].DataBoundItem)["id_curso"].ToString());
            DocentesCursos form = new DocentesCursos(ID);
            form.ShowDialog();
        }


    }
}
