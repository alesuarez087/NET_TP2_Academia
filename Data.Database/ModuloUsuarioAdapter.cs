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
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll(int IdUsuario)
        {
            List<ModuloUsuario> lista = new List<ModuloUsuario>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("ModuloUsuarioGetAll", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdUsuario);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = dr.IsDBNull(2) ? modusu.ID = 0 : (int)dr["id_modulo_usuario"];
                    modusu.IdUsuario = dr.IsDBNull(7) ? modusu.IdUsuario = IdUsuario : (int)dr["id_usuario"];
                    modusu.PermiteAlta = dr.IsDBNull(3) ? modusu.PermiteAlta = false : (bool)dr["alta"];
                    modusu.PermiteBaja = dr.IsDBNull(4) ? modusu.PermiteBaja = false : (bool)dr["baja"];
                    modusu.PermiteModificacion = dr.IsDBNull(5) ? modusu.PermiteModificacion = false : (bool)dr["modificacion"];
                    modusu.PermiteConsulta = dr.IsDBNull(6) ? modusu.PermiteConsulta = false : (bool)dr["consulta"];
                    modusu.IdModulo = (int)dr["id_modulo"];
                    modusu.DescripcionModulo = (string)dr["desc_modulo"];
                    lista.Add(modusu);
                }
                return lista;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los módulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> lista = new List<ModuloUsuario>();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("ModuloGetAll", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.PermiteAlta = 
                    modusu.PermiteBaja = 
                    modusu.PermiteModificacion = 
                    modusu.PermiteConsulta = false;
                    modusu.IdModulo = (int)dr["id_modulo"];
                    modusu.DescripcionModulo = (string)dr["desc_modulo"];
                    lista.Add(modusu);
                }
                return lista;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los módulos", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<ModuloUsuario> GetPermisos(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("ModuloUsuarioGetPermisos", sqlConn);
                cmdGetAll.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGetAll.Parameters.AddWithValue("@id", idUsuario);
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modusu.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los permisos.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modusu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("ModuloUsuarioGetOne", sqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
                cmdGetOne.Parameters.AddWithValue("@id", ID);
                SqlDataReader drModulosUsuarios = cmdGetOne.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modusu.IdModulo = (int)drModulosUsuarios["id_modulo"];
                }
                drModulosUsuarios.Close();
                return modusu;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Modulo Usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("ModuloUsuarioUpdate", sqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

                cmdUpdate.Parameters.AddWithValue("@id", modusu.ID);
                cmdUpdate.Parameters.AddWithValue("@id_modulo", modusu.IdModulo);
                cmdUpdate.Parameters.AddWithValue("@id_usuario", modusu.IdUsuario);
                cmdUpdate.Parameters.AddWithValue("@alta", modusu.PermiteAlta);
                cmdUpdate.Parameters.AddWithValue("@baja", modusu.PermiteBaja);
                cmdUpdate.Parameters.AddWithValue("@modificacion", modusu.PermiteModificacion);
                cmdUpdate.Parameters.AddWithValue("@consulta", modusu.PermiteConsulta);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("ModuloUsuarioInsert", sqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

                cmdInsert.Parameters.AddWithValue("@id_modulo", modusu.IdModulo);
                cmdInsert.Parameters.AddWithValue("@id_usuario", modusu.IdUsuario);
                cmdInsert.Parameters.AddWithValue("@alta", modusu.PermiteAlta);
                cmdInsert.Parameters.AddWithValue("@baja", modusu.PermiteBaja);
                cmdInsert.Parameters.AddWithValue("@modificacion", modusu.PermiteModificacion);
                cmdInsert.Parameters.AddWithValue("@consulta", modusu.PermiteConsulta);
                modusu.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una permiso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("ModulosUsuariosDelete", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.AddWithValue("@id", ID);
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el permiso", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modusu)
        {
            if (modusu.State == BusinessEntity.States.New)
            {
                this.Insert(modusu);
            }
            else if (modusu.State == BusinessEntity.States.Modified)
            {
                this.Update(modusu);
            }
            else if(modusu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modusu.ID);
            }
            modusu.State = BusinessEntity.States.Unmodified;
        }
    }
}
