using System;

namespace PlayersWallet.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }
    }
}
