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
        private GuardianDbContext _guardian_context;
        private StudentDbContext _student_context;

        public GuardiansController(GuardianDbContext GuardianContex, StudentDbContext StudentContext)
        {
            this._guardian_context = GuardianContex;
            this._student_context = StudentContext;
        }

        // GET: api/guardians
        [HttpGet]
        public IEnumerable<Guardian> Get()
        {
            var result =_guardian_context.Guardians.ToList();
            return result;
        }

        // GET api/student/5
        [HttpGet("id/{id}")]
        public IEnumerable<Guardian> GetById(int id)
        {
            var result =_guardian_context.Guardians.ToList().Where(w => w.GuardianId == id);
            return result;
        }
        // GET api/student/name/John
        [HttpGet("name/{name}")]
        public IEnumerable<Guardian> GetByName(string name)
        {
            var result =_guardian_context.Guardians.ToList().Where(w => w.FirstName.ToUpper().Contains(name.ToUpper()) || w.LastName.ToUpper().Contains(name.ToUpper()));
            return result;
        }
        // GET api/student/role/1
        [HttpGet("role/{role}")]
        public IEnumerable<Guardian> GetByRole(int role)
        {
            var result =_guardian_context.Guardians.ToList().Where(w => w.Role == role);
            return result;
        }
        // GET api/student/status/1
        [HttpGet("status/{status}")]
        public IEnumerable<Guardian> GetByStatus(int status)
        {
            var result =_guardian_context.Guardians.ToList().Where(w => w.Status == status);
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
                //_guardian_context.Guardians.Where(w => w.GuardianId == guardian.GuardianId).Single();

               _guardian_context.Remove(guardian);

               _guardian_context.SaveChanges();
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

               _guardian_context.Add(guardian);
               _guardian_context.SaveChanges();
            }
            return Json(guardian);
        }


        [HttpGet("payments/date/{year}/{month}/{day}")]
        public IEnumerable<Invoice> GetAllInvoicesByYearMonthDay(int year, int month, int day)
        {
            return GetAllInvoices(year, month, day);
        }
        [HttpGet("payments/date/{year}/{month}")]
        public IEnumerable<Invoice> GetAllInvoicesByYearMonth(int year, int month)
        {
            return GetAllInvoices(year, month, null);
        }
        [HttpGet("payments/date/{year}")]
        public IEnumerable<Invoice> GetAllInvoicesByYear(int year)
        {
            return GetAllInvoices(year, null, null);
        }
        private IEnumerable<Invoice> GetAllInvoices(int year, int? month, int? day)
        {
            if (day.HasValue)
                return _guardian_context.Invoices.Where(m => m.DueDate.Year == year && m.DueDate.Month == month && m.DueDate.Day == day);
            else if (month.HasValue)
                return _guardian_context.Invoices.Where(m => m.DueDate.Year == year && m.DueDate.Month == month);
            else
                return _guardian_context.Invoices.Where(m => m.DueDate.Year == year);
        }

        [HttpGet("payments/guardian/id/{id}")]
        public IEnumerable<Invoice> GetAllInvoicesByGuardian(int id)
        {
            return _guardian_context.Invoices.Where(m => m.GuardianId == id);
        }

        [HttpGet("payments/invoice/id/{id}")]
        public IEnumerable<Invoice> GetAllInvoicesById(int id)
        {
            return _guardian_context.Invoices.Where(m => m.InvoiceId == id);
        }


        [HttpGet("payments/collected")]
        public double GetTotalCollectedThisMonth()
        {
            return _guardian_context.Invoices.Sum(m => m.PaidAmount);
        }
        [HttpGet("payments/projected")]
        public double GetTotalProjectedThisMonth()
        {
            return _guardian_context.Invoices.Sum(m => m.DueAmount);
        }

        [HttpGet("payments/due")]
        public IEnumerable<Invoice> GetOutstandingInvoices()
        {
            return _guardian_context.Invoices.Where(m => m.DueAmount > m.PaidAmount);
        }


        [HttpGet("id/{id}/students")]
        public IEnumerable<Student> GetStudentsUnderGuardian(int id)
        {
            return getStudentsUnderGuardian(id);
        }

        [HttpPost("payments/generate")]
        public IEnumerable<Invoice> GenerateMonthyInvoices()
        {
            var invoices = new List<Invoice>();
            var guardians = new List<Guardian>();

            double total = 0.0;

            guardians = _guardian_context.Guardians.ToList();

            foreach (var guardian in guardians)
            {

                foreach (var student in getStudentsUnderGuardian(guardian.GuardianId))
                {
                    if (student.CurrentGrade < 6)
                    {
                        total = 250.00;
                    }
                    else if (student.CurrentGrade < 8)
                    {
                        total = 280.00;
                    }
                    else
                    {
                        total = 300.00;
                    }
                    invoices.Add(new Invoice
                    {
                        DueAmount = total,
                        DueDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 15),
                        GuardianId = guardian.GuardianId,
                        PaidAmount = 0.0,
                        StudentId = student.StudentId,
                        PaidDate = null
                    });
                }

            }
            foreach (var invoice in invoices)
            {
                _guardian_context.Add(invoice);
            }
            _guardian_context.SaveChanges();
            return invoices;
        }

        private List<Student> getStudentsUnderGuardian(int guardianId)
        {
            var relations = _guardian_context.Relations.Where(m => m.guardianId == guardianId).ToList();

            return _student_context.Students.Where(m => relations.Find(n => n.studentId == m.StudentId) != null).ToList();
        }
    }
}