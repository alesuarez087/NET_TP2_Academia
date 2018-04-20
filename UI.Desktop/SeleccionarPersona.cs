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
    public partial class SeleccionarPersona : ApplicationForm
    {
        public Persona PersonaSeleccionada
        {
            get;set;
        }
        public SeleccionarPersona()
        {
            InitializeComponent();
            this.Combo();
            this.dgvSeleccionPersona.AutoGenerateColumns = false;
        }

        private void Combo()
        {
            tscmbTipo.Items.Add("Todos");
            tscmbTipo.Items.Add("Alumnos");
            tscmbTipo.Items.Add("Profesores");
            tscmbTipo.Items.Add("Administradores");
            tscmbTipo.SelectedItem = "Todos";
        }

        private void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> lista = new List<Persona>();
            switch ((string)tscmbTipo.SelectedItem)
            {
                case "Todos": lista = pl.GetAll();
                    break;
                case "Alumnos": foreach (Persona per in pl.GetAll()) if(per.TipoPersona == Persona.TiposPersonas.Alumno) lista.Add(per);
                    break;
                case "Profesores": foreach (Persona per in pl.GetAll()) if (per.TipoPersona == Persona.TiposPersonas.Profesor) lista.Add(per);
                    break;
                case "Administradores": foreach (Persona per in pl.GetAll()) if (per.TipoPersona == Persona.TiposPersonas.Administrador) lista.Add(per);
                    break;
            }
                this.dgvSeleccionPersona.DataSource = lista;
        }
        private void SeleccionarPersona_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)dgvSeleccionPersona.SelectedRows[0].DataBoundItem).ID;
            PersonaLogic pl = new PersonaLogic();
            PersonaSeleccionada = pl.GetOne(ID);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevaPersona_Click(object sender, EventArgs e)
        {
            PersonaDesktop form = new PersonaDesktop(ModoForm.Alta);
            form.ShowDialog();
            this.Listar();
        }

        private void tscmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listar();
        }


    }
}
