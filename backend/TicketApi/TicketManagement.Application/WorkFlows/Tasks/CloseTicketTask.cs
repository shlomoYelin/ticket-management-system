using TicketManagement.Application.Data.Ticket.Command;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;

namespace TicketManagement.Application.WorkFlows.Tasks
{
    public class CloseTicketTask : ICloseTicketTask
    {
        private readonly IUpdateTicketCommand _command;

        public CloseTicketTask(IUpdateTicketCommand command)
        {
            _command = command;
        }

        public void Update(Domain.Entities.Ticket ticket)
        {
            ticket .IsClosed = true;
            _command.Update(ticket);
        }
    }
}
