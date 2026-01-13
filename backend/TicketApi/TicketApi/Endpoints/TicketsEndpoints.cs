using TicketManagement.Application.Services.Interfaces;

namespace TicketApi.Endpoints
{
    public static class TicketsEndpoints
    {
        public static IEndpointRouteBuilder MapTicketsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/tickets");

            group.MapGet("/", (ITicketService service) =>
            {
                var result = service.GetAllTickets();
                return Results.Ok(result);
            });

            return app;
        }
    }
}
