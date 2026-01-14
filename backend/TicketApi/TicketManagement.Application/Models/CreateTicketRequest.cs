namespace TicketManagement.Application.Models
{
    public class CreateTicketRequest
   
    {
        public int UserId { get; } 
        public string Subject { get; } = string.Empty;
        public string Description { get; } = string.Empty;
    }
}
