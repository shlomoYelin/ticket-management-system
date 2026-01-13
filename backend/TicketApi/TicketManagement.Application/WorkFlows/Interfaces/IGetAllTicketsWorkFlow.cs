using TicketManagement.Application.Dtos;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows.Interfaces
{
    public interface IGetAllTicketsWorkFlow
    {
        ResultModel<IEnumerable<TicketDto>> Get();
    }
}
