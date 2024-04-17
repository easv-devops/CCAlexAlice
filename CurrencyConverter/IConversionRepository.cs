namespace CurrencyConverter;

public interface IConversionRepository
{
    History SaveConversion(string source, string target, float value, float result);
    IEnumerable<History> GetConversionHistory();
}