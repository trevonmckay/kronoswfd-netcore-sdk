using Newtonsoft.Json;
using Xunit;

namespace Kronos.WFD.Core.Tests
{
    public class DataRootEntityConverterTests
    {
        private class TestRootElement
        {
            public string ElementName { get; set; }

            public DataRootEntity RootEntity { get; set; }
        }

        [Fact]
        public void SerializeMissingValue_Success()
        {
            // Arrange
            const string jsonString = "{\"elementName\": \"ROOT ELEMENT\"}";

            // Act
            var rootElement = JsonConvert.DeserializeObject<TestRootElement>(jsonString);

            // Assert
            Assert.Null(rootElement.RootEntity);
        }

        [Fact]
        public void SerializeNullValue_Success()
        {
            // Arrange
            const string jsonString = "{\"rootEntity\": null}";

            // Act
            var rootElement = JsonConvert.DeserializeObject<TestRootElement>(jsonString);

            // Assert
            Assert.Null(rootElement.RootEntity);
        }

        [Fact]
        public void SerializeStringValue_Success()
        {
            // Arrange
            const string name = "PEOPLE";
            const string jsonString = "{\"rootEntity\": \"" + name + "\"}";

            // Act
            var rootElement = JsonConvert.DeserializeObject<TestRootElement>(jsonString);

            // Assert
            Assert.Equal(name, rootElement.RootEntity.Name);
            Assert.False(rootElement.RootEntity.Composed);
        }

        [Fact]
        public void SerializeObjectValue_Success()
        {
            // Arrange
            const string name = "PEOPLE";
            const string jsonString = "{\"name\": \"" + name + "\", \"composed\": true}";

            // Act
            var rootEntity = JsonConvert.DeserializeObject<DataRootEntity>(jsonString);

            // Assert
            Assert.Equal(name, rootEntity.Name);
            Assert.True(rootEntity.Composed);
        }
    }
}
