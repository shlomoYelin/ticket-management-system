using TicketManagement.Application.Dtos;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Mappings
{
    public static class TicketMappings
    {
        public static TicketDto ToDto(this Ticket t) =>
            new(
                t.TicketId,
                t.UserId,
                t.Subject,
                t.Description,
                t.IsClosed
            );

        public static Ticket ToEntity(this TicketDto t) =>
            new(
                t.TicketId,
                t.UserId,
                t.Subject,
                t.Description,
                t.IsClosed
            );
    }
}
