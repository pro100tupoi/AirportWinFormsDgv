using AirportWinFormsDgv.BL.Services.Contracts;
using AirportWinFormsDgv.DAL.Repository.Contracts;
using AirportWinFormsDgv.DAL.Entities.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace AirportWinFormsDgv.BL.Services.Tests
{
    /// <summary>
    /// Набор тестов для проверки <see cref="FlightService"/>
    /// </summary>
    public class FlightServiceTest
    {
        private readonly Mock<IStorage> mockStorage;
        private readonly IFlightServices service;
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

        /// <summary>
        /// Конструктор для класса <see cref="FlightServiceTest"/>
        /// </summary>
        public FlightServiceTest()
        {
            mockStorage = new Mock<IStorage>();
            service = new FlightService(mockStorage.Object, loggerFactory);
            cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Проверка вызова метода добавления при добавлении в хранилище
        /// </summary>
        [Fact]
        public async Task AddFlightShouldCallStorageAddFlight()
        {
            // Arrange
            var flight = new FlightModel
            {
                Id = Guid.NewGuid(),
                FlightNumber = "SU-213",
                AircraftType = AircraftType.Airbus,
                ArrivalTime = DateTime.Now.AddDays(1),
                NumberOfPassengers = 150,
                TaxPerPassenger = 250.50m,
                NumberOfCrew = 8,
                TaxPerCrew = 120.75m,
                ServicePercentage = 15.5m
            };

            // Act
            await service.AddFlightAsync(flight, cancellationTokenSource.Token);

            // Assert
            mockStorage.Verify(x => x.AddFlightAsync(flight, cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка вызова метода удаления при удалении из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteFlightShouldCallStorageDeleteFlight()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await service.DeleteFlightAsync(id, cancellationTokenSource.Token);

            // Assert
            mockStorage.Verify(x => x.DeleteFlightAsync(id, cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка корректности возвращаемых данных при вызове получения всех рейсов
        /// </summary>
        [Fact]
        public async Task GetAllFlightsShouldReturnDataFromStorage()
        {
            // Arrange
            var list = new List<FlightModel>
            {
                new FlightModel { Id = Guid.NewGuid() },
                new FlightModel { Id = Guid.NewGuid() },
            };
            mockStorage
                .Setup(x => x.GetAllFlightsAsync(cancellationTokenSource.Token))
                .ReturnsAsync(list);

            // Act
            var res = await service.GetAllFlightsAsync(cancellationTokenSource.Token);

            // Assert
            res.Should().BeSameAs(list);
        }

        /// <summary>
        /// Проверка корректности данных возвращаемой статистики
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldReturnCorrectData()
        {
            // Arrange
            var expectedStatistics = new FlightStorageStatistics
            {
                TotalFlights = 5,
                TotalPassengers = 250,
                TotalCrew = 25,
                TotalRevenue = 50000
            };

            mockStorage.Setup(s => s.GetStatisticsAsync(cancellationTokenSource.Token))
                       .ReturnsAsync(expectedStatistics);

            var result = await service.GetStatisticsAsync(cancellationTokenSource.Token);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedStatistics);
            mockStorage.Verify(s => s.GetStatisticsAsync(cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка обновления рейса при вызове метода обновления
        /// </summary>
        [Fact]
        public async Task UpdateFlightShouldUpdateEntityDataInStorage()
        {
            // Arrange
            var incomingFlight = new FlightModel
            {
                Id = Guid.NewGuid(),
                FlightNumber = "BA-456",
                AircraftType = AircraftType.Boeing,
                ArrivalTime = DateTime.Now.AddDays(2),
                NumberOfPassengers = 85,
                TaxPerPassenger = 180.00m,
                NumberOfCrew = 6,
                TaxPerCrew = 100.25m,
                ServicePercentage = 12.0m
            };

            mockStorage.Setup(x => x.UpdateFlightAsync(
                It.Is<FlightModel>(f =>
                    f.FlightNumber == incomingFlight.FlightNumber &&
                    f.AircraftType == incomingFlight.AircraftType &&
                    f.ArrivalTime == incomingFlight.ArrivalTime &&
                    f.NumberOfPassengers == incomingFlight.NumberOfPassengers &&
                    f.TaxPerPassenger == incomingFlight.TaxPerPassenger &&
                    f.NumberOfCrew == incomingFlight.NumberOfCrew &&
                    f.TaxPerCrew == incomingFlight.TaxPerCrew &&
                    f.ServicePercentage == incomingFlight.ServicePercentage
                ), cancellationTokenSource.Token)
            ).Returns(Task.CompletedTask);

            // Act
            await service.UpdateFlightAsync(incomingFlight, cancellationTokenSource.Token);

            // Assert
            mockStorage.Verify(s => s.UpdateFlightAsync(
                It.Is<FlightModel>(f =>
                    f.FlightNumber == incomingFlight.FlightNumber &&
                    f.AircraftType == incomingFlight.AircraftType &&
                    f.ArrivalTime == incomingFlight.ArrivalTime &&
                    f.NumberOfPassengers == incomingFlight.NumberOfPassengers &&
                    f.TaxPerPassenger == incomingFlight.TaxPerPassenger &&
                    f.NumberOfCrew == incomingFlight.NumberOfCrew &&
                    f.TaxPerCrew == incomingFlight.TaxPerCrew &&
                    f.ServicePercentage == incomingFlight.ServicePercentage
                ), cancellationTokenSource.Token), Times.Once
            );
        }

    }
}
