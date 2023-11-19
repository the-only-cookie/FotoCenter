using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ProvisionOfServicesRepositoryImpl
        : BaseRepositoryImpl<ProvisionOfServices>, IProvisionOfServicesRepository 
    {
        public ProvisionOfServicesRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
