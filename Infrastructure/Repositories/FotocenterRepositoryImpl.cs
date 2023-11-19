using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class FotocenterRepositoryImpl
        : BaseRepositoryImpl<Fotocenter>, IFotocenterRepository
    {
        public FotocenterRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
