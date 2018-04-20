using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> Lista = new List<Persona>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PersonaGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Persona p = new Persona();
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.ID = (int)dr["id_persona"];
                    p.IdPlan = (int)dr["id_plan"];
                    p.Legajo = (int)dr["legajo"];
                    p.Nombre = (string)dr["nombre"];
                    p.Telefono = (string)dr["telefono"];

                    if ((int)dr["tipo_persona"] == 0) p.TipoPersona = Persona.TiposPersonas.Administrador;
                    else if ((int)dr["tipo_persona"] == 1) p.TipoPersona = Persona.TiposPersonas.Alumno;
                    else p.TipoPersona = Persona.TiposPersonas.Profesor;
                    
                    Lista.Add(p);
                }
                return Lista;
            }
            catch(Exception e)
            {
                Exception ExcepcionManjeda = new Exception("Error al recuperar las personas", e);
                throw ExcepcionManjeda;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Persona> GetAllAlumnos()
        {
            List<Persona> alumnos = new List<Persona>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnoGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona per = new Persona();
                    per.Apellido = (string)dr["apellido"];
                    per.Direccion = (string)dr["direccion"];
                    per.Email = (string)dr["email"];
                    per.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    per.ID = (int)dr["id_persona"];
                    per.IdPlan = (int)dr["id_plan"];
                    per.Legajo = (int)dr["legajo"];
                    per.Nombre = (string)dr["nombre"];
                    per.Telefono = (string)dr["telefono"];
                    per.TipoPersona = Persona.TiposPersonas.Alumno;
                    per.State = BusinessEntity.States.Unmodified;
                    alumnos.Add(per);
                }
                dr.Close();
                return alumnos;
            }
            catch (SqlException ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Persona> Buscador(string texto)
        {
            List<Persona> Lista = new List<Persona>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnoBuscador", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@texto", texto);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona p = new Persona();
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.ID = (int)dr["id_persona"];
                    p.IdPlan = (int)dr["id_plan"];
                    p.Legajo = (int)dr["legajo"];
                    p.Nombre = (string)dr["nombre"];
                    p.Telefono = (string)dr["telefono"];
                    p.TipoPersona = Persona.TiposPersonas.Alumno;

                    Lista.Add(p);
                }
                return Lista;
            }
            catch (Exception e)
            {
                Exception ExcepcionManjeda = new Exception("Error al recuperar las personas", e);
                throw ExcepcionManjeda;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Persona> Buscador(int idOrLegajo)
        {
            List<Persona> Lista = new List<Persona>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnoBuscadorNro", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro", idOrLegajo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona p = new Persona();
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.ID = (int)dr["id_persona"];
                    p.IdPlan = (int)dr["id_plan"];
                    p.Legajo = (int)dr["legajo"];
                    p.Nombre = (string)dr["nombre"];
                    p.Telefono = (string)dr["telefono"];
                    p.TipoPersona = Persona.TiposPersonas.Alumno;

                    Lista.Add(p);
                }
                return Lista;
            }
            catch (Exception e)
            {
                Exception ExcepcionManjeda = new Exception("Error al recuperar las personas", e);
                throw ExcepcionManjeda;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Persona GetOne(int IdPersona)
        {
            Persona p = new Persona();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PersonaGetOne", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdPersona);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.ID = (int)dr["id_persona"];
                    p.IdPlan = (int)dr["id_plan"];
                    p.Legajo = (int)dr["legajo"];
                    p.Nombre = (string)dr["nombre"];
                    p.Telefono = (string)dr["telefono"];

                    if ((int)dr["tipo_persona"] == 0) p.TipoPersona = Persona.TiposPersonas.Administrador;
                    else if ((int)dr["tipo_persona"] == 1) p.TipoPersona = Persona.TiposPersonas.Alumno;
                    else p.TipoPersona = Persona.TiposPersonas.Profesor;
                }
                return p;
            }
            catch(Exception e)
            {
                Exception ExcepcionManjeda = new Exception("Error al recuperar la persona", e);
                throw ExcepcionManjeda;
            }
            finally
            {
                this.CloseConnection();
            }
        }
   
        public void Save(Persona p)
        {
            if (p.State == BusinessEntity.States.New) this.Insert(p);
            else if (p.State == BusinessEntity.States.Modified) this.Update(p);
            else if (p.State == BusinessEntity.States.Deleted) this.Delete(p);
            p.State = BusinessEntity.States.Unmodified;
        }

        public void Delete(Persona p)
        {
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PersonaDelete";
            cmd.Parameters.AddWithValue("@id", p.ID);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        public void Update(Persona p)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("PersonaUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", p.ID);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@fecha_nac", p.FechaNacimiento);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@email", p.Email);
                cmd.Parameters.AddWithValue("@legajo", p.Legajo);
                cmd.Parameters.AddWithValue("@id_plan", p.IdPlan);

                switch(p.TipoPersona)
                {
                    case Persona.TiposPersonas.Administrador: cmd.Parameters.AddWithValue("@tipo", 0);
                        break;
                    case Persona.TiposPersonas.Alumno: cmd.Parameters.AddWithValue("@tipo", 1);
                        break;
                    case Persona.TiposPersonas.Profesor: cmd.Parameters.AddWithValue("@tipo", 2);
                        break;
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona p)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PersonaInsert";
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@fecha_nac", p.FechaNacimiento);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@email", p.Email);
                cmd.Parameters.AddWithValue("@id_plan", p.IdPlan);
                cmd.Parameters.AddWithValue("@legajo", p.Legajo);

                switch (p.TipoPersona)
                {
                    case Persona.TiposPersonas.Administrador: cmd.Parameters.AddWithValue("@tipo", 0);
                        break;
                    case Persona.TiposPersonas.Alumno: cmd.Parameters.AddWithValue("@tipo", 1);
                        break;
                    case Persona.TiposPersonas.Profesor: cmd.Parameters.AddWithValue("@tipo", 2);
                        break;
                }

                p.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
