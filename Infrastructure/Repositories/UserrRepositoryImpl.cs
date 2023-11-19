using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserrRepositoryImpl
        : BaseRepositoryImpl<User>, IUserrRepository
    {
        public UserrRepositoryImpl(AppContext context)
            : base(context)
        {
        }

        public async Task<User> GetUserrByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(userr => userr.Login == login);
        }
    }
}
