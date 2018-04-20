using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public DataTable GetAll()
        {
            DataTable comisiones = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmdAll = new SqlCommand("ComisionGetAll", sqlConn);
                cmdAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drPlanes = cmdAll.ExecuteReader();
                comisiones.Load(drPlanes);
                drPlanes.Close();
                return comisiones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al mostrar las comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            this.OpenConnection();
            try
            {
                SqlCommand cmdComisiones = new SqlCommand("ComisionGetOne", sqlConn);
                cmdComisiones.CommandType = CommandType.StoredProcedure;
                cmdComisiones.Parameters.AddWithValue("@id", ID);
                SqlDataReader drComision = cmdComisiones.ExecuteReader();
                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IdPlan = (int)drComision["id_plan"];
                }
                drComision.Close();
                return com;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Delete(int ID)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmdDelete = new SqlCommand("ComisionDelete", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.AddWithValue("@id", ID);
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }







        public void Update(Comision com)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmdUpdate = new SqlCommand("ComisionUpdate", sqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.Parameters.AddWithValue("@id", com.ID);
                cmdUpdate.Parameters.AddWithValue("@desc_comision", com.Descripcion);
                cmdUpdate.Parameters.AddWithValue("@anio_especialidad", com.AnioEspecialidad);
                cmdUpdate.Parameters.AddWithValue("@id_plan", com.IdPlan);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision com)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmdInsert = new SqlCommand("ComisionInsert", sqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@descripcion", com.Descripcion);
                cmdInsert.Parameters.AddWithValue("@anio_especialidad", com.AnioEspecialidad);
                cmdInsert.Parameters.AddWithValue("@id_plan", com.IdPlan);
                com.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
