using MediatR;
using shoppingkart_ui_backend.application.Authentication.Common.Interface.Authentication;
using shoppingkart_ui_backend.application.Authentication.Common.Interface.Persistance;
using shoppingkart_ui_backend.application.Services.Authentication.Common;
using shoppingkart_ui_backend.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingkart_ui_backend.application.Authentication.Queries.Login
{
    internal class LoginQueryHandler:IRequestHandler<LoginQuery,AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var Id = new Guid();
            var user = new User { Email = query.Email, Password = query.Password };
            var token = _jwtTokenGenerator.GenerateToken(user.Id, "jit", "sen");
            return new AuthenticationResult(user, token);
        }
    }
}
