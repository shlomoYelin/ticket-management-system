namespace TicketManagement.Application.Dtos
{
    public record TicketDto
    (
    int TicketId,
    int UserId,
    string Subject,
    string Description,
    bool IsClosed
);
}
