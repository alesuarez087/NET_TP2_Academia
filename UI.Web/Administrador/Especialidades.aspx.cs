using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

public partial class Especialidades : BaseForm
{
    EspecialidadLogic _logic;

    #region PROPIEDADES
    
    private EspecialidadLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new EspecialidadLogic();
            }
            return _logic;
        }
    }

    private Especialidad EspecialidadActual
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
            if (Logic.GetAll().Count != 0)
            {
                this.gvEspecialidades.Visible = true;
                this.lblVacio.Visible = false;
                this.gvEspecialidades.DataSource = Logic.GetAll();
                this.gvEspecialidades.DataBind();
            }
            else
            {
                this.gvEspecialidades.Visible = false;
                this.lblVacio.Visible = true;
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
        EspecialidadActual = this.Logic.GetOne(this.SelectedID);
        this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
    }
    public override void MapearADatos()
    {
        switch (this.FormMode)
        {
            case FormModes.Baja: this.EspecialidadActual = this.Logic.GetOne(SelectedID); 
                                 this.DeleteEntity(this.SelectedID);
                break;
            case FormModes.Modificacion: this.EspecialidadActual = this.Logic.GetOne(SelectedID);
                                         this.EspecialidadActual.State = BusinessEntity.States.Modified;
                break;
            case FormModes.Alta: this.EspecialidadActual = new Especialidad();
                this.EspecialidadActual.State = BusinessEntity.States.New;
                break;
            default: break;
        }
        EspecialidadActual.Descripcion = this.txtDescripcion.Text;
    }
    public override void Save()
    {
        try
        {
            this.Logic.Save(EspecialidadActual);
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
 	    this.txtDescripcion.Text = string.Empty;
        this.lblEliminar.Visible = false;
    }
    
    #endregion

    #region EVENTOS
    protected void gvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvEspecialidades.SelectedValue;
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Modificacion;
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Especialidad a Editar";
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            this.Save();
            this.pnTabla.Visible = true;
            this.pnGrilla.Visible = false;
            this.LoadGrid();
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (this.IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Baja;
            Session["FormMode"] = FormMode;
            this.EnableForm(false);
            this.lblEliminar.Visible = true;
            this.MapearDeDatos();
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Especialidad a Editar";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null) Page.Response.Redirect("~/Default.aspx");
        else if (!IsPostBack) this.LoadGrid();
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        this.pnTabla.Visible = false;
        this.pnGrilla.Visible = true;
        this.FormMode = FormModes.Alta;
        this.CleanForm();
        this.EnableForm(true);
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }
    protected void cvEspecialiiadd_ServerValidate(object source, ServerValidateEventArgs args)
    {
        bool b = true;
        this.MapearADatos();
        if (EspecialidadActual.State == BusinessEntity.States.New)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            foreach (Especialidad e in el.GetAll()) if (EspecialidadActual.Descripcion == e.Descripcion)
            {
                b = false;
            }
        }
        args.IsValid = b;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        this.pnTabla.Visible = true;
        this.pnGrilla.Visible = false;
    }

    protected void gvEspecialidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEspecialidades.PageIndex = e.NewPageIndex;
        gvEspecialidades.DataSource = Logic.GetAll();
        gvEspecialidades.DataBind();
    }
    #endregion
}