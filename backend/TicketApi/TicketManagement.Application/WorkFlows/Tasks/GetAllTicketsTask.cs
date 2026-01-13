using TicketManagement.Application.Data.Ticket.Query;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.WorkFlows.Tasks
{
    public class GetAllTicketsTask : IGetAllTicketsTask
    {
        private readonly IGetAllTicketsQuery _getAllTicketsQuery;

        public GetAllTicketsTask(IGetAllTicketsQuery getAllTicketsQuery)
        {
            _getAllTicketsQuery = getAllTicketsQuery;
        }

        public IEnumerable<Ticket> Get()
        {
            return _getAllTicketsQuery.Get();
        }
    }
}
