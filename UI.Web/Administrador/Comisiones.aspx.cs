using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

public partial class Administrador_Comisiones : BaseForm
{
    ComisionLogic _logic;

    #region PROPIEDADES

    private ComisionLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new ComisionLogic();
            }
            return _logic;
        }
    }

    private Comision ComisionActual
    {
        get;
        set;
    }

    #endregion

    #region METODOS CREADOS
    public override void LoadGrid()
    {
        try
        {
            if (Logic.GetAll().Rows.Count != 0)
            {
                this.gvComisiones.Visible = true;
                this.lblVacio.Visible = false;
                this.gvComisiones.DataSource = Logic.GetAll();
                this.gvComisiones.DataBind();
            }
            else
            {
                this.gvComisiones.Visible = false;
                this.lblVacio.Visible = true;
                this.lblVacio.Text = "No existen Comisiones";
            }
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
                this.lblPlanVacio.Visible = false;
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
            if (pl.GetAll(IdEspecialidad).Count > 0)
            {
                List<Plan> planes = pl.GetAll(IdEspecialidad);
                this.ddlPlan.Enabled = true;
                this.ddlPlan.Visible = true;
                this.lblPlanVacio.Visible = false;
                this.ddlPlan.DataSource = planes;
                this.ddlPlan.DataTextField = "Descripcion";
                this.ddlPlan.DataValueField = "ID";
                this.ddlPlan.DataBind();
                this.ddlPlan.Items.Insert(0, "Seleccione Plan");
                this.ddlPlan.SelectedIndex = 0;
            }
            else
            {
                this.lblPlanVacio.Visible = true;
                this.lblPlanVacio.Text = "No existen Planes para asociar";
                this.ddlPlan.Visible = false;
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
            PlanLogic pl = new PlanLogic();
            ComisionActual = this.Logic.GetOne(this.SelectedID);
            Plan plan = pl.GetOne(ComisionActual.IdPlan);
            this.ddlAno.SelectedValue = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.CargarEspecialidad();
            this.ddlEspecialidad.SelectedValue = plan.IDEespecialidad.ToString(); this.CargarPlan(plan.IDEespecialidad);
            this.ddlPlan.SelectedValue = plan.ID.ToString();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void MapearADatos()
    {
        switch (this.FormMode)
        {
            case FormModes.Alta: this.ComisionActual = new Comision();
                this.ComisionActual.State = BusinessEntity.States.New;
                ComisionActual.Descripcion = ComisionActual.AnioEspecialidad.ToString() + this.txtDescripcion.Text;
                break;
            case FormModes.Baja: this.ComisionActual = Logic.GetOne(SelectedID);
                this.ComisionActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: this.ComisionActual = new Comision();
                this.ComisionActual.ID = this.SelectedID;
                this.ComisionActual.State = BusinessEntity.States.Modified;
                ComisionActual.Descripcion = ComisionActual.AnioEspecialidad.ToString();
                break;
            default: ComisionActual.State = BusinessEntity.States.Unmodified;
                break;
        }

        ComisionActual.AnioEspecialidad = int.Parse(this.ddlAno.SelectedValue);
        ComisionActual.IdPlan = int.Parse(this.ddlPlan.SelectedValue);
    }
    public override void Save()
    {
        try
        {
            this.Logic.Save(ComisionActual);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void EnableForm(bool bolean)
    {
        this.txtDescripcion.Enabled = bolean;
        this.ddlAno.Enabled = bolean;
        this.ddlEspecialidad.Enabled = bolean;
        this.ddlPlan.Enabled = bolean;
    }
    public override void DeleteEntity(int id)
    {
        try
        {
            this.Logic.Save(this.Logic.GetOne(id));
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("../Error.aspx");
        }
    }
    public override void CleanForm()
    {
        this.CargarEspecialidad();
        this.txtDescripcion.Text = string.Empty;
        this.lblEliminar.Visible = false;
        this.ddlEspecialidad.SelectedIndex = -1;
        this.ddlAno.SelectedIndex = -1;
        this.ddlPlan.SelectedIndex = -1;
        this.lblMensaje.Visible = false;
    }

    #endregion

    #region EVENTOS

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        this.pnGrilla.Visible = true;
        this.pnTabla.Visible = false;
        this.FormMode = FormModes.Alta;
        Session["FormMode"] = FormMode;
        this.CleanForm();
        this.CargarEspecialidad();
        this.EnableForm(true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Modificacion;
            Session["FormMode"] = FormMode;
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Comisión a Editar";
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Baja;
            this.EnableForm(false);
            this.lblEliminar.Visible = true;
            Session["FormMode"] = FormMode;
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Comisión a Eliminar";
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
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
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (!IsPostBack) this.LoadGrid();
        }
        else Page.Response.Redirect("~/Login.aspx");
    }
    protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargarPlan(Int32.Parse(this.ddlEspecialidad.SelectedValue));
    }
    protected void gvComisiones_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvComisiones.SelectedValue;
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void cvComision_ServerValidate(object source, ServerValidateEventArgs args)
    {
        FormMode = (FormModes)Session["FormMode"];
        if (FormMode == FormModes.Alta)
        {
            MapearADatos();
            if (ComisionActual.ID == 0)
            {
                ComisionLogic cl = new ComisionLogic(); bool b = true;
                foreach (DataRow row in cl.GetAll().Rows)
                {
                    if (this.ComisionActual.Descripcion == (string)row["desc_comision"] && this.ComisionActual.IdPlan == (int)row["id_plan"])
                    {
                        b = false;
                    }
                }
                args.IsValid = b;
            }
            else args.IsValid = true;
        }
    }

    protected void gvComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvComisiones.PageIndex = e.NewPageIndex;
        gvComisiones.DataSource = Logic.GetAll();
        gvComisiones.DataBind();
    }
    #endregion
}