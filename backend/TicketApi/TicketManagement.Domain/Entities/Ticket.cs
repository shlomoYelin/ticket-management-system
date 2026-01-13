namespace TicketManagement.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsClosed { get; set; }
    }
}
