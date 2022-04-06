﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using oebb.efi.DataAccess;

#nullable disable

namespace oebb.efi.DataAccess.Migrations
{
    [DbContext(typeof(EfiContext))]
    [Migration("20220406074318_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("oebb.efi.DataAccess.Models.Station", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("SearchTerm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.HasKey("Id");

                    b.ToTable("Station", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Wien",
                            SearchTerm = "Wien",
                            Shortcut = "W"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Salzburg",
                            SearchTerm = "Salzburg",
                            Shortcut = "S"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Linz",
                            SearchTerm = "Linz",
                            Shortcut = "L"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
