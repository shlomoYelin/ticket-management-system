using TicketManagement.Application.Data.Ticket.Query;

namespace TicketManagement.Infrastructure.Data.Ticket.Query
{
    public class GetTicketByIdQuery : IGetTicketByIdQuery
    {
        private readonly TicketsDbContext _context;

        public GetTicketByIdQuery(TicketsDbContext context)
        {
            _context = context;
        }

        public Domain.Entities.Ticket Get(int id)
        {
            return _context.Tickets.FirstOrDefault(x => x.TicketId == id);
        }
    }
}
