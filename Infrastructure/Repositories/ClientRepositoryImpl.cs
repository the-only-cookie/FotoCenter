using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ClientRepositoryImpl 
        : BaseRepositoryImpl<Client>, IClientRepository
    {
        public ClientRepositoryImpl(AppContext context)
            : base(context)
        {

        }
    }
}
