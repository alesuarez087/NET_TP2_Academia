using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de BaseForm
/// </summary>
public partial class BaseForm : System.Web.UI.Page
{
    public enum FormModes { Alta, Baja, Modificacion }

    public FormModes FormMode
    {
        get
        {
            return (FormModes)this.ViewState["FormMode"];
        }
        set
        {
            this.ViewState["FormMode"] = value;
        }
    }

    public int SelectedID //guarda ID de la entidad actual
    {
        get
        {
            if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
            else return 0;
        }
        set
        {
            this.ViewState["SelectedID"] = value;
        }
    }

    public bool IsEntitySelected //devuelve null si SelectedID = 0
    {
        get { return this.SelectedID != 0; }
    }

    public virtual void LoadGrid() { }

    public virtual void MapearDeDatos() { } //muestra los datos de varias a pantalla

    public virtual void MapearADatos() { } //capta los datos de pantalla hacia variable local

    public virtual void Save() { } //guarda en BD los datos de variable local

    public virtual void EnableForm(bool enable) { } //bloquea los componentes del formulario

    public virtual void CleanForm() { } //limpia los valores de formulario

    public virtual void DeleteEntity(int id) { }

}