using Repository.Models;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<TabUser> userTake(int id);
        Task<bool> userSave(TabUser user);
        Task<bool> userUpdate(TabUser user);
        Task<bool> userDelete(int id);
        Task<TabUser> authUser(AuthUser authUser);
    }
}
