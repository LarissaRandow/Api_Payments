using Core.Entities;
using Core.Interfaces.IRepository;
using MediatR;

namespace Core.Query.Handler
{
    public class GetUserPaymentQueryHandler : IRequestHandler<GetUserPaymentQuery, IEnumerable<IEnumerable<Payment>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;

        public GetUserPaymentQueryHandler(IUserRepository userRepository, IPaymentRepository paymentRepository)
        {
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<IEnumerable<Payment>>> Handle(GetUserPaymentQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId).Result;
            var payment = await _paymentRepository.GetUserPayment(user.A_Grid, user.B_Grid, user.C_Grid);
            return payment;
        }
    }
}
