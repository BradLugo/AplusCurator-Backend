using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplusCurator.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AplusCurator.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserDbContext _context;

        public UsersController(UserDbContext Repository)
        {
            this._context = Repository;
        }

        // GET: api/values
        [HttpGet]
        public bool DoesEmailExist(string email)
        {
            return _context.Users.First(user => user.email == email) != null;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetUserByEmailAndPassword(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(_user =>
                _user.email == email && _user.password == password);

            return user == null ? Json(new { Response = "Invalid Login" }) : Json(user);
        }

        // POSTS: api/values
        [HttpGet]
        public bool CheckCredentials(string email, string password)
        {
            return _context.Users.First(user =>
                user.email == email && user.password == password) != null;
        }
    }
}
