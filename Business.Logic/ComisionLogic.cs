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
    public class ComisionLogic : BusinessLogic
    {
        public ComisionAdapter ComisionData
        {
            get; set;
        }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public DataTable GetAll()
        {
            return ComisionData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }


        public void Save(Business.Entities.Comision com)
        {
            ComisionData.Save(com);
        }
    }
}
