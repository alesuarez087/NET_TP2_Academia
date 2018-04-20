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
    public class InscripcionLogic: BusinessLogic
    {
        public InscripcionAdapter DataInscripcion
        {
            get;
            set;
        }

        public InscripcionLogic()
        {
            DataInscripcion = new InscripcionAdapter();
        }

        public DataTable GetAll(int IdAlumno)
        {
            return DataInscripcion.GetAll(IdAlumno);
        }

        public DataTable GetAllComisiones(int IdCurso)
        {
            return DataInscripcion.GetAllComision(IdCurso);
        }

        public AlumnoInscripcion GetOne(int IdInscripcion)
        {
            return DataInscripcion.GetOne(IdInscripcion);
        }

        public DataTable GetAllInscripciones(Persona alumno)
        {
            return DataInscripcion.GetAllInscripciones(alumno);
        }
        public DataTable GetAllInscripcionesForAlumno(Persona alumno)
        {
            return DataInscripcion.GetAllInscripcionesForAlumno(alumno);
        }
        public List<Materia> GetMaterias(int IdPlan)
        {
            return DataInscripcion.GetMaterias(IdPlan);
        }

        public DataTable GetMateriaCursos(int idMateria)
        {
            return DataInscripcion.GetMateriaCursos(idMateria);
        }

        public void GuardarCambios(AlumnoInscripcion aluIns)
        {
            this.DataInscripcion.GuardarCambios(aluIns);
        }
    }
}
