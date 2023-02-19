﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NadmetanjeApp.Data;

#nullable disable

namespace NadmetanjeApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230218193026_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NadmetanjeApp.Models.Nadmetanje", b =>
                {
                    b.Property<int>("NadmetanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NadmetanjeID"));

                    b.Property<int>("CenaPoHektaru")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Krug")
                        .HasColumnType("int");

                    b.HasKey("NadmetanjeID");

                    b.ToTable("Nadmetanja");
                });

            modelBuilder.Entity("NadmetanjeApp.Models.OtvaranjePonude", b =>
                {
                    b.Property<int>("OtvaranjePonudeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OtvaranjePonudeID"));

                    b.Property<int>("NadmetanjeID")
                        .HasColumnType("int");

                    b.HasKey("OtvaranjePonudeID");

                    b.HasIndex("NadmetanjeID");

                    b.ToTable("OtvaranjePonuda");
                });

            modelBuilder.Entity("NadmetanjeApp.Models.OtvaranjePonude", b =>
                {
                    b.HasOne("NadmetanjeApp.Models.Nadmetanje", "Nadmetanje")
                        .WithMany()
                        .HasForeignKey("NadmetanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nadmetanje");
                });
#pragma warning restore 612, 618
        }
    }
}