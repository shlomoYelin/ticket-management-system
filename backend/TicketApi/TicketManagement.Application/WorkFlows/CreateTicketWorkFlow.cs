using Microsoft.Extensions.Logging;
using TicketManagement.Application.Dtos;
using TicketManagement.Application.Mappings;
using TicketManagement.Application.Models;
using TicketManagement.Application.Validators.Interfaces;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;
using TicketManagement.Domain.Models;

namespace TicketManagement.Application.WorkFlows
{
    public class CreateTicketWorkFlow : ICreateTicketWorkFlow
    {
        private readonly ICreateTicketTask _createTicketTask;
        private readonly IGetNextTicketIdTask _getNextTicketIdTask;
        private readonly ICreateTicketRequestValidator _validator;
        private readonly ILogger<CreateTicketWorkFlow> _logger;

        public CreateTicketWorkFlow(
            ICreateTicketTask createTicketTask, 
            ILogger<CreateTicketWorkFlow> logger, 
            IGetNextTicketIdTask getNextTicketIdTask,
            ICreateTicketRequestValidator validator)
        {
            _createTicketTask = createTicketTask;
            _logger = logger;
            _getNextTicketIdTask = getNextTicketIdTask;
            _validator = validator;
        }

        public ResultModel<TicketDto> Create(CreateTicketRequest request)
        {
            try
            {
               
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return new ()
                    {
                        Success = false,
                        ErrorMessage = string.Join("; ", validationResult.Errors)
                    };
                }

                var ticket = request.ToEntity();

                ticket.TicketId = _getNextTicketIdTask.Get();

                ticket = _createTicketTask.Create(ticket);

                var ticketDto = ticket.ToDto();

                return new()
                {
                    Success = true,
                    Data = ticketDto
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
