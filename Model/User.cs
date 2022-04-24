using System;

namespace PlayersWallet.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public decimal Balance { get; set; }
    }
}
