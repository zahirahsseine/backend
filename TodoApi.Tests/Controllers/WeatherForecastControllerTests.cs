using TodoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TodoApi.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            _controller = new WeatherForecastController();
        }

        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_ReturnsWeatherForecastsWithValidProperties()
        {
            // Act
            var result = _controller.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.NotNull(forecast);
                Assert.True(forecast.Date >= DateOnly.FromDateTime(DateTime.Now));
                Assert.InRange(forecast.TemperatureC, -20, 55);
                Assert.NotNull(forecast.Summary);
            }
        }
    }
}
