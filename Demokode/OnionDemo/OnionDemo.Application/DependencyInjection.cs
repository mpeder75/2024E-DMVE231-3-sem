using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Command;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query;

namespace OnionDemo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register command handlers
        services.AddScoped<IBookingCommand, BookingCommand>();
        services.AddScoped<IAccommodationCommand, AccommodationCommand>();

        // Register query handlers
        services.AddScoped<IAccommodationQuery, AccommodationQueryHandler>();

        return services;
    }
}