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
        [HttpPost("delete")]
        public void Delete([FromBody]int id)
        {
            // issue: id not being populated by json body
            _context.Remove(_context.Instructors.Where(w => w.InstructorId == id));
            _context.SaveChanges();
        }

        /// <summary>
        /// http post request for creating a new instructor object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses a json body
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        /// Body must be a single instructor json object
        /// POST api/instructor/create
        [HttpPost("create")]
        public IActionResult CreateFromBody([FromBody]Instructor instructor)
        {
            return CreateInstructor(instructor);
        }

        /// <summary>
        /// http post request for creating a new instructor object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses form data
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        /// Data must be from a form request
        /// POST api/instructor/create
        [HttpPost("create")]
        public IActionResult CreateFromForm(Instructor instructor)
        {
            return CreateInstructor(instructor);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Instructor to 
        /// the Database
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        private IActionResult CreateInstructor(Instructor instructor)
        {
            if (ModelState.IsValid && instructor != null)
            {

                _context.Add(instructor);
                _context.SaveChanges();
            }
            return Json(instructor);
        }
    }
}
