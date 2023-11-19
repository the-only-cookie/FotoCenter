using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class EmployeeRepositoryImpl 
        : BaseRepositoryImpl<Employee>, IEmployeeRepository
    {
        public EmployeeRepositoryImpl(AppContext context)
            : base(context)
        {
        }
    }
}
