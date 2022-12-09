using Application.Currencies;
using Application.Currencies.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

            services.AddScoped<ICurrencyService, CurrencyService>();

            return services;
        }
    }
}
