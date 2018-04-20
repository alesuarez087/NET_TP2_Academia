using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        public ModuloAdapter ModuloData
        {
            get;
            set;
        }

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public Modulo GetOne(int IdModulo)
        {
            return ModuloData.GetOne(IdModulo);
        }

    }
}
