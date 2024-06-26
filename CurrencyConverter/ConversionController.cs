using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter;

public class ConversionController : ControllerBase
{
    private readonly ConversionService _conversionService;

    public ConversionController(ConversionService conversionService)
    {
        _conversionService = conversionService;
    }


    [HttpPost]
    [Route("/api/conversion")]
    public History Post([FromBody] ConversionDto dto)

    {
        if (dto.Source != null && dto.Target != null)
        {
            decimal convertedResult = _conversionService.ConvertCurrency((decimal)dto.Value, dto.Source, dto.Target);
            float convertedResultFloat = Convert.ToSingle(convertedResult);
            return _conversionService.SaveConversion(dto.Source, dto.Target, dto.Value, convertedResultFloat);
        }
        else
        {
            throw new ArgumentException("Source or target is null");
        }
    }


    [HttpGet]
    [Route("/api/history")]
    public IEnumerable<History> GetConversionHistory()
    {
        return _conversionService.GetHistory();
    }
}