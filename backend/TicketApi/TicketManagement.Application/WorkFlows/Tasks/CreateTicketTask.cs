using TicketManagement.Application.Data.Ticket.Command;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.WorkFlows.Tasks
{
    public class CreateTicketTask : ICreateTicketTask
    {
        private readonly ICreateTicketCommand _createTicketCommand;

        public CreateTicketTask(ICreateTicketCommand createTicketCommand)
        {
            _createTicketCommand = createTicketCommand;
        }

        public Ticket Create(Ticket ticket)
        {
            return _createTicketCommand.Create(ticket);
        }
    }
}
