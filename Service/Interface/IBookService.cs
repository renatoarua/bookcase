using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBookService
    {
        Task<TabBook> bookTake(int id);
        Task<IEnumerable<TabBook>> booksTake(string username);
        Task<bool> bookSave(TabBook book);
        Task<bool> bookUpdate(TabBook book, int userId);
        Task<bool> bookDelete(int bookId, int userId);
    }
}
