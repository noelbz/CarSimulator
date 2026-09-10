using APIServiceLibrary.DTO;
using CarSimulator.Server.Factories;
using Xunit;

namespace CarSimulator.Tests.Factories
{
    public class DriverFactoryTests
    {
        [Fact]
        public void CreateDriver_ShouldMapDriverDataCorrectly()
        {
            var resultDto = new ResultsDTO
            {
                Results = new List<ResultDTO>
                {
                    new ResultDTO
                    {
                        Name = new NameDTO
                        {
                            Title = "Mr",
                            First = "Noel",
                            Last = "Test"
                        },
                        Location = new LocationDTO
                        {
                            City = "Stockholm",
                            Country = "Sweden"
                        }
                    }
                }
            };

            var factory = new DriverFactory();

            var result = factory.CreateDriver(resultDto);

            Assert.Equal("Mr", result.Title);
            Assert.Equal("Noel", result.First);
            Assert.Equal("Test", result.Last);
            Assert.Equal("Stockholm", result.City);
            Assert.Equal("Sweden", result.Country);
        }
    }
}
