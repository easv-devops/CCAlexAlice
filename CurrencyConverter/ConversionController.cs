using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter;

public class ConversionController
{
    private readonly DatabaseService _dbService;
    [HttpPost]
    [Route("/api/conversion")]
    public History Post([FromBody] ConversionDto dto)
    {
        return _dbService.SaveConversion(dto.ConversionDate,dto.Source,dto.Target,dto.Value,dto.Result);
    }
}