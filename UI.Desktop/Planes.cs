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
    public partial class Planes : Form
    {
        public Usuario UsuarioActual
        {
            get;set;
        }

        public Planes(Usuario u)
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            UsuarioActual = u;
        }


        public void Listar()
        {
            this.dgvPlanes.AutoGenerateColumns = false;
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetTabla();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach (ModuloUsuario mu in mul.GetPermisos(UsuarioActual.ID))
            {
                if (mu.DescripcionModulo == "Planes")
                {
                    this.dgvPlanes.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop formPlan = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((DataRowView)this.dgvPlanes.SelectedRows[0].DataBoundItem)["id_plan"].ToString());
            PlanesDesktop formPlan = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea eliminar el Plan?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(((DataRowView)this.dgvPlanes.SelectedRows[0].DataBoundItem)["id_plan"].ToString());
                PlanesDesktop formPlan = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
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
