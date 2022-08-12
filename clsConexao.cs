using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PdfView
{
     class clsConexao
    {
        private static string server  = @"DESKTOP-NO90F78\SQLEXPRESS";
        private static string dataBase = "teste";
        private static string user =@"DESKTOP-NO90F78\Due";



        public static string StrCon        
        {
          get
            {
             return "Data Source=" + server + ";Initial Catalog=" + dataBase + ";Integrated Security=True";
            }
        }
         

    }
}
