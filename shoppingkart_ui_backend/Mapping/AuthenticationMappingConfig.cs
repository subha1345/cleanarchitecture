using Mapster;
using shoppingkart_ui_backend.application.Services.Authentication.Common;
using shoppingkart_ui_backend.contract.Authentication;

namespace shoppingkart_ui_backend.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
