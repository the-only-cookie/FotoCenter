using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class CategoryRepositoryImpl : BaseRepositoryImpl<Category>, ICategoryRepository
    {
        public CategoryRepositoryImpl(AppContext context)
            : base(context)
        { 

        }
    }
}
