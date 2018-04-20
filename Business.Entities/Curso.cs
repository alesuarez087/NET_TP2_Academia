using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private String _Descripcion;
        private int _IdComision;
        private int _IdMateria;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }
    }
}
