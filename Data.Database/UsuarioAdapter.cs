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
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            this.OpenConnection();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioGetAll", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Clave = (string)dr["clave"];
                    usr.Email = (string)dr["email"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IdPersona = (int)dr["id_persona"];
                    lista.Add(usr);
                }
                return lista;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Usuario> Buscador(string texto)
        {
            this.OpenConnection();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioBuscador", sqlConn);
                cmd.Parameters.AddWithValue("@texto", texto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Clave = (string)dr["clave"];
                    usr.Email = (string)dr["email"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IdPersona = (int)dr["id_persona"];
                    lista.Add(usr);
                }
                return lista;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioGetOne", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Clave = (string)dr["clave"];
                    usr.Email = (string)dr["email"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IdPersona = (int)dr["id_persona"];
                }
                return usr;
            }
            catch(Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuparar el Usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }       

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Usuario usuario)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioUpdate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", usuario.ID);
                cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.ExecuteNonQuery();
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

        protected void Insert(Usuario usuario)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioInsert", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.Parameters.AddWithValue("@id_persona", usuario.IdPersona);
                usuario.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
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
                SqlCommand cmd = new SqlCommand("UsuarioDelete", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Usuario GetUsuarioForLogin(string usuario, string contrasenia)
        {
            Usuario u = new Usuario();
            this.OpenConnection();
            try
            {
                SqlCommand cmdUsuarios = new SqlCommand("UsuarioGetOneUsrPass", sqlConn);
                cmdUsuarios.CommandType = CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@user", usuario);
                cmdUsuarios.Parameters.AddWithValue("@pass", contrasenia);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    u.Apellido = (string)drUsuarios["apellido"];
                    u.Clave = (string)drUsuarios["clave"];
                    u.Email = (string)drUsuarios["email"];
                    u.Habilitado = (bool)drUsuarios["habilitado"];
                    u.ID = (int)drUsuarios["id_usuario"];
                    u.Nombre = (string)drUsuarios["nombre"];
                    u.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    u.IdPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("No se pudo recuperar el Usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return u;
        }


        public Usuario GetOneForPersona(int IdPersona)
        {
            Usuario usr = new Usuario();
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("UsuarioGetOneForPersona", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdPersona);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Clave = (string)dr["clave"];
                    usr.Email = (string)dr["email"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IdPersona = (int)dr["id_persona"];
                }
                return usr;
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuparar el Usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
