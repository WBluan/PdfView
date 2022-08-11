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
        private SqlConnection Conectar()
        {
            string strConexao = @"Data Source=DESKTOP-NO90F78\SQLEXPRESS;Initial Catalog=teste;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(strConexao);

            sqlCon.Open();

            return sqlCon;
   }

        public SqlDataReader Consulta(string cons)
        {
            SqlDataReader dtDados;
            SqlConnection con1 = Conectar();
            SqlCommand comando = new SqlCommand(cons, con1);
            dtDados = comando.ExecuteReader();

            return dtDados;
        }
        public String InserirDados(String comandoInsercao)
        {
            SqlConnection con1 = Conectar();
            SqlCommand insere = new SqlCommand(comandoInsercao, con1);
            insere.ExecuteNonQuery();

            return "Inserido com sucesso";
        }

    }
}
