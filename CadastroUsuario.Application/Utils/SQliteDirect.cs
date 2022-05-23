using CadastroUsuario.Domain.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace CadastroUsuario.Application.Utils
{
    public class SQliteDirect
    {
        private static SqliteConnection sqliteConnection;

        public SQliteDirect()
        { }

        private static SqliteConnection DbConnection()
        {
            sqliteConnection = new SqliteConnection("Data Source=C:\\Users\\joaob\\OneDrive\\Documentos\\BaseDeDados\\CadastroUsuarioProjeto.db");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void Update(string tableName, ParametrosDeAcessoEntity entity, string update)
        {
            try
            {
                using (var command = DbConnection().CreateCommand())
                {
                    if (entity.Id != Guid.Empty)
                    {
                        string campo = update.Substring(1);
                        string comando = $"entity{update}";

                        command.CommandText = $"UPDATE {tableName} SET {campo}=@Update WHERE Id=@Id";
                        command.Parameters.AddWithValue("@Id", entity.Id);
                        command.Parameters.AddWithValue("@Update", comando); //não executa o comando, salva a string no banco.
                        command.ExecuteNonQuery();
                    }
                };
            }
            catch
            {
                throw new Exception("Houve um erro ao tentar atualizar um registro na base de dados.");
            }
        }

        public string PreparaParametros(List<string> lista, string nomeCampo)
        {
            var result = string.Join(" and ", lista.Select(x => $"{nomeCampo} = {x}").ToList());

            return result;
        }
    }
}
