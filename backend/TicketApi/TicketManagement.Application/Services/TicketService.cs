using TicketManagement.Application.Dtos;
using TicketManagement.Application.Models;
using TicketManagement.Application.Services.Interfaces;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IGetAllTicketsWorkFlow _getAllTicketsWorkFlow;
        private readonly ICreateTicketWorkFlow _createTicketWorkFlow;
        private readonly ICloseTicketWorkFlow _closeTicketWorkFlow;

        public TicketService(IGetAllTicketsWorkFlow getAllTicketsWorkFlow, ICreateTicketWorkFlow createTicketWorkFlow, ICloseTicketWorkFlow closeTicketWorkFlow)
        {
            _getAllTicketsWorkFlow = getAllTicketsWorkFlow;
            _createTicketWorkFlow = createTicketWorkFlow;
            _closeTicketWorkFlow = closeTicketWorkFlow;
        }

        public ResultModel<IEnumerable<TicketDto>> GetAllTickets()
        {
            return _getAllTicketsWorkFlow.Get();
        }

        public ResultModel<TicketDto> CreateTicket(CreateTicketRequest request)
        {
            return _createTicketWorkFlow.Create(request);
        }

        public ResultModel<object> CloseTicket(CloseTicketRequest request)
        {
            return _closeTicketWorkFlow.Close(request);
        }
    }
}
