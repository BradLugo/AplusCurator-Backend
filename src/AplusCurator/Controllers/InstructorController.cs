using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AplusCurator.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AplusCurator.Controllers
{
    [Route("api/[controller]")]
    public class InstructorController : Controller
    {
        private InstructorDbContext _context;

        public InstructorController(InstructorDbContext Repository)
        {
            this._context = Repository;
        }
        
        // GET: api/instructor
        [HttpGet]
        public IEnumerable<Instructor> Get()
        {
            var result = _context.Instructors;
            return result;
        }

        // GET api/instructor/5
        [HttpGet("id/{id}")]
        public IEnumerable<Instructor> GetById(int id)
        {
            var result = _context.Instructors.Where(w => w.InstructorId == id);
            return result;
        }
        // GET api/instructor/name/John
        [HttpGet("name/{name}")]
        public IEnumerable<Instructor> GetByName(string name)
        {
            var result = _context.Instructors.Where(w => w.FirstName.ToUpper().Contains(name.ToUpper()) || w.LastName.ToUpper().Contains(name.ToUpper()));
            return result;
        }
        // GET api/instructor/role/1
        [HttpGet("role/{role}")]
        public IEnumerable<Instructor> GetByRole(int role)
        {
            var result = _context.Instructors.Where(w => w.Role == role);
            return result;
        }
        // GET api/instructor/status/1
        [HttpGet("status/{status}")]
        public IEnumerable<Instructor> GetByStatus(int status)
        {
            var result = _context.Instructors.Where(w => w.Status == status);
            return result;
        }

        // POST api/values
        [HttpPost("delete/{id}")]
        public void Delete([FromBody]int id)
        {
            _context.Remove(_context.Instructors.Where(w => w.InstructorId == id));
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

    }
}
