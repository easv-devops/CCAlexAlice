namespace CurrencyConverter;

public class ConversionService

{
    private readonly Dictionary<string, decimal> _rates;

    public ConversionService()
    {
        _rates = new Dictionary<string, decimal>
        {
            {"USD", 1m},   // 1 USD is equivalent to 1 USD
            {"EUR", 0.93m}, // 1 USD is equivalent to 0.93 EUR
            {"GBP", 0.76m}, // 1 USD is equivalent to 0.76 GBP
            {"JPY", 130.53m}, // 1 USD is equivalent to 130.53 JPY
            {"AUD", 1.31m}  // 1 USD is equivalent to 1.31 AUD
        };
    }

    public decimal ConvertCurrency(decimal value, string source, string target)
    {
        if (!_rates.ContainsKey(source) || !_rates.ContainsKey(target))
        {
            throw new InvalidOperationException("Unsupported currency.");
        }

        if (source == target)
        {
            return value;
        }
        decimal rateFrom = _rates[source];
        decimal rateTo = _rates[target];
        
        decimal convertedValue = (value / rateFrom) * rateTo;
        return convertedValue;
    }
}

