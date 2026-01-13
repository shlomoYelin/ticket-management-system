using Microsoft.Extensions.Logging;
using TicketManagement.Application.Dtos;
using TicketManagement.Application.Mappings;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows
{
    public class GetAllTicketsWorkFlow : IGetAllTicketsWorkFlow
    {
		private readonly IGetAllTicketsTask _getAllTicketsTask;
        private readonly ILogger<GetAllTicketsWorkFlow> _logger;

        public GetAllTicketsWorkFlow(IGetAllTicketsTask getAllTicketsTask, ILogger<GetAllTicketsWorkFlow> logger)
        {
            _getAllTicketsTask = getAllTicketsTask;
            _logger = logger;
        }

        public ResultModel<IEnumerable<TicketDto>> Get()
        {
			try
			{
                var tickets = _getAllTicketsTask.Get().Select(x => x.ToDto());

                return new ()
                {
                    Success = true,
                    Data = tickets
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
