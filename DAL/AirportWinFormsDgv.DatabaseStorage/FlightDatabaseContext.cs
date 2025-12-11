using AirportWinFormsDgv.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportWinFormsDgv.DAL.DatabaseStorage
{
    /// <summary>
    /// Контекст базы данных для управления рейсами
    /// </summary>
    public class FlightDatabaseContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="FlightModel"/>.
        /// </summary>
        public DbSet<FlightModel> Flights { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="FlightDatabaseContext"/>.
        /// </summary>
        public FlightDatabaseContext() => Database.EnsureCreated();

        /// <summary>
        /// Конфигурация подключения к базе данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=FlightDatabase;Trusted_Connection=True;");

        /// <summary>
        /// Конфигурация модели данных
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightModel>(entity =>
            {
                // Указываем первичный ключ
                entity.HasKey(e => e.Id);

                // Номер рейса — обязательное поле, максимальная длина из константы
                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                // Тип самолёта — обязательное поле, сохраняем как целое число
                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasConversion<int>();

                // Время прибытия — обязательное
                entity.Property(e => e.ArrivalTime)
                    .IsRequired();

                // Количество пассажиров — целое число
                entity.Property(e => e.NumberOfPassengers)
                    .IsRequired();

                // Сбор за пассажира — денежная сумма
                entity.Property(e => e.TaxPerPassenger)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                // Количество экипажа — целое число
                entity.Property(e => e.NumberOfCrew)
                    .IsRequired();

                // Сбор за экипаж — денежная сумма
                entity.Property(e => e.TaxPerCrew)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                // Процент надбавки — денежная сумма
                entity.Property(e => e.ServicePercentage)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
        }
    }
}
