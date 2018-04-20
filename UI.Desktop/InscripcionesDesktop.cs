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
    public partial class InscripcionesDesktop : ApplicationForm
    {
        public InscripcionesDesktop()
        {
            InitializeComponent();
        }

        public Persona AlumnoActual
        {
            get;set;
        }
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get;set;
        }
        public Curso CursoActual
       {
           get; set;
       }

        public InscripcionesDesktop(Persona p)
        {
            InitializeComponent();
            AlumnoActual = p;
            AlumnoInscripcionActual = new AlumnoInscripcion();
            CursoActual = new Curso();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvMaterias.AutoGenerateColumns = false;
            this.ListarMaterias();
        }

        private void ListarMaterias()
        {
            InscripcionLogic il = new InscripcionLogic();
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = new List<Materia>();
            List<Materia> materiasPlan = il.GetMaterias(AlumnoActual.IdPlan);
            int i = 0;
            for (i = 0; i < materiasPlan.Count; i++)
            {
                bool valida = true;
                foreach (DataRow row in il.GetAll(AlumnoActual.ID).Rows)
                {
                    Materia matInsc = ml.GetOne((int)row["id_materia"]);
                    if (matInsc.Descripcion.Equals(materiasPlan[i].Descripcion))
                    {
                        if (!((string)row["condicion"]).Equals("Libre")) valida = false;
                    }
                }
                if (valida) materias.Add(materiasPlan[i]);
            }
            this.dgvMaterias.DataSource = materias;
        }

        public override void MapearADatos()
        {
            CursoLogic cl = new CursoLogic();
            AlumnoInscripcionActual.IdCurso = Convert.ToInt32(((DataRowView)this.dgvComisiones.SelectedRows[0].DataBoundItem)["id_curso"].ToString());
            AlumnoInscripcionActual.Condicion = "Inscripto";
            AlumnoInscripcionActual.IdAlumno = this.AlumnoActual.ID;
            AlumnoInscripcionActual.State = BusinessEntity.States.New;

            CursoActual = cl.GetOne(AlumnoInscripcionActual.IdCurso);
        }

        public override bool Validar()
        {
            InscripcionLogic il = new InscripcionLogic();
            int count = 0;
            foreach (DataRow row in il.GetAllComisiones(AlumnoInscripcionActual.ID).Rows)
            {
                if ((int)row["id_curso"] == CursoActual.ID) ++count;
            }

            if (CursoActual.Cupo > count)
            {
                if (Modo == ModoForm.Alta)
                {
                    bool valid = true;
                    foreach (DataRow row in il.GetAll(AlumnoActual.ID).Rows)
                    {
                        if (AlumnoInscripcionActual.IdCurso == (int)row["id_curso"])
                        {
                            valid = false;
                        }
                    }
                    if (valid) return true;
                    else
                    {
                        this.Notificar("Ya se encuentra inscripto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                else
                {
                    return true;
                }
            }
            else
            {
                this.Notificar("No hay cupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if(this.Validar())
            {
                InscripcionLogic il = new InscripcionLogic();
                il.GuardarCambios(AlumnoInscripcionActual);
                this.Close();
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string descripcionMateria = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Descripcion;
            InscripcionLogic il = new InscripcionLogic();
            this.dgvComisiones.DataSource = il.GetMateriaCursos(descripcionMateria);
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        
    }
}
