using TicketManagement.Application.Dtos;
using TicketManagement.Application.Validators.Models;

namespace TicketManagement.Application.Validators.Interfaces
{
    public interface ICreateTicketRequestValidator
    {
        ValidationResult Validate(CreateTicketRequest request);
    }
}
