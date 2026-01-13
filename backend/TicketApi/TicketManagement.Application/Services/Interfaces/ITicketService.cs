using TicketManagement.Application.Dtos;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.Services.Interfaces
{
    public interface ITicketService
    {
        ResultModel<IEnumerable<TicketDto>> GetAllTickets();
    }
}
