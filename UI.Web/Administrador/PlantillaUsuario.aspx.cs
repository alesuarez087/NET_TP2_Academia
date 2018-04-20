using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_PlantillaUsuario : BaseForm
{
    private UsuarioLogic _logic;
    
    #region PROPIEDADES
    public UsuarioLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new UsuarioLogic();
            }
            return _logic;
        }
    }
    public Usuario UsuarioActual
    {
        get;set;
    }
    public Usuario UsuarioSeleccionado
    {
        get;set;
    }
    public List<ModuloUsuario> ModuloUsuarioSeleccionado
    {
        get;set;
    }
    public Persona PersonaActual
    {
        get;set;
    }
#endregion

    #region METODOS
    private void CargaModulos()
    {
        List<ModuloUsuario> list = new List<ModuloUsuario>();
        ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
        if(FormMode == FormModes.Alta)
        {
            list = mul.GetAll();
        }
        else
        {
            UsuarioSeleccionado = (Usuario)Session["usuarioSeleccionado"];
            list = mul.GetAll(UsuarioSeleccionado.ID);
        }
        this.ModuloUsuarioSeleccionado = list;
        Session["modulos"] = list;
        this.gvModulos.DataSource = list;
        this.gvModulos.DataBind();
    }
    public override void MapearDeDatos()
    {
        UsuarioSeleccionado = (Usuario)Session["usuario"]; Session["usuarioSeleccionado"] = UsuarioSeleccionado;
        this.txtNombre.Text = this.UsuarioSeleccionado.Nombre;
        this.txtApellido.Text = this.UsuarioSeleccionado.Apellido;
        this.txtEmail.Text = this.UsuarioSeleccionado.Email;
        this.chckbxHabilitado.Checked = this.UsuarioSeleccionado.Habilitado;
        this.txtNombreUsuario.Text = this.UsuarioSeleccionado.NombreUsuario;
    }
    public override void MapearADatos()
    {
        switch(FormMode)
        {
            case FormModes.Alta: UsuarioSeleccionado = new Usuario() ; UsuarioSeleccionado.State = BusinessEntity.States.New;
                break;
            case FormModes.Modificacion: UsuarioSeleccionado = (Usuario)Session["usuarioSeleccionado"]; UsuarioSeleccionado.State = BusinessEntity.States.Modified;
                break;
            case FormModes.Baja: UsuarioSeleccionado = (Usuario)Session["usuarioSeleccionado"]; UsuarioSeleccionado.State = BusinessEntity.States.Deleted;
                break;
            default: UsuarioSeleccionado = (Usuario)Session["usuarioSeleccionado"]; UsuarioSeleccionado.State = BusinessEntity.States.Unmodified;
                break;
        }
        if(Session["persona"]!=null) UsuarioSeleccionado.IdPersona = ((Persona)Session["persona"]).ID;
        UsuarioSeleccionado.Nombre = this.txtNombre.Text;
        UsuarioSeleccionado.Apellido = this.txtApellido.Text;
        UsuarioSeleccionado.Clave = this.txtClave.Text;
        UsuarioSeleccionado.Email = this.txtEmail.Text;
        UsuarioSeleccionado.Habilitado = this.chckbxHabilitado.Checked;
        UsuarioSeleccionado.NombreUsuario = this.txtNombreUsuario.Text;
        
        ModuloUsuarioSeleccionado = (List<ModuloUsuario>)Session["modulos"];
        foreach(ModuloUsuario mu in ModuloUsuarioSeleccionado)
        {
            mu.State = UsuarioSeleccionado.State;
        }
    }
    public override void EnableForm(bool bolean)
    {
        FormMode = (FormModes)Session["FormMode"];
        this.txtApellido.Enabled = bolean;
        this.txtNombre.Enabled = bolean;
        
        if (FormMode == FormModes.Modificacion)
        {
            this.MapearDeDatos();
            btnAceptar.Text = "Modificar";
        }
        else if(FormMode == FormModes.Alta)
        {
            btnAceptar.Text = "Agregar";
        }
        else if(FormMode == FormModes.Baja)
        {
            this.MapearDeDatos();
            this.txtClave.Enabled = bolean;
            this.txtConfirmarClave.Enabled = bolean;
            this.txtEmail.Enabled = bolean;
            this.txtNombreUsuario.Enabled = bolean;
            this.txtClave.Enabled = bolean;
            this.txtConfirmarClave.Enabled = bolean;
        }
        
    }
    public override void Save()
    {
        if (IsValid)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            Logic.Save(UsuarioSeleccionado);
            if((FormModes)Session["FormMode"] == FormModes.Alta)
            {
                UsuarioLogic ul = new UsuarioLogic();
                UsuarioSeleccionado = ul.GetUsuarioForLogin(UsuarioSeleccionado.NombreUsuario, UsuarioSeleccionado.Clave);
                foreach (ModuloUsuario mu in ModuloUsuarioSeleccionado)
                {
                    mu.IdUsuario = UsuarioSeleccionado.ID;
                    mul.Save(mu);
                }
            }
            else
            {
                foreach (ModuloUsuario mu in ModuloUsuarioSeleccionado)
                {
                    mul.Save(mu);
                }
            }
        }
    }
    private void ActualizarModulos(int ID, bool Alta, bool Baja, bool Consulta, bool Modificacion)
    {
        if (Session["modulos"] != null) ModuloUsuarioSeleccionado = (List<ModuloUsuario>)Session["modulos"];
            else ModuloUsuarioSeleccionado = new List<ModuloUsuario>();
        foreach (ModuloUsuario mu in ModuloUsuarioSeleccionado)
        {
            if (mu.IdModulo == ID)
            {
                mu.PermiteAlta = Alta;
                mu.PermiteBaja = Baja;
                mu.PermiteConsulta = Consulta;
                mu.PermiteModificacion = Modificacion;
            }
        }
        Session["modulos"] = ModuloUsuarioSeleccionado;
    }
    private List<ModuloUsuario> ObtenerModulos()
    {
        return (List<ModuloUsuario>)Session["modulos"];
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["usuario"] != null)
        {
            if (Session["persona"] != null)
            {
                UsuarioSeleccionado = new Usuario();
                this.txtApellido.Text = ((Persona)Session["persona"]).Apellido;
                this.txtNombre.Text = ((Persona)Session["persona"]).Nombre;
                this.txtEmail.Text = ((Persona)Session["persona"]).Email;
                UsuarioSeleccionado.IdPersona = ((Persona)Session["persona"]).ID;
            }
            if (Session["edit"] != null)
            {
                this.txtNombreUsuario.Text = ((Usuario)Session["edit"]).NombreUsuario;
                this.txtClave.Text = ((Usuario)Session["edit"]).Clave;
            }
            if (!IsPostBack)
            {
                UsuarioActual = (Usuario)Session["usuario"];
                PersonaLogic pl = new PersonaLogic();
                PersonaActual = pl.GetOne(UsuarioActual.IdPersona);
                //            Session["Persona"] = PersonaActual;

                if (Session["FormMode"] == null) Session["FormMode"] = FormModes.Modificacion;
                else FormMode = (FormModes)Session["FormMode"];
                if (Session["usuarioSeleccionado"] != null)
                {
                    UsuarioSeleccionado = (Usuario)Session["usuarioSeleccionado"];
                }

                if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno || PersonaActual.TipoPersona == Persona.TiposPersonas.Profesor)
                {
                    this.lblHabilitado.Visible = false;
                    this.gvModulos.Visible = false;
                    this.btnAgregarPersona.Visible = false;
                    this.chckbxHabilitado.Visible = false;
                    this.gvModulos.Visible = false;
                }
                else
                {
                    this.gvModulos.Visible = true;
                    this.btnAgregarPersona.Visible = true;
                    this.chckbxHabilitado.Visible = true;
                }
                this.EnableForm(false);
                this.CargaModulos();
            }
        }
        else
        {
            Page.Response.Redirect("~/Login.aspx");
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        PersonaActual = (Persona)Session["Persona"];
        this.Save();
        Session["edit"] = null;
        if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador) Page.Response.Redirect("Usuarios.aspx");
        else Page.Response.Redirect("~/Default.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        PersonaActual = (Persona)Session["Persona"];
        if(PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador) Page.Response.Redirect("Usuarios.aspx");
        else Page.Response.Redirect("~/Default.aspx");
    }
    protected void btnAgregarPersona_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Personas.aspx");
    }
    protected void gvModulos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (this.txtClave.Text != "" || this.txtNombreUsuario.Text != "")
        {
            Usuario u = new Usuario();
            u.NombreUsuario = this.txtNombreUsuario.Text;
            u.Clave = this.txtClave.Text;
            Session["edit"] = u;
        }
        this.gvModulos.EditIndex = e.NewEditIndex;
        //this.CargaModulos();
        this.gvModulos.DataSource = this.ObtenerModulos();
        this.gvModulos.DataBind();
    }
    protected void gvModulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.gvModulos.EditIndex = -1;
        this.ObtenerModulos();
    }
    protected void gvModulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        CheckBox chckbxAlta = (CheckBox)gvModulos.Rows[e.RowIndex].FindControl("chckbxAlta");
        CheckBox chckbxBaja = (CheckBox)gvModulos.Rows[e.RowIndex].FindControl("chckbxBaja");
        CheckBox chckbxConsulta = (CheckBox)gvModulos.Rows[e.RowIndex].FindControl("chckbxConsulta");
        CheckBox chckbxModificacion = (CheckBox)gvModulos.Rows[e.RowIndex].FindControl("chckbxModificacion");
        
        int IdModulo = Int32.Parse(gvModulos.DataKeys[e.RowIndex].Values[0].ToString());

        this.ActualizarModulos(IdModulo, chckbxAlta.Checked, chckbxBaja.Checked, chckbxConsulta.Checked, chckbxModificacion.Checked);

        this.gvModulos.EditIndex = -1;
        this.gvModulos.DataSource = this.ObtenerModulos();
        this.gvModulos.DataBind();
    }
    protected void cvContrasena_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtClave.Text.Length < 8) args.IsValid=false;
        else if (txtClave.Text.Equals(txtConfirmarClave.Text)) args.IsValid = true;
        else
        {
            cvContrasena.Text = " * Las contraseñas son diferentes";
            args.IsValid = false;
        }
    }
    protected void cvUsuarios_ServerValidate(object source, ServerValidateEventArgs args)
    {
        this.MapearADatos();
        bool b = true;
        if (UsuarioSeleccionado.State == BusinessEntity.States.New)
        {
            UsuarioLogic ul = new UsuarioLogic();
            bool rep = false;
            foreach (Usuario u in ul.GetAll()) if (u.NombreUsuario.Equals(txtNombreUsuario.Text)) rep = true;
            if (rep)
            {
                b = false;
            }
            args.IsValid = b;
        }
    }
    protected void cvNombreUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtApellido.Text.Equals("")) args.IsValid = true;
        else if (txtNombreUsuario.Text.Equals("")) args.IsValid = false;
        else args.IsValid = true;
    }
    #endregion

    
}