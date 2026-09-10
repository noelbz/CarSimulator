using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using Xunit;

namespace CarSimulator.Tests.DirectionStrategies
{
    public class DriveForwardStrategyTests
    {
        [Fact]
        public void DriveForward_WhenAlreadyForward_ShouldKeepDirection()
        {
            var strategy = new DriveForwardStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.East,
                MovementAction = MovementAction.Forward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.East, result.CardinalDirection);
            Assert.Equal(MovementAction.Forward, result.MovementAction);
        }

        [Fact]
        public void DriveForward_AfterReversingNorth_ShouldFaceSouth()
        {
            var strategy = new DriveForwardStrategy();

            var status = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Backward
            };

            var result = strategy.Execute(status);

            Assert.Equal(CardinalDirection.South, result.CardinalDirection);
            Assert.Equal(MovementAction.Forward, result.MovementAction);
        }
    }
}