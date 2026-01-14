using TicketManagement.Application.Models;
using TicketManagement.Application.Services.Interfaces;

namespace TicketApi.Endpoints
{
    public static class TicketsEndpoints
    {
        public static IEndpointRouteBuilder MapTicketsEndpoints(this IEndpointRouteBuilder app)
        {

            var ticketsGroup = app.MapGroup("/tickets");

            ticketsGroup.MapGet("/GetAllTickets", (ITicketService service) =>
            {
                var result = service.GetAllTickets();
                return Results.Ok(result);
            });

            ticketsGroup.MapPost("/CreateTicket", (CreateTicketRequest request, ITicketService service) =>
            {
                var result = service.CreateTicket(request);
                
                return Results.Ok(result);
            });

            ticketsGroup.MapPost("/CloseTicket", (CloseTicketRequest request, ITicketService service) =>
            {
                var result = service.CloseTicket(request);
                return Results.Ok(result);
            });

            return app;
        }
    }
}
