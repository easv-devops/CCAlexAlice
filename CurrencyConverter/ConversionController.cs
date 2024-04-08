using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter;

public class ConversionController:ControllerBase
{
    private readonly DatabaseService _dbService;

    public ConversionController(DatabaseService dbService)
    {
        _dbService = dbService;

    }
    [HttpPost]
    [Route("/api/conversion")]
    public IActionResult  Post([FromBody] ConversionDto dto)
    {
        try
        {
            var history = _dbService.SaveConversion(dto.Source, dto.Target, dto.Value, dto.Result);
            return Ok(history);
        }
        catch(Exception e)
        { 
            Console.WriteLine($"An error occurred while saving the conversion: {e.Message}");
            return StatusCode(500, "An error occurred while saving the conversion.");
        }
    }
    
    
    [HttpGet]
    [Route("/api/history")]
    public IEnumerable<History> GetConversionHistory()
    {
        return _dbService.GetConversionHistory();
    }
}