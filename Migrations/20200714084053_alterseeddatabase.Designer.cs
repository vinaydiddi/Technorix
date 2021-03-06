﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using newmvccore.Models;

namespace newmvccore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200714084053_alterseeddatabase")]
    partial class alterseeddatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("newmvccore.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("department")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            id = 1,
                            department = 1,
                            email = "diddivinay@gmail.com",
                            name = "vinay"
                        },
                        new
                        {
                            id = 2,
                            department = 2,
                            email = "kalyani@gmail.com",
                            name = "kalyani"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
