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
    public partial class Usuarios : ApplicationForm
    {
        public Usuario UsuarioActual
        {
            get;set;
        }

        public Usuarios(Usuario u)
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
            UsuarioActual = u;
        }

        private void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ModuloLogic ml = new ModuloLogic();
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach(ModuloUsuario mu in mul.GetPermisos(UsuarioActual.ID))
            {
                Modulo mod = ml.GetOne(mu.IdModulo);
                if (mod.Descripcion == "Usuarios")
                {
                    this.dgvUsuarios.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuariosDesktop form = new UsuariosDesktop(UsuarioActual.ID, ID, ModoForm.Modificacion);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuariosDesktop form = new UsuariosDesktop(ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                    UsuarioLogic user = new UsuarioLogic();
                    user.Delete(ID);
                    this.Listar();
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
