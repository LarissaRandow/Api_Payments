using Core.Entities;
using MediatR;

namespace Core.Query
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public GetAllUsersQuery()
        {
        }
    }
}
