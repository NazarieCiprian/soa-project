﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckerMicroservice.Infrastructure;

namespace TruckerMicroservice.Migrations
{
    [DbContext(typeof(TruckerDbContext))]
    [Migration("20210125121612_CREATE_TRUCKER_RELATED_ENTITIES")]
    partial class CREATE_TRUCKER_RELATED_ENTITIES
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TruckerMicroservice.Domain.FreightsRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("Payment")
                        .HasColumnType("int")
                        .HasColumnName("Payment");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<int>("TruckerId")
                        .HasColumnType("int")
                        .HasColumnName("TruckerId");

                    b.HasKey("Id");

                    b.ToTable("FREIGHT_REGISTER");
                });

            modelBuilder.Entity("TruckerMicroservice.Domain.TruckerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("TruckingCompany")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TruckingCompany");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("TRUCKER");
                });
#pragma warning restore 612, 618
        }
    }
}
