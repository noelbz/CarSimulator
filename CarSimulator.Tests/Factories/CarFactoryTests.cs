using CarSimulator.Server.Factories;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.Factories
{
    public class CarFactoryTests
    {
        [Fact]
        public void CreateCar_ShouldCreateCarWithDefaultValues()
        {
            var factory = new CarFactory();

            var result = factory.CreateCar();

            Assert.Equal(CardinalDirection.North, result.CardinalDirection);
            Assert.Equal(20, result.GasValue);
        }
    }
}