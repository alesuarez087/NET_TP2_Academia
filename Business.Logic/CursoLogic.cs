using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoAdapter CursoData
        {
            get; set;
        }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public DataTable GetAll()
        {
            return CursoData.GetAll();
        }

        public DataTable GetAll(int IdMateria)
        {
            return CursoData.GetAll(IdMateria);
        }

        public DataTable GetAllComisiones(int IdPersona)
        {
            return CursoData.GetAllComisiones(IdPersona);
        }

        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }


    }
}
