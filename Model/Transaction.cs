using System;

namespace PlayersWallet.Model
{
    public enum TransactionType
    {
        Deposit = 0,
        Stake = 1,
        Win = 2
    }

    public class Transaction
    {
        public Guid Id { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }
    }
}
