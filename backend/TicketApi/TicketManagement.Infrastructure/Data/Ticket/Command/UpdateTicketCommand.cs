using TicketManagement.Application.Data.Ticket.Command;

namespace TicketManagement.Infrastructure.Data.Ticket.Command
{
    public class UpdateTicketCommand : IUpdateTicketCommand
    {
        private readonly TicketsDbContext _context;

        public UpdateTicketCommand(TicketsDbContext context)
        {
            _context = context;
        }

        public void Update(Domain.Entities.Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}
