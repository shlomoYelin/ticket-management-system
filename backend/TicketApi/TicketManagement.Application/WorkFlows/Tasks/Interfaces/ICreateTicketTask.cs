using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.WorkFlows.Tasks.Interfaces
{
    public interface ICreateTicketTask
    {
        Ticket Create(Ticket request);
    }
}
