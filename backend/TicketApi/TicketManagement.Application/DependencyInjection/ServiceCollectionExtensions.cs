using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Services;
using TicketManagement.Application.Services.Interfaces;
using TicketManagement.Application.Validators;
using TicketManagement.Application.Validators.Interfaces;
using TicketManagement.Application.WorkFlows;
using TicketManagement.Application.WorkFlows.Interfaces;
using TicketManagement.Application.WorkFlows.Tasks;
using TicketManagement.Application.WorkFlows.Tasks.Interfaces;

namespace TicketManagement.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGetAllTicketsWorkFlow, GetAllTicketsWorkFlow>();
            services.AddScoped<ICreateTicketWorkFlow, CreateTicketWorkFlow>();
            services.AddScoped<ICloseTicketWorkFlow, CloseTicketWorkFlow>();

            services.AddScoped<IGetAllTicketsTask, GetAllTicketsTask>();
            services.AddScoped<ICreateTicketTask, CreateTicketTask>();
            services.AddScoped<IGetNextTicketIdTask, GetNextTicketIdTask>();
            services.AddScoped<IGetTicketByIdTask, GetTicketByIdTask>();
            services.AddScoped<ICloseTicketTask, CloseTicketTask>();

            services.AddScoped<ICreateTicketRequestValidator, CreateTicketRequestValidator>();

            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }

}
