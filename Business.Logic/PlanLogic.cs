using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanAdapter PlanData
        {
            get;set;
        }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return this.PlanData.GetAll();
        }

        public List<Plan> GetAll(int IdEspecialidad)
        {
            return this.PlanData.GetAll(IdEspecialidad);
        }

        public DataTable GetTabla()
        {
            return this.PlanData.GetTable();
        }

        public Plan GetOne(int IdPlan)
        {
            return this.PlanData.GetOne(IdPlan);
        }

        public void Save(Plan p)
        {
            this.PlanData.Save(p);
        }
    }
}
