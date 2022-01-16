using Contracts;
using JSONReaderWriter;
using System.Collections.Generic;
using Xunit;

namespace TestTaskApi.UnitTests
{
    public class JSONReaderWriterTests
    {
        [Fact]
        public void ReadJSONFromDictionary()
        {
            // Arrange
            string jsonExample = "{grade:8}";

            // Act
            Dictionary<string, int> result = jsonExample.FromJson<Dictionary<string, int>>();

            // Assert
            Dictionary<string, int> grades = new() { { "grade", 8 } };

            Assert.Equal(grades.Keys, result.Keys);
            Assert.Equal(grades.Values, result.Values);
        }

        [Fact]
        public void WriteJSONFromArray()
        {
            // Arrange
            int[] numbers = new int[] { 5, 62, 2233 };

            // Act
            string result = numbers.ToJson();

            // Assert
            string jsonExample = "[5,62,2233]";

            Assert.Equal(jsonExample, result);
        }

        [Fact]
        public void ReadJSONFromObject()
        {
            // Arrange
            string jsonExample = "{\"FirstName\":\"Ivan\",\"LastName\":\"Petrov\",\"Address\":{\"City\":\"Kiev\",\"AddressLine\":\"prospect “Peremogy” 28/7\"}}";

            // Act
            PersonDto result = jsonExample.FromJson<PersonDto>();

            // Assert
            PersonDto person = new()
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Address = new()
                {
                    City = "Kiev",
                    AddressLine = "prospect “Peremogy” 28/7",
                }
            };
            Assert.Equal(person.FirstName, result.FirstName);
            Assert.Equal(person.LastName, result.LastName);
            Assert.Equal(person.Address.City, result.Address.City);
            Assert.Equal(person.Address.AddressLine, result.Address.AddressLine);
        }

        [Fact]
        public void WriteJSONFromObject()
        {
            // Arrange
            PersonDto person = new()
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Address = new()
                {
                    City = "Kiev",
                    AddressLine = "prospect “Peremogy” 28/7",
                }
            };

            // Act
            string result = person.ToJson();

            // Assert
            string jsonExample = "{\"FirstName\":\"Ivan\",\"LastName\":\"Petrov\",\"Address\":{\"City\":\"Kiev\",\"AddressLine\":\"prospect “Peremogy” 28/7\"}}";

            Assert.Equal(jsonExample, result);
        }
    }
}
