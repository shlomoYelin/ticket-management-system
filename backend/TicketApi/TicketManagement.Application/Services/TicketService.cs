using TicketManagement.Application.Dtos;
using TicketManagement.Application.Services.Interfaces;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IGetAllTicketsWorkFlow _getAllTicketsWorkFlow;
        private readonly ICreateTicketWorkFlow _createTicketWorkFlow;

        public TicketService(IGetAllTicketsWorkFlow getAllTicketsWorkFlow, ICreateTicketWorkFlow createTicketWorkFlow)
        {
            _getAllTicketsWorkFlow = getAllTicketsWorkFlow;
            _createTicketWorkFlow = createTicketWorkFlow;
        }

        public ResultModel<IEnumerable<TicketDto>> GetAllTickets()
        {
            return _getAllTicketsWorkFlow.Get();
        }

        public ResultModel<TicketDto> CreateTicket(CreateTicketRequest request)
        {
            return _createTicketWorkFlow.Create(request);
        }
    }
}
