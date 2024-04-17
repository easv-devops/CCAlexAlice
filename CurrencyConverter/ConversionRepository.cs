using Dapper;
using MySqlConnector;

namespace CurrencyConverter;

public class ConversionRepository:IConversionRepository
{
  
    
    private static MySqlConnection GetConnection()
    {
        string connectionString = Utilities.GetConnectionString();
        var connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }

    public History SaveConversion(string source, string target, float value, float result)
    {
        DateTime date = DateTime.Today;
        using var connection = GetConnection();
       
        string sql = $@"INSERT INTO conversion_history.history(date, source,target, value, result) VALUES (@date, @source,@target,@value,@result)";

        return connection.QueryFirstOrDefault<History>(sql, new {date,source, target, value, result });
      
       
    }

    public IEnumerable<History> GetConversionHistory()
    {
        string sql = $@"
SELECT 
  date as {nameof(History.ConversionDate)},
       source as {nameof(History.Source)},
    target as {nameof(History.Target)},
    value as {nameof(History.Value)},
      result as {nameof(History.Result)}

FROM conversion_history.history;
";
        using var connection = GetConnection();
            return connection.Query<History>(sql);
        
    }
}