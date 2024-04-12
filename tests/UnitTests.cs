using System.Net.Http.Json;
using CurrencyConverter;
using Dapper;
using FluentAssertions;
using MySqlConnector;
using Newtonsoft.Json;
using NUnit.Framework;
using tests.model;

namespace tests;

    
    [TestFixture]
    public class ConversionServiceTests
    {
        private ConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            _conversionService = new ConversionService();
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
        public void ConvertCurrency_WithUnsupportedCurrency_ThrowsException()
        {
            // Arrange
            decimal value = 100m;
            string source = "USD";
            string target = "unsupportedCurrency"; 

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _conversionService.ConvertCurrency(value, source, target));
        } 
    
        
    
    
}