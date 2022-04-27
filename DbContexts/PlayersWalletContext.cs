using Microsoft.EntityFrameworkCore;
using PlayersWallet.Model;

namespace PlayersWallet.DbContexts
{
    public class PlayersWalletContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public PlayersWalletContext(DbContextOptions<PlayersWalletContext> options)
            : base(options)
        {
        }
    }
}
