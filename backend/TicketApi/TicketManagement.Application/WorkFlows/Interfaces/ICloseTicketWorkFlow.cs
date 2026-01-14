using TicketManagement.Application.Models;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows.Interfaces
{
    public interface ICloseTicketWorkFlow
    {
        ResultModel<object> Close(CloseTicketRequest request);
    }
}
