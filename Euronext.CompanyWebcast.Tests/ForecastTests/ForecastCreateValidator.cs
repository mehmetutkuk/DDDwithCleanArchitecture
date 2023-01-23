using System;
using Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;

namespace Euronext.CompanyWebcast.Tests.ForecastTests
{
	public class ForecastCreateValidator
	{
        [Fact]
        public async Task TestHandler_Default_Validator()
        {

            // Arrange
            var validator = new CreateForecastCommandValidator();
            var cmd = new CreateForecastCommand("sd", DateTime.UtcNow.AddHours(2), Convert.ToDecimal(-59.99));

            // Act
            var validationResult = await validator.ValidateAsync(cmd);

            // Assert
            Assert.True(validationResult.IsValid);

        }
        [Fact]
        public async Task TestHandler_Default_Validator_ExceededCelcius_False()
        {

            // Arrange
            var validator = new CreateForecastCommandValidator();
            var cmd = new CreateForecastCommand("sd", DateTime.UtcNow.AddHours(2), Convert.ToDecimal(-70));

            // Act
            var validationResult = await validator.ValidateAsync(cmd);

            // Assert
            Assert.False(validationResult.IsValid);

        }

        [Fact]
        public async Task TestHandler_Default_Validator_DateTimeCantBeNowOrEarilier_False()
        {

            // Arrange
            var validator = new CreateForecastCommandValidator();
            var cmd = new CreateForecastCommand("sd", DateTime.UtcNow, Convert.ToDecimal(-10));

            // Act
            var validationResult = await validator.ValidateAsync(cmd);

            // Assert
            Assert.False(validationResult.IsValid);

        }
    }
}

