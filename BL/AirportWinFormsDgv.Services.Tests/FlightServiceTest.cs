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

        /// <summary>
        /// Проверка получения рейса по ID
        /// </summary>
        [Fact]
        public async Task GetFlightByIdShouldReturnCorrectFlight()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedFlight = new FlightModel { Id = id, FlightNumber = "SU-213" };
            mockStorage.Setup(x => x.GetFlightByIdAsync(id, cancellationTokenSource.Token))
                       .ReturnsAsync(expectedFlight);

            // Act
            var result = await service.GetFlightByIdAsync(id, cancellationTokenSource.Token);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeSameAs(expectedFlight);
            result.Id.Should().Be(id);
            mockStorage.Verify(x => x.GetFlightByIdAsync(id, cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка расчета выручки рейса
        /// </summary>
        [Fact]
        public async Task CalculateRevenueShouldReturnCorrectValue()
        {
            // Arrange
            var flight = new FlightModel
            {
                NumberOfPassengers = 100,
                TaxPerPassenger = 200m,
                NumberOfCrew = 10,
                TaxPerCrew = 50m,
                ServicePercentage = 10m
            };

            // Act
            var result = await service.CalculateRevenueAsync(flight, cancellationTokenSource.Token);

            // Assert
            var expectedRevenue = (flight.NumberOfPassengers * flight.TaxPerPassenger +
                                  flight.NumberOfCrew * flight.TaxPerCrew) +
                                 flight.ServicePercentage;
            result.Should().Be(expectedRevenue);
        }

        /// <summary>
        /// Проверка выброса исключения при передаче null в CalculateRevenue
        /// </summary>
        [Fact]
        public async Task CalculateRevenueShouldThrowArgumentNullExceptionWhenFlightIsNull()
        {
            // Arrange
            FlightModel? nullFlight = null;

            // Act & Assert
            await service.Invoking(x => x.CalculateRevenueAsync(nullFlight!, cancellationTokenSource.Token))
                         .Should().ThrowAsync<ArgumentNullException>();
        }

        /// <summary>
        /// Проверка вызова метода обновления в хранилище с правильным объектом
        /// </summary>
        [Fact]
        public async Task UpdateFlightShouldCallStorageWithCorrectFlight()
        {
            // Arrange
            var flight = new FlightModel
            {
                Id = Guid.NewGuid(),
                FlightNumber = "TEST123",
                AircraftType = AircraftType.Airbus
            };

            // Act
            await service.UpdateFlightAsync(flight, cancellationTokenSource.Token);

            // Assert
            mockStorage.Verify(x => x.UpdateFlightAsync(
                It.Is<FlightModel>(f => f.Id == flight.Id && f.FlightNumber == flight.FlightNumber),
                cancellationTokenSource.Token), Times.Once);
        }

    }
}
