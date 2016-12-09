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
    public class GuardiansController : Controller
    {
        private GuardianDbContext _context;

        public GuardiansController(GuardianDbContext DbContex)
        {
            this._context = DbContex;
        }

        // GET: api/student
        [HttpGet]
        public IEnumerable<Guardian> Get()
        {
            var result = _context.Guardians.ToList();
            return result;
        }

        // GET api/student/5
        [HttpGet("id/{id}")]
        public IEnumerable<Guardian> GetById(int id)
        {
            var result = _context.Guardians.ToList().Where(w => w.GuardianId == id);
            return result;
        }
        // GET api/student/name/John
        [HttpGet("name/{name}")]
        public IEnumerable<Guardian> GetByName(string name)
        {
            var result = _context.Guardians.ToList().Where(w => w.FirstName.ToUpper().Contains(name.ToUpper()) || w.LastName.ToUpper().Contains(name.ToUpper()));
            return result;
        }
        // GET api/student/role/1
        [HttpGet("role/{role}")]
        public IEnumerable<Guardian> GetByRole(int role)
        {
            var result = _context.Guardians.ToList().Where(w => w.Role == role);
            return result;
        }
        // GET api/student/status/1
        [HttpGet("status/{status}")]
        public IEnumerable<Guardian> GetByStatus(int status)
        {
            var result = _context.Guardians.ToList().Where(w => w.Status == status);
            return result;
        }

        // POST api/guardians/delete
        [HttpPost("body/delete")]
        public IActionResult DeleteFromBody([FromBody]Guardian guardian)
        {
            return DeleteGuardian(guardian);
        }



        // POST api/guardians/delete
        [HttpPost("form/delete")]
        public IActionResult DeleteFromForm(Guardian guardian)
        {
            return DeleteGuardian(guardian);
        }

        private IActionResult DeleteGuardian(Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                // Throw exception if guardian doesn't exist
                //_context.Guardians.Where(w => w.GuardianId == guardian.GuardianId).Single();

                _context.Remove(guardian);

                _context.SaveChanges();
            }
            return Json(guardian);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Guardian to 
        /// the Database
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        private IActionResult UpdateGuardian(Guardian guardian)
        {
            if (ModelState.IsValid && guardian != null)
            {
                _context.Update(guardian);
                _context.SaveChanges();
            }
            return Json(guardian);
        }

        /// <summary>
        /// http post request for creating a new guardian object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses a json body
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        /// Body must be a single guardian json object
        /// POST api/student/create
        [HttpPost("body/update")]
        public IActionResult UpdateFromBody([FromBody]Guardian guardian)
        {
            return UpdateGuardian(guardian);
        }

        /// <summary>
        /// http post request for creating a new guardian object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses form data
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        /// Data must be from a form request
        /// POST api/student/create
        [HttpPost("form/update")]
        public IActionResult UpdateFromForm(Guardian guardian)
        {
            return UpdateGuardian(guardian);
        }

        /// <summary>
        /// http post request for creating a new guardian object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses a json body
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        /// Body must be a single guardian json object
        /// POST api/guardian/create
        [HttpPost("body/create")]
        public IActionResult CreateFromBody([FromBody]Guardian guardian)
        {
            return CreateGuardian(guardian);
        }

        /// <summary>
        /// http post request for creating a new guardian object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses form data
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        /// Data must be from a form request
        /// POST api/guardian/create
        [HttpPost("form/create")]
        public IActionResult CreateFromForm(Guardian guardian)
        {
            return CreateGuardian(guardian);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Guardian to 
        /// the Database
        /// </summary>
        /// <param name="guardian"></param>
        /// <returns></returns>
        private IActionResult CreateGuardian(Guardian guardian)
        {
            if (ModelState.IsValid && guardian != null)
            {

                _context.Add(guardian);
                _context.SaveChanges();
            }
            return Json(guardian);
        }
    }
}
