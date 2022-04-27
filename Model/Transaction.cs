using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }
    }
}
