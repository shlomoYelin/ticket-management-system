using TicketManagement.Application.Data.Ticket.Query;

namespace TicketManagement.Infrastructure.Data.Ticket.Query
{
    public class GetNextTicketIdQuery : IGetNextTicketIdQuery
    {
        private readonly TicketsDbContext _dbContext;

        public GetNextTicketIdQuery(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Generate next TicketId (required for In-Memory DB as it doesn't support auto-increment)
        public int Get()
        {
            return _dbContext.Tickets.Any()? _dbContext.Tickets.Max(t => t.TicketId) + 1 :1;
        }
    }
}
