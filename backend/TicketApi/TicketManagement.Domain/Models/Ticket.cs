namespace TicketManagement.Domain.Models
{
    public record Ticket(
    int TicketId,
    int UserId,
    string Subject,
    string Description,
    bool IsClosed
);
}
