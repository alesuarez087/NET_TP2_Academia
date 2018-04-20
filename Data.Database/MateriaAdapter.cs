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
    public class MateriaAdapter : Adapter
    {
        public DataTable GetAll()
        {
            DataTable materias = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("MateriaGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drMaterias = cmd.ExecuteReader();
                materias.Load(drMaterias);
                drMaterias.Close();
                return materias;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public List<Materia> GetAllForPlan(int IdPlan)
        {
            List<Materia> retorno = new List<Materia>();
            Materia row;
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("MateriasGetAllForPlan", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_plan", IdPlan);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    row = new Materia();
                    row.ID = (int)dr["id_materia"];
                    row.Descripcion = (string)dr["desc_materia"];
                    retorno.Add(row);
                }
                dr.Close();
                return retorno;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperara", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("MateriaGetOne", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader drMateria = cmd.ExecuteReader();
                if (drMateria.Read())
                {
                    mat.ID = (int)drMateria["id_materia"];
                    mat.Descripcion = (string)drMateria["desc_materia"];
                    mat.HSSemanales = (int)drMateria["hs_semanales"];
                    mat.HSTotales = (int)drMateria["hs_totales"];
                    mat.IdPlan = (int)drMateria["id_plan"];
                }
                drMateria.Close();
                return mat;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
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
                SqlCommand cmd = new SqlCommand("MateriaDelete", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            else if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }

        public void Update(Materia mat)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("MateriaUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_materia", mat.ID);
                cmd.Parameters.AddWithValue("@desc_materia", mat.Descripcion);
                cmd.Parameters.AddWithValue("@hs_semanales", mat.HSSemanales);
                cmd.Parameters.AddWithValue("@hs_totales", mat.HSTotales);
                cmd.Parameters.AddWithValue("@id_plan", mat.IdPlan);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia mat)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("MateriaInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc_materia", mat.Descripcion);
                cmd.Parameters.AddWithValue("@hs_semanales", mat.HSSemanales);
                cmd.Parameters.AddWithValue("@hs_totales", mat.HSTotales);
                cmd.Parameters.AddWithValue("@id_plan", mat.IdPlan);
                mat.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ingresar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
