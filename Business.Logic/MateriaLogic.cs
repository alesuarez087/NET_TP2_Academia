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
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData
        {
            get; set;
        }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public DataTable GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }

        public List<Materia> GetAllForPlan(int IdPlan)
        {
            return MateriaData.GetAllForPlan(IdPlan);
        }
    }
}
