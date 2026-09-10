using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.DirectionStrategies
{
    public class TurnLeftStrategyTests
    {
        [Fact]
        public void TurnLeft_FromNorth_ShouldFaceWest()
        {
            var strategy = new TurnLeftStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.West, result.CardinalDirection);
            Assert.Equal(MovementAction.Left, result.MovementAction);
        }

        [Fact]
        public void TurnLeft_FromEast_ShouldFaceNorth()
        {
            var strategy = new TurnLeftStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.East,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.North, result.CardinalDirection);
            Assert.Equal(MovementAction.Left, result.MovementAction);
        }

        [Fact]
        public void TurnLeft_WhenReversingFromNorth_ShouldFaceEast()
        {
            var strategy = new TurnLeftStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Backward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.East, result.CardinalDirection);
            Assert.Equal(MovementAction.Left, result.MovementAction);
        }
    }
}