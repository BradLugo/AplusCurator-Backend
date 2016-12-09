using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AplusCurator.Models;

namespace AplusCurator.Migrations.ContentDb
{
    [DbContext(typeof(ContentDbContext))]
    [Migration("20161209032806_Content")]
    partial class Content
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AplusCurator.Models.Assessment", b =>
                {
                    b.Property<int>("AssessmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Completed")
                        .HasColumnType("Date");

                    b.Property<string>("PdfPath")
                        .IsRequired();

                    b.Property<string>("RawQuestionScoreList");

                    b.Property<string>("RawQuestionTopicList");

                    b.Property<int>("StudentId");

                    b.HasKey("AssessmentId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("AplusCurator.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LearningplanId");

                    b.Property<string>("RawAssignedPages");

                    b.Property<int>("SectionId");

                    b.HasKey("AssignmentId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("AplusCurator.Models.Learningplan", b =>
                {
                    b.Property<int>("LearningplanId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssessmentId");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("Date");

                    b.Property<int>("StudentId");

                    b.HasKey("LearningplanId");

                    b.ToTable("Learningplans");
                });

            modelBuilder.Entity("AplusCurator.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PathToPages")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });
        }
    }
}
