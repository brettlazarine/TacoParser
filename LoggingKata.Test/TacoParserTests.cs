using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //DONE -- TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //DONE -- TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var testLongitude = new TacoParser();
            //Act
            var actual = testLongitude.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude); 
        }


        //DONE -- TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var testLatitude = new TacoParser(); //Arrange
            var actual = testLatitude.Parse(line).Location.Latitude; //Act
            Assert.Equal(expected, actual); //Assert
        }
    }
}
