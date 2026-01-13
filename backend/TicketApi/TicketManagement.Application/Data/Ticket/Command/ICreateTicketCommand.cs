namespace TicketManagement.Application.Data.Ticket.Command
{
    public interface ICreateTicketCommand
    {
        Domain.Entities.Ticket Create(Domain.Entities.Ticket ticket);
    }
}
