using Dapper;
using MySqlConnector;

namespace CurrencyConverter;

public class DatabaseService
{
    private MySqlConnection GetConnection()
    {
        var connection = new MySqlConnection("Server=mariadb;Database=conversion_history;Uid=myuser;Pwd=mypassword;");
        connection.Open();
        return connection;
    }

    public History SaveConversion(DateOnly date, string source, string target, float value, float result)
    {
        using var connection = GetConnection();
        using var transaction = connection.BeginTransaction();
        string sql = $@"INSERT INTO conversion_history.history(date, source, target, value, result) VALUES (@date, @source,@target,@value,@result)";

        return connection.QueryFirst<History>(sql, new { date, source, target, value, result });
      
       
    }
}