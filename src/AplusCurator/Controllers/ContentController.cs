using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplusCurator.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AplusCurator.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private ContentDbContext _context;
        private StudentDbContext _student_context;

        public ContentController(ContentDbContext content_context, StudentDbContext student_context)
        {
            this._context = content_context;
            this._student_context = student_context;
        }

        [HttpPost("learningplan/body/create")]
        public IActionResult CreateLearningplanFromBody([FromBody]Learningplan learningplan)
        {
            return CreateLearningplan(learningplan);
        }

        [HttpPost("learningplan/form/create")]
        public IActionResult CreateLearningplanFromForm(Learningplan learningplan)
        {
            return CreateLearningplan(learningplan);
        }
        
        private JsonResult CreateLearningplan(Learningplan learningplan)
        {
            // Create the learning plan object here
            if (ModelState.IsValid)
            {
                ValidateLearningplan(learningplan);
                _context.Learningplans.Add(learningplan);
            }
            return Json(learningplan);
        }

        private void ValidateLearningplan(Learningplan learningplan)
        {
            var sections = _context.Sections.ToList();
            var planAssignments = _context.Assignments.Where(m => m.LearningplanId == learningplan.LearningplanId).ToList();

            if (!planAssignments.Any()) // Make sure there are assignments in the plan
            {
                // ERR match
            }

            foreach (var assign in planAssignments) 
            {
                if (! _context.Sections.Any(m => m.SectionId == assign.SectionId)) // Make sure that the assignments have valid section numbers
                {
                    // ERR match
                    // That section does not exist
                }
                if (assign.AssignedPagesData.Length <= 0) // make sure the assignments have a valid length
                {
                    // ERR Assignment length is 0
                }
            }

            if (!_student_context.Students.Any(m => m.StudentId == learningplan.StudentId)) // Make sure that the student exists
            {
                // ERR match
                // That student does not exist
            }
        }
    }
}
