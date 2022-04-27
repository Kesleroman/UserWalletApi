using PlayersWallet.Model;
using System.Collections.Generic;

namespace PlayersWallet.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions(string userName);

        bool RegisterTransaction(Transaction transaction);

        void SaveChanges();
    }
}
