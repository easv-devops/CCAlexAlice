using Dapper;
using MySqlConnector;

namespace CurrencyConverter;

public class DatabaseService
{
    private static MySqlConnection GetConnection()
    {
        string connectionString = Utilities.GetConnectionString();
        var connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }

    public static History SaveConversion(string source, string target, float value, float result)
    {
        DateTime date = DateTime.Today;
        using var connection = GetConnection();
       
        string sql = $@"INSERT INTO conversion_history.history(date, source,target, value, result) VALUES (@date, @source,@target,@value,@result)";

        return connection.QueryFirstOrDefault<History>(sql, new {date,source, target, value, result });
      
       
    }
}