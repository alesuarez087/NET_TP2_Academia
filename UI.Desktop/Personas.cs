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
    public partial class Personas : Form
    {
        public Usuario UsuarioActual
        {
            get; set;
        }
        public Personas(Usuario u)
        {
            InitializeComponent();
            UsuarioActual = u;
        }

        private void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop form = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID);
            PersonaDesktop formPlan = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea eliminar la Persona?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID);
                PersonaDesktop formPlan = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
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

        private void Personas_Load(object sender, EventArgs e)
        {
            this.dgvPersonas.AutoGenerateColumns = false;
            this.Listar();
        }
    }
}
