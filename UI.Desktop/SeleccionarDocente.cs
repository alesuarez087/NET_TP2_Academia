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
    public partial class SeleccionarDocente : ApplicationForm
    {
        public Persona Docente
        {
            get; set;
        }
        public SeleccionarDocente()
        {
            InitializeComponent();
            this.dgvSeleccionarDocente.AutoGenerateColumns = false;
            Listar();
        }

        public void Listar()
        {
            List<Persona> docente = new List<Persona>();
            PersonaLogic pl = new PersonaLogic();
            foreach(Persona p in pl.GetAll())
            {
                if(p.TipoPersona == Persona.TiposPersonas.Profesor)
                {
                    docente.Add(p);
                }
            }
            this.dgvSeleccionarDocente.DataSource = docente;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //int ID = Convert.ToInt32((((DataRowView)this.dgvSeleccionarDocente.SelectedRows[0].DataBoundItem))["id_persona"].ToString());
            int ID = Convert.ToInt32(((Persona)this.dgvSeleccionarDocente.SelectedRows[0].DataBoundItem).ID);
            PersonaLogic pl = new PersonaLogic();
            Docente = pl.GetOne(ID);
            this.Close();
        }
    }
}
