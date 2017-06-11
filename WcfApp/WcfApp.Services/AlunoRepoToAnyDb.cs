using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfApp.Services
{
    public interface IAlunoRepoToAnyDb
    {
        string GetAlunos();
    }

    public class AlunoRepoToAnyDb : IAlunoRepoToAnyDb
    {
        private string _databaseServer;

        public AlunoRepoToAnyDb(string databaseServer)
        {
            _databaseServer = databaseServer;
        }

        public string GetAlunos()
        {
            using (SqlConnection conn = new SqlConnection(_databaseServer))
            {
                SqlCommand cmd = new SqlCommand("Select Name from Alunos", conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    string nomesDoAlunos = null;

                    while (reader.Read())
                        nomesDoAlunos += reader[0].ToString().Trim() + ", ";

                    return nomesDoAlunos ?? "Não foi encontrado nenhum aluno";
                }
            }
        }
    }
}
