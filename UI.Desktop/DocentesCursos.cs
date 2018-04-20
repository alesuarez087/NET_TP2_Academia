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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos()
        {
            InitializeComponent();
        }

        public Curso CursoActual 
        {
            get; set; 
        }

        public DocentesCursos(int id_dictado)
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(id_dictado);
        }

        public void Listar()
        {
            this.dgvDocentesCursos.AutoGenerateColumns = false;
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DataTable table = new DataTable();
            DataRow rowTable;

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Apellido", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Cargo", typeof(string));
            table.Columns.Add("IdDictado", typeof(int));


            foreach (DataRow rowDocente in dcl.GetAll(CursoActual.ID).Rows)
            {
                rowTable = table.NewRow();
                rowTable["ID"] = (int)rowDocente["id_docente"];
                rowTable["Apellido"] = (string)rowDocente["apellido"];
                rowTable["Nombre"] = (string)rowDocente["nombre"];
                rowTable["IdDictado"] = (int)rowDocente["id_dictado"];

                switch ((int)rowDocente["cargo"])
                {
                    case 1: rowTable["Cargo"] = "Titular"; break;
                    case 2: rowTable["Cargo"] = "Auxiliar"; break;
                    case 3: rowTable["Cargo"] = "Ayudante"; break;
                }

                table.Rows.Add(rowTable);
            }

            this.dgvDocentesCursos.DataSource = table;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocentesCursosDesktop form = new DocentesCursosDesktop(ApplicationForm.ModoForm.Alta, CursoActual);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((DataRowView)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem)["IdDictado"].ToString());
            DocentesCursosDesktop form = new DocentesCursosDesktop(ID, ApplicationForm.ModoForm.Modificacion, CursoActual);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Desea eliminar la relación Docente Curso?", "Advertencia", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = int.Parse(((DataRowView)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem)["IdDictado"].ToString());
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                dcl.Delete(ID);
                this.Listar();
            }
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }



    }
}
