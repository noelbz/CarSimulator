using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.DirectionStrategies
{
    public class ReverseStrategyTests
    {
        [Fact]
        public void Reverse_FromNorth_ShouldFaceSouth()
        {
            var strategy = new ReverseStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.South, result.CardinalDirection);
            Assert.Equal(MovementAction.Backward, result.MovementAction);
        }

        [Fact]
        public void Reverse_FromEast_ShouldFaceWest()
        {
            var strategy = new ReverseStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.East,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.West, result.CardinalDirection);
            Assert.Equal(MovementAction.Backward, result.MovementAction);
        }

        [Fact]
        public void Reverse_WhenAlreadyReversing_ShouldKeepDirection()
        {
            var strategy = new ReverseStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.South,
                MovementAction = MovementAction.Backward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.South, result.CardinalDirection);
            Assert.Equal(MovementAction.Backward, result.MovementAction);
        }
    }
}