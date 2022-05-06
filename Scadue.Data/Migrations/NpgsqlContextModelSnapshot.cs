﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scadue.Data;

namespace Scadue.Data.Migrations
{
    [DbContext(typeof(NpgsqlContext))]
    partial class NpgsqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Scadue.Data.Models.AdministrativeUnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AdminLevel")
                        .HasColumnType("integer");

                    b.Property<float>("CenterLatitude")
                        .HasColumnType("real");

                    b.Property<float>("CenterLongitude")
                        .HasColumnType("real");

                    b.Property<string>("ISO3166")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentAdminUnitId")
                        .HasColumnType("integer");

                    b.Property<string>("Place")
                        .HasColumnType("text");

                    b.Property<int>("Population")
                        .HasColumnType("integer");

                    b.Property<string>("UnitCoordinates")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentAdminUnitId");

                    b.ToTable("AdministrativeUnits");
                });

            modelBuilder.Entity("Scadue.Data.Models.AdministrativeUnitEntity", b =>
                {
                    b.HasOne("Scadue.Data.Models.AdministrativeUnitEntity", "ParentAdministrativeUnit")
                        .WithMany("ChildUnits")
                        .HasForeignKey("ParentAdminUnitId");

                    b.Navigation("ParentAdministrativeUnit");
                });

            modelBuilder.Entity("Scadue.Data.Models.AdministrativeUnitEntity", b =>
                {
                    b.Navigation("ChildUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
