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
    public partial class CursosDesktop : ApplicationForm
    {

        #region PROPIEDADES
        public Curso CursoActual
        {
            get; set;
        }

        public Plan PlanActual
        {
            get;set;
        }

        public CursosDesktop()
        {
            InitializeComponent();
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.cmbPlan.Enabled = true;
            this.cmbComision.Enabled = true;
            this.cmbMateria.Enabled = true;
            CursoActual = new Curso();
            this.ComboEspecialidad();
        }

        public CursosDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            this.ComboEspecialidad();
            MapearDeDatos();
        }
        #endregion

        #region MÉTODOS
        private void ComboEspecialidad()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                cmbEspecialidad.DataSource = el.GetAll();
                cmbEspecialidad.ValueMember = "ID";
                cmbEspecialidad.DisplayMember = "Descripcion";
                cmbEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ComboEspecialidad(int IdPlan)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            PlanLogic pl = new PlanLogic();
            try
            {
                cmbEspecialidad.DataSource = el.GetAll();
                cmbEspecialidad.ValueMember = "ID";
                cmbEspecialidad.DisplayMember = "Descripcion";
                cmbEspecialidad.SelectedValue = pl.GetOne(IdPlan).IDEespecialidad;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboPlanes(int IdEspecialiad)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> list = new List<Plan>();
            try
            {
                foreach (Plan i in pl.GetAll())
                {
                    if (i.IDEespecialidad == IdEspecialiad) list.Add(i);
                }
                cmbPlan.Enabled = true;
                cmbPlan.DataSource = list;
                cmbPlan.DisplayMember = "Descripcion";
                cmbPlan.ValueMember = "ID";
                cmbPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboMaterias(int IdPlan)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> list = new List<Materia>();
            try
            {
                Materia m;
                foreach (DataRow i in ml.GetAll().Rows)
                {
                    if ((int)i["id_plan"] == IdPlan)
                    {
                        m = new Materia();
                        m.ID = (int)i["id_materia"];
                        m.Descripcion = (string)i["desc_materia"];
                        list.Add(m);
                    }
                }
                cmbMateria.Enabled = true;
                cmbMateria.DataSource = list;
                cmbMateria.ValueMember = "ID";
                cmbMateria.DisplayMember = "Descripcion";
                cmbMateria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboComisiones(int IdPlan)
        {
            ComisionLogic cl = new ComisionLogic();
            Comision c;
            try
            {
                List<Comision> list = new List<Comision>();
                foreach (DataRow i in cl.GetAll().Rows)
                {
                    if ((int)i["id_plan"] == IdPlan)
                    {
                        c = new Comision();
                        c.ID = (int)i["id_comision"];
                        c.Descripcion = (string)i["desc_comision"];
                        list.Add(c);
                    }
                }
                cmbComision.Enabled = true;
                cmbComision.DataSource = list;
                cmbComision.ValueMember = "ID";
                cmbComision.DisplayMember = "Descripcion";
                cmbComision.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboComisiones()
        {
            ComisionLogic cl = new ComisionLogic();
            MateriaLogic ml = new MateriaLogic();
            PlanLogic pl = new PlanLogic();
            List<Comision> listaComision = new List<Comision>();
            List<Materia> listaMateria = new List<Materia>();
            Comision c; Materia m;

            try
            {
                #region CARGA COMISIONES
                foreach (DataRow i in cl.GetAll().Rows)
                {
                    c = new Comision();
                    c.ID = (int)i["id_comision"];
                    c.Descripcion = (string)i["desc_comision"];
                    listaComision.Add(c);
                }
                cmbComision.Enabled = true;
                cmbComision.DataSource = listaComision;
                cmbComision.ValueMember = "ID";
                cmbComision.DisplayMember = "Descripcion";
                #endregion

                #region CARGA MATERIAS
                foreach (DataRow i in ml.GetAll().Rows)
                {
                    m = new Materia();
                    m.ID = (int)i["id_materia"];
                    m.Descripcion = (string)i["desc_materia"];
                    listaMateria.Add(m);

                }
                cmbMateria.Enabled = true;
                cmbMateria.DataSource = listaMateria;
                cmbMateria.ValueMember = "ID";
                cmbMateria.DisplayMember = "Descripcion";
                #endregion

                #region CARGA PLANES
                cmbPlan.DataSource = pl.GetAll();
                cmbPlan.DisplayMember = "Descripcion";
                cmbPlan.ValueMember = "ID";
                cmbPlan.SelectedIndex = -1;
                #endregion

                c = cl.GetOne(CursoActual.IdComision);
                m = ml.GetOne(CursoActual.IdMateria);

                foreach (Plan p in pl.GetAll())
                {
                    if (p.ID == c.IdPlan && p.ID == m.IdPlan)
                    {
                        this.cmbPlan.SelectedValue = p.ID;
                        this.cmbComision.SelectedValue = c.ID;
                        this.cmbMateria.SelectedValue = m.ID;
                    }
                }

                this.ComboEspecialidad((int)this.cmbPlan.SelectedValue);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            ComisionLogic cl = new ComisionLogic();
            MateriaLogic ml = new MateriaLogic();
            PlanLogic pl = new PlanLogic();

            foreach (Plan p in pl.GetAll())
            {
                if (p.ID == ml.GetOne(this.CursoActual.IdMateria).IdPlan && p.ID == cl.GetOne(this.CursoActual.IdComision).IdPlan)
                {
                    PlanActual = p;
                }
            }
            
            txtId.Text = CursoActual.ID.ToString(); ;
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();

            this.cmbEspecialidad.SelectedValue = this.PlanActual.IDEespecialidad; this.ComboPlanes(PlanActual.IDEespecialidad);
            this.cmbPlan.SelectedValue = PlanActual.ID; this.ComboMaterias(PlanActual.ID); this.ComboComisiones(PlanActual.ID);
            this.cmbMateria.SelectedValue = this.CursoActual.IdMateria;
            this.cmbComision.SelectedValue = this.CursoActual.IdComision;
            

            switch(Modo)
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
            MateriaLogic ml = new MateriaLogic();

            CursoActual.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);
            CursoActual.Cupo = Int32.Parse(txtCupo.Text);
            CursoActual.IdComision = (int)cmbComision.SelectedValue;
            CursoActual.IdMateria = (int)cmbMateria.SelectedValue;
            CursoActual.Descripcion = ml.GetOne(CursoActual.IdMateria).Descripcion;

            switch (this.Modo)
            {
                case ModoForm.Alta: CursoActual.State = BusinessEntity.States.New;
                          break;
                case ModoForm.Baja: CursoActual.State = BusinessEntity.States.Deleted;
                          break;
                case ModoForm.Consulta: CursoActual.State = BusinessEntity.States.Unmodified;
                          break;
                case ModoForm.Modificacion: CursoActual.State = BusinessEntity.States.Modified;
                          break;
            }
        }

        public override bool Validar()
        {
            if(this.CursoActual == null)
            {
                this.Notificar("Advertencia", "Existen campos sin completar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                if (Validar())
                {
                    this.MapearADatos();
                    CursoLogic cl = new CursoLogic();
                    cl.Save(CursoActual);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void cmbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ComboPlanes((int)cmbEspecialidad.SelectedValue);
        }

        private void cmbPlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ComboComisiones((int)cmbPlan.SelectedValue);
            this.ComboMaterias((int)cmbPlan.SelectedValue);
        }
        #endregion


    }
}
