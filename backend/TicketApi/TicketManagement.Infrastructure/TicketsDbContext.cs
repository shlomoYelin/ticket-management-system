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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasKey(t => t.TicketId);
        
        modelBuilder.Entity<Ticket>()
            .Property(t => t.TicketId)
            .ValueGeneratedOnAdd();
    }
}
