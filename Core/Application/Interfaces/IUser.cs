using Domain.Entities;

namespace Application.interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();

        public User GetUserById(int id);
    }
}