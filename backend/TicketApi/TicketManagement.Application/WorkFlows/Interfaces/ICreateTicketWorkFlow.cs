using TicketManagement.Application.Dtos;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows.Interfaces
{
    public interface ICreateTicketWorkFlow
    {
        ResultModel<TicketDto> Create(CreateTicketRequest request);
    }
}
