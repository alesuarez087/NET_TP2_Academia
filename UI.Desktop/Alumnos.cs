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
    public partial class Alumnos : ApplicationForm
    {
        #region PROPIEDADES Y CONSTRUCTORES
        private Usuario UsuarioAdministrador
        {
            get;
            set;
        }
        private PersonaLogic _logic;
        public Alumnos(Usuario administrador)
        {
            InitializeComponent();
            this.UsuarioAdministrador = administrador;
            this.Listar();
        }
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null) _logic = new PersonaLogic();
                return _logic;
            }
        }
#endregion

        #region METODOS
        private void Listar()
        {
            try
            {
                this.dgvAlumnos.AutoGenerateColumns = false;
                this.dgvAlumnos.DataSource = Logic.GetAllAlumnos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Listar(string texto)
        {
            try
            {
                this.dgvAlumnos.AutoGenerateColumns = false;
                if (!texto.Equals(""))
                {
                    try
                    {
                        this.dgvAlumnos.DataSource = Logic.BuscadorAlumno(Convert.ToInt32(texto));
                    }
                    catch
                    {
                        this.dgvAlumnos.DataSource = Logic.BuscadorAlumno(texto);
                    }
                }
                else this.dgvAlumnos.DataSource = Logic.GetAllAlumnos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS
        private void btnInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                Persona alumno = Logic.GetOne(ID);
                Inscripciones form = new Inscripciones(alumno, UsuarioAdministrador);
                form.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Listar(txtBuscar.Text);
        }
        #endregion
    }
}
