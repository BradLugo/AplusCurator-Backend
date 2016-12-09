using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AplusCurator.Models;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AplusCurator.Controllers
{
    [Route("api/[controller]")]
    public class InstructorsController : Controller
    {
        private InstructorDbContext _context;

        public InstructorsController(InstructorDbContext Repository)
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

        // POST api/instructors/delete
        [HttpPost("body/delete")]
        public IActionResult DeleteFromBody([FromBody]Instructor instructor)
        {
            return DeleteInstructor(instructor);
        }



        // POST api/instructors/delete
        [HttpPost("form/delete")]
        public IActionResult DeleteFromForm(Instructor instructor)
        {
            return DeleteInstructor(instructor);
        }

        private IActionResult DeleteInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                // Throw exception if instructor doesn't exist
                //_context.Instructors.Where(w => w.InstructorId == instructor.InstructorId).Single();

                _context.Remove(instructor);

                _context.SaveChanges();
            }
            return Json(instructor);
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
        [HttpPost("body/update")]
        public IActionResult UpdateFromBody([FromBody]Instructor instructor)
        {
            return UpdateInstructor(instructor);
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
        [HttpPost("form/update")]
        public IActionResult UpdateFromForm(Instructor instructor)
        {
            return UpdateInstructor(instructor);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Instructor to 
        /// the Database
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        private IActionResult UpdateInstructor(Instructor instructor)
        {
            if (ModelState.IsValid && instructor != null)
            {

                _context.Update(instructor);
                _context.SaveChanges();
            }
            return Json(instructor);
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
        [HttpPost("body/create")]
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
        [HttpPost("form/create")]
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

        [HttpGet("current")]
        public IEnumerable<Instructor> GetInstructorsCurrentlyIn()
        {
            var openAttendances = _context.InstructorsAttendance.Where(m => !m.Duration.HasValue).ToList();
            List<Instructor> currentInstructors = new List<Instructor>();
            foreach (var attendance in openAttendances)
            {
                currentInstructors.Add(_context.Instructors.Where(m => attendance.InstructorId == m.InstructorId).Single());
            }
            return currentInstructors;
        }

        [HttpGet("notcurrent")]
        public IEnumerable<Instructor> GetInstructorsNotCurrentlyIn()
        {
            var openAttendances = _context.InstructorsAttendance.Where(m => !m.Duration.HasValue).ToList();
            List<Instructor> currentInstructors = _context.Instructors.ToList();
            foreach (var attendance in openAttendances)
            {
                currentInstructors.Remove(_context.Instructors.Where(m => m.InstructorId == attendance.InstructorId).Single());
            }
            return currentInstructors;
        }

        /// <summary>
        /// Sign in an instructor from body post request
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        [HttpPost("form/signout")]
        public IActionResult InstructorSignOutFromForm(Instructor instructor)
        {
            return InstructorSignOut(instructor);
        }

        /// <summary>
        /// Sign in an instructor from form post request
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        [HttpPost("body/signout")]
        public IActionResult InstructorSignOutFromBody([FromBody]Instructor instructor)
        {
            return InstructorSignOut(instructor);
        }

        private IActionResult InstructorSignOut(Instructor instructor)
        {
            if (ModelState.IsValid && instructor != null)
            {
                // Check if the instructor exists or is currently signed in already
                var instructorExists = _context.Instructors.Where(m => m.InstructorId == instructor.InstructorId).Single();
                var attendanceExists = _context.InstructorsAttendance.Where(m => m.InstructorId == instructor.InstructorId && !m.Duration.HasValue).Single();
                attendanceExists.Duration = DateTime.Now.TimeOfDay - attendanceExists.EntryTime;

                _context.Update(attendanceExists);
                _context.SaveChanges();
                return Json(attendanceExists);
            }
            return Json(instructor);
        }

        /// <summary>
        /// Sign in an instructor from body post request
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        [HttpPost("form/signin")]
        public IActionResult InstructorSignInFromForm(Instructor instructor)
        {
            return InstructorSignIn(instructor);
        }

        /// <summary>
        /// Sign in an instructor from form post request
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        [HttpPost("body/signin")]
        public IActionResult InstructorSignInFromBody([FromBody]Instructor instructor)
        {
            return InstructorSignIn(instructor);
        }

        private IActionResult InstructorSignIn(Instructor instructor)
        {
            if (ModelState.IsValid && instructor != null)
            {
                // Check if the instructor exists or is currently signed in already
                var instructorExists = _context.Instructors.Where(m => m.InstructorId == instructor.InstructorId).Single();
                var attendanceExists = _context.InstructorsAttendance.Where(m => m.InstructorId == instructor.InstructorId && !m.Duration.HasValue);
                if (attendanceExists.Count() == 1)
                {
                    // The instructor is already signed in
                }
                else
                {
                    _context.Add(new InstructorAttendance { InstructorId = instructor.InstructorId, EntryTime = DateTime.Now.TimeOfDay, AttendanceDate = DateTime.Now });
                    _context.SaveChanges();
                    return Json(attendanceExists);
                }
            }
            return Json(instructor);
        }
    }
}
