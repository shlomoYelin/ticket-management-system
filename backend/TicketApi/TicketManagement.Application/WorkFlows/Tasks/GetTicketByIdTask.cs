using TicketManagement.Application.Data.Ticket.Query;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;

namespace TicketManagement.Application.WorkFlows.Tasks
{
    public class GetTicketByIdTask : IGetTicketByIdTask
    {
        private readonly IGetTicketByIdQuery _query;

        public GetTicketByIdTask(IGetTicketByIdQuery query)
        {
            _query = query;
        }

        public Domain.Entities.Ticket Get(int id)
        {
            return _query.Get(id);
        }
    }
}
