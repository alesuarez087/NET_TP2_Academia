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
    public partial class Materias : Form
    {
        public Usuario UsuarioActual
        {
            get;set;
        }

        public Materias(Usuario u)
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            UsuarioActual = u;
        }

        public void Listar()
        {
            this.dgvMaterias.AutoGenerateColumns = false;
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach (ModuloUsuario mu in mul.GetPermisos(UsuarioActual.ID))
            {
                if (mu.DescripcionModulo == "Materias")
                {
                    this.dgvMaterias.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbElimiar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop form = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((((DataRowView)this.dgvMaterias.SelectedRows[0].DataBoundItem))["id_materia"].ToString());
            MateriasDesktop form = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbElimiar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea Eliminar la materia?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = Convert.ToInt32((((DataRowView)this.dgvMaterias.SelectedRows[0].DataBoundItem))["id_materia"].ToString());
                MateriasDesktop form = new MateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
