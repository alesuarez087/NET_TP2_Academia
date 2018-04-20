using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public Usuario UsuarioActual
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            string txtUsuario = Request.Form["txtUsuario"];
            string txtContrasena = Request.Form["txtContrasena"];
            UsuarioLogic user = new UsuarioLogic();
            UsuarioActual = user.GetUsuarioForLogin(txtUsuario, txtContrasena);
            if (UsuarioActual.ID != 0)
            {
                if (UsuarioActual.Habilitado)
                {
                    Session["usuario"] = UsuarioActual;
                    Page.Response.Redirect("Default.aspx");
                }
                else
                {
                    this.lblMensaje.Visible = true;
                    this.lblMensaje.Text = "Usuario no habilitado !";
                }
            }
            else
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "Usuario o Contraseña incorrectos";
            }
        }
        catch(Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("Error.aspx");
            
        }
    }
}