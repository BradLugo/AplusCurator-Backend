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
    public class StudentsController : Controller
    {
        private StudentDbContext _context;

        public StudentsController(StudentDbContext DbContex)
        {
            this._context = DbContex;
        }

        // GET: api/students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var result =_context.Students.ToList();
            return result;
        }

        // GET api/student/5
        [HttpGet("id/{id}")]
        public IEnumerable<Student> GetById(int id)
        {
            var result =_context.Students.ToList().Where(w => w.StudentId == id);
            return result;
        }
        // GET api/student/name/John
        [HttpGet("name/{name}")]
        public IEnumerable<Student> GetByName(string name)
        {
            var result =_context.Students.ToList().Where(w => w.FirstName.ToUpper().Contains(name.ToUpper()) || w.LastName.ToUpper().Contains(name.ToUpper()));
            return result;
        }

        // GET api/student/status/1
        [HttpGet("status/{status}")]
        public IEnumerable<Student> GetByStatus(int status)
        {
            var result =_context.Students.ToList().Where(w => w.Status == status);
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/students/delete
        [HttpPost("body/delete")]
        public IActionResult DeleteFromBody([FromBody]Student student)
        {
            return DeleteStudent(student);
        }



        // POST api/students/delete
        [HttpPost("form/delete")]
        public IActionResult DeleteFromForm(Student student)
        {
            return DeleteStudent(student);
        }

        private IActionResult DeleteStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                // Throw exception if student doesn't exist
                //_context.Students.Where(w => w.StudentId == student.StudentId).Single();

               _context.Remove(student);

               _context.SaveChanges();
            }
            return Json(student);
        }

        /// <summary>
        /// http post request for creating a new student object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses a json body
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// Body must be a single student json object
        /// POST api/student/create
        [HttpPost("body/update")]
        public IActionResult UpdateFromBody([FromBody]Student student)
        {
            return UpdateStudent(student);
        }

        /// <summary>
        /// http post request for creating a new student object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses form data
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// Data must be from a form request
        /// POST api/student/create
        [HttpPost("form/update")]
        public IActionResult UpdateFromForm(Student student)
        {
            return UpdateStudent(student);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Student to 
        /// the Database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private IActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid && student != null)
            {
               _context.Update(student);
               _context.SaveChanges();
            }
            return Json(student);
        }

        /// <summary>
        /// http post request for creating a new student object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses a json body
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// Body must be a single student json object
        /// POST api/student/create
        [HttpPost("body/create")]
        public IActionResult CreateFromBody([FromBody]Student student)
        {
            return CreateStudent(student);
        }

        /// <summary>
        /// http post request for creating a new student object in the database
        /// this method is one way to reach the creation method and is used to expose
        /// a route that uses form data
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// Data must be from a form request
        /// POST api/student/create
        [HttpPost("form/create")]
        public IActionResult CreateFromForm(Student student)
        {
            return CreateStudent(student);
        }

        /// <summary>
        /// Method used by the Create and CreateFromBody methods to add an Student to 
        /// the Database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid && student != null)
            {
               _context.Add(student);
               _context.SaveChanges();
            }
            return Json(student);
        }

        [HttpGet("current")]
        public IEnumerable<Student> GetStudentsCurrentlyIn()
        {
            var openAttendances = _context.StudentsAttendance.Where(m => !m.Duration.HasValue).ToList();
            List<Student> currentStudents = new List<Student>();
            foreach (var attendance in openAttendances)
            {
                currentStudents.Add(_context.Students.Where(m => attendance.StudentId == m.StudentId).Single());
            }
            return currentStudents;
        }

        [HttpGet("notcurrent")]
        public IEnumerable<Student> GetStudentsNotCurrentlyIn()
        {
            var openAttendances = _context.StudentsAttendance.Where(m => !m.Duration.HasValue).ToList();
            List<Student> currentStudents = _context.Students.ToList();
            foreach (var attendance in openAttendances)
            {
                currentStudents.Remove(_context.Students.Where(m => m.StudentId == attendance.StudentId).Single());
            }
            return currentStudents;
        }

        /// <summary>
        /// Sign in an student from body post request
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("form/signout")]
        public IActionResult StudentSignOutFromForm(Student student)
        {
            return StudentSignOut(student);
        }

        /// <summary>
        /// Sign in an student from form post request
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("body/signout")]
        public IActionResult StudentSignOutFromBody([FromBody]Student student)
        {
            return StudentSignOut(student);
        }

        private IActionResult StudentSignOut(Student student)
        {
            if (ModelState.IsValid && student != null)
            {
                // Check if the student exists or is currently signed in already
                var studentExists = _context.Students.Where(m => m.StudentId == student.StudentId).Single();
                var attendanceExists = _context.StudentsAttendance.Where(m => m.StudentId == student.StudentId && !m.Duration.HasValue).Single();
                attendanceExists.Duration = DateTime.Now.TimeOfDay - attendanceExists.EntryTime;

                _context.Update(attendanceExists);
                _context.SaveChanges();
                return Json(attendanceExists);
            }
            return Json(student);
        }

        /// <summary>
        /// Sign in an student from body post request
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("form/signin")]
        public IActionResult StudentSignInFromForm(Student student)
        {
            return StudentSignIn(student);
        }

        /// <summary>
        /// Sign in an student from form post request
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("body/signin")]
        public IActionResult StudentSignInFromBody([FromBody]Student student)
        {
            return StudentSignIn(student);
        }

        private IActionResult StudentSignIn(Student student)
        {
            if (ModelState.IsValid && student != null)
            {
                // Check if the student exists or is currently signed in already
                var studentExists = _context.Students.Where(m => m.StudentId == student.StudentId).Single();
                var attendanceExists = _context.StudentsAttendance.Where(m => m.StudentId == student.StudentId && !m.Duration.HasValue);
                if (attendanceExists.Count() == 1)
                {
                    // The student is already signed in
                }
                else
                {
                    _context.Add(new StudentAttendance { StudentId = student.StudentId, EntryTime = DateTime.Now.TimeOfDay, AttendanceDate = DateTime.Now });
                    _context.SaveChanges();
                    return Json(attendanceExists);
                }
            }
            return Json(student);
        }
    }
}
