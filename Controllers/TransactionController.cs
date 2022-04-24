using Microsoft.AspNetCore.Mvc;
using PlayersWallet.Model;
using System;
using System.Collections.Generic;

namespace PlayersWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions()
        {
            return new Transaction[] 
            { 
                new() { Id = Guid.NewGuid(), Amount = 1.4M }, 
                new() { Id = Guid.NewGuid(), Amount = 10.4M } 
            };
        }

        [HttpPost("register")]
        public bool RegisterTransaction(Transaction transaction)
        {
            return false;
        }
    }
}
