using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_DocentesCursos : BaseForm
{

    #region PROPIEDADES
    private DocenteCursoLogic _logic;

    public DocenteCursoLogic Logic
    {
        get
        {
            if(_logic == null)
            {
                _logic = new DocenteCursoLogic();
            }
            return _logic;
        }
    }
    public DocenteCurso DocenteCursoActual
    {
        get;set;
    }
    public Persona DocenteActual
    {
        get;
        set;
    }
    #endregion

    #region METODOS
    private void LoadDocenteCurso()
    {
        try
        {
            int ID = ((Curso)Session["cursoSeleccionado"]).ID;
            if (Logic.GetAll(ID).Rows.Count > 0)
            {
                DataTable table = new DataTable();

                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Apellido", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Cargo", typeof(string));
                table.Columns.Add("IdDictado", typeof(int));

                DataRow rowTable;
                foreach (DataRow rowDocente in Logic.GetAll(ID).Rows)
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

                this.lblVacio.Visible = false;
                this.gvDocentesCurso.Visible = true;
                this.gvDocentesCurso.DataSource = table;
                this.gvDocentesCurso.DataBind();
            }
            else
            {
                this.lblVacio.Text = "No hay Docentes asignados";
                this.lblVacio.Visible = true;
                this.gvDocentesCurso.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    private void LoadDocentes()
    {
        try
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();
            foreach (Persona p in pl.GetAll())
            {
                if (p.TipoPersona == Persona.TiposPersonas.Profesor)
                {
                    docentes.Add(p);
                }
            }
            if (docentes.Count > 0)
            {
                gvDocentes.DataSource = docentes;
                gvDocentes.DataBind();
            }
            else
            {
                this.lblMensajeDocente.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void MapearDeDatos()
    {
        try
        {
            if (FormMode == FormModes.Modificacion || FormMode == FormModes.Baja)
            {
                PersonaLogic pl = new PersonaLogic();
                DocenteCursoActual = Logic.GetOne(SelectedID);
                DocenteActual = pl.GetOne(DocenteCursoActual.IDDocente);
                lblDocente.Text = DocenteActual.Apellido + ", " + DocenteActual.Nombre;
                ddlTipoCargo.SelectedValue = DocenteCursoActual.TipoCargo.ToString();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void MapearADatos()
    {
        if (FormMode == FormModes.Alta)
        {
            DocenteCursoActual = new DocenteCurso();
            DocenteCursoActual.State = BusinessEntity.States.New;
            DocenteCursoActual.IDDocente = (int)gvDocentes.SelectedDataKey.Value;
            DocenteCursoActual.IDCurso = ((Curso)Session["cursoSeleccionado"]).ID;
        }
        else
        {
            DocenteCursoActual = (DocenteCurso)Session["docenteCurso"];
            if (FormMode == FormModes.Modificacion)
            {
                DocenteCursoActual.State = BusinessEntity.States.Modified;
            }
            else DocenteCursoActual.State = BusinessEntity.States.Deleted;
        }
        
        switch(ddlTipoCargo.SelectedValue)
        {
            case "Auxiliar": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Auxiliar; break;
            case "Ayudante": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Ayudante; break;
            case "Titular": DocenteCursoActual.TipoCargo = DocenteCurso.TiposCargos.Titular; break;
        }
    }
    public override void EnableForm(bool enable)
    {
        if(FormMode == FormModes.Alta || FormMode == FormModes.Baja)
        {
            btnAgregarDocente.Visible = enable;
            ddlTipoCargo.Enabled = enable;
            if (FormMode == FormModes.Alta) btnAgregarDocenteCurso.Text = "Agregar";
            else btnAgregarDocenteCurso.Text = "Eliminar";
        } else if (FormMode == FormModes.Modificacion)
        {
            btnAgregarDocente.Visible = enable;
            ddlTipoCargo.Enabled = !enable;
            btnAgregarDocenteCurso.Text = "Modificar";
        }
        lblDocente.Text = "";
        
    }
    public override void Save()
    {
        try
        {
            MapearADatos();
            if (IsValid)
            {
                Logic.Save(DocenteCursoActual);
                Session["docente"] = null;
                pnDocentes.Visible = false;
                pnDesktop.Visible = false;
                pnTabla.Visible = true;
                this.LoadDocenteCurso();
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (!IsPostBack)
            {
                this.LoadDocenteCurso();
            }
        }
        else Page.Response.Redirect("~/Login.aspx");
    }
    protected void gvDocentesCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedID = Convert.ToInt32(this.gvDocentesCurso.DataKeys[this.gvDocentesCurso.SelectedRow.RowIndex].Value);
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Alta;
        Session["FormMode"] = FormMode;
        pnDesktop.Visible = true;
        pnTabla.Visible = false;
        this.EnableForm(true);
        
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Modificacion;
        Session["FormMode"] = FormMode;
        Session["docenteCurso"] = Logic.GetOne(SelectedID);
        this.EnableForm(false);
        pnDesktop.Visible = true;
        pnTabla.Visible = false;
        this.MapearDeDatos();
        lblDocente.Visible = true;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Baja;
        Session["FormMode"] = FormMode;
        Session["docenteCurso"] = Logic.GetOne(SelectedID);
        this.EnableForm(false);
        pnDesktop.Visible = true;
        pnTabla.Visible = false;
        this.MapearDeDatos();
        lblDocente.Visible = true;
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Session["cursoSeleccionado"] = null;
        Page.Response.Redirect("Cursos.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnDesktop.Visible = false;
        pnTabla.Visible = true;
    }
    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
        this.pnDocentes.Visible = true;
        this.pnDesktop.Visible = false;
        this.LoadDocentes();
    }
    protected void gvDocentes_SelectedIndexChanged(object sender, EventArgs e)
    {
        PersonaLogic pl = new PersonaLogic();
        Session["docente"] = pl.GetOne((int)gvDocentes.SelectedDataKey.Value);
        Persona docente = (Persona)Session["docente"];
        this.pnDesktop.Visible = true;
        this.pnDocentes.Visible = false;
        this.lblDocente.Visible = true;
        this.lblDocente.Text = docente.Apellido + ", " + docente.Nombre;
    }
    protected void btnAgregarDocenteCurso_Click(object sender, EventArgs e)
    {
        this.Save();
    }
    protected void cvDocenteCurso_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Session["docente"] != null)
        {
            bool b = true;
            this.MapearADatos();
            if (DocenteCursoActual.ID == 0)
            {
                foreach (DataRow i in Logic.GetAll(DocenteCursoActual.IDCurso).Rows)
                {
                    if (DocenteCursoActual.IDCurso == (int)i["id_curso"] && DocenteCursoActual.IDDocente == (int)i["id_docente"])
                    {
                        b = false;
                    }
                }
            }
            args.IsValid = b;
        }
    }
    protected void cvCargo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if(Session["docente"] != null)
        {
            if ((FormModes)Session["FormMode"] != FormModes.Baja)
            {
                this.MapearADatos();
                {
                    DocenteCursoLogic dl = new DocenteCursoLogic();
                    int tipoCargo;
                    switch (DocenteCursoActual.TipoCargo)
                    {
                        case DocenteCurso.TiposCargos.Titular: tipoCargo = 1;
                            break;
                        case DocenteCurso.TiposCargos.Ayudante: tipoCargo = 3;
                            break;
                        case DocenteCurso.TiposCargos.Auxiliar: tipoCargo = 2;
                            break;
                        default: tipoCargo = 0;
                            break;
                    }
                    Curso CursoActual = (Curso)Session["cursoSeleccionado"];
                    foreach (DataRow i in dl.GetAll(CursoActual.ID).Rows)
                    {
                        if (tipoCargo == (int)i["cargo"])
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }
    }
    #endregion
}