using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        Task<TabUser> userTakeById(int id);
        Task<TabUser> userTakeByUsername(string username);
        Task<TabUser> userTakeByEmail(string email);
        Task<bool> userSave(TabUser user);
        Task<bool> userUpdate(TabUser user);
        Task<bool> userDelete(TabUser user);
    }
}
