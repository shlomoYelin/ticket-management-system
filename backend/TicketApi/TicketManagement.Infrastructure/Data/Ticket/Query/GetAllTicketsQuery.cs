using TicketManagement.Application.Data.Ticket.Query;

namespace TicketManagement.Infrastructure.Data.Ticket.Query
{
    public class GetAllTicketsQuery : IGetAllTicketsQuery
    {
        private readonly TicketsDbContext _dbContext;

        public GetAllTicketsQuery(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Domain.Entities.Ticket> Get()
        {
            return _dbContext.Tickets.ToList();
        }
    }
}
