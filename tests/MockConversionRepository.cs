using CurrencyConverter;
using NUnit.Framework;

namespace tests;

 public class MockConversionRepository : IConversionRepository
 
 
    {
        private List<History> _conversionHistory = new List<History>();
        public History SaveConversion(string source, string target, float value, float result)
        {
            
            var conversion= new History
            {
                ConversionDate = DateTime.Today,
                Source = source,
                Target = target,
                Value = value,
                Result = result
            };
            
            _conversionHistory.Add(conversion);
            return conversion;
        }

        public List<History> GetSavedConversionHistory()
        {
            return _conversionHistory;
        }
        
        
        public IEnumerable<History> GetConversionHistory()
        {
            
            return new List<History>
            {
                new History
                {
                    ConversionDate = DateTime.Parse("2023-01-01"),
                    Source = "USD",
                    Target = "USD",
                    Value = 100,
                    Result = 100
                },
                new History
                {
                    ConversionDate = DateTime.Parse("2023-01-02"),
                    Source = "EUR",
                    Target = "GBP",
                    Value = 150,
                    Result = 125
                }
               
            };
        }
        
        
    
    }
