using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ServiceRepositoryImpl: BaseRepositoryImpl<Service>, IServiceRepository
    {
        public ServiceRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
