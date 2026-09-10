using DataLogicLibrary.Factories;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.Factories
{
    public class StatusFactoryTests
    {
        [Fact]
        public void CreateStatus_ShouldCreateCorrectDefaultStatus()
        {
            var factory = new StatusFactory();

            var result = factory.CreateStatus();

            Assert.Equal(CardinalDirection.North, result.CardinalDirection);
            Assert.Equal(MovementAction.Forward, result.MovementAction);
            Assert.Equal(20, result.GasValue);
            Assert.Equal(20, result.EnergyValue);
        }
    }
}