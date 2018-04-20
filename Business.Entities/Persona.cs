using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        public enum TiposPersonas { Administrador, Alumno, Profesor } ;
        private String _Apellido;
        private String _Nombre;
        private String _Email;
        private DateTime _FechaNacimiento;
        private int _IdPlan;
        private int _Legajo;
        private String _Direccion;
        private String _Telefono;
        private TiposPersonas _TipoPersona;
        

        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }
        public TiposPersonas TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

    }
}
