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
    public partial class ReporteCurso : ApplicationForm
    {
        #region PROPIEDADES Y CONSTRUCTORES
        EspecialidadLogic _logicEspecialidades;
        PlanLogic _logicPlan;
        CursoLogic _logicCurso;
        MateriaLogic _logicMateria;
        private EspecialidadLogic LogicEspecialidades
        {
            get
            {
                if (_logicEspecialidades == null) _logicEspecialidades = new EspecialidadLogic();
                return _logicEspecialidades;
            }
        }
        private PlanLogic LogicPlan
        {
            get
            {
                if (_logicPlan == null) _logicPlan = new PlanLogic();
                return _logicPlan;
            }
        }
        private CursoLogic LogicCurso
        {
            get
            {
                if (_logicCurso == null) _logicCurso = new CursoLogic();
                return _logicCurso;
            }
        }
        private MateriaLogic LogicMateria
        {
            get
            {
                if (_logicMateria == null) _logicMateria = new MateriaLogic();
                return _logicMateria;
            }
        }
        public ReporteCurso()
        {
            InitializeComponent();
        }
        #endregion

        #region METODOS
        private void LoadEspecialidades()
        {
            this.cmbEspecialidad.Items.Clear();
            try
            {
                this.cmbEspecialidad.DataSource = LogicEspecialidades.GetAll();
                this.cmbEspecialidad.DisplayMember = "Descripcion";
                this.cmbEspecialidad.ValueMember = "ID";
                this.cmbEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadPlanes(int idEspecialidad)
        {
            try
            {
                this.cmbPlan.Items.Clear();
                List<Plan> planes = LogicPlan.GetAll(idEspecialidad);
                if (planes.Count > 0)
                {
                    this.cmbPlan.DataSource = planes;
                    this.cmbPlan.DisplayMember = "Descripcion";
                    this.cmbPlan.ValueMember = "ID";
                    this.cmbPlan.SelectedIndex = -1;
                    this.cmbPlan.Enabled = true;
                }
                else
                {
                    this.cmbPlan.Enabled = false;
                    this.cmbPlan.Items.Insert(0, "No existen Planes");
                    this.cmbPlan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMaterias(int idPlan)
        {
            try
            {
                this.cmbMateria.Items.Clear();
                if (LogicMateria.GetAllForPlan(idPlan).Count > 0)
                {
                    this.cmbMateria.DataSource = LogicMateria.GetAllForPlan(idPlan);
                    this.cmbMateria.ValueMember = "ID";
                    this.cmbMateria.DisplayMember = "Descripcion";
                    this.cmbMateria.SelectedIndex = -1;
                    this.cmbMateria.Enabled = true;
                }
                else
                {
                    this.cmbMateria.Items.Insert(0, "No existen materias");
                    this.cmbMateria.SelectedIndex = 0;
                    this.cmbMateria.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCursos(int idMateria)
        {
            try
            {
                this.cmbComision.Items.Clear();
                this.cmbAnio.Items.Clear();
                if (LogicCurso.GetAllForMateria(idMateria).Rows.Count > 0)
                {
                    this.cmbComision.DataSource = LogicCurso.GetAllForMateria(idMateria);
                    this.cmbComision.DisplayMember = "desc_comision";
                    this.cmbComision.ValueMember = "id_comision";
                    this.cmbComision.SelectedIndex = -1;

                    this.cmbComision.Enabled = true;
                }
                else
                {
                    this.cmbComision.Items.Insert(0, "No existen Comisiones");
                    this.cmbComision.SelectedIndex = 0;
                    this.cmbAnio.Items.Insert(0, "----");
                    this.cmbAnio.SelectedIndex = 0;
                    this.cmbComision.Enabled = false;
                    this.cmbAnio.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAnios(int idMateria, int idComision)
        {
            try
            {
                if (LogicCurso.GetAll(idMateria, idComision).Rows.Count > 0)
                {
                    this.cmbAnio.Enabled = true;
                    this.cmbAnio.DataSource = LogicCurso.GetAll(idMateria, idComision);
                    this.cmbAnio.DisplayMember = "anio_calendario";
                    this.cmbAnio.ValueMember = "id_curso";
                    this.cmbAnio.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadReporte()
        {
            Util.ReporteCurso reporte = new Util.ReporteCurso();
            reporte.SetParameterValue("@id_curso", (int)this.cmbAnio.SelectedValue);
            this.crvCurso.ReportSource = reporte;
        }
        #endregion

        #region EVENTOS
        private void cmbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadPlanes((int)this.cmbEspecialidad.SelectedValue);
        }

        private void cmbPlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadMaterias((int)this.cmbPlan.SelectedValue);
        }

        private void cmbMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadCursos((int)this.cmbMateria.SelectedValue);
        }

        private void cmbComision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadAnios((int)this.cmbMateria.SelectedValue, (int)this.cmbComision.SelectedValue);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.LoadReporte();
        }

        private void ReporteCurso_Load(object sender, EventArgs e)
        {
            this.LoadEspecialidades();
        }
        #endregion
    }
}
