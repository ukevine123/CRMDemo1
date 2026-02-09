using Domain.Entities;
using Application.interfaces;
namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUser _user;

        //constructor

        public UserService(IUser user)
        {
            _user = user;
        }
       public List<User> GetAllUsers()
       {
          List<User> _users = _user.GetAllUsers();
          return _users;
       }


        public User GetUserById(int id)
        {
           return _user.GetUserById(id);
        }
    }
}