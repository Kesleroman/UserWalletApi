using Microsoft.AspNetCore.Mvc;
using PlayersWallet.Model;
using PlayersWallet.Repositories;
using System.Collections.Generic;
using System.Data;

namespace PlayersWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return repository.GetAllUsers();
        }

        [HttpGet("{userName}/balance")]
        public ActionResult<decimal> GetUserBalance(string userName)
        {
            var foundUser = repository.GetUserByName(userName);

            if (foundUser is null)
                return NotFound("User not found");

            return Ok(foundUser.Balance);
        }

        [HttpPost]
        public ActionResult<User> RegisterUser(string userName)
        {
            var user = new User
            {
                UserName = userName,
                Balance = 0
            };

            try
            {
                repository.AddUser(user);
                repository.SaveChanges();
            }
            catch (DuplicateNameException)
            {
                return BadRequest($"User with the username '{userName}' already exists.");
            }

            return CreatedAtAction("RegisterUser", new { userName }, user);
        }
    }
}
