using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AplusCurator.Models;

namespace AplusCurator.Migrations.StudentDb
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AplusCurator.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurrentGrade")
                        .IsRequired();

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 99999);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<int?>("Gender")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<int?>("Status");

                    b.Property<string>("SystemInfo")
                        .HasAnnotation("MaxLength", 99999);

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });
        }
    }
}
