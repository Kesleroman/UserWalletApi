using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayersWallet.Model;
using PlayersWallet.Repositories;
using System.Collections.Generic;

namespace PlayersWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly object transactionLock = new();
        private readonly ITransactionRepository repository;
        private readonly IMapper mapper;

        public TransactionController(ITransactionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("transactions/{username}")]
        public ActionResult<IEnumerable<Transaction>> GetTransactions(string username)
        {
            var transactions = repository.GetAllTransactions(username);
            if (transactions is null)
                return NotFound();

            var transactionsResult = mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return Ok(transactionsResult);
        }

        [HttpPost("register")]
        public ActionResult<bool> RegisterTransaction(Transaction transaction)
        {
            lock (transactionLock)
            {
                var result = repository.RegisterTransaction(transaction);
                return result ? Ok(result) : BadRequest(result);
            }
        }
    }
}
