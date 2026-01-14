namespace TicketManagement.Application.WorkFlows.Tasks.Interfaces
{
    public interface ICloseTicketTask
    {
        void Update(Domain.Entities.Ticket ticket);
    }
}
