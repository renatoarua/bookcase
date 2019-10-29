using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookcaseContext _bookcaseContext;
        public BookRepository(BookcaseContext bookcaseContext)
        {
            _bookcaseContext = bookcaseContext;
        }

        public async Task<bool> bookDelete(TabBook book)
        {
            _bookcaseContext.TabBook.Remove(book);
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> bookSave(TabBook book)
        {
            _bookcaseContext.TabBook.Add(book);
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TabBook>> booksTake(int userId)
        {
            return await _bookcaseContext.TabBook.Where(book => book.UserId == userId).ToListAsync();
        }

        public async Task<TabBook> bookTake(int id)
        {
            return await _bookcaseContext.TabBook.FindAsync(id);
        }

        public async Task<bool> bookUpdate(TabBook book)
        {
            _bookcaseContext.Entry(book).State = EntityState.Modified;
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }
    }
}
