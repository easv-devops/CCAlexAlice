using NUnit.Framework;

namespace tests;
[TestFixture]
public class DatabaseServiceTests
{  
    /*
    
    private Mock<MySqlConnection> _mockConnection;
        private DatabaseService _dbService;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<MySqlConnection>();
            _dbService = new DatabaseService(_mockConnection.Object);
        }

        [Test]
        public void SaveConversion_ReturnsHistoryObject()
        {
            // Arrange
            var expectedHistory = new History(); // Mock the expected return value
            _mockConnection.Setup(m => m.QueryFirstOrDefault<History>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(expectedHistory);

            // Act
            var result = _dbService.SaveConversion("USD", "EUR", 100.0f, 85.0f);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedHistory, result);
        }

        [Test]
        public void GetConversionHistory_ReturnsHistoryList()
        {
            // Arrange
            var expectedHistoryList = new List<History>(); // Mock the expected return value
            _mockConnection.Setup(m => m.Query<History>(It.IsAny<string>()))
                .Returns(expectedHistoryList);

            // Act
            var result = _dbService.GetConversionHistory();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedHistoryList, result);
        }
    }*/
}