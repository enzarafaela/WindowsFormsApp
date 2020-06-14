using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp.ManipulaAgenda
{
    class Conexao
    {
        public static SqlConnection Conectar() {
            string conexao = @"Data Source=DESKTOP-GLFFKF4\SQLEXPRESS;Initial Catalog=windowsFormsPOO;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conexao); // objeto conexão
            connection.Open(); // abre conexao no objeto criado
            return connection; // retorna objeto com conexao aberta
        }

    }
   
}
