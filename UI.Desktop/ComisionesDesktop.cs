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
    public partial class ComisionesDesktop : ApplicationForm
    {
        #region PROPIEDADES
        public Comision ComisionActual
        {
            get;set;
        }

        public ComisionesDesktop()
        {
            InitializeComponent();
            this.cmbPlan.Enabled = false;
            this.CargaEspecialidades();
        }
        #endregion

        #region MÉTODOS
        public void CargaPlanes(int ID)
        {
            List<Plan> listado = new List<Plan>();
            PlanLogic pl = new PlanLogic();
            try
            {
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
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                listado = null;
            }
        }

        public void CargaEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                cmbEspecialidad.DataSource = el.GetAll();
                cmbEspecialidad.ValueMember = "ID";
                cmbEspecialidad.DisplayMember = "Descripcion";
                this.CargaPlanes((int)cmbEspecialidad.SelectedValue);
            }
            catch(Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.nudAnio.Value = this.ComisionActual.AnioEspecialidad;
            this.cmbPlan.SelectedItem = this.ComisionActual.IdPlan;
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
                    btnAceptar.Text = "Salir";
                }

            }

        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Comision com = new Comision();
                ComisionActual = com;
                ComisionActual.State = BusinessEntity.States.New;
            }
            else
            {
                if (Modo == ModoForm.Modificacion)
                {
                    this.ComisionActual.ID = int.Parse(this.txtId.Text);

                    ComisionActual.State = BusinessEntity.States.Modified;
                }
            }
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = (int)this.nudAnio.Value;
            this.ComisionActual.IdPlan = (int)this.cmbPlan.SelectedValue;
        }

        public override bool Validar()
        {
            if (this.ComisionActual == null)
            {
                this.Notificar("Advertencia", "No se han completado todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                ComisionLogic cl = new ComisionLogic();
                foreach (DataRow row in cl.GetAll().Rows)
                {
                    if (ComisionActual.Descripcion == (string)row["desc_comision"] && ComisionActual.IdPlan == (int)row["id_plan"])
                    {
                        this.Notificar("Advertencia", "Ya existe esa Comisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                return true;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            try
            {
                if (Validar())
                {
                    ComisionLogic comision = new ComisionLogic();
                    comision.Save(ComisionActual);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS
        public ComisionesDesktop(ApplicationForm.ModoForm modo) : this()
        {
            ComisionActual = new Comision();
        }

        public ComisionesDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            ComisionLogic cl = new ComisionLogic();
            if (modo == ModoForm.Baja)
            {
                cl.Delete(ID);
            }
            if (modo == ModoForm.Modificacion)
            {
                Modo = modo;
                this.ComisionActual = cl.GetOne(ID);
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
        #endregion

    }
}
