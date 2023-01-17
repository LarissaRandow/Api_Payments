using Core.Entities;
using Core.Interfaces.IRepository;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        IEnumerable<User> users = new List<User> 
        {
            new User { Id = Guid.Parse("591c8eed-8b2c-4eae-80b6-68757bcceb0b"), Name = "Alberto Quintero", A_Grid = "Luz", B_Grid = "Água", C_Grid = "Internet"},
            new User { Id = Guid.Parse("8d4b453d-2a1d-4e30-be9f-32f7333349bc"), Name = "Alicia Cardin", A_Grid = "Água", B_Grid = "Internet", C_Grid = "Luz"},
            new User { Id = Guid.Parse("cda16fde-2549-401f-a821-8228e4b2d5b7"), Name = "Amandio Igrejas", A_Grid = "Internet", B_Grid = "Luz", C_Grid = "Água"}
        };

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(users);
        }

        public async Task<User> GetById(Guid id)
        {
            User user = users.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }
    }
}
