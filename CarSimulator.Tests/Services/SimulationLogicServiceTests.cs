using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using Xunit;

namespace CarSimulator.Tests.Services
{
    public class SimulationLogicServiceTests
    {
        private SimulationLogicService CreateService()
        {
            var context = new DirectionContext();

            SimulationLogicService.DirectionStrategyResolver resolver =
                movementAction =>
                {
                    return movementAction switch
                    {
                        MovementAction.Left => new TurnLeftStrategy(),
                        MovementAction.Right => new TurnRightStrategy(),
                        MovementAction.Forward => new DriveForwardStrategy(),
                        MovementAction.Backward => new ReverseStrategy(),
                        _ => throw new ArgumentOutOfRangeException()
                    };
                };

            return new SimulationLogicService(context, resolver);
        }

        [Fact]
        public void PerformAction_Rest_ShouldSetEnergyTo20()
        {
            var service = CreateService();

            var status = new StatusDTO
            {
                EnergyValue = 5,
                GasValue = 10,
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward
            };

            var result = service.PerformAction(5, status);

            Assert.Equal(20, result.EnergyValue);
        }

        [Fact]
        public void DecreaseStatusValues_Rest_ShouldNotDecreaseGas()
        {
            var service = CreateService();

            var status = new StatusDTO
            {
                EnergyValue = 20,
                GasValue = 20
            };

            var result = service.DecreaseStatusValues(5, status);

            Assert.Equal(20, result.GasValue);
            Assert.InRange(result.EnergyValue, 15, 19);
        }

        [Fact]
        public void DecreaseStatusValues_ShouldNeverSetGasBelowZero()
        {
            var service = CreateService();

            var status = new StatusDTO
            {
                EnergyValue = 20,
                GasValue = 0
            };

            var result = service.DecreaseStatusValues(3, status);

            Assert.Equal(0, result.GasValue);
        }

        [Fact]
        public void DecreaseStatusValues_ShouldNeverSetEnergyBelowZero()
        {
            var service = CreateService();

            var status = new StatusDTO
            {
                EnergyValue = 0,
                GasValue = 20
            };

            var result = service.DecreaseStatusValues(3, status);

            Assert.Equal(0, result.EnergyValue);
        }
    }
}