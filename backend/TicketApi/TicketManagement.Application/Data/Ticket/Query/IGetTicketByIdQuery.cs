namespace TicketManagement.Application.Data.Ticket.Query
{
    public interface IGetTicketByIdQuery
    {
        Domain.Entities.Ticket Get(int id);
    }
}
