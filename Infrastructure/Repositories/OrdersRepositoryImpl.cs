using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class OrdesRepositoryImpl
        : BaseRepositoryImpl<Post>, IPostRepository
    {
        public OrdesRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
