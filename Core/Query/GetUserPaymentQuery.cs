using Core.Entities;
using MediatR;

namespace Core.Query
{
    public class GetUserPaymentQuery : IRequest<IEnumerable<IEnumerable<Payment>>>
    {
        public Guid UserId { get; set; }

        public GetUserPaymentQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
