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
    public History Post([FromBody] ConversionDto dto)
    {
        return _dbService.SaveConversion(dto.Source,dto.Target,dto.Value,dto.Result);
    }
}