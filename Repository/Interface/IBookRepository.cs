using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookRepository
    {
        Task<TabBook> bookTake(int id);
        Task<IEnumerable<TabBook>> booksTake(int userId);
        Task<bool> bookSave(TabBook book);
        Task<bool> bookUpdate(TabBook book);
        Task<bool> bookDelete(TabBook book);
    }
}
