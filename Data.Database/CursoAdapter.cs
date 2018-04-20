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
    public class CursoAdapter : Adapter
    {
        public DataTable GetAll()
        {
            DataTable cursos = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("CursosGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drCursos = cmd.ExecuteReader();
                cursos.Load(drCursos);
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public DataTable GetAllComisiones(int IdMateria)
        {
            DataTable cursos = new DataTable();
            this.OpenConnection();
            
            try
            {
                SqlCommand cmd = new SqlCommand("CursosGetAllComisiones", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_materia", IdMateria);
                SqlDataReader drCursos = cmd.ExecuteReader();
                cursos.Load(drCursos);
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public DataTable GetAll(int IdPersona)
        {
            DataTable table = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllDocenteComision", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_persona", IdPersona);
                SqlDataReader drGetAll = cmd.ExecuteReader();
                table.Load(drGetAll);
                drGetAll.Close();
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las comisiones", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return table;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("CursosGetOne", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader drCursos = cmd.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (String)drCursos["desc_comision"];
                }
                drCursos.Close();
                return cur;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar dato del curso", Ex);
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
            SqlCommand cmd = new SqlCommand("CursoDelete", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        public void Save(Curso cur)
        {
            if (cur.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cur.ID);
            }
            if (cur.State == BusinessEntity.States.Modified)
            {
                this.Update(cur);
            }
            if (cur.State == BusinessEntity.States.New)
            {
                this.Insert(cur);
            }
            cur.State = BusinessEntity.States.Unmodified;
        }








        public void Update(Curso cur)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("CursoUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", cur.ID);
                cmd.Parameters.AddWithValue("@id_materia", cur.IdMateria);
                cmd.Parameters.AddWithValue("@id_comision", cur.IdComision);
                cmd.Parameters.AddWithValue("@anio_calendario", cur.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", cur.Cupo);
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar dato del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Insert(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("CursoInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_materia", cur.IdMateria);
                cmd.Parameters.AddWithValue("@id_comision", cur.IdComision);
                cmd.Parameters.AddWithValue("@anio_calendario", cur.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", cur.Cupo);
                cur.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
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
