using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioAdapter UsuarioData
        {
            get;
            set;
        }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public void Save(Usuario u)
        {
            this.UsuarioData.Save(u);
        }

        public void Delete(int IdUsuario)
        {
            this.UsuarioData.Delete(IdUsuario);
        }

        public Usuario GetUsuarioForLogin(string nombreUsuario, string contrasena)
        {
            return this.UsuarioData.GetUsuarioForLogin(nombreUsuario, contrasena);
        }

        public Usuario GetOneForPersona(int IdPersona)
        {
            return this.UsuarioData.GetOneForPersona(IdPersona);
        }
        public List<Usuario> Buscador(string texto)
        {
            return this.UsuarioData.Buscador(texto);
        }
    }
}
