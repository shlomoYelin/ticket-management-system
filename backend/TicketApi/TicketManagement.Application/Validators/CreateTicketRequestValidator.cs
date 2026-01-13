using TicketManagement.Application.Dtos;
using TicketManagement.Application.Validators.Interfaces;
using TicketManagement.Application.Validators.Models;

namespace TicketManagement.Application.Validators
{
    public class CreateTicketRequestValidator : ICreateTicketRequestValidator
    {
        public ValidationResult Validate(CreateTicketRequest request)
        {
            var result = new ValidationResult();
            
            if (request.UserId <= 0)
                result.AddError("מספר משתמש חייב להיות גדול מ-0");
            
            if (string.IsNullOrWhiteSpace(request.Subject))
                result.AddError("נושא הכרטיס הוא שדה חובה");
            
            if (string.IsNullOrWhiteSpace(request.Description))
                result.AddError("תיאור הכרטיס הוא שדה חובה");
            
            return result;
        }
    }
}
