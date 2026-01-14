namespace TicketManagement.Application.Models
{
    public class CreateTicketRequest
   
    {
        public int UserId { get; set; } 
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
