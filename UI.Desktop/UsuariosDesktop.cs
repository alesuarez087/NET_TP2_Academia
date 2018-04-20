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
    public partial class UsuariosDesktop : ApplicationForm
    {
        public Usuario UsuarioSeleccionado
        {
            get;
            set;
        }
        public Usuario UsuarioActual
        {
            get;set;
        }
        public Persona PersonaSeleccionada
        {
            get;
            set;
        }
        public Persona PersonaActual
        {
            get;set;
        }
        public List<ModuloUsuario> ModuloUsuarioSeleccionado
        {
            get;
            set;
        }
        private int count;

        #region CONSTRUCTORES
        public UsuariosDesktop()
        {
            InitializeComponent();
            this.dgvModulo.AutoGenerateColumns = false;
            ModuloUsuarioSeleccionado = new List<ModuloUsuario>();
        }

        public UsuariosDesktop(int IdAdministrador, int IdModifica, ApplicationForm.ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(IdAdministrador);
            UsuarioSeleccionado = ul.GetOne(IdModifica);
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(UsuarioActual.IdPersona);
            PersonaSeleccionada = pl.GetOne(UsuarioSeleccionado.IdPersona);
            UsuarioSeleccionado.State = BusinessEntity.States.Modified;
            if(PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
            {
                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                count = mul.GetAll(UsuarioSeleccionado.ID).Count;
                if(count == 0)
                {
                    this.dgvModulo.DataSource = mul.GetAll();
                }
                else
                {
                    this.dgvModulo.DataSource = mul.GetAll(UsuarioSeleccionado.ID);
                }
            }
            this.MapearDeDatos();
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Enabled = true;
        }

        public UsuariosDesktop(int IdUsuario, ApplicationForm.ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioSeleccionado = ul.GetOne(IdUsuario);
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = PersonaSeleccionada = pl.GetOne(UsuarioSeleccionado.IdPersona);
            UsuarioSeleccionado.State = BusinessEntity.States.Modified;
            this.chbxHabilitado.Visible = false;
            this.btnSeleccionarPersonas.Visible = false;
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Enabled = true;
            this.MapearDeDatos();
        }

        public UsuariosDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioActual = new Usuario();
            PersonaActual = new Persona();
            UsuarioActual.State = BusinessEntity.States.New;
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            this.dgvModulo.DataSource = mul.GetAll();
        }
#endregion

        #region METODOS CREADOS
        public override void MapearDeDatos()
        {
            if(Modo != ModoForm.Alta)
            {
                this.txtId.Text = UsuarioSeleccionado.ID.ToString();
                this.txtUsuario.Text = UsuarioSeleccionado.NombreUsuario;
                this.chbxHabilitado.Checked = UsuarioSeleccionado.Habilitado;
                this.txtPersona.Text = UsuarioSeleccionado.Apellido + ", " + UsuarioSeleccionado.Nombre;
            }
            else this.txtPersona.Text = PersonaSeleccionada.Apellido + ", " + PersonaSeleccionada.Nombre;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            BusinessEntity.States estado = new BusinessEntity.States();
            if (count == 0)
            {
                UsuarioSeleccionado = new Usuario();
                estado = BusinessEntity.States.New;
            }
            else
            {
                estado = BusinessEntity.States.Modified;
            }

            UsuarioSeleccionado.Apellido = PersonaSeleccionada.Apellido;
            UsuarioSeleccionado.Email = PersonaSeleccionada.Email;
            UsuarioSeleccionado.IdPersona = PersonaSeleccionada.ID;
            UsuarioSeleccionado.Nombre = PersonaSeleccionada.Nombre;
            UsuarioSeleccionado.NombreUsuario = txtUsuario.Text;
            UsuarioSeleccionado.Clave = txtContrasena.Text;
            UsuarioSeleccionado.Habilitado = chbxHabilitado.Checked;
            UsuarioSeleccionado.State = estado; 

            foreach (DataGridViewRow row in this.dgvModulo.Rows)
            {
                ModuloUsuario mu = new ModuloUsuario();
                mu.State = estado;
                mu.IdUsuario = UsuarioActual.ID;
                mu.IdModulo = (int)row.Cells[0].Value;
                mu.PermiteAlta = (bool)row.Cells[2].Value;
                mu.PermiteBaja = (bool)row.Cells[3].Value;
                mu.PermiteModificacion = (bool)row.Cells[5].Value;
                mu.PermiteConsulta = (bool)row.Cells[4].Value;
                mu.ID = (int)row.Cells[6].Value;
                ModuloUsuarioSeleccionado.Add(mu);
            }
        }

        private void btnSeleccionarPersonas_Click(object sender, EventArgs e)
        {
            SeleccionarPersona form = new SeleccionarPersona();
            form.ShowDialog();
            PersonaSeleccionada = form.PersonaSeleccionada;
            if (PersonaActual != null)
            {
                this.MapearDeDatos();
            }
            else
            {
                this.Close();
            }
        }

        public override bool Validar()
        {
            if(UsuarioSeleccionado.State == BusinessEntity.States.New)
            {
                UsuarioLogic ul = new UsuarioLogic();
                bool rep = false;
                foreach (Usuario u in ul.GetAll()) if (u.NombreUsuario.Equals(txtUsuario.Text)) rep = true;
                if (rep)
                {
                    this.Notificar("Advertencia", "Usuario Repetido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if(txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
            {
                if (txtContrasena.Text.Equals(""))
                {
                    this.Notificar("Advertencia", "Ingrese Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                this.Notificar("Advertencia", "Contraseñas distintas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if(this.Validar())
            {
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(UsuarioSeleccionado);
                Usuario seleccionado = ul.GetUsuarioForLogin(UsuarioSeleccionado.NombreUsuario, UsuarioSeleccionado.Clave);
                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                foreach(ModuloUsuario mu in ModuloUsuarioSeleccionado)
                {
                    mu.IdUsuario = seleccionado.ID;
                    mul.Save(mu);
                }
                this.Close();
            }
        }

        private void GuardaModulos()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario seleccionado = ul.GetUsuarioForLogin(UsuarioSeleccionado.NombreUsuario, UsuarioSeleccionado.Clave);
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            foreach (ModuloUsuario mu in ModuloUsuarioSeleccionado)
            {
                mu.IdUsuario = seleccionado.ID;
                mul.Save(mu);
            }
            this.Close();
        }
#endregion

        #region EVENTOS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuariosDesktop_Load(object sender, EventArgs e)
        {
            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
                this.dgvModulo.Visible = true;
            else
                this.dgvModulo.Visible = false;
        }
    }
        #endregion
}
