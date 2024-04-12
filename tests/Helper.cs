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

    
    public static string GetConnectionString()
    {
        return ConnectionString;
    }
}