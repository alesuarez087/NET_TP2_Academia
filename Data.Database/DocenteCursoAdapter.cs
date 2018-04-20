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
    public class DocenteCursoAdapter : Adapter
    {
        public DataTable GetAll(int IdCurso)
        {
            DataTable docenteCurso = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("DocenteCursoGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCurso", IdCurso);
                SqlDataReader drDocenteCurso = cmd.ExecuteReader();
                docenteCurso.Load(drDocenteCurso);
                drDocenteCurso.Close();
                return docenteCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Docentes de Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso = new DocenteCurso();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("DocenteCursoGetOne", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader drDocenteCurso = cmd.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    docenteCurso.ID = (int)drDocenteCurso["id_dictado"];
                    docenteCurso.IDCurso = (int)drDocenteCurso["id_curso"];
                    docenteCurso.IDDocente = (int)drDocenteCurso["id_docente"];
                    switch ((int)drDocenteCurso["cargo"])
                    {
                        case 1: docenteCurso.TipoCargo = DocenteCurso.TiposCargos.Titular;
                            break;
                        case 2: docenteCurso.TipoCargo = DocenteCurso.TiposCargos.Auxiliar;
                            break;
                        case 3: docenteCurso.TipoCargo = DocenteCurso.TiposCargos.Ayudante;
                            break;
                    }
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar datos de Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCurso;
        }

        public void Delete(int ID)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("DocenteCursoDelete", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (ApplicationException e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Docente", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(DocenteCurso dc)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("DocenteCursoUpdate", sqlConn);
                int cargo = idCargo(dc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", dc.ID);
                cmd.Parameters.AddWithValue("@id_curso", dc.IDCurso);
                cmd.Parameters.AddWithValue("@id_docente", dc.IDDocente);
                cmd.Parameters.AddWithValue("@cargo", cargo);
                cmd.ExecuteNonQuery();
            }
            catch (ApplicationException e)
            {
                Exception ExcepcionManejada = new Exception("Error al Modificar el Docente al Curso", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted) this.Delete(dc.ID);
            else if (dc.State == BusinessEntity.States.Modified) this.Update(dc);
            else if (dc.State == BusinessEntity.States.New) this.Insert(dc);
            dc.State = BusinessEntity.States.Unmodified;
        }

        public void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DocenteCursoInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                int cargo = idCargo(dc);
                cmd.Parameters.AddWithValue("@id_curso", dc.IDCurso);
                cmd.Parameters.AddWithValue("@id_docente", dc.IDDocente);
                cmd.Parameters.AddWithValue("@cargo", cargo);
                dc.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (ApplicationException e)
            {
                Exception ExcepcionManejada = new Exception("No se pudo agregar el Docente al Curso", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        private int idCargo(DocenteCurso dc)
        {
            int cargo = 0;
            if (dc.TipoCargo == DocenteCurso.TiposCargos.Titular)
            {
                cargo = 1;
            }
            else
            {
                if (dc.TipoCargo == DocenteCurso.TiposCargos.Auxiliar)
                {
                    cargo = 2;
                }
                else
                {
                    cargo = 3;
                }
            }
            return cargo;
        }
    }
}
