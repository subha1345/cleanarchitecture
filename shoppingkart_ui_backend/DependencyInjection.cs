using Microsoft.AspNetCore.Mvc.Infrastructure;
using shoppingkart_ui_backend.Errors;
using shoppingkart_ui_backend.Mapping;

namespace shoppingkart_ui_backend
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, ShoppingKartDetailsProblemFactory>();
            services.AddMappings();
            return services;
        }
    }
}
