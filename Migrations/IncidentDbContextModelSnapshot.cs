using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using USTVA.Entities;

namespace USTVA.Migrations
{
    [DbContext(typeof(IncidentDbContext))]
    partial class IncidentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("USTVA.Entities.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("CommercialLicense");

                    b.Property<string>("Gender");

                    b.Property<string>("Race");

                    b.Property<string>("State");

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("USTVA.Entities.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alcohol");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<int?>("DriverId");

                    b.Property<string>("Fatal");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("SeatBelts");

                    b.Property<int?>("VehicleId");

                    b.Property<int?>("ViolationId");

                    b.HasKey("IncidentId");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("ViolationId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("USTVA.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("CommercialVehicle");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("Type");

                    b.Property<int>("Year");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("USTVA.Entities.Violation", b =>
                {
                    b.Property<int>("ViolationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArrestType");

                    b.Property<string>("Article");

                    b.Property<string>("Charge");

                    b.Property<int>("ViolationType");

                    b.HasKey("ViolationId");

                    b.ToTable("Violation");
                });

            modelBuilder.Entity("USTVA.Entities.Incident", b =>
                {
                    b.HasOne("USTVA.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("USTVA.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.HasOne("USTVA.Entities.Violation", "Violation")
                        .WithMany()
                        .HasForeignKey("ViolationId");
                });
        }
    }
}
