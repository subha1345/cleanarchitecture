
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using shoppingkart_ui_backend.application.Authentication.Commands.Register;
using shoppingkart_ui_backend.application.Authentication.Queries.Login;
using shoppingkart_ui_backend.application.Services.Authentication.Common;
using shoppingkart_ui_backend.contract.Authentication;
using shoppingkart_ui_backend.Filters;

namespace shoppingkart_ui_backend.Controllers
{
    [ApiController]
    [Route("auth")]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator, IMapper imapper)
        {
            _mapper = imapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var command = _mapper.Map<RegisterCommand>(request);
            AuthenticationResult authResult = await _mediator.Send(command);
            //var response = new AuthenticationResponse(authResult.Id, 
            //                                            authResult.FirstName, 
            //                                            authResult.LastName, 
            //                                            authResult.Email, 
            //                                            authResult.Token);
            var response = _mapper.Map<AuthenticationResult>(authResult);

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginRequest>(request);
            var authResult = await _mediator.Send(query);
            //var response = new AuthenticationResponse(authResult.Id, 
            //                                            authResult.FirstName, 
            //                                            authResult.LastName, 
            //                                            authResult.Email, 
            //                                            authResult.Token);
            var response = _mapper.Map<AuthenticationResult>(authResult);
            return Ok(response);
        }
    }
}
