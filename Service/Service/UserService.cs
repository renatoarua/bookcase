using Repository.Interface;
using Repository.Models;
using Service.Interface;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TabUser> authUser(AuthUser authUser)
        {
            return await _userRepository.authUser(authUser);
        }

        public async Task<bool> userDelete(int id)
        {
            var user = await _userRepository.userTakeById(id);

            if(user == null) return false;

            return await _userRepository.userDelete(user);
        }

        public async Task<bool> userSave(TabUser user)
        {
            var userByUsername = await _userRepository.userTakeByUsername(user.UserName);
            if (userByUsername != null) return false;

            var userByEmail = await _userRepository.userTakeByEmail(user.UserEmail);
            if (userByEmail != null) return false;

            return await _userRepository.userSave(user);
        }

        public async Task<TabUser> userTake(int id)
        {
            var user =  await _userRepository.userTakeById(id);

            if(user != null) user.UserPassword = string.Empty;

            return user;
        }

        public async Task<bool> userUpdate(TabUser user)
        {
            var oldUser = await _userRepository.userTakeById(user.UserId);

            if (oldUser == null) return false;

            user.UserPassword = oldUser.UserPassword;
            return await _userRepository.userUpdate(user);
        }
    }
}
