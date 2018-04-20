using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Listados_Cursos : BaseForm
{
    CursoLogic _logic;

    #region PROPIEDADES
    public CursoLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new CursoLogic();
            }
            return _logic;
        }
    }
    private Curso CursoActual
    {
        get; set;
    }
    #endregion

    #region METODOS CREADOS

    public override void LoadGrid()
    {
        try
        {
            if (Logic.GetAll().Rows.Count != 0)
            {
                this.gvCursos.Visible = true;
                this.lblVacio.Visible = false;
                this.gvCursos.DataSource = Logic.GetAll();
                this.gvCursos.DataBind();
            }
            else
            {
                this.gvCursos.Visible = false;
                this.lblVacio.Visible = true;
                this.lblVacio.Text = "No existen Cursos";
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
        MateriaLogic ml = new MateriaLogic();
        switch (this.FormMode)
        {
            case FormModes.Baja: this.CursoActual.ID = this.SelectedID; 
                                 this.CursoActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: this.CursoActual.ID = this.SelectedID;
                                         this.CursoActual.State = BusinessEntity.States.Modified;
                break;
            case FormModes.Alta: this.CursoActual = new Curso();
                                 CursoActual.State = BusinessEntity.States.New;
                break;
            default: break;
        }
        this.CursoActual.AnioCalendario = int.Parse(this.txtAno.Text);
        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
        this.CursoActual.Descripcion = ml.GetOne(int.Parse(this.ddlMaterias.SelectedValue)).Descripcion;
        this.CursoActual.IdComision = int.Parse(this.ddlComisiones.SelectedValue);
        this.CursoActual.IdMateria = int.Parse(this.ddlMaterias.SelectedValue);
    }
    public override void MapearDeDatos()
    {
        try
        {
            PlanLogic pl = new PlanLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic cl = new ComisionLogic();
            Plan plan = new Plan();
            this.CursoActual = this.Logic.GetOne(SelectedID);
            this.txtAno.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();

            foreach (Plan p in pl.GetAll())
            {
                if (p.ID == ml.GetOne(this.CursoActual.IdMateria).IdPlan && p.ID == cl.GetOne(this.CursoActual.IdComision).IdPlan)
                {
                    plan = p;
                }
            }

            this.CargarEspecialidad();
            this.ddlEspecialidad.SelectedValue = plan.IDEespecialidad.ToString(); this.CargarPlan(plan.IDEespecialidad);
            this.ddlPlan.SelectedValue = plan.ID.ToString(); this.CargaMateria(plan.ID); this.CargaComisiones(plan.ID);
            this.ddlMaterias.SelectedValue = this.CursoActual.IdMateria.ToString();
            this.ddlComisiones.SelectedValue = this.CursoActual.IdComision.ToString();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    private void CargarEspecialidad()
    {
        try
        {
            EspecialidadLogic el = new EspecialidadLogic();
            if (el.GetAll().Count > 1)
            {
                ddlEspecialidad.DataSource = el.GetAll();
                ddlEspecialidad.DataTextField = "Descripcion";
                ddlEspecialidad.DataValueField = "ID";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, "Seleccione Especialidad");
                ddlEspecialidad.SelectedIndex = 0;
            }
            else
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "No existen Especialidades para asociar. Primero ingrese una especialidad";
                this.pnGrilla.Visible = false;
                this.pnTabla.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    private void CargarPlan(int IdEspecialidad)
    {
        try
        {
            PlanLogic pl = new PlanLogic();
            if (pl.GetAll().Count > 1)
            {
                List<Plan> planes = pl.GetAll(IdEspecialidad);
                ddlPlan.Enabled = true;
                ddlPlan.DataSource = planes;
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "ID";
                ddlPlan.DataBind();
                ddlPlan.Items.Insert(0, "Seleccione Plan");
                ddlPlan.SelectedIndex = 0;
                this.ddlMaterias.Enabled = true;
                this.ddlComisiones.Enabled = true;
            }
            else
            {
                this.lblPlanVacio.Visible = true;
                this.lblPlanVacio.Text = "No existen Planes para asociar";
                this.ddlPlan.Visible = false;
                this.ddlComisiones.Enabled = true;
                this.ddlComisiones.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    private void CargaMateria(int IdPlan)
    {
        try
        {
            MateriaLogic ml = new MateriaLogic();
            if (ml.GetAll().Rows.Count > 0)
            {
                List<Materia> list = new List<Materia>();
                Materia m;
                foreach (DataRow i in ml.GetAll().Rows)
                {
                    if ((int)i["id_plan"] == IdPlan)
                    {
                        m = new Materia();
                        m.ID = (int)i["id_materia"];
                        m.Descripcion = (string)i["desc_materia"];
                        list.Add(m);
                    }
                }
                ddlMaterias.Enabled = true;
                ddlMaterias.DataSource = list;
                ddlMaterias.DataTextField = "Descripcion";
                ddlMaterias.DataValueField = "ID";
                ddlMaterias.DataBind();
                ddlMaterias.Items.Insert(0, "Seleccione Materias");
                ddlMaterias.SelectedIndex = 0;
            }
            else
            {
                this.lblMateriasVacio.Visible = true;
                this.lblMateriasVacio.Text = "No existen Materias para asociar";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    private void CargaComisiones(int IdPlan)
    {
        try
        {
            ComisionLogic cl = new ComisionLogic();
            if (cl.GetAll().Rows.Count != 0)
            {
                Comision c;
                List<Comision> list = new List<Comision>();
                foreach (DataRow i in cl.GetAll().Rows)
                {
                    if ((int)i["id_plan"] == IdPlan)
                    {
                        c = new Comision();
                        c.ID = (int)i["id_comision"];
                        c.Descripcion = (string)i["desc_comision"];
                        list.Add(c);
                    }
                }

                ddlComisiones.DataSource = list;
                ddlComisiones.DataTextField = "Descripcion";
                ddlComisiones.DataValueField = "ID";
                ddlComisiones.DataBind();
                ddlComisiones.Items.Insert(0, "Seleccione Comisiones");
                ddlComisiones.SelectedIndex = 0;
            }
            else
            {
                this.lblComisionesVacio.Visible = true;
                this.lblComisionesVacio.Text = "No existen Comisiones para asociar";
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void Save()
    {
        try
        {
            this.Logic.Save(CursoActual);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void EnableForm(bool enable)
    {
        this.txtAno.Enabled = enable;
        this.txtCupo.Enabled = enable;
        this.ddlComisiones.Enabled = enable;
        this.ddlEspecialidad.Enabled = enable;
        this.ddlPlan.Enabled = enable;
        this.ddlMaterias.Enabled = enable;
        this.ddlPlan.Enabled = enable;
    }
    public override void CleanForm()
    {
        this.CargarEspecialidad();
        this.txtAno.Text = string.Empty;
        this.txtCupo.Text = string.Empty;
        ddlEspecialidad.SelectedIndex = -1;
        ddlMaterias.SelectedIndex = -1;
        ddlComisiones.SelectedIndex = -1;
        ddlPlan.SelectedIndex = -1;
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
                Session["cursoSeleccionado"] = null;
            }
        }
        else Page.Response.Redirect("~/Login.aspx");
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        this.pnGrilla.Visible = true;
        this.pnTabla.Visible = false;
        this.FormMode = FormModes.Alta; Session["FormMode"] = FormMode;
        this.CleanForm();
        this.EnableForm(true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Modificacion; Session["FormMode"] = FormMode;
            this.MapearDeDatos();
            this.EnableForm(true);
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Curso a Editar";
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.lblEliminar.Visible = true;
            this.FormMode = FormModes.Baja;
            Session["FormMode"] = FormMode;
            this.MapearDeDatos();
            this.EnableForm(false);
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Curso a Editar";
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        MapearADatos();
        if (IsValid)
        {
            this.Save();
            this.LoadGrid();
            this.pnGrilla.Visible = false;
            this.pnTabla.Visible = true;
            Session["cursoSeleccionado"] = null;
        }
    }
    protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvCursos.SelectedValue;
        this.btnAgregarDocente.Visible = true;
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
        Session["cursoSeleccionado"] = Logic.GetOne(SelectedID);
        Page.Response.Redirect("DocentesCursos.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }
    protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargarPlan(Int32.Parse(this.ddlEspecialidad.SelectedValue));
    }
    protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargaMateria(Int32.Parse(this.ddlPlan.SelectedValue));
        this.CargaComisiones(Int32.Parse(this.ddlPlan.SelectedValue));
    }
    protected void cvCurso_ServerValidate(object source, ServerValidateEventArgs args)
    {
        FormMode = (FormModes)Session["FormMode"];
        if (FormMode == FormModes.Alta)
        {
            this.MapearADatos();
            if (CursoActual.ID == 0)
            {
                bool b = true;
                CursoLogic cl = new CursoLogic();
                foreach (DataRow row in cl.GetAll().Rows)
                {
                    if (CursoActual.IdComision == (int)row["id_comision"] && CursoActual.IdMateria == (int)row["id_materia"] && CursoActual.AnioCalendario == (int)row["anio_calendario"])
                    {
                        b = false;
                    }
                }
                args.IsValid = b;
            }
            else args.IsValid = true;
        }
    }

    protected void gvCursos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCursos.PageIndex = e.NewPageIndex;
        gvCursos.DataSource = Logic.GetAll();
        gvCursos.DataBind();
    }
    #endregion
}
