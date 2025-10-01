using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.ApplicationUser;
using WebApp.Application.Devices.Commands.CreateModem;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Application.Mappings;

namespace WebApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateDSLCommand));
            services.AddMediatR(typeof(CreateModemCommand));

            services.AddAutoMapper(typeof(ModemMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateModemCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateDSLCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
        }
    }
}
