using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AplusCurator.Models;

namespace AplusCurator.Migrations
{
    [DbContext(typeof(InstructorDbContext))]
    [Migration("20161107230059_UpdatedAttendance")]
    partial class UpdatedAttendance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AplusCurator.Models.Instructor", b =>
                {
                    b.Property<int?>("InstructorId")
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

                    b.Property<DateTime?>("EmploymentStartDate")
                        .IsRequired();

                    b.Property<DateTime?>("EmploymentTerminationDate");

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

                    b.Property<int?>("Role")
                        .IsRequired();

                    b.Property<int?>("Status")
                        .IsRequired();

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("AplusCurator.Models.InstructorAttendance", b =>
                {
                    b.Property<int>("InstructorAttendanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("Date");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("Time");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("Time");

                    b.Property<int?>("InstructorId")
                        .IsRequired();

                    b.HasKey("InstructorAttendanceId");

                    b.ToTable("InstructorsAttendance");
                });
        }
    }
}
