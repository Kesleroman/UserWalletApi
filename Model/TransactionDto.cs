using System;

namespace PlayersWallet.Model
{
    public class TransactionDto
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
    }
}
