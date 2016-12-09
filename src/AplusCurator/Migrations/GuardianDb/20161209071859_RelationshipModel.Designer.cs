using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AplusCurator.Models;

namespace AplusCurator.Migrations.GuardianDb
{
    [DbContext(typeof(GuardianDbContext))]
    [Migration("20161209071859_RelationshipModel")]
    partial class RelationshipModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AplusCurator.Models.Guardian", b =>
                {
                    b.Property<int>("GuardianId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 99999);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<string>("MobileNumber")
                        .HasAnnotation("MaxLength", 127);

                    b.Property<DateTime>("MostRecentPayement")
                        .HasColumnType("Date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 127);

                    b.Property<int?>("Role")
                        .IsRequired();

                    b.Property<int?>("Status");

                    b.Property<string>("SystemInfo")
                        .HasAnnotation("MaxLength", 99999);

                    b.HasKey("GuardianId");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("AplusCurator.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DueAmount");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("Date");

                    b.Property<int>("GuardianId");

                    b.Property<double>("PaidAmount");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("Date");

                    b.Property<int>("StudentId");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("AplusCurator.Models.StudentRelation", b =>
                {
                    b.Property<int>("relationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("guardianId");

                    b.Property<int>("studentId");

                    b.HasKey("relationId");

                    b.ToTable("Relations");
                });
        }
    }
}
