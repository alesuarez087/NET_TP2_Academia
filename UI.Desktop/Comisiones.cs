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
    public partial class Comisiones : Form
    {
        #region PROPIEDADES
        public Usuario UsuarioActual
        {
            get;set;
        }

        public Comisiones(Usuario u)
        {
            InitializeComponent();
            UsuarioActual = u;
        }
        #endregion

        #region MÉTODOS
        public void Listar()
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
        }
#endregion

        #region EVENTOS
        private void Comisiones_Load(object sender, EventArgs e)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach (ModuloUsuario mu in mul.GetPermisos(UsuarioActual.ID))
            {
                if (mu.DescripcionModulo == "Comisiones")
                {
                    this.dgvComisiones.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop formComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((DataRowView)this.dgvComisiones.SelectedRows[0].DataBoundItem)["id_comision"].ToString());
            ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea eliminar la Comisión?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = Convert.ToInt32((((DataRowView)this.dgvComisiones.SelectedRows[0].DataBoundItem))["id_comision"].ToString());
                ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
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

        #endregion
    }
}
