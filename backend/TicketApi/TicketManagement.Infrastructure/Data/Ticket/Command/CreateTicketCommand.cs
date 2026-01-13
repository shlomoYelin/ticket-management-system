using TicketManagement.Application.Data.Ticket.Command;

namespace TicketManagement.Infrastructure.Data.Ticket.Command
{
    public class CreateTicketCommand : ICreateTicketCommand
    {
        private readonly TicketsDbContext _dbContext;

        public CreateTicketCommand(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Entities.Ticket Create(Domain.Entities.Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket;
        }
    }
}
