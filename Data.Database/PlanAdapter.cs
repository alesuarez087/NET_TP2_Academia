using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll() // sp hecho
        {
            List<Plan> planes = new List<Plan>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PlanGetAllTabla", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drPlanes = cmd.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEespecialidad = (int)drPlanes["id_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
                return planes;
            }
            catch (Exception Ex)
            {
                Exception ExcecionManejada = new Exception("error", Ex);
                throw ExcecionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Plan> GetAll(int idEspecialidad) // sp hecho
        {
            List<Plan> planes = new List<Plan>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PlanGetAllForEspecialidad", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                SqlDataReader drPlanes = cmd.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEespecialidad = (int)drPlanes["id_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
                return planes;
            }
            catch (Exception Ex)
            {
                Exception ExcecionManejada = new Exception("error", Ex);
                throw ExcecionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetTable() // sphecho
        {
            DataTable planes = new DataTable("Planes");
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("PlanGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drPlanes = cmd.ExecuteReader();
                planes.Load(drPlanes);
                drPlanes.Close();
                return planes;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejado = new Exception("Error al mostrar los planes", Ex);
                throw ExcepcionManejado;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PlanGetOne", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader drPlan = cmd.ExecuteReader();
                while (drPlan.Read())
                {
                    plan.ID = (int)drPlan["id_plan"];
                    plan.IDEespecialidad = (int)drPlan["id_especialidad"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                }
                drPlan.Close();
                return plan;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Modified;
        }



        //Metodos  para el metodo Save()
        //-----------------------------

        private void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("PlanUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", plan.ID);
                cmd.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IDEespecialidad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Insert(Plan plan)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("PlanInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IDEespecialidad);
                plan.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan", Ex);
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
            SqlCommand cmd = new SqlCommand("PlanDelete", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

    }
}
