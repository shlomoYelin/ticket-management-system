using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.WorkFlows.Tasks.Interfaces
{
    public interface IGetTicketByIdTask
    {
        Ticket Get(int id);
    }
}
