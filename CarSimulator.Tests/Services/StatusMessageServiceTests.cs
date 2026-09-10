using DataLogicLibrary.Services;
using Xunit;

namespace CarSimulator.Tests.Services
{
    public class StatusMessageServiceTests
    {
        [Fact]
        public void GetCurrentActionMessage_WithNoGas_ShouldTellUserToRefuel()
        {
            var service = new StatusMessageService();

            var result = service.GetCurrentActionMessage(
                3,
                0,
                "Noel"
            );

            Assert.Equal("Refuel to drive the car!", result);
        }

        [Fact]
        public void GetDriverStatusMessage_Energy10_ShouldWarnDriver()
        {
            var service = new StatusMessageService();

            var result = service.GetDriverStatusMessage(
                10,
                "Noel"
            );

            Assert.Equal(
                "Noel is getting tired, consider taking a rest.",
                result
            );
        }

        [Fact]
        public void GetDriverStatusMessage_Energy5_ShouldGiveSeriousWarning()
        {
            var service = new StatusMessageService();

            var result = service.GetDriverStatusMessage(
                5,
                "Noel"
            );

            Assert.Equal(
                "Noel is struggling to stay awake!",
                result
            );
        }

        [Fact]
        public void GetCarStatusMessage_Gas10_ShouldWarnAboutGas()
        {
            var service = new StatusMessageService();

            var result = service.GetCarStatusMessage(10);

            Assert.Equal(
                "Car is running out of gas, consider refuelling the car.",
                result
            );
        }
    }
}