using PlayersWallet.Model;
using System.Collections.Generic;

namespace PlayersWallet.Repositories
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);

        IEnumerable<User> GetAllUsers();

        void AddUser(User User);

        void SaveChanges();
    }
}
