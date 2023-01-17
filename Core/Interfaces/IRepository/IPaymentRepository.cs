using Core.Entities;

namespace Core.Interfaces.IRepository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<IEnumerable<Payment>>> GetUserPayment(string aGrid, string bGrid, string cGrid);
    }
}
