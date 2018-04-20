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
    public partial class MateriasDesktop : ApplicationForm
    {
        public MateriasDesktop()
        {
            InitializeComponent();
            this.cmbPlan.Enabled = false;
            this.CargaEspecialidades();
        }

        public Materia MateriaActual
        {
            get;set;
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

        public void CargaPlanes()
        {
            PlanLogic pl = new PlanLogic();
            this.cmbPlan.ValueMember = "Id";
            this.cmbPlan.DisplayMember = "Descripcion";
            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.SelectedValue = MateriaActual.IdPlan;
            this.CargaEspecialidades(MateriaActual.IdPlan);
        }

        public void CargaEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidad.ValueMember = "Id";
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.DataSource = el.GetAll();
            this.CargaPlanes((int)cmbEspecialidad.SelectedValue);
        }

        public void CargaEspecialidades(int IdPlan)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            PlanLogic pl = new PlanLogic();
            cmbEspecialidad.ValueMember = "Id";
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.DataSource = el.GetAll();
            Plan p = pl.GetOne(IdPlan);
            foreach(Especialidad e in el.GetAll())
            {
                if (e.ID == p.IDEespecialidad) this.cmbEspecialidad.SelectedValue = e.ID;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = MateriaActual.ID.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHsSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = MateriaActual.HSTotales.ToString();
            this.CargaPlanes();
            if (Modo == ApplicationForm.ModoForm.Alta || Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else
            {
                if (Modo == ApplicationForm.ModoForm.Consulta)
                {
                    btnAceptar.Text = "Aceptar";
                }
                else
                {
                    btnAceptar.Text = "Salir";
                }
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Materia mat = new Materia();
                MateriaActual = mat;
                MateriaActual.State = BusinessEntity.States.New;
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
            }
            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HSSemanales = int.Parse(this.txtHsSemanales.Text);
            this.MateriaActual.HSTotales = int.Parse(this.txtHsTotales.Text);
            this.MateriaActual.IdPlan = (int)this.cmbPlan.SelectedValue;
        }

        public override bool Validar()
        {
            if (MateriaActual == null)
            {
                this.Notificar("Advertencia", "No se completaron todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                bool o = true;
                MateriaLogic ml = new MateriaLogic();
                foreach (DataRow i in ml.GetAll().Rows)
                {
                    if ((string)i["desc_materia"] == MateriaActual.Descripcion && MateriaActual.IdPlan == (int)i["id_plan"])
                    {
                        o = false;
                    }
                }
                if (o)
                {
                    return true;
                }
                else
                {
                    this.Notificar("Advertencia", "Ya existe esa materia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }


            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if (Validar())
            {
                MateriaLogic ml = new MateriaLogic();
                ml.Save(MateriaActual);
                this.Close();
            }
        }

        public MateriasDesktop(ApplicationForm.ModoForm modo) : this()
        {
            MateriaActual = new Materia();
        }

        public MateriasDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            MateriaLogic ml = new MateriaLogic();
            if (modo == ModoForm.Baja)
            {
                ml.Delete(ID);
            }
            if (modo == ModoForm.Modificacion)
            {
                Modo = modo;
                this.MateriaActual = ml.GetOne(ID);
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

        private void cmbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.CargaPlanes((int)cmbEspecialidad.SelectedValue);
        }
    
    
    }
}
