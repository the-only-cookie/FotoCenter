using Domain.Models;
using Domain.Models.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public abstract class BaseRepositoryImpl<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        protected AppContext _context;

        public BaseRepositoryImpl(AppContext context)
        {
            _context = new AppContext();
        }

        public void CreateItem(TModel item)
        {
            _context.Set<TModel>().Add(item);
        }

        public async Task<List<TModel>> GetItemListAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public void RemoveItem(TModel item)
        {
            _context.Set<TModel>().Remove(item);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TModel> TryGetItemByIdAsync(int id)
        {
           return await _context.Set<TModel>().FirstAsync(item => item.Id == id);
        }

        public TModel UpdateItem(TModel item)
        {
            _context.Set<TModel>().AddOrUpdate(item);
            return item;
        }
    }
}
