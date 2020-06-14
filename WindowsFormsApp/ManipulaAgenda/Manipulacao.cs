using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.EntitiesAgenda;

namespace WindowsFormsApp.ManipulaAgenda
{
    public class Manipulacao
    {

        public static List<Pessoa> SelecionarRegistros()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Conexao.Conectar();
            command.CommandText = "SELECT * FROM Agenda";
            SqlDataReader linhasRegistros = command.ExecuteReader();

            List<Pessoa> Pessoas = new List<Pessoa>();
            Pessoa pessoa;

            while (linhasRegistros.Read())
            {
                var nome = linhasRegistros[1].ToString();
                var endereco = linhasRegistros[2].ToString();
                var telefone = linhasRegistros[3].ToString();
                var email = linhasRegistros[4].ToString();

                pessoa = new Pessoa(nome, endereco, telefone, email);
                Pessoas.Add(pessoa);
            }

            return Pessoas;
        }

        public static void InserirRegistro(string nome, string endereco, string telefone, string email)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Conexao.Conectar();
            command.CommandText = $"INSERT Agenda values (@nome, @endereco, @telefone, @email)";


            command.Parameters.AddWithValue("@nome", nome);
            command.Parameters.AddWithValue("@endereco", endereco);
            command.Parameters.AddWithValue("@telefone", telefone);
            command.Parameters.AddWithValue("@email", email);


            command.ExecuteNonQuery();
        }

        public static void AtualizarRegistro(string nome, string endereco, string telefone, string email, string nomeOrignal)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Conexao.Conectar();
            command.CommandText = $"UPDATE Agenda SET nome = @nome, " +
                                                     "endereco = @endereco, "+ 
                                                     "telefone = @telefone, "+
                                                     "email = @email " + 
                                            "WHERE nome = @nomeOriginal";
                                                  

            command.Parameters.AddWithValue("@nome", nome);
            command.Parameters.AddWithValue("@endereco", endereco);
            command.Parameters.AddWithValue("@telefone", telefone);
            command.Parameters.AddWithValue("@email", email);

            command.Parameters.AddWithValue("@nomeOriginal", nomeOrignal);

            command.ExecuteNonQuery();
        }

        public static void ExcluirRegistro(string nomeOriginal)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Conexao.Conectar();

            command.CommandText = "DELETE FROM Agenda " +
                                          "WHERE nome = @nomeOriginal";

            command.Parameters.AddWithValue("@nomeOriginal", nomeOriginal);
            command.ExecuteNonQuery();
        }


    }
}
