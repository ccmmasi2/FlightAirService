using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.AirService.AccessData.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240127_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);


            modelBuilder.Entity("Flight.AirService.DTOObjects.Models.Transport", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("FlightCarrier")
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("nvarchar(4)");

                b.Property<int>("FlightNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(4)");

                b.HasKey("ID");

                b.ToTable("Transport");
            });


            modelBuilder.Entity("Flight.AirService.DTOObjects.Models.Journey", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("Client")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<DateTime>("Date")
                    .IsRequired()
                    .HasColumnType("Date");

                b.Property<string>("Origin")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("nvarchar(3)");

                b.Property<string>("Destination")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("nvarchar(3)");

                b.Property<int>("TotalPrice")
                    .IsRequired()
                    .HasColumnType("decimal");

                b.HasKey("ID");

                b.ToTable("Journey");
            });

            modelBuilder.Entity("Flight.AirService.DTOObjects.Models.FlightDTL", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<int>("IDTransport")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<int>("IDJourney")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<string>("Origin")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("nvarchar(3)");

                b.Property<string>("Destination")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("nvarchar(3)");

                b.Property<int>("Price")
                    .IsRequired()
                    .HasColumnType("decimal");

                b.HasKey("ID");

                b.HasIndex("IDTransport");

                b.HasIndex("IDJourney");

                b.ToTable("FlightDTL");
            });

            base.BuildTargetModel(modelBuilder);
        }
    }
}
