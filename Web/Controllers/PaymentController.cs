using Core.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api;

namespace Web.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var command = new GetUserPaymentQuery(userId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
