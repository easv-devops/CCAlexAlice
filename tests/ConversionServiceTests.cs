
using CurrencyConverter;

using NUnit.Framework;


namespace tests;

    
    [TestFixture]
    public class ConversionServiceTests
    {
        private ConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            _conversionService = new ConversionService(new MockConversionRepository());
            
        }

        [Test]
        public void ConverterWithSameSourceAndTargetReturnsSameValue()
        {
            //Arrange
            decimal value = 100m;
            string source = "USD";
            string target = "USD";

            //Act
            decimal result = _conversionService.ConvertCurrency(value, source, target);

            //Assert
            Assert.AreEqual(value, result);
        }

        [Test]
        public void ConverterWithValidSourceAndTargetConvertsCorrectly()
        {
            //Arrange
            decimal value = 100m;
            string source = "USD";
            string target = "EUR";

            //Act
            decimal result = _conversionService.ConvertCurrency(value, source, target);

            //Assert
            Assert.AreEqual(93m, result);
        }

        [Test]
        public void ConvertCurrencyWithUnsupportedCurrencyThrowsException()
        {
            //Arrange
            decimal value = 100m;
            string source = "USD";
            string target = "unsupportedCurrency"; 

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _conversionService.ConvertCurrency(value, source, target));
        } 
    
        [Test]
        public void SaveConversionSuccessfully()
        {
            //Arrange
            var dto = new ConversionDto
            {
                Source = "USD",
                Target = "EUR",
                Value = 100,
                Result = 93 
            };

            //Act
            _conversionService.SaveConversion(dto.Source, dto.Target,dto.Value,dto.Result);
            
            var history = _conversionService.GetHistory();
            
            Assert.IsNotNull(history);
           
             
            var mockRepository = (MockConversionRepository)_conversionService.ConversionRepository;
            
            var savedConversions = mockRepository.GetSavedConversionHistory();
            
            var savedConversion = savedConversions.FirstOrDefault(h => h.Source == dto.Source
                                                                       && h.Target == dto.Target
                                                                       && h.Value == dto.Value
                                                                       && h.Result == dto.Result);
            Assert.IsNotNull(savedConversion, "Saved conversion not found in internal conversion history");
            
            
            
        }

        [Test]
        public void GetHistoryReturnsConversionHistory()
        {
            //Act
            Assert.AreEqual(2,_conversionService.GetHistory().Count());

        }
    
}