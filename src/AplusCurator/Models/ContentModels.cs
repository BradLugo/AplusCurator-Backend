using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplusCurator.Models
{
    public class Learningplan
    {
        [Key]
        public int LearningplanId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("AssessmentId")]
        public int AssessmentId { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime DateCreated { get; set; }
    }

    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        public string RawQuestionTopicList { get; set; }
        [NotMapped]
        public int[] QuestionTopicData
        {
            get
            {
                return RawQuestionTopicList.Split(';').Select(m => int.Parse(m)).ToArray();
            }
            set
            {
                RawQuestionTopicList = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }

        public string RawQuestionScoreList { get; set; }

        [NotMapped]
        public int[] QuestionScoreData
        {
            get
            {
                return RawQuestionScoreList.Split(';').Select(m => int.Parse(m)).ToArray();
            }
            set
            {
                RawQuestionScoreList = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }

        [Required]
        public string PdfPath { get; set; }

        [Column(TypeName = "Date"), Required]
        public DateTime Completed { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
    }

    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [ForeignKey("SectionId")]
        public int SectionId { get; set; }

        [ForeignKey("LearningplanId")]
        public int LearningplanId { get; set; }

        public string RawAssignedPages { get; set; }
        [NotMapped]
        public int[] AssignedPagesData
        {
            get
            {
                return RawAssignedPages.Split(';').Select(m => int.Parse(m)).ToArray();
            }
            set
            {
                RawAssignedPages = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }
    }

    public class Section
    {
        [Key]
        public int SectionId { get; set; }

        [Required]
        public string PathToPages { get; set; }

        [Required]
        public string Title { get; set; }
    }


}