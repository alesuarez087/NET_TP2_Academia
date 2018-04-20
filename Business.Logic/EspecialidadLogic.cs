using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadAdapter EspecialidadData
        {
            get;set;
        }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return this.EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int IdEspecialidad)
        {
            return this.EspecialidadData.GetOne(IdEspecialidad);
        }

        public void Save(Especialidad e)
        {
            this.EspecialidadData.Save(e);
        }

        public void Delete(Especialidad e)
        {
            this.EspecialidadData.Delete(e);
        }
    }
}
