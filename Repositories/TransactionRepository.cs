using Microsoft.EntityFrameworkCore;
using PlayersWallet.DbContexts;
using PlayersWallet.Model;
using System.Collections.Generic;
using System.Linq;

namespace PlayersWallet.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PlayersWalletContext context;

        public TransactionRepository(PlayersWalletContext transactionContext)
        {
            this.context = transactionContext;
        }

        public IEnumerable<Transaction> GetAllTransactions(string userName)
        {
            var history = context.Users
                .Where(u => u.UserName == userName)
                .Include(u => u.TransactionHistory)
                .FirstOrDefault()
                ?.TransactionHistory;

            return history;
        }

        public bool RegisterTransaction(Transaction transaction)
        {
            var transactionInDb = context.Transactions.Find(transaction.Id);
            if (transactionInDb is not null)
                return true;

            var user = context.Users.Find(transaction.UserId);
            if (user is null)
                return false;

            var success = ChangeBallance(transaction, user);
            if (!success)
                return false;

            user.TransactionHistory.Add(transaction);
            context.SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private static bool ChangeBallance(Transaction transaction, User user)
        {
            var newBalance = transaction.TransactionType switch
            {
                TransactionType.Deposit => user.Balance + transaction.Amount,
                TransactionType.Stake => user.Balance - transaction.Amount,
                TransactionType.Win => user.Balance + transaction.Amount,
                _ => -1
            };

            if (newBalance < 0)
                return false;

            user.Balance = newBalance;
            return true;
        }
    }
}
