using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        public ModuloUsuarioAdapter ModUsuData
        {
            get;
            set;
        }

        public ModuloUsuarioLogic()
        {
            ModUsuData = new ModuloUsuarioAdapter();
        }

        public List<ModuloUsuario> GetAll(int IdUsuario)
        {
            return ModUsuData.GetAll(IdUsuario);
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModUsuData.GetAll();
        }

        public List<ModuloUsuario> GetPermisos(int IdUsuario)
        {
            return ModUsuData.GetPermisos(IdUsuario);
        }

        public ModuloUsuario GetOne(int IdModUsu)
        {
            return ModUsuData.GetOne(IdModUsu);
        }

        public void Save(ModuloUsuario mu)
        {
            ModUsuData.Save(mu);
        }

    }
}
