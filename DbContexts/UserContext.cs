using Microsoft.EntityFrameworkCore;
using PlayersWallet.Model;

namespace PlayersWallet.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
