using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Infrastructure.Queries;

namespace OnionDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingQuery, BookingQuery>();
        services.AddScoped<IAccommodationRepository, AccommodationRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IHostRepository, HostRepository>();
        services.AddScoped<IBookingDomainService, BookingDomainService>();
        services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();


        // Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        // Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        services.AddDbContext<BookMyHomeContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("BookMyHomeDbConnection"),
                x =>
                    x.MigrationsAssembly("OnionDemo.DatabaseMigration")));
        return services;
    }
}