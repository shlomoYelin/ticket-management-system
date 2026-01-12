using Microsoft.EntityFrameworkCore;
using TicketManagement.Domain.Models;

namespace TicketManagement.Infrastructure.Data;

public class TicketsDbContext : DbContext
{
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
}
