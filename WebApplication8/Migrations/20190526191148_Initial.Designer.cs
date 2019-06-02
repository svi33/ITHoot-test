﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication8.Data;

namespace WebApplication8.Migrations
{
    [DbContext(typeof(CProjectContext))]
    [Migration("20190526191148_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication8.Models.Coder", b =>
                {
                    b.Property<int>("CoderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoderInfo");

                    b.Property<string>("Name");

                    b.HasKey("CoderID");

                    b.ToTable("Coder");
                });

            modelBuilder.Entity("WebApplication8.Models.CoderProject", b =>
                {
                    b.Property<int>("CoderProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoderID");

                    b.Property<int>("ProjectID");

                    b.HasKey("CoderProjectID");

                    b.HasIndex("CoderID");

                    b.HasIndex("ProjectID");

                    b.ToTable("CoderProject");
                });

            modelBuilder.Entity("WebApplication8.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("ProjectID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("WebApplication8.Models.CoderProject", b =>
                {
                    b.HasOne("WebApplication8.Models.Coder", "CoderTo")
                        .WithMany("projects")
                        .HasForeignKey("CoderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication8.Models.Project", "ProjectTo")
                        .WithMany("coders")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
