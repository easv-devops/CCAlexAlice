using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter;

public class ConversionController:ControllerBase
{
    private readonly DatabaseService _dbService;
    private readonly ConversionService _conversionService;

    public ConversionController(DatabaseService dbService, ConversionService conversionService)
    {
        _dbService = dbService;
        _conversionService = conversionService;

    }
    [HttpPost]
    [Route("/api/conversion")]
    public IActionResult Post([FromBody] ConversionDto dto)
    {
        try
        {
            decimal value = (decimal)dto.Value;
            decimal convertedResult = _conversionService.ConvertCurrency(value, dto.Source, dto.Target);
            float convertedResultFloat = Convert.ToSingle(convertedResult);
            var history = _dbService.SaveConversion(dto.Source, dto.Target, dto.Value, convertedResultFloat);
            return Created("/api/conversion", history);
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