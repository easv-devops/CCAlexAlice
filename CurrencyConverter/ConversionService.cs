using Monitoring;

namespace CurrencyConverter;

public class ConversionService

{
    private readonly IConversionRepository _repo;
    private readonly Dictionary<string, decimal> _rates;

    public IConversionRepository ConversionRepository => _repo;

    public ConversionService(IConversionRepository repo)
    {
        _repo = repo;

        _rates = new Dictionary<string, decimal>
        {
            { "USD", 1m }, // 1 USD is equivalent to 1 USD
            { "EUR", 0.93m }, // 1 USD is equivalent to 0.93 EUR
            { "GBP", 0.76m }, // 1 USD is equivalent to 0.76 GBP
            { "JPY", 130.53m }, // 1 USD is equivalent to 130.53 JPY
            { "AUD", 1.31m } // 1 USD is equivalent to 1.31 AUD
        };
    }

    public IEnumerable<History> GetHistory()
    {
        return _repo.GetConversionHistory();
    }

    public History SaveConversion(string source, string target, float value, float convertedResultFloat)
    {
        using (var activity = MonitorService.ActivitySource.StartActivity())

        {
            MonitorService.Log.Debug("Entered Method SaveConversion");
            return _repo.SaveConversion(source, target, value, convertedResultFloat);
        }
    }





public decimal ConvertCurrency(decimal value, string source, string target)
    {
        using (var activity = MonitorService.ActivitySource.StartActivity())

        {
            MonitorService.Log.Debug("Entered Method ConvertCurrency");
            if (!_rates.ContainsKey(source) || !_rates.ContainsKey(target))
            {
                MonitorService.Log.Error("Error: unsupported currency");
                throw new InvalidOperationException("Unsupported currency.");
            }

            if (source == target)
            {
                return value;
            }

            decimal rateFrom = _rates[source];
            decimal rateTo = _rates[target];

            decimal convertedValue = (value / rateFrom) * rateTo;
            MonitorService.Log.Information("value has been converted");
            return convertedValue;
        }
    }
}

