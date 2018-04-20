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
    public partial class Login : ApplicationForm
    {

#region PROPIEDADES
        public Usuario UsuarioActual
        {
            get; set;
        }

        public Login()
        {
            InitializeComponent();
        }
#endregion

#region EVENTOS
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                UsuarioActual = user.GetUsuarioForLogin(txtUsuario.Text, txtContrasena.Text);
                if (UsuarioActual.ID != 0)
                {
                    if (UsuarioActual.Habilitado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtContrasena.Clear();
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion
    }
}
