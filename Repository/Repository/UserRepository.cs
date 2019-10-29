using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookcaseContext _bookcaseContext;
        public UserRepository(BookcaseContext bookcaseContext)
        {
            _bookcaseContext = bookcaseContext;
        }

        public async Task<bool> userDelete(TabUser user)
        {
            _bookcaseContext.TabUser.Remove(user);
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> userSave(TabUser user)
        {
            _bookcaseContext.TabUser.Add(user);
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<TabUser> userTakeById(int id)
        {
            return await _bookcaseContext.TabUser.FindAsync(id);
        }

        public async Task<TabUser> userTakeByEmail(string email)
        {
            return await _bookcaseContext.TabUser.Where(user => user.UserEmail == email).FirstOrDefaultAsync();
        }

        public async Task<TabUser> userTakeByUsername(string username)
        {
            return await _bookcaseContext.TabUser.Where(user => user.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<bool> userUpdate(TabUser user)
        {
            _bookcaseContext.Entry(user).State = EntityState.Modified;
            await _bookcaseContext.SaveChangesAsync();

            return true;
        }
    }
}
