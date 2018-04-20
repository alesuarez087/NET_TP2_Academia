using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("EspecialidadGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drEspecialidades = cmd.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(esp);
                }
                drEspecialidades.Close();
                return especialidades;
            }
            catch (Exception Ex)
            {
                Exception ExcecionManejada = new Exception("Error al recuperar la lista de Carreras", Ex);
                throw ExcecionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            this.OpenConnection();
            try
            {
                SqlCommand cmdEspecialidades = new SqlCommand("EspecialidadesGetOne", sqlConn);
                cmdEspecialidades.CommandType = CommandType.StoredProcedure;
                cmdEspecialidades.Parameters.AddWithValue("@id", ID);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
                return esp;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Carrera", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }


        // METODO SAVE


        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("EspecialidadUpdate", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;
                cmdSave.Parameters.AddWithValue("@id", especialidad.ID);
                cmdSave.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Insert(Especialidad especialidad)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmdSave = new SqlCommand("EspecialidadesInsert", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;
                cmdSave.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la Carrera", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(Especialidad e)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmdEspecialidades = new SqlCommand("EspecialidadesDelete", sqlConn);
                cmdEspecialidades.CommandType = CommandType.StoredProcedure;
                cmdEspecialidades.Parameters.AddWithValue("@id", e.ID);
                cmdEspecialidades.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error ! Contactarse con Administrador", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
