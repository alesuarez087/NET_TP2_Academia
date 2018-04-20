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
    public class InscripcionAdapter : Adapter
    {
        public DataTable GetAll(int IdAlumno)
        {
            this.OpenConnection();
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnosInscripcionesGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_persona", IdAlumno);
                SqlDataReader drInscripciones = cmd.ExecuteReader();
                table.Load(drInscripciones);
                drInscripciones.Close();
                return table;
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error a recuperar las inscripciones", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetAllComision(int IdCurso)
        {
            this.OpenConnection();
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnosInscripcionesGetAllComisiones", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", IdCurso);
                SqlDataReader drInscripciones = cmd.ExecuteReader();
                table.Load(drInscripciones);
                drInscripciones.Close();
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error a recuperar las inscripciones", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return table;
        }

        public AlumnoInscripcion GetOne(int IdInscripcion)
        {
            this.OpenConnection();
            AlumnoInscripcion alIn = new AlumnoInscripcion();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnosInscripcionesGetOne", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdInscripcion);
                SqlDataReader drInscripcion = cmd.ExecuteReader();
                while (drInscripcion.Read())
                {
                    alIn.ID = (int)drInscripcion["id_inscripcion"];
                    alIn.IdAlumno = (int)drInscripcion["id_alumno"];
                    alIn.IdCurso = (int)drInscripcion["id_curso"];
                    alIn.Condicion = (string)drInscripcion["condicion"];
                }
                drInscripcion.Close();
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la Inscripción", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alIn;
        }

        public List<Materia> GetMaterias(int IdPlan)
        {
            List<Materia> listado = new List<Materia>();
            Materia materia; int i = 0;
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("InscripcionesGetAllMaterias", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_plan", IdPlan);
                cmd.Parameters.AddWithValue("@anio_calendario", DateTime.Today.Year);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    materia = new Materia();
                    materia.ID = i;
                    materia.Descripcion = (string)dr["desc_materia"];
                    listado.Add(materia);
                    i++;
                }
                dr.Close();
                return listado;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error a recuperar las Materias", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetAllInscripciones(Persona alumno)
        {
            DataTable tabla = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("InscripcionesGetAll", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_alumno", alumno.ID);
                cmd.Parameters.AddWithValue("@id_plan", alumno.IdPlan);
                cmd.Parameters.AddWithValue("@anio", DateTime.Today.Year);
                SqlDataReader dr = cmd.ExecuteReader();
                tabla.Load(dr);
                dr.Close();
                return tabla;
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

        public DataTable GetAllInscripcionesForAlumno(Persona alumno)
        {
            DataTable tabla = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("InscripcionesGetAllForAlumno", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_alumno", alumno.ID);
                cmd.Parameters.AddWithValue("@id_plan", alumno.IdPlan);
                SqlDataReader dr = cmd.ExecuteReader();
                tabla.Load(dr);
                dr.Close();
                return tabla;
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

        public DataTable GetMateriaCursos(int idMateria)
        {
            DataTable tabla = new DataTable();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("InscripcionesGetAllMateriaCursos", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_materia", idMateria);
                cmd.Parameters.AddWithValue("@anio_calendario", DateTime.Today.Year);
                SqlDataReader dr = cmd.ExecuteReader();
                tabla.Load(dr);
                dr.Close();
                return tabla;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las comisiones", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int IdInscripcion)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnosInscripcionesDelete", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdInscripcion);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la Inscripción", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void GuardarCambios(AlumnoInscripcion aluIns)
        {
            if (aluIns.State == BusinessEntity.States.New)
            {
                this.Insert(aluIns);
            }
            if (aluIns.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluIns.ID);
            }
            if (aluIns.State == BusinessEntity.States.Modified)
            {
                this.Update(aluIns);
            }
            aluIns.State = BusinessEntity.States.Unmodified;
        }



        private void Insert(AlumnoInscripcion aluIns)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnosInscripcionesInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", aluIns.IdCurso);
                cmd.Parameters.AddWithValue("@id_alumno", aluIns.IdAlumno);
                cmd.Parameters.AddWithValue("@condicion", aluIns.Condicion);
                aluIns.ID = Convert.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar la Inscripción", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Update(AlumnoInscripcion aluIns)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("AlumnoInscripcionUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", aluIns.ID);
                cmd.Parameters.AddWithValue("@nota", aluIns.Nota);
                cmd.Parameters.AddWithValue("@condicion", aluIns.Condicion);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la nota", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    
    }
}
