using Core.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api;

namespace Web.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllUsersQuery();
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
