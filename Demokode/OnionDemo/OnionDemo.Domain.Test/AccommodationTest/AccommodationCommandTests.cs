using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnionDemo.Application.Command;
using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Infrastructure;
using Xunit;

namespace OnionDemo.Domain.Test.AccommodationTest
{
    public class AccommodationCommandTests
    {
        private readonly DbContextOptions<BookMyHomeContext> _options;

        public AccommodationCommandTests()
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("BookMyHomeDbConnection");

            // Configure DbContext options without retrying execution strategy
            _options = new DbContextOptionsBuilder<BookMyHomeContext>()
                .UseSqlServer(connectionString)
                .Options;
        }


        [Fact]
        public void CreateAccommodation_AddsAccommodationToDatabase()
        {
            using (var context = new BookMyHomeContext(_options))
            {
                var unitOfWork = new UnitOfWork<BookMyHomeContext>(context);
                var repository = new AccommodationRepository(context);
                IAccommodationCommand accommodationCommand = new AccommodationCommand(unitOfWork, repository);
                var createAccommodationDto = new CreateAccommodationDto
                {
                    Name = "Mountain Cabin",
                    Location = "Colorado",
                    HostId = 1 // Assuming HostId 1 exists
                };

                accommodationCommand.CreateAccommodation(createAccommodationDto);

                var accommodation = context.Accommodations.SingleOrDefault(a => a.Name == "Mountain Cabin");
                Assert.NotNull(accommodation);
                Assert.Equal("Mountain Cabin", accommodation.Name);
                Assert.Equal("Colorado", accommodation.Location);
                Assert.Equal(1, accommodation.HostId);
            }
        }
    }
}
        

    

