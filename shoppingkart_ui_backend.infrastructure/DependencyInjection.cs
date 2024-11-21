using Microsoft.Extensions.DependencyInjection;
using shoppingkart_ui_backend.infrastructure.Persistance;
using shoppingkart_ui_backend.infrastructure.Authentication;
using shoppingkart_ui_backend.application.Authentication.Common.Interface.Authentication;
using shoppingkart_ui_backend.application.Authentication.Common.Interface.Persistance;

namespace shoppingkart_ui_backend.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
