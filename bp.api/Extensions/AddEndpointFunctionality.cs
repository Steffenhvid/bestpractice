using bp.api.Commands.Generic;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Extensions
{
    public static class AddEndpointFunctionality
    {
        public static IServiceCollection AddBasicEndpointFunctionality<T>(this IServiceCollection services) where T : BaseEntity
        {
            services.AddScoped<ICreate<T>, Create<T>>();
            services.AddScoped<IGet<T>, Get<T>>();
            services.AddScoped<IUpdate<T>, Update<T>>();
            return services;
        }
    }
}