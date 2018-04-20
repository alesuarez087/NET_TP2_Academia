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
    public partial class DocentesCursosDesktop : ApplicationForm
    {
        public DocenteCurso DocenteCursoActual
        {
            get;set;
        }
        public Curso CursoActual
        {
            get;set;
        }
        public Persona ProfesorActual
        {
            get;set;
        }

        public DocentesCursosDesktop()
        {
            InitializeComponent();

        }

        public DocentesCursosDesktop(ModoForm modo, Curso c) : this()
        {
            this.Modo = modo;
            CursoActual = c;
            DocenteCursoActual = new DocenteCurso();
            ProfesorActual = new Persona();
        }


        public DocentesCursosDesktop(int ID, ModoForm modo, Curso c) : this()
        {
            this.Modo = modo;
            CursoActual = c;
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCursoActual = dcl.GetOne(ID);
            PersonaLogic pl = new PersonaLogic();
            ProfesorActual = pl.GetOne(DocenteCursoActual.IDDocente);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.CargaCombo();
            this.txtId.Text = ProfesorActual.ID.ToString();
            this.txtDocente.Text = ProfesorActual.Apellido + ", " + ProfesorActual.Nombre;

            switch (DocenteCursoActual.TipoCargo)
            {
                case DocenteCurso.TiposCargos.Titular: cmbCargo.SelectedText = "Titular";
                    break;
                case DocenteCurso.TiposCargos.Auxiliar: cmbCargo.SelectedText = "Auxiliar";
                    break;
                case DocenteCurso.TiposCargos.Ayudante: cmbCargo.SelectedText = "Ayudante";
                    break;
                default: cmbCargo.SelectedItem = -1;
                    break;
            }

            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.btnAgregarDocente.Visible = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
            this.cmbCargo.Enabled = true;
        }

        private void CargaCombo()
        {
            cmbCargo.Items.Add("Auxiliar");
            cmbCargo.Items.Add("Ayudante");
            cmbCargo.Items.Add("Titular");
            cmbCargo.SelectedIndex = -1;
        }

        public override void MapearADatos()
        {
            DocenteCursoActual.IDCurso = CursoActual.ID;
            DocenteCursoActual.IDDocente = ProfesorActual.ID;

            switch (cmbCargo.Text)
            {
                case "Titular": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Titular;
                    break;
                case "Ayudante": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Ayudante;
                    break;
                case "Auxiliar": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Auxiliar;
                    break;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta: DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja: DocenteCursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta: DocenteCursoActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion: DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cmbCargo.SelectedItem == null)
            {
                EsValido = false;
                this.Notificar("Advertencia", "No se seleccionó un Cargo para el Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.DocenteCursoActual == null)
            {
                this.Notificar("Advertencia", "No se seleccionó un Docente para el Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EsValido = false;
            }

            if (DocenteCursoActual.ID == 0)
            {
                DocenteCursoLogic dl = new DocenteCursoLogic();
                foreach (DataRow i in dl.GetAll(CursoActual.ID).Rows)
                {
                    if (DocenteCursoActual.IDCurso == (int)i["id_curso"] && DocenteCursoActual.IDDocente == (int)i["id_docente"])
                    {
                        this.Notificar("Advertencia", "Ya fue agregado a un cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EsValido = false;
                    }
                }
            }
            else
            {
                DocenteCursoLogic dl = new DocenteCursoLogic();
                int tipoCargo;
                switch(DocenteCursoActual.TipoCargo)
                {
                    case DocenteCurso.TiposCargos.Titular: tipoCargo = 1;
                        break;
                    case DocenteCurso.TiposCargos.Ayudante: tipoCargo = 3;
                        break;
                    case DocenteCurso.TiposCargos.Auxiliar: tipoCargo = 2;
                        break;
                    default: tipoCargo=0;
                        break;
                }
                foreach (DataRow i in dl.GetAll(CursoActual.ID).Rows)
                {
                    if (tipoCargo == (int)i["cargo"])
                    {
                        this.Notificar("Advertencia", "Ya fue agregado ese cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EsValido = false;
                    }
                }
            }
            return EsValido;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            if (Validar())
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                dcl.Save(DocenteCursoActual);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            SeleccionarDocente form = new SeleccionarDocente();
            form.ShowDialog();
            ProfesorActual = form.Docente;
            this.MapearDeDatos();
            this.cmbCargo.Enabled = true;
        }
    }
}
