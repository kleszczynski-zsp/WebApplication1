﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models.DB;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240415111728_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.DB.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"), 1L, 1);

                    b.Property<int>("NazwaMarki")
                        .HasColumnType("int");

                    b.HasKey("MarkaId");

                    b.ToTable("Marki");
                });

            modelBuilder.Entity("WebApplication1.Models.DB.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"), 1L, 1);

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<string>("NazwaModelu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelId");

                    b.HasIndex("MarkaId");

                    b.ToTable("Modele");
                });

            modelBuilder.Entity("WebApplication1.Models.DB.Model", b =>
                {
                    b.HasOne("WebApplication1.Models.DB.Marka", "Marka")
                        .WithMany("ModelList")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("WebApplication1.Models.DB.Marka", b =>
                {
                    b.Navigation("ModelList");
                });
#pragma warning restore 612, 618
        }
    }
}