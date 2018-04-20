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
    public partial class Docentes : ApplicationForm
    {
        #region PROPIEDADES Y CONSTRUCTORES
        public Docentes()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
            this.Listar();
        }
        #endregion

        #region METODOS
        private void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.dgvDocentes.DataSource = pl.GetAllDocentes();
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
                PersonaLogic pl = new PersonaLogic();
                try
                {
                    this.dgvDocentes.DataSource = pl.BuscadorDocente(Convert.ToInt32(texto));
                }
                catch
                {
                    this.dgvDocentes.DataSource = pl.BuscadorDocente(texto);
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                PersonaLogic pl = new PersonaLogic();
                Persona PersonaActual = pl.GetOne(id);
                CursoLogic cl = new CursoLogic();
                DataTable comisiones = cl.GetAllForPersona(PersonaActual.ID).Clone();
                foreach (DataRow row in cl.GetAllForPersona(PersonaActual.ID).Rows)
                {
                    if ((int)row["cargo"] == 1)
                    {
                        comisiones.ImportRow(row);
                    }
                }
                if (comisiones.Rows.Count == 0)
                {
                    this.Notificar("Advertencia", "No posee materias a su titularidad. No puede agregar notas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    RegistroNota form = new RegistroNota(PersonaActual, comisiones);
                    form.ShowDialog();
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBuscador.Text.Equals("")) this.Listar();
            else this.Listar(this.txtBuscador.Text);
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
