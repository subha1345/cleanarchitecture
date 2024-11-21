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

namespace shoppingkart_ui_backend.application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var Id = new Guid();
            var user = new User { Email = command.Email, FirstName = command.FirstName, LastName = command.LastName, Password = command.Password };
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResult(user, token);
        }
    }
}
