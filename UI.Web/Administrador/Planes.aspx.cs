using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Planes : BaseForm
{
    PlanLogic _logic;

    #region PROPIEDADES

    private PlanLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new PlanLogic();
            }
            return _logic;
        }
    }

    private Plan PlanActual
    {
        get;
        set;
    }

    #endregion

    #region METODOS CREADOS
    public override void LoadGrid()
    {
        if (Logic.GetTabla().Rows.Count != 0) 
        {
            gvPlanes.Visible = true;
            lblVacio.Visible = false;
            gvPlanes.DataSource = Logic.GetTabla();
            gvPlanes.DataBind();
        }
        else
        {
            gvPlanes.Visible = false;
            lblVacio.Visible = true;
            lblVacio.Text = "No existen Planes";
        }
    }
    public override void MapearDeDatos()
    {
        PlanActual = this.Logic.GetOne(this.SelectedID);
        this.txtPlan.Text = this.PlanActual.Descripcion;
        this.CargaEspecialidades();
        this.ddlEspecialidad.SelectedValue = this.PlanActual.IDEespecialidad.ToString();
    }
    public override void MapearADatos()
    {
        switch (this.FormMode)
        {
            case FormModes.Alta: PlanActual = new Plan();
                                              PlanActual.State = BusinessEntity.States.New;
                break;
            case FormModes.Baja: this.PlanActual = this.Logic.GetOne(SelectedID);
                                                   this.PlanActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: this.PlanActual = this.Logic.GetOne(SelectedID);
                                         this.PlanActual.State = BusinessEntity.States.Modified;
                break;
            default: break;
        }
        PlanActual.Descripcion = this.txtPlan.Text;
        PlanActual.IDEespecialidad = int.Parse(this.ddlEspecialidad.SelectedValue);
    }
    public override void Save()
    {
        this.Logic.Save(PlanActual);
    }
    public override void EnableForm(bool bolean)
    {
        this.txtPlan.Enabled = bolean;
        this.ddlEspecialidad.Enabled = bolean;
    }
    public override void DeleteEntity(int id)
    {
        this.Logic.Save(this.Logic.GetOne(id));
    }
    public override void CleanForm()
    {
        this.lblEliminar.Visible = false;
        this.txtPlan.Text = string.Empty;
        this.CargaEspecialidades();
        this.ddlEspecialidad.SelectedIndex = -1;
    }
    private void CargaEspecialidades()
    {
        EspecialidadLogic el = new EspecialidadLogic();
        if(el.GetAll().Count > 1)
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
            this.lblVacio.Visible = true;
            this.lblVacio.Text = "No existen Especialidades para asociar. Primero ingrese una especialidad";
            this.pnForm.Visible = false;
            this.pnTabla.Visible = true;
        }
    }
    private void LabelFalse()
    {
        if (this.lblMensaje.Visible) this.lblMensaje.Visible = false;
    }
    
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null) Page.Response.Redirect("~/Default.aspx");
        else if (!IsPostBack) { this.LoadGrid();}
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        this.pnTabla.Visible = false;
        this.pnForm.Visible = true;
        this.FormMode = FormModes.Alta;
        this.CleanForm();
        Session["FormMode"] = FormMode;
        this.EnableForm(true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if(this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnForm.Visible = true;
            this.FormMode = FormModes.Modificacion;
            Session["FormMode"] = FormMode;
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Plan a Editar";
        }
    }
    protected void gvPlanes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvPlanes.SelectedValue;
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if(this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnForm.Visible = true;
            this.FormMode = FormModes.Baja;
            this.lblEliminar.Visible = true;
            Session["FormMode"] = FormMode;
            this.EnableForm(false);
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Plan a Eliminar";
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        this.MapearADatos();
        if (IsValid)
        {
            this.Save();
            this.LoadGrid();
            this.pnTabla.Visible = true;
            this.pnForm.Visible = false;
            this.LabelFalse();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        this.pnForm.Visible = false;
        this.pnTabla.Visible = true;
        this.LabelFalse();
    }
    
    protected void cvPlanes_ServerValidate(object source, ServerValidateEventArgs args)
    {
        FormMode = (FormModes)Session["FormMode"];
        if (FormMode == FormModes.Alta)
        {
            MapearADatos();
            bool valid = true;
            PlanLogic pl = new PlanLogic();
            foreach (Plan p in pl.GetAll())
            {
                if (p.IDEespecialidad == PlanActual.IDEespecialidad && p.Descripcion == PlanActual.Descripcion)
                {
                    valid = false;
                }
            }
            args.IsValid = valid;
        }
    }
    protected void lnkbtnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }

    protected void gvPlanes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPlanes.PageIndex = e.NewPageIndex;
        gvPlanes.DataSource = Logic.GetAll();
        gvPlanes.DataBind();
    }
    #endregion
}