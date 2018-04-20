using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> lista = new List<Modulo>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("ModuloGetAll", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Modulo m = new Modulo();
                    m.Descripcion = (string)dr["descripcion"];
                    m.Ejecuta = (string)dr["ejecuta"];
                    m.ID = (int)dr["id_modulo"];
                    lista.Add(m);
                }
                return lista;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los módulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        
        public Modulo GetOne(int IdModulo)
        {
            Modulo m = new Modulo();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("ModuloGetOne", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdModulo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    m.Descripcion = (string)dr["desc_modulo"];
                    m.Ejecuta = (string)dr["ejecuta"];
                    m.ID = (int)dr["id_modulo"];
                }
                return m;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el módulo", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
