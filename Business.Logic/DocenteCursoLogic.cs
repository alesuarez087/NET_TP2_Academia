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
    public class DocenteCursoLogic : BusinessLogic
    {
        public DocenteCursoAdapter DocenteCursoData
        {
            get;
            set;
        }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public DataTable GetAll(int IdCurso)
        {
            return DocenteCursoData.GetAll(IdCurso);
        }

        public DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public void Save(DocenteCurso dc)
        {
            DocenteCursoData.Save(dc);
        }

        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }

    }
}
