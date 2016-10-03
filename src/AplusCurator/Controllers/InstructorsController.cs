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
    public class InstructorsController : Controller
    {
        private InstructorDbContext _context;

        public InstructorsController(InstructorDbContext DbContex)
        {
            this._context = DbContex;
        }
        
        // GET: api/instructors
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = new JsonResult(_context.Instructors.ToList());
            return result;
        }

        // GET api/instructors/5
        [HttpGet("id/{id}")]
        public JsonResult GetById(int id)
        {
            var result = new JsonResult(_context.Instructors.ToList().Where(w => w.InstructorId == id));
            return result;
        }
        // GET api/instructors/name/John
        [HttpGet("name/{name}")]
        public JsonResult GetByName(string name)
        {
            var result = new JsonResult(_context.Instructors.ToList().Where(w => w.FirstName.ToUpper().Contains(name.ToUpper()) || w.LastName.ToUpper().Contains(name.ToUpper())) );
            return result;
        }
        // GET api/instructors/role/1
        [HttpGet("role/{role}")]
        public JsonResult GetByRole(int role)
        {
            var result = new JsonResult(_context.Instructors.ToList().Where(w => w.Role == role));
            return result;
        }
        // GET api/instructors/status/1
        [HttpGet("status/{status}")]
        public JsonResult GetByStatus(int status)
        {
            var result = new JsonResult(_context.Instructors.ToList().Where(w => w.Status == status));
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
    }
}
