using MySql.Data.MySqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
            // String de conexão com o MySQL
            string connectionString = "Server=;uid=;Password=;database=";

        // Criar a conexão com o MySQL
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            // Abrir a conexão
            connection.Open();
            Console.WriteLine("Conexão aberta com sucesso.");
            // Criar um comando
            // string query = "UPDATE usuario SET login ='Adm' WHERE login ='adm';";
              string query = "Insert into usuario(idUsuario,login,senha)values(2,'adm1',23456);";
            MySqlCommand command = new MySqlCommand(query, connection);
            // Executar o comando e ler os dados
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Supondo que a tabela tem uma coluna chamada 'nome'
                    string login = reader.GetString("login");
                      string senha = reader.GetString("senha");
                    Console.WriteLine($"Login: {login} e Senha:{senha}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
              connection.Close();
                     System.Console.WriteLine("Fechando conexao");
        }
    }
}