using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.WorkFlows.Tasks.Interfaces
{
    public interface IGetAllTicketsTask
    {
        IEnumerable<Ticket> Get();
    }
}
