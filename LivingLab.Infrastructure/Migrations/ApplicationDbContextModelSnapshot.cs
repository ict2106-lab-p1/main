﻿// <auto-generated />
using System;
using LivingLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LivingLab.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("LivingLab.Domain.Entities.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessoryTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("Date");

                    b.Property<int>("LabId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LabUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("Date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccessoryTypeId");

                    b.HasIndex("LabId");

                    b.ToTable("Accessory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessoryTypeId = 1,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 2,
                            AccessoryTypeId = 1,
                            DueDate = new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 1,
                            LastUpdated = new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 3,
                            AccessoryTypeId = 2,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 4,
                            AccessoryTypeId = 2,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 5,
                            AccessoryTypeId = 3,
                            DueDate = new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 2,
                            LastUpdated = new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 6,
                            AccessoryTypeId = 3,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 7,
                            AccessoryTypeId = 4,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 8,
                            AccessoryTypeId = 4,
                            DueDate = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 3,
                            LastUpdated = new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 9,
                            AccessoryTypeId = 5,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 10,
                            AccessoryTypeId = 5,
                            DueDate = new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 4,
                            LastUpdated = new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 11,
                            AccessoryTypeId = 6,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 12,
                            AccessoryTypeId = 6,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 13,
                            AccessoryTypeId = 7,
                            DueDate = new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 5,
                            LastUpdated = new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 14,
                            AccessoryTypeId = 7,
                            DueDate = new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LabId = 1,
                            LabUserId = 6,
                            LastUpdated = new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Borrowed"
                        },
                        new
                        {
                            Id = 15,
                            AccessoryTypeId = 8,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 16,
                            AccessoryTypeId = 8,
                            LabId = 1,
                            LastUpdated = new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Available"
                        });
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.AccessoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Borrowable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AccessoryType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Borrowable = true,
                            Description = "Its purpose is to capture images and videos",
                            Name = "Sony A7 IV",
                            Type = "Camera"
                        },
                        new
                        {
                            Id = 2,
                            Borrowable = true,
                            Description = "Its purpose is to detect obstacles",
                            Name = "MA300D1-1",
                            Type = "Ultrasonic Sensor"
                        },
                        new
                        {
                            Id = 3,
                            Borrowable = true,
                            Description = "Its purpose is to detect humidity in the environment",
                            Name = "DHT22",
                            Type = "Humidity Sensor"
                        },
                        new
                        {
                            Id = 4,
                            Borrowable = true,
                            Description = "Its purpose is to detect water pressure",
                            Name = "LEFOO LFT2000W",
                            Type = "Water pressure Sensor"
                        },
                        new
                        {
                            Id = 5,
                            Borrowable = true,
                            Description = "It is used to switch on the lights in the lab",
                            Name = "RM1802",
                            Type = "IR Sensor"
                        },
                        new
                        {
                            Id = 6,
                            Borrowable = true,
                            Description = "Its purpose is to detect proximity of an obstacle",
                            Name = "HC-SR04",
                            Type = "Proximity Sensor"
                        },
                        new
                        {
                            Id = 7,
                            Borrowable = false,
                            Description = "Its purpose is to emit light",
                            Name = "EDGELEC 4Pin LED Diodes",
                            Type = "LED Lights"
                        },
                        new
                        {
                            Id = 8,
                            Borrowable = true,
                            Description = "Its purpose is to emit sound from the device",
                            Name = "TMB09A05",
                            Type = "Buzzer"
                        });
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LabId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.ToTable("Device");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Its purpose is to detect situation in the laboratory",
                            LabId = 1,
                            LastUpdated = new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Surveillance Camera",
                            SerialNo = "SC1001",
                            Status = "Available"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Its purpose is to detect temperature in the laboratory",
                            LabId = 1,
                            LastUpdated = new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Temperature Sensor",
                            SerialNo = "R1001",
                            Status = "Available"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Its purpose is to detect humidity in the laboratory",
                            LabId = 1,
                            LastUpdated = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Humidity Sensor",
                            SerialNo = "S1001",
                            Status = "Available"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Its purpose is to detect light in the laboratory",
                            LabId = 1,
                            LastUpdated = new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Light Sensor",
                            SerialNo = "SL1001",
                            Status = "Available"
                        },
                        new
                        {
                            Id = 5,
                            Description = "It is used to control brightness of the lights in the lab",
                            LabId = 1,
                            LastUpdated = new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "VR Light Controls",
                            SerialNo = "VRL1001",
                            Status = "Unavailable"
                        });
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LabStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonInCharge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lab");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LabStatus = "Available",
                            Location = "NYP-SR7C",
                            PersonInCharge = "David"
                        });
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Logging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataUploaded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LabId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NoOfHoursLogged")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.ToTable("Logging");
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Accessory", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.AccessoryType", "AccessoryType")
                        .WithMany("Accessories")
                        .HasForeignKey("AccessoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivingLab.Domain.Entities.Lab", "Lab")
                        .WithMany("Accessories")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessoryType");

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Device", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.Lab", "Lab")
                        .WithMany("Devices")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Logging", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.Lab", "Lab")
                        .WithMany("Logs")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivingLab.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LivingLab.Domain.Entities.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.AccessoryType", b =>
                {
                    b.Navigation("Accessories");
                });

            modelBuilder.Entity("LivingLab.Domain.Entities.Lab", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Devices");

                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
