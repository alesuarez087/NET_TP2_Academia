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
using Util;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public Persona PersonaActual
        {
            get; set;
        }

        public PersonaDesktop(ModoForm modo)
        {
            this.Modo = modo;
            InitializeComponent();
            PersonaActual = new Persona();
            this.CargaCarrera();
            this.CargaTipoPersona();
        }

        public PersonaDesktop(int ID, ModoForm modo)
        {
            this.Modo = modo;
            InitializeComponent();
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            this.CargaCarrera();
            this.CargaTipoPersona();
            this.MapearDeDatos();
        }

        public void CargaPlanes(int ID)
        {
            List<Plan> listado = new List<Plan>();
            PlanLogic pl = new PlanLogic();
            foreach (Plan i in pl.GetAll())
            {
                if (i.IDEespecialidad == ID)
                {
                    listado.Add(i);
                }

            }
            if (listado.Count == 0)
            {
                this.cmbPlan.Enabled = false;
                this.cmbPlan.Text = "";
            }
            else
            {
                this.cmbPlan.Enabled = true;
            }
            cmbPlan.DataSource = listado;
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
            listado = null;
        }

        public void CargaCarrera()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbCarrera.ValueMember = "Id";
            cmbCarrera.DisplayMember = "Descripcion";
            cmbCarrera.DataSource = el.GetAll();
            this.CargaPlanes((int)cmbCarrera.SelectedValue);
        }

        private void CargaTipoPersona()
        {
            this.cmbTipoPersona.Items.Add("Alumno");
            this.cmbTipoPersona.Items.Add("Profesor");
            this.cmbTipoPersona.Items.Add("Administrador");
        }

        public override void MapearADatos()
        {
            PersonaActual.Nombre = this.txtNombre.Text;
            PersonaActual.Apellido = this.txtApellido.Text;
            PersonaActual.Direccion = this.txtDireccion.Text;
            PersonaActual.Email = this.txtEmail.Text;
            PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
            PersonaActual.Telefono = this.txtTelefono.Text;
            PersonaActual.IdPlan = (int)this.cmbPlan.SelectedValue;
            PersonaActual.FechaNacimiento = new DateTime(int.Parse(txtAno.Text), int.Parse(txtMes.Text), int.Parse(txtDia.Text));

            switch((string)this.cmbTipoPersona.SelectedItem)
            {
                case "Alumno": PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
                    break;
                case "Administrador": PersonaActual.TipoPersona = Persona.TiposPersonas.Administrador;
                    break;
                case "Profesor": PersonaActual.TipoPersona = Persona.TiposPersonas.Profesor;
                    break;
            }
            
            switch(this.Modo)
            {
                case ModoForm.Alta: PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja: PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion: PersonaActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtNombre.Text = PersonaActual.Nombre;
            this.txtApellido.Text = PersonaActual.Apellido;
            this.txtDireccion.Text = PersonaActual.Direccion;
            this.txtEmail.Text = PersonaActual.Email;
            this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = PersonaActual.Telefono;
            this.cmbPlan.SelectedValue = PersonaActual.IdPlan;
            this.txtAno.Text = PersonaActual.FechaNacimiento.Year.ToString();
            this.txtMes.Text = PersonaActual.FechaNacimiento.Month.ToString();
            this.txtDia.Text = PersonaActual.FechaNacimiento.Day.ToString();

            switch(PersonaActual.TipoPersona)
            {
                case Persona.TiposPersonas.Administrador: this.cmbTipoPersona.SelectedItem = "Administrador";
                    break;
                case Persona.TiposPersonas.Alumno: this.cmbTipoPersona.SelectedItem = "Alumno";
                    break;
                case Persona.TiposPersonas.Profesor: this.cmbTipoPersona.SelectedItem = "Profesor";
                    break;
            }

            switch (this.Modo)
            {
                case ModoForm.Baja: PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion: PersonaActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (this.PersonaActual == null)
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (PersonaActual.FechaNacimiento.Day > 31)
                {
                    this.Notificar("Advertencia", "Error en los días de fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    if (PersonaActual.FechaNacimiento.Month < 1 || PersonaActual.FechaNacimiento.Month > 12)
                    {
                        this.Notificar("Advertencia", "Error en los meses de fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                    {
                        if ((PersonaActual.FechaNacimiento.Month == 4 || PersonaActual.FechaNacimiento.Month == 6 ||
                        PersonaActual.FechaNacimiento.Month == 9 || PersonaActual.FechaNacimiento.Month == 11)
                        && PersonaActual.FechaNacimiento.Day > 30)
                        {
                            this.Notificar("Advertencia", "Error en los días de fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        else
                        {
                            if (PersonaActual.FechaNacimiento.Day > 31 && (PersonaActual.FechaNacimiento.Month == 1 || PersonaActual.FechaNacimiento.Month == 7 ||
                                PersonaActual.FechaNacimiento.Month == 3 || PersonaActual.FechaNacimiento.Month == 5 || PersonaActual.FechaNacimiento.Month == 8 ||
                                PersonaActual.FechaNacimiento.Month == 10 || PersonaActual.FechaNacimiento.Month == 12))
                            {
                                this.Notificar("Advertencia", "Error en los días de fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            else
                            {
                                if (Validacion.EsMailValido(PersonaActual.Email))
                                {
                                    if (PersonaActual.FechaNacimiento.Month == 2 && PersonaActual.FechaNacimiento.Day > 28)
                                    {
                                        if (PersonaActual.FechaNacimiento.Day == 29 && PersonaActual.FechaNacimiento.Month == 2 && PersonaActual.FechaNacimiento.Year % 4 != 0)
                                        {
                                            this.Notificar("Advertencia", "Error en los días de fecha de nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                     }
                                     else
                                     {
                                         return true;
                                     }
                                }
                                else
                                {
                                    this.Notificar("Advertencia", "Error en el ingreso del mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if(this.Validar())
            {
                PersonaLogic pl = new PersonaLogic();
                pl.Save(PersonaActual);
                this.Close();
            }
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargaPlanes((int)cmbCarrera.SelectedValue);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }

    }
}
