using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class RoleRepositoryImpl 
        : BaseRepositoryImpl<Role>, IRoleRepository
    {
        public RoleRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
