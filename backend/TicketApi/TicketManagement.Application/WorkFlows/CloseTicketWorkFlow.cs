using Microsoft.Extensions.Logging;
using TicketManagement.Application.Models;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows
{
    public class CloseTicketWorkFlow : ICloseTicketWorkFlow
    {
        private readonly IGetTicketByIdTask _getTicketByIdTask;
        private readonly ICloseTicketTask _closeTicketTask;
        private readonly ILogger<CloseTicketWorkFlow> _logger;

        public CloseTicketWorkFlow(IGetTicketByIdTask getTicketByIdTask, ICloseTicketTask closeTicketTask, ILogger<CloseTicketWorkFlow> logger)
        {
            _getTicketByIdTask = getTicketByIdTask;
            _closeTicketTask = closeTicketTask;
            _logger = logger;
        }

        public ResultModel<object> Close(CloseTicketRequest request)
        {
            try
            {
                var ticket = _getTicketByIdTask.Get(request.TicketId);
                if (ticket == null)
                    throw new ("Ticket not found");

                _closeTicketTask.Update(ticket);

                return new ()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} - {ex.StackTrace}");
                return new() { Success = false, ErrorMessage = "ארעה שגיאה לא צפויה" };
            }
        }
    }
}
