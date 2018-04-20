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
    public partial class PlanesDesktop : ApplicationForm
    {
        public Plan PlanActual
        {
            get; set;
        }

        public void CargarEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.cmbEspecialidad.ValueMember = "Id";
            this.cmbEspecialidad.DisplayMember = "Descripcion";
            this.cmbEspecialidad.DataSource = el.GetAll();
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cmbEspecialidad.SelectedValue = this.PlanActual.IDEespecialidad;
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else
            {
                if (Modo == ModoForm.Consulta)
                {
                    btnAceptar.Text = "Aceptar";
                }
                else
                {
                    btnAceptar.Text = "Eliminar";
                }
            }

        }

        public override void MapearADatos()
        {
            if(Modo==ModoForm.Alta)
            {
                Plan plan = new Plan();
                PlanActual = plan;
                PlanActual.State = BusinessEntity.States.New;
            }
            else
            {
                  if(Modo == ModoForm.Modificacion)
                    {
                        this.PlanActual.ID = int.Parse(this.txtId.Text);
                        PlanActual.State = BusinessEntity.States.Modified;
                    }
            }
            this.PlanActual.Descripcion = this.txtDescripcion.Text;

            this.PlanActual.IDEespecialidad = (int)this.cmbEspecialidad.SelectedValue;
        }

        public override bool Validar()
        {
            if(PlanActual == null)
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                bool valid = true ;
                PlanLogic pl = new PlanLogic();
                foreach(Plan p in pl.GetAll())
                {
                    if(p.IDEespecialidad == PlanActual.IDEespecialidad && p.Descripcion == PlanActual.Descripcion)
                    {
                        valid = false;
                    }
                }
                if(valid)
                {
                    return true;
                }
                else
                {
                    this.Notificar("Advertencia", "Ya existe este plan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if (Validar())
            {
                PlanLogic pl = new PlanLogic();
                pl.Save(PlanActual);
                this.Close();
            }
        }

        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ApplicationForm.ModoForm form) : this()
        {
            PlanActual = new Plan();
        }

        public PlanesDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            PlanLogic pl = new PlanLogic();
            if(modo == ModoForm.Baja)
            {
                this.GuardarCambios();
            }
            if(modo==ModoForm.Modificacion)
            {
                Modo = modo;
                this.PlanActual = pl.GetOne(ID);
                this.MapearDeDatos();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
            this.CargarEspecialidades();
        }
    }
}
