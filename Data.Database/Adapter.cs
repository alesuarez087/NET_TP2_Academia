using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //Clave por defecto a utilizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";
        SqlConnection _sqlConn;
       

        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }




        protected void OpenConnection()
        {
          string conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
          //Recupero el string de la conexion
          sqlConn = new SqlConnection(conn);
          sqlConn.Open();
        
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }



    }
}
