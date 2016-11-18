using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AplusCurator.Models;

namespace AplusCurator.Migrations
{
    [DbContext(typeof(InstructorDbContext))]
    partial class InstructorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("AplusCurator.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("EmergencyContactName")
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("EmergencyContactPhone")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<DateTime>("EmploymentStartDate");

                    b.Property<DateTime>("EmploymentTerminationDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("MiddleName")
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("MobilePhoneNumber")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<int>("Role");

                    b.Property<int>("Status");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });
        }
    }
}
