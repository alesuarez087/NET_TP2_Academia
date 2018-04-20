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
    public partial class RegistroNota : ApplicationForm
    {
        public RegistroNota()
        {
            InitializeComponent();
        }
        public Persona Docente
        {
            get;set;
        }
        public DocenteCurso DocenteCursoActual
        {
            get; set;
        }
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get;set;
        }
        public DataTable CursosActuales
        {
            get; set;
        }
 
        public RegistroNota(Persona docente, DataTable comisiones)
        {
            InitializeComponent();
            Docente = docente;
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCursoActual = dcl.GetOne(Docente.ID);
            AlumnoInscripcionActual = new AlumnoInscripcion();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.dgvComisiones.DataSource = comisiones;
        }

        private DataTable ListarAlumnos()
        {
            InscripcionLogic il = new InscripcionLogic();
            int IdCurso = Convert.ToInt32(((DataRowView)this.dgvComisiones.SelectedRows[0].DataBoundItem)["id_curso"].ToString());
            this.CargaCombos();
            return il.GetAllComisiones(IdCurso);
        }

        private void CargaCombos()
        {
            for (int i = 0; i < 11; i++)
            {
                cmbNota.Items.Add(i);
            }
            cmbCondicion.Items.Add("Aprobado");
            cmbCondicion.Items.Add("Regular");
            cmbCondicion.Items.Add("Inscripto");
            cmbCondicion.Items.Add("Libre");
            cmbNota.SelectedIndex = -1;
            cmbCondicion.SelectedIndex = -1;
        }

        public override void MapearADatos()
        {
            int IdInscripcion = Convert.ToInt32(((DataRowView)this.dgvAlumnos.SelectedRows[0].DataBoundItem)["id_inscripcion"].ToString());
            InscripcionLogic il = new InscripcionLogic();
            AlumnoInscripcionActual = il.GetOne(IdInscripcion);
            AlumnoInscripcionActual.Nota = cmbNota.SelectedIndex;
            AlumnoInscripcionActual.Condicion = (string)cmbCondicion.SelectedItem;
            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if(Validar())
            {
                InscripcionLogic il = new InscripcionLogic();
                il.GuardarCambios(AlumnoInscripcionActual);
                this.dgvAlumnos.DataSource = this.ListarAlumnos();
            }
        }

        public override bool Validar()
        {
            if(AlumnoInscripcionActual == null)
            {
                this.Notificar("Atencion", "No están completos todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
        #region EVENTOS
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.ListarAlumnos();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrarNota_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea borrar la nota?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int IdInscripcion = Convert.ToInt32(((DataRowView)this.dgvAlumnos.SelectedRows[0].DataBoundItem)["id_inscripcion"].ToString());
                InscripcionLogic il = new InscripcionLogic();
                AlumnoInscripcionActual = il.GetOne(IdInscripcion);
                AlumnoInscripcionActual.Nota = 0;
                AlumnoInscripcionActual.Condicion = "Inscripto";
                AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                il.GuardarCambios(AlumnoInscripcionActual);
                this.dgvAlumnos.DataSource = this.ListarAlumnos();
            }
        }

        private void RegistroNota_Load(object sender, EventArgs e)
        {
            //this.ListarComisiones();
            this.dgvComisiones.ClearSelection();
        }

        private void dgvComisiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAlumnos.DataSource = this.ListarAlumnos();
        }
        #endregion
    }
}
