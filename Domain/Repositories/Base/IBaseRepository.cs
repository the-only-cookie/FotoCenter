using Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        Task<List<TModel>> GetItemListAsync();
        Task<TModel> TryGetItemByIdAsync(int id);
        void CreateItem(TModel item);
        TModel UpdateItem(TModel item);
        void RemoveItem(TModel item);
        Task SaveAsync();
    }
}
