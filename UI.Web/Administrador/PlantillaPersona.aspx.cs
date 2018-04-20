using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlantillaPersona : BaseForm
{
    #region PROPIEDADES
    private PersonaLogic _logic;
    public PersonaLogic Logic
    {
        get
        {
            if (_logic == null) _logic = new PersonaLogic();
            return _logic;
        }
    }
    public Persona PersonaActual
    {
        get;set;
    }
    #endregion

    #region METODOS
    public override void LoadGrid()
    {
        this.gvPersonas.DataSource = Logic.GetAll();
        this.gvPersonas.DataBind();
    }
    public void CargaPlanes(int ID)
    {
        List<Plan> listado = new List<Plan>();
        PlanLogic pl = new PlanLogic();
        foreach (Plan i in pl.GetAll())
        {
            if (i.IDEespecialidad == ID)
            {
                listado.Add(i);
            }

        }
        if (listado.Count == 0)
        {
            this.ddlPlan.Enabled = false;
            this.ddlPlan.Text = "";
        }
        else
        {
            this.ddlPlan.Enabled = true;
        }
        this.ddlPlan.DataSource = listado;
        this.ddlPlan.DataValueField = "ID";
        this.ddlPlan.DataTextField = "Descripcion";
        this.ddlPlan.DataBind();
        listado = null;
    }

    public void CargaCarrera()
    {
        EspecialidadLogic el = new EspecialidadLogic();
        this.ddlEspecialidad.DataSource = el.GetAll();
        this.ddlEspecialidad.DataValueField = "ID";
        this.ddlEspecialidad.DataTextField = "Descripcion";
        this.ddlEspecialidad.DataBind();
        this.ddlEspecialidad.SelectedIndex = -1;
        this.CargaPlanes(Int32.Parse(ddlEspecialidad.SelectedValue));
    }

    private void CargaTipoPersona()
    {
        this.ddlTipoPersona.Items.Add("Alumno");
        this.ddlTipoPersona.Items.Add("Profesor");
        this.ddlTipoPersona.Items.Add("Administrador");
    }

    public override void MapearADatos()
    {
        switch (this.FormMode)
        {
            case FormModes.Alta: PersonaActual = new Persona();
                                 PersonaActual.State = BusinessEntity.States.New;
                break;
            case FormModes.Baja: PersonaActual = this.Logic.GetOne(SelectedID);
                                 PersonaActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: PersonaActual = this.Logic.GetOne(SelectedID); 
                                         PersonaActual.State = BusinessEntity.States.Modified;
                break;
        }
        PersonaActual.Nombre = this.txtNombre.Text;
        PersonaActual.Apellido = this.txtApellido.Text;
        PersonaActual.Direccion = this.txtDireccion.Text;
        PersonaActual.Email = this.txtEmail.Text;
        PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
        PersonaActual.Telefono = this.txtTelefono.Text;
        PersonaActual.IdPlan = Int32.Parse(this.ddlPlan.SelectedValue);
        PersonaActual.FechaNacimiento = new DateTime(int.Parse(txtAno.Text), int.Parse(txtMes.Text), int.Parse(txtDia.Text));

        switch (this.ddlTipoPersona.SelectedValue)
        {
            case "Alumno": PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
                break;
            case "Administrador": PersonaActual.TipoPersona = Persona.TiposPersonas.Administrador;
                break;
            case "Profesor": PersonaActual.TipoPersona = Persona.TiposPersonas.Profesor;
                break;
        }
    }

    public override void MapearDeDatos()
    {
        PersonaActual = (Persona)Session["persona"];

        PlanLogic pl = new PlanLogic();
        this.txtNombre.Text = PersonaActual.Nombre;
        this.txtApellido.Text = PersonaActual.Apellido;
        this.txtDireccion.Text = PersonaActual.Direccion;
        this.txtEmail.Text = PersonaActual.Email;
        this.txtLegajo.Text = PersonaActual.Legajo.ToString();
        this.txtTelefono.Text = PersonaActual.Telefono;
        this.ddlEspecialidad.SelectedValue = pl.GetOne(PersonaActual.IdPlan).IDEespecialidad.ToString(); this.CargaPlanes(Int32.Parse(this.ddlEspecialidad.SelectedValue));
        this.ddlPlan.SelectedValue = PersonaActual.IdPlan.ToString();
        this.txtAno.Text = PersonaActual.FechaNacimiento.Year.ToString();
        this.txtMes.Text = PersonaActual.FechaNacimiento.Month.ToString();
        this.txtDia.Text = PersonaActual.FechaNacimiento.Day.ToString();

        switch (PersonaActual.TipoPersona)
        {
            case Persona.TiposPersonas.Administrador: this.ddlTipoPersona.SelectedValue= "Administrador";
                break;
            case Persona.TiposPersonas.Alumno: this.ddlTipoPersona.SelectedValue = "Alumno";
                break;
            case Persona.TiposPersonas.Profesor: this.ddlTipoPersona.SelectedValue = "Profesor";
                break;
        }

        switch (this.FormMode)
        {
            case FormModes.Baja: PersonaActual.State = BusinessEntity.States.Deleted;
                break;
            case FormModes.Modificacion: PersonaActual.State = BusinessEntity.States.Modified;
                break;
        }
    }

    public override void Save()
    {
        this.Logic.Save(PersonaActual);
    }
    private void DeleleEntity(int id)
    {
        this.Logic.Save(this.Logic.GetOne(id));
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["usuario"]!=null)
        {
            if(!IsPostBack)
            {
                this.LoadGrid();
                this.CargaCarrera();
                this.CargaTipoPersona();
            }
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Alta;
        pnGrilla.Visible = true;
        pnTabla.Visible = false;
        this.EnableForm(true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Modificacion;
        Session["persona"] = Logic.GetOne(SelectedID);
        this.EnableForm(false);
        pnGrilla.Visible = true;
        pnTabla.Visible = false;
        this.MapearDeDatos();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        FormMode = FormModes.Baja;
        Session["persona"] = Logic.GetOne(SelectedID);
        this.EnableForm(false);
        pnGrilla.Visible = true;
        pnTabla.Visible = false;
        this.MapearDeDatos();
    }
    protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvPersonas.SelectedValue;
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if(IsValid)
        {
            this.Save();
            pnGrilla.Visible = false;
            pnTabla.Visible = true;
            this.LoadGrid();
        }
    }

    protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargaPlanes((int)ddlEspecialidad.SelectedIndex);
    }
    protected void cvFechaNacimineto_ServerValidate(object source, ServerValidateEventArgs args)
    {
        this.MapearADatos();
        bool b = true;
        if (PersonaActual.FechaNacimiento.Day > 31)
        {
            b = false;
        }
        else
        {
            if (PersonaActual.FechaNacimiento.Month < 1 || PersonaActual.FechaNacimiento.Month > 12)
            {
                b = false;
            }
            else
            {
                if ((PersonaActual.FechaNacimiento.Month == 4 || PersonaActual.FechaNacimiento.Month == 6 ||
                PersonaActual.FechaNacimiento.Month == 9 || PersonaActual.FechaNacimiento.Month == 11)
                && PersonaActual.FechaNacimiento.Day > 30)
                {
                    b = false;
                }
                else
                {
                    if (PersonaActual.FechaNacimiento.Day > 31 && (PersonaActual.FechaNacimiento.Month == 1 || PersonaActual.FechaNacimiento.Month == 7 ||
                        PersonaActual.FechaNacimiento.Month == 3 || PersonaActual.FechaNacimiento.Month == 5 || PersonaActual.FechaNacimiento.Month == 8 ||
                        PersonaActual.FechaNacimiento.Month == 10 || PersonaActual.FechaNacimiento.Month == 12))
                    {
                        b = false;
                    }
                    else
                    {
                        if (PersonaActual.FechaNacimiento.Day == 29 && PersonaActual.FechaNacimiento.Month == 2 && PersonaActual.FechaNacimiento.Year % 4 != 0)
                        {
                            b = false;
                        }
                    }
                }
            }
        }
        args.IsValid = b;
    }
    protected void cvLegajo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        this.MapearADatos();
        if(PersonaActual.ID == 0)
        {
            bool b = true;
            foreach (Persona p in Logic.GetAll())
            {
                if (PersonaActual.Legajo == p.Legajo) b = false;
            }
            args.IsValid = b;
        }
    }

    protected void gvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonas.PageIndex = e.NewPageIndex;
        gvPersonas.DataSource = Logic.GetAll();
        gvPersonas.DataBind();
    }
    #endregion
}