using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayersWallet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayersWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
            {
                UserId = Guid.NewGuid(),
                Balance = (decimal) (rng.NextDouble() * 100)
            })
            .ToArray();
        }
    }
}
