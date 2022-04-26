using Microsoft.EntityFrameworkCore;
using PlayersWallet.DbContexts;
using PlayersWallet.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PlayersWallet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            var sameUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (sameUser is not null)
            {
                throw new DuplicateNameException(nameof(user.UserName));
            }

            _context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserByName(string userName)
        {
            return _context.Users.FirstOrDefault(b => b.UserName == userName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
