namespace TicketManagement.Application.Dtos
{
    public record CreateTicketRequest
    (
        int UserId,
        string Subject,
        string Description
    );
}
