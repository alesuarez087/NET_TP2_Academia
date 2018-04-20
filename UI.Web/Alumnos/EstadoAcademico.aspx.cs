using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Data;

public partial class Alumnos_EstadoAcademico : BaseForm
{
    #region PROPIEDADES

    private InscripcionLogic _logic;
    public InscripcionLogic Logic
    {
        get { if (_logic == null) _logic = new InscripcionLogic();  return _logic; }
    }
    public Persona PersonaActual { get; set; }
    #endregion

    public override void LoadGrid()
    {
        MateriaLogic ml = new MateriaLogic();
        PersonaLogic pl = new PersonaLogic();
        DataTable tabla = new DataTable();
        DataTable retorno = null;
        DataRow rowTabla;

        tabla.Columns.Add("ID", typeof(int));
        tabla.Columns.Add("Materia", typeof(string));
        tabla.Columns.Add("Texto", typeof(string));

        PersonaActual = pl.GetOne(((Usuario)Session["usuario"]).IdPersona);

        foreach(DataRow row in Logic.GetAll(PersonaActual.ID).Rows)
        {
            if(!((string)row["condicion"]).Equals("Libre"))
            {
                rowTabla = tabla.NewRow();
                rowTabla["ID"] = (int)row["id_materia"];
                rowTabla["Materia"] = (string)row["desc_materia"];

                if ((string)row["condicion"] == "Inscripto") rowTabla["Texto"] = "Cursando en Comisión " + (string)row["desc_comision"];
                else if ((string)row["condicion"] == "Regular") rowTabla["Texto"] = "Regular en año " + (int)row["anio_calendario"];
                else if((string)row["condicion"] == "Aprobado") rowTabla["Texto"] = "Aprobada con " + (int)row["nota"];

                tabla.Rows.Add(rowTabla);
            }
        }

        retorno = tabla.Copy();

        List<Materia> materiasPlan = ml.GetAllForPlan(PersonaActual.IdPlan);
        for (int i = 0; i < materiasPlan.Count; i++)
        {
            bool valida = true;
            foreach(DataRow row in tabla.Rows)
            {
                if (materiasPlan[i].Descripcion.Equals((string)row["Materia"])) valida = false;
            }
            if(valida)
            {
                rowTabla = retorno.NewRow();
                rowTabla["Materia"] = materiasPlan[i].Descripcion;
                rowTabla["Texto"] = "";
                retorno.Rows.Add(rowTabla);
            }
        }


        this.gvEstadoAcademico.DataSource = retorno;
        this.gvEstadoAcademico.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadGrid();
    }
}