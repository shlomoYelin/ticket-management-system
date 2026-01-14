namespace TicketManagement.Application.Data.Ticket.Command
{
    public interface IUpdateTicketCommand
    {
        void Update(Domain.Entities.Ticket ticket);
    }
}
