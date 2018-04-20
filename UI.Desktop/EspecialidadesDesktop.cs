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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        public Especialidad EspecialidadActual
        {
            get;set;
        }
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadesDesktop(ModoForm modo) : this()    
        {
            this.Modo = modo;
        }
        public EspecialidadesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
            try
            {
                EspecialidadActual = EspecialidadNegocio.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos() 
        {
            this.txtId.Text = EspecialidadActual.ID.ToString();
            this.txtEspecialidad.Text = EspecialidadActual.Descripcion;
           
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
            #region STATE
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    EspecialidadActual.State = Especialidad.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    EspecialidadActual.State = Especialidad.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.State = Especialidad.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = Especialidad.States.Modified;
                    break;
            }
            #endregion
            
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    EspecialidadActual.ID = Convert.ToInt32(this.txtId.Text);
                EspecialidadActual.Descripcion = this.txtEspecialidad.Text;
            }

        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            if (this.Validar())
            {
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspecialidadActual);
                this.Close();
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.txtEspecialidad.Text == String.Empty)
            {
                EsValido = false;
                this.Notificar("Es campo Descripcion es obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(EspecialidadActual.State == BusinessEntity.States.New)
            {
                EspecialidadLogic el = new EspecialidadLogic();
                foreach (Especialidad e in el.GetAll()) if (EspecialidadActual.Descripcion == e.Descripcion)
                    {
                        EsValido = false;
                    }
                if (!EsValido) this.Notificar("Advertencia", "Ya existe esa Carrera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return EsValido;
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
