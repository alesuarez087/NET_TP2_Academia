using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaAdapter PersonaData
        {
            get;
            set;
        }
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return this.PersonaData.GetAll();
        }
        public List<Persona> GetAllAlumnos()
        {
            return this.PersonaData.GetAllAlumnos();
        }
        public List<Persona> BuscadorAlumno(string texto)
        {
            return this.PersonaData.Buscador(texto);
        }
        public List<Persona> BuscadorAlumno(int idLegajo)
        {
            return this.PersonaData.Buscador(idLegajo);
        }
        public Persona GetOne(int IdPersona)
        {
            return this.PersonaData.GetOne(IdPersona);
        }
        
        public void Save(Persona p)
        {
            this.PersonaData.Save(p);
        }
    }
}
