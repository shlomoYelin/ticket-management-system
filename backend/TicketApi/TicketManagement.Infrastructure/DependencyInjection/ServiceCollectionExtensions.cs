using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Data.Ticket.Query;
using TicketManagement.Infrastructure.Data.Ticket.Query;

namespace TicketManagement.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<TicketsDbContext>(options =>
            options.UseInMemoryDatabase("TicketsDb"));

        services.AddScoped<IGetAllTicketsQuery, GetAllTicketsQuery>();

        return services;
    }
}
