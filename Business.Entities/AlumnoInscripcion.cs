using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private String _Condicion;
        private int _IdAlumno;
        private int _IdCurso;
        private int _Nota;

        public String Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public int IdAlumno
        {
            get { return _IdAlumno; }
            set { _IdAlumno = value; }
        }
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
