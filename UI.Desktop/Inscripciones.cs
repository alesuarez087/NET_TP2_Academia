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
    public partial class Inscripciones : Form
    {
        public Inscripciones()
        {
            InitializeComponent();
        }

        public Persona AlumnoActual
        {
            get; set;
        }


        public Inscripciones(Persona p)
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
            this.AlumnoActual = p;
            this.Listar();
        }

        private void Listar()
        {
            InscripcionLogic il = new InscripcionLogic();
            this.dgvInscripciones.DataSource = il.GetAll(AlumnoActual.ID);
        }



        private void ActualizarCurso(AlumnoInscripcion a)
        {
            CursoLogic cl = new CursoLogic();
            Curso curso = cl.GetOne(a.IdCurso);
            ++curso.Cupo;
            curso.State = BusinessEntity.States.Modified;
            cl.Save(curso);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsbInscribirse_Click(object sender, EventArgs e)
        {
            InscripcionesDesktop form = new InscripcionesDesktop(AlumnoActual);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((DataRowView)this.dgvInscripciones.SelectedRows[0].DataBoundItem)["id_inscripcion"].ToString());
            InscripcionLogic il = new InscripcionLogic();
            AlumnoInscripcion a = il.GetOne(ID);
            if (!a.Condicion.Equals("Inscripto")) MessageBox.Show("No puede borrar esta inscripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var re = MessageBox.Show("Desea eliminar la Inscripción ?", "Eliminar Inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (re == DialogResult.Yes)
                {
                    a.State = BusinessEntity.States.Deleted;
                    this.ActualizarCurso(a);
                    il.GuardarCambios(a);
                    this.Listar();
                }
            }
        }

    }
}
