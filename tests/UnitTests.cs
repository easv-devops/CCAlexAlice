using System.Net.Http.Json;
using Dapper;
using FluentAssertions;
using MySqlConnector;
using Newtonsoft.Json;
using NUnit.Framework;
using tests.model;

namespace tests;

public class UnitTests
{


    [TestCase(1, "2024-04-09", "USD", "USD", 1, 1)]
    public async Task ConversionCanSuccessfullyBeCreatedFromHttpRequest(int id, DateTime date, string source,
        string target, float value, float result)
    {
        //ARRANGE
        Helper.TriggerRebuild();

        var testConversion = new History()
        {
            Id = id, ConversionDate = date, Source = source, Target = target, Value = value,
            Result = result
        };

        Console.WriteLine("test " + testConversion);
        //ACT
        var httpResponse = await new HttpClient().PostAsJsonAsync(Helper.ApiBaseUrl + "/conversion", testConversion);
        Console.WriteLine("response " + httpResponse);
        var historyFromResponseBody =
            JsonConvert.DeserializeObject<History>(await httpResponse.Content.ReadAsStringAsync());

        Console.WriteLine("history " + historyFromResponseBody);
        //ASSERT

        await using var conn = new MySqlConnection(Helper.GetConnectionString());
        conn.Open();

        var resultFromDB = await conn.QueryFirstOrDefaultAsync<History>(
            @"SELECT id as Id, date as ConversionDate, source as Source, target as Target, value as Value, result as Result 
                  FROM conversion_history.history",
            testConversion);

        resultFromDB.Should().NotBeNull(); 
        resultFromDB.Should().BeEquivalentTo(testConversion);

    }
    
    [Test]
    [TestCase(1, "2024-04-09", "USD", "USD", 2, 2)]
    public  async Task GetConversionHistoryReturnsCorrectHistory(int id, DateTime date, string source, string target, float value, float result)
    {
        //ARRANGE
        Helper.TriggerRebuild();

        var testConversion = new History()
        {
          
            ConversionDate = date,
            Source = source,
            Target = target,
            Value = value,
            Result = result
        };

        await using var conn = new MySqlConnection(Helper.GetConnectionString());
        conn.Open();
    
        string insertSql = @"INSERT INTO conversion_history.history (date, source, target, value, result) 
                         VALUES (@Date, @Source, @Target, @Value, @Result)";
        conn.Execute(insertSql, new { Date = date, Source = source, Target = target, Value = value, Result = result });

        //ACT
    
        var httpResponse = await new HttpClient().GetAsync(Helper.ApiBaseUrl + "/history");
        var historyFromResponseBody = await httpResponse.Content.ReadFromJsonAsync<List<History>>();

        //ASSERT
        historyFromResponseBody.Should().NotBeNull();
        historyFromResponseBody.Should().ContainEquivalentOf(testConversion);
        
        
        
        

        
        
        
    }
        
    
    
}