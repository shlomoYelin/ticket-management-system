namespace TicketManagement.Domain.Models
{
    public class ResultModel<T> where T : class
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
    }
}
