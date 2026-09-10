using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.DirectionStrategies
{
    public class TurnRightStrategyTests
    {
        [Fact]
        public void TurnRight_FromNorth_ShouldFaceEast()
        {
            var strategy = new TurnRightStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.East, result.CardinalDirection);
            Assert.Equal(MovementAction.Right, result.MovementAction);
        }

        [Fact]
        public void TurnRight_FromWest_ShouldFaceNorth()
        {
            var strategy = new TurnRightStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.West,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.North, result.CardinalDirection);
            Assert.Equal(MovementAction.Right, result.MovementAction);
        }

        [Fact]
        public void TurnRight_WhenReversingFromNorth_ShouldFaceWest()
        {
            var strategy = new TurnRightStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Backward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.West, result.CardinalDirection);
            Assert.Equal(MovementAction.Right, result.MovementAction);
        }
    }
}