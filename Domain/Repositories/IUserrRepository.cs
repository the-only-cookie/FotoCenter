using Domain.Models;
using Domain.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserrRepository
        : IBaseRepository<User>
    {
        Task<User> GetUserrByLoginAsync(string Login);
    }
}
