using TicketManagement.Application.Dtos;
using TicketManagement.Application.Services.Interfaces;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IGetAllTicketsWorkFlow _getAllTicketsWorkFlow;

        public TicketService(IGetAllTicketsWorkFlow getAllTicketsWorkFlow)
        {
            _getAllTicketsWorkFlow = getAllTicketsWorkFlow;
        }

        public ResultModel<IEnumerable<TicketDto>> GetAllTickets()
        {
            return _getAllTicketsWorkFlow.Get();
        }
    }
}
