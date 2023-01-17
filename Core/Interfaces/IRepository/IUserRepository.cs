using Core.Entities;

namespace Core.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
    }
}
