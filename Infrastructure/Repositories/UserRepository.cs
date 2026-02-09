using Application.interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        // Retrieving users

        public List<User> GetAllUsers()
        {
            List<User> _users = _dbContext.Users.ToList();
            return _users;
        }  
        public User GetUserById(int id)
        {
           return _dbContext.Users.FirstOrDefault(c=>c.Id==id);
        }
    }
}