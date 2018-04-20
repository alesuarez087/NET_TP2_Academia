using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Listados_Materias : BaseForm
{
    MateriaLogic _logic;

    #region PROPIEDADES

    private MateriaLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new MateriaLogic();
            }
            return _logic;
        }
    }

    private Materia MateriaActual
    {
        get;
        set;
    }
    #endregion

    #region METODOS CREADOS
    public override void LoadGrid()
    {
        if(Logic.GetAll().Rows.Count != 0)
        {
            this.gvMaterias.Visible = true;
            this.lblVacio.Visible = false;
            this.gvMaterias.DataSource = Logic.GetAll();
            this.gvMaterias.DataBind();
        }
        else
        {
            this.gvMaterias.Visible = false;
            this.lblVacio.Visible = true;
            this.lblVacio.Text = "No existen Materias";
        }
    }
    private void CargarEspecialidad()
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
    private void CargarPlan(int ID)
    {
        PlanLogic pl = new PlanLogic();
        if(pl.GetAll(ID).Count > 0)
        {
            this.lblPlanVacio.Visible = false;
            this.ddlPlan.Visible = true;
            List<Plan> planes = pl.GetAll(ID);
            
            ddlPlan.DataSource = planes;
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataBind();
            ddlPlan.Items.Insert(0, "Seleccionar Plan");
            ddlPlan.SelectedIndex = 0;
        }
        else
        {
            this.lblPlanVacio.Visible = true;
            this.lblPlanVacio.Text = "No existen Planes para asociar";
            this.ddlPlan.Visible = false;
        }
    }
    public override void MapearDeDatos()  //muestra los datos de varias a pantalla
    {
        this.MateriaActual = this.Logic.GetOne(SelectedID);

        PlanLogic pl = new PlanLogic();
        Plan p = pl.GetOne(this.MateriaActual.IdPlan);
        
        this.txtNombreMateria.Text = this.MateriaActual.Descripcion;
        this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
        this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();

        this.ddlEspecialidad.SelectedValue = p.IDEespecialidad.ToString(); this.CargarPlan(p.IDEespecialidad);
        this.ddlPlan.SelectedValue = this.MateriaActual.IdPlan.ToString();
    }
    public override void MapearADatos()  //capta los datos de pantalla hacia variable local
    {
        switch (this.FormMode)
        {
            case FormModes.Alta: MateriaActual = new Materia();
                                 MateriaActual.State = BusinessEntity.States.New;
                break;
            case FormModes.Baja: MateriaActual = Logic.GetOne(SelectedID);
                                                 MateriaActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: Logic.GetOne(SelectedID); 
                                         this.MateriaActual.State = BusinessEntity.States.Modified;
                break;
        }
        this.MateriaActual.Descripcion = this.txtNombreMateria.Text;
        this.MateriaActual.HSSemanales = int.Parse(this.txtHsSemanales.Text);
        this.MateriaActual.HSTotales = int.Parse(this.txtHsTotales.Text);
        this.MateriaActual.IdPlan = int.Parse(this.ddlPlan.SelectedValue);
    }
    public override void Save()  //guarda en BD los datos de variable local
    {
        this.Logic.Save(MateriaActual);
    }
    public override void EnableForm(bool enabled)  //bloquea los componentes del formulario
    {
        this.txtNombreMateria.Enabled = enabled;
        this.txtHsSemanales.Enabled = enabled;
        this.txtHsTotales.Enabled = enabled;
        this.ddlPlan.Enabled = enabled;
        this.ddlEspecialidad.Enabled = enabled;
    }
    public override void CleanForm()  //limpia los valores de formulario
    {
        this.CargarEspecialidad();
        this.lblEliminar.Visible = false;
        this.txtNombreMateria.Text = string.Empty;
        this.txtHsSemanales.Text = string.Empty;
        this.txtHsTotales.Text = string.Empty;
        this.ddlPlan.SelectedIndex = -1;
        this.ddlEspecialidad.SelectedIndex = -1;
    }
#endregion
    
    #region EVENTOS
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        MapearADatos();
        if(IsValid)
        {
            this.Save();
            this.LoadGrid();
            this.pnTabla.Visible = true;
            this.pnGrilla.Visible = false;
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        this.pnTabla.Visible = false;
        this.pnGrilla.Visible = true;
        this.FormMode = FormModes.Alta;
        Session["FormMode"] = FormMode;
        this.CleanForm();
        this.EnableForm(true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        
        if(IsEntitySelected)
        {
            this.pnTabla.Visible = false;
            this.pnGrilla.Visible = true;
            this.FormMode = FormModes.Modificacion;
            Session["FormMode"] = FormMode;
            this.CleanForm();
            this.MapearDeDatos();
            this.EnableForm(true);
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = " * Seleccione Materia a Editar";
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
            this.lblEliminar.Visible = true;
            this.MapearDeDatos();
            this.EnableForm(false);
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = " * Seleccione Materia a Eliminar";
        }
    }
    protected void gvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvMaterias.SelectedValue;
        this.btnEliminar.Enabled = this.btnEditar.Enabled = true;
    }    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }
    protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargarPlan(int.Parse(this.ddlEspecialidad.SelectedValue));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (!IsPostBack) this.LoadGrid();
        }
        else Page.Response.Redirect("~/Login.aspx");
    }
    protected void cvMateria_ServerValidate(object source, ServerValidateEventArgs args)
    {
        FormMode = (FormModes)Session["FormMode"];
        if (FormMode == FormModes.Alta)
        {
            MapearADatos();
            bool o = true;
            MateriaLogic ml = new MateriaLogic();
            foreach (DataRow i in ml.GetAll().Rows)
            {
                if ((string)i["desc_materia"] == MateriaActual.Descripcion && MateriaActual.IdPlan == (int)i["id_plan"])
                {
                    o = false;
                }
            }
            args.IsValid = o;
        }
    }

    protected void gvMaterias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaterias.PageIndex = e.NewPageIndex;
        gvMaterias.DataSource = Logic.GetAll();
        gvMaterias.DataBind();
    }
    #endregion
}