using CurrencyConverter;
using NUnit.Framework;

namespace tests;

[TestFixture]
public class UtilitiesTests
{
    
        [Test]
        public void GetConnectionStringReturnsEnvironmentVariable()
        {
            //Arrange
            string expectedConnectionString = "Server=example;Database=testdb;Uid=testuser;Pwd=testpassword";
            System.Environment.SetEnvironmentVariable("sqlconn", expectedConnectionString);

            //Act
            string result = Utilities.GetConnectionString();

            //Assert
            Assert.AreEqual(expectedConnectionString, result);
        }
    

        [Test]
        public void BuildConnectionStringWithCustomParametersReturnsConnectionString()
        {
            //Arrange
            string expectedConnectionString = "Server=example;Database=testdb;Uid=testuser;Pwd=testpassword;";

            //Act
            string result = Utilities.BuildConnectionString(server: "example", database: "testdb", user: "testuser", password: "testpassword");

            //Assert
            Assert.AreEqual(expectedConnectionString, result);
        }
    }
