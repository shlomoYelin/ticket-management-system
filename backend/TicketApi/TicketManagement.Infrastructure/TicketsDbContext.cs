using Microsoft.EntityFrameworkCore;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Infrastructure;

public class TicketsDbContext : DbContext
{
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
}
