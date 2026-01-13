using TicketManagement.Application.Data.Ticket.Query;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;

namespace TicketManagement.Application.WorkFlows.Tasks
{
    public class GetNextTicketIdTask : IGetNextTicketIdTask
    {
        private readonly IGetNextTicketIdQuery _getNextTicketIdQuery;

        public GetNextTicketIdTask(IGetNextTicketIdQuery getNextTicketIdQuery)
        {
            _getNextTicketIdQuery = getNextTicketIdQuery;
        }

        public int Get()
        {
            return _getNextTicketIdQuery.Get();
        }
    }
}
