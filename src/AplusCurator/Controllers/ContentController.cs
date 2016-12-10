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

        [HttpGet("students/id/{id}/learningplans")]
        public IEnumerable<Learningplan> GetLearningplanByStudentId(int id)
        {
            return _context.Learningplans.Where(m => m.StudentId == id);
        }

        [HttpGet("learningplans/id/{id}/assignments")]
        public IEnumerable<Assignment> GetAssignmentsByLearningplanId(int id)
        {
            return _context.Assignments.Where(m => m.LearningplanId == id);
        }


        [HttpGet("students/id/{id}/assessments")]
        public IEnumerable<Assessment> GetAssessmentsByStudentId(int id)
        {
            return _context.Assessments.Where(m => m.StudentId == id);
        }

        [HttpPost("learningplan/body/create")]
        public IActionResult CreateLearningplanFromBody([FromBody]Assessment assessment)
        {
            return CreateLearningplan(assessment);
        }

        [HttpPost("learningplan/form/create")]
        public IActionResult CreateLearningplanFromForm(Assessment assessment)
        {
            return CreateLearningplan(assessment);
        }
        
        private IActionResult CreateLearningplan(Assessment assessment)
        {

            Learningplan lp = new Learningplan();
            lp.AssessmentId = assessment.AssessmentId;
            lp.StudentId = assessment.StudentId;
            lp.DateCreated = DateTime.Now;

            // Validate assessment

            _context.Add(lp);
            _context.SaveChanges();

            // Generate assignments

            var scoresAndTopics = assessment.QuestionScoreData.Zip(assessment.QuestionTopicData, (scores, topics) => new int[] { scores, topics });
            foreach (var scoreAndTopic in scoresAndTopics)
            {
                if (scoreAndTopic[0] < 4)
                {
                    _context.Add(new Assignment
                    {
                        LearningplanId = lp.LearningplanId,
                        AssignedPagesData = new int[] { 1, 2, 3, 4, 5, 6, 7 },
                        SectionId = scoreAndTopic[1]
                    });
                }
                else if (scoreAndTopic[0] < 2)
                {
                    _context.Add(new Assignment
                    {
                        LearningplanId = lp.LearningplanId,
                        AssignedPagesData = new int[] { 1, 2, 6, 7 },
                        SectionId = scoreAndTopic[1]
                    });
                }
            }
            _context.SaveChanges();
            return Json(lp);
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
