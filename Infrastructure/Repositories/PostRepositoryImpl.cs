using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class PostRepositoryImpl
        : BaseRepositoryImpl<Post>, IPostRepository
    {
        public PostRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
