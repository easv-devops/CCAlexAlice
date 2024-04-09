using Dapper;
using MySqlConnector;

namespace tests;

public class Helper
{
    public static readonly string ApiBaseUrl = "http://localhost:5000/api";
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("sqlconn")!;


    static Helper()
    {
        if (string.IsNullOrEmpty(ConnectionString))
        {
            throw new Exception($@"The conn string sqlconn is empty.");
        }
    }


    public static void TriggerRebuild()
    {
        using var connection = new MySqlConnection("Server=localhost;Database=conversion_history;Uid=myuser;Pwd=mypassword;");
        connection.Open();
        try
        {
            connection.Execute("DROP TABLE IF EXISTS conversion_history.history;");
                
            connection.Execute(@"
                
                CREATE TABLE conversion_history.history (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    date DATE DEFAULT CURRENT_DATE() NOT NULL,
                    source TEXT NOT NULL,
                    target TEXT NOT NULL,
                    value FLOAT NOT NULL,
                    result FLOAT NOT NULL
                );");
        }
        catch (Exception e)
        {
            throw new Exception($"There was an error rebuilding the database.", e);
        }
    }

    public static string GetConnectionString()
    {
        return ConnectionString;
    }
}