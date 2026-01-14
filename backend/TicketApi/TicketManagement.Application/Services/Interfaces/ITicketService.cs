using TicketManagement.Application.Dtos;
using TicketManagement.Application.Models;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.Services.Interfaces
{
    public interface ITicketService
    {
        ResultModel<IEnumerable<TicketDto>> GetAllTickets();
        ResultModel<TicketDto> CreateTicket(CreateTicketRequest request);
        ResultModel<object> CloseTicket(CloseTicketRequest request);
    }
}
