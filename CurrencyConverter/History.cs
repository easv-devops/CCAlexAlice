using System.Runtime.InteropServices.JavaScript;

namespace CurrencyConverter;

public class History
{
  public DateOnly ConversionDate { get; set; } 
  public string Source { get; set; }
  public string Target { get; set; }
  public float Value { get; set; }
  public float Result { get; set; }
}