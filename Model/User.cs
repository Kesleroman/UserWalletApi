using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayersWallet.Model
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
    }
}
