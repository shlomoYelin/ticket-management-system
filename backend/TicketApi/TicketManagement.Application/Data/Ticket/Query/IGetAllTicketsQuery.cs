namespace TicketManagement.Application.Data.Ticket.Query
{
    public interface IGetAllTicketsQuery
    {
        IEnumerable<Domain.Entities.Ticket> Get();
    }
}
