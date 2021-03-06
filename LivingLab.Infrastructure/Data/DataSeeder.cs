using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Data;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public static class DataSeeder
{
    /// <summary>
    /// This is where you add your seed data.
    /// This method has been called in the ApplicationDbContext class.
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Add your seed data here.
        // You can add seed data for specific tables here if you need to.
        // You can also create entities and add them directly here if you need to.
        // modelBuilder.Entity<YourEntity>().HasData(new YourEntity { Id = 1, Name = "Your New Entity" });

        var user1 = new ApplicationUser { Id = "DefaultAdmin1", FirstName = "Default", LastName = "Sotong", UserName = "nghanyi1997@gmail.com", NormalizedUserName = "nghanyi1997@gmail.com", NormalizedEmail = "nghanyi1997@gmail.com", PhoneNumber = "To Be Changed", Email = "nghanyi1997@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "SE", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = true, PhoneNumberConfirmed = false, PreferredNotification = NotificationType.EMAIL };
        var user2 = new ApplicationUser { Id = "DefaultAdmin2", FirstName = "Ji Pyeong", LastName = "Han", UserName = "mailstohenry@gmail.com", NormalizedUserName = "mailstohenry@gmail.com", NormalizedEmail = "mailstohenry@gmail.com", PhoneNumber = "To Be Changed", Email = "mailstohenry@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "SE", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = true, PhoneNumberConfirmed = false, PreferredNotification = NotificationType.NONE };
        var user3 = new ApplicationUser { Id = "DefaultAdmin3", FirstName = "Do San", LastName = "Nam", UserName = "shengyu98@hotmail.com", NormalizedUserName = "shengyu98@hotmail.com", NormalizedEmail = "shengyu98@hotmail.com", PhoneNumber = "To Be Changed", Email = "shengyu98@hotmail.com", TwoFactorEnabled = false, AuthenticationType = "None", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "SE", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = true, PhoneNumberConfirmed = false, PreferredNotification = NotificationType.NONE };
        var user4 = new ApplicationUser { Id = "DefaultAdmin4", FirstName = "Test", LastName = "Test", UserName = "test@gmail.com", NormalizedUserName = "test@gmail.com", PhoneNumber = "00000000", Email = "test@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "ICT", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = false, PhoneNumberConfirmed = false, PreferredNotification = NotificationType.NONE };

        var passwordHasher = new PasswordHasher<IdentityUser>();
        user1.PasswordHash = passwordHasher.HashPassword(user1, "P@ssw0rd");
        user2.PasswordHash = passwordHasher.HashPassword(user2, "P@ssw0rd");
        user3.PasswordHash = passwordHasher.HashPassword(user4, "P@ssw0rd");
        user4.PasswordHash = passwordHasher.HashPassword(user3, "P@ssw0rd");

        modelBuilder.Entity<ApplicationUser>().HasData(user1, user2, user3, user4);

        modelBuilder.Entity<IdentityRole>().HasData(
            new { Id = "1", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "" },
            new { Id = "2", Name = "Labtech", NormalizedName = "LABTECH", ConcurrencyStamp = "" },
            new { Id = "3", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "" });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new { UserId = "DefaultAdmin1", RoleId = "1" },
            new { UserId = "DefaultAdmin1", RoleId = "2" },
            new { UserId = "DefaultAdmin1", RoleId = "3" },
            new { UserId = "DefaultAdmin2", RoleId = "1" },
            new { UserId = "DefaultAdmin2", RoleId = "2" },
            new { UserId = "DefaultAdmin2", RoleId = "3" },
            new { UserId = "DefaultAdmin3", RoleId = "1" },
            new { UserId = "DefaultAdmin3", RoleId = "2" },
            new { UserId = "DefaultAdmin3", RoleId = "3" }
            );

        modelBuilder.Entity<Lab>().HasData(
            new Lab { LabId = 1, LabLocation = "NYP-SR7A", LabInCharge = "DefaultAdmin1", LabStatus = "Available", Occupied = 0, Capacity = 25, EnergyUsageBenchmark = 111.5, Area = 300 },
            new Lab { LabId = 2, LabLocation = "NYP-SR7B", LabInCharge = "DefaultAdmin1", LabStatus = "Available", Occupied = 0, Capacity = 30, EnergyUsageBenchmark = 111.5, Area = 200 },
            new Lab { LabId = 3, LabLocation = "NYP-SR7C", LabInCharge = "DefaultAdmin1", LabStatus = "Available", Occupied = 0, Capacity = 20, EnergyUsageBenchmark = 111.5, Area = 200 }
        );

        modelBuilder.Entity<Booking>().HasData(
            new { BookingId = 1, StartDateTime = new DateTime(2022, 7, 19, hour: 10, minute: 00, second: 00), EndDateTime = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), LabId = 1, UserId = "DefaultAdmin3" }
        );

        modelBuilder.Entity<Device>().HasData(
                new { Id = 1, Name = "Surveillance Camera", LastUpdated = new DateTime(2020, 10, 10), SerialNo = "SC1001", LabId = 1, Status = "Available", Type = "Surveillance Camera", Description = "Its purpose is to detect situation in the laboratory", ReviewStatus = "Approved" },
                new { Id = 2, Name = "Temperature Sensor", LastUpdated = new DateTime(2020, 10, 11), SerialNo = "R1001", LabId = 2, Status = "Available", Type = "Temperature Sensor", Description = "Its purpose is to detect temperature in the laboratory", ReviewStatus = "Approved" },
                new { Id = 3, Name = "Humidity Sensor", LastUpdated = new DateTime(2020, 9, 9), SerialNo = "S1001", LabId = 2, Status = "Available", Type = "Humidity Sensor", Description = "Its purpose is to detect humidity in the laboratory", ReviewStatus = "Approved" },
                new { Id = 4, Name = "Light Sensor", LastUpdated = new DateTime(2019, 8, 1), SerialNo = "SL1001", LabId = 3, Status = "Available", Type = "Light Sensor", Description = "Its purpose is to detect light in the laboratory", ReviewStatus = "Rejected" },
                new { Id = 5, Name = "VR Light Controls", LastUpdated = new DateTime(2019, 7, 3), SerialNo = "VRL1001", LabId = 3, Status = "Unavailable", Type = "VR Light Controls", Description = "It is used to control brightness of the lights in the lab", ReviewStatus = "Approved" },
                new { Id = 6, Name = "Surveillance Camera", LastUpdated = new DateTime(2020, 10, 10), SerialNo = "SC1001", LabId = 1, Status = "Available", Type = "Surveillance Camera", Description = "Its purpose is to detect situation in the laboratory", ReviewStatus = "Approved" },
                new { Id = 7, Name = "Temperature Sensor", LastUpdated = new DateTime(2020, 10, 11), SerialNo = "R1001", LabId = 2, Status = "Available", Type = "Temperature Sensor", Description = "Its purpose is to detect temperature in the laboratory", ReviewStatus = "Approved" },
                new { Id = 8, Name = "Humidity Sensor", LastUpdated = new DateTime(2020, 9, 9), SerialNo = "S1001", LabId = 2, Status = "Available", Type = "Humidity Sensor", Description = "Its purpose is to detect humidity in the laboratory", ReviewStatus = "Approved" },
                new { Id = 9, Name = "Light Sensor", LastUpdated = new DateTime(2019, 8, 1), SerialNo = "SL1001", LabId = 3, Status = "Available", Type = "Light Sensor", Description = "Its purpose is to detect light in the laboratory", ReviewStatus = "Rejected" },
                new { Id = 10, Name = "VR Light Controls", LastUpdated = new DateTime(2019, 7, 3), SerialNo = "VRL1001", LabId = 3, Status = "Unavailable", Type = "VR Light Controls", Description = "It is used to control brightness of the lights in the lab", ReviewStatus = "Approved" }
        );

        // Accessory and Accessory Types
        modelBuilder.Entity<AccessoryType>().HasData(
                new { Id = 1, Type = "Camera", Borrowable = true, Description = "Its purpose is to capture images and videos" },
                new { Id = 2, Type = "Ultrasonic Sensor", Borrowable = true, Description = "Its purpose is to detect obstacles" },
                new { Id = 3, Type = "Humidity Sensor", Borrowable = true, Description = "Its purpose is to detect humidity in the environment" },
                new { Id = 4, Type = "Water pressure Sensor", Borrowable = true, Description = "Its purpose is to detect water pressure" },
                new { Id = 5, Type = "IR Sensor", Borrowable = true, Description = "It is used to switch on the lights in the lab" },
                new { Id = 6, Type = "Proximity Sensor", Borrowable = true, Description = "Its purpose is to detect proximity of an obstacle" },
                new { Id = 7, Type = "LED Lights", Borrowable = false, Description = "Its purpose is to emit light" },
                new { Id = 8, Type = "Buzzer", Borrowable = true, Description = "Its purpose is to emit sound from the device" }
        );

        modelBuilder.Entity<Accessory>().HasData(
                new { Id = 1, Name = "Sony A7 IV", Status = "Available", LastUpdated = new DateTime(2021, 10, 10), LabId = 1, AccessoryTypeId = 1, ReviewStatus = "Approved" },
                new { Id = 2, Name = "Sony A8 IV", Status = "Borrowed", LastUpdated = new DateTime(2021, 10, 14), LabId = 1, AccessoryTypeId = 1, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 10, 14), ReviewStatus = "Approved" },
                new { Id = 3, Name = "MA300D1-1", Status = "Available", LastUpdated = new DateTime(2021, 10, 17), LabId = 2, AccessoryTypeId = 2, ReviewStatus = "Approved" },
                new { Id = 4, Name = "MA300D1-2", Status = "Available", LastUpdated = new DateTime(2021, 10, 21), LabId = 2, AccessoryTypeId = 2, ReviewStatus = "Approved" },
                new { Id = 5, Name = "DHT22", Status = "Borrowed", LastUpdated = new DateTime(2021, 9, 9), LabId = 3, AccessoryTypeId = 3, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 9, 9), ReviewStatus = "Approved" },
                new { Id = 6, Name = "DHT23", Status = "Available", LastUpdated = new DateTime(2021, 9, 5), LabId = 3, AccessoryTypeId = 3, ReviewStatus = "Approved" },
                new { Id = 7, Name = "LEFOO LFT2000W", Status = "Available", LastUpdated = new DateTime(2021, 8, 1), LabId = 1, AccessoryTypeId = 4, ReviewStatus = "Approved" },
                new { Id = 8, Name = "LEFO1 LFT2000W", Status = "Borrowed", LastUpdated = new DateTime(2021, 8, 10), LabId = 1, AccessoryTypeId = 4, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 9, 5), ReviewStatus = "Approved" },
                new { Id = 9, Name = "RM1802", Status = "Available", LastUpdated = new DateTime(2021, 7, 3), LabId = 2, AccessoryTypeId = 5, ReviewStatus = "Approved" },
                new { Id = 10, Name = "RM1803", Status = "Borrowed", LastUpdated = new DateTime(2021, 6, 24), LabId = 2, AccessoryTypeId = 5, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 10, 14), ReviewStatus = "Approved" },
                new { Id = 11, Name = "HC-SR04", Status = "Available", LastUpdated = new DateTime(2021, 7, 25), LabId = 3, AccessoryTypeId = 6, ReviewStatus = "Approved" },
                new { Id = 12, Name = "HC-SR05", Status = "Available", LastUpdated = new DateTime(2021, 4, 3), LabId = 3, AccessoryTypeId = 6, ReviewStatus = "Approved" },
                new { Id = 13, Name = "EDGELEC 4Pin LED Diodes", Status = "Borrowed", LastUpdated = new DateTime(2021, 7, 19), LabId = 1, AccessoryTypeId = 7, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 7, 19), ReviewStatus = "Approved" },
                new { Id = 14, Name = "EDGELEC 6Pin LED Diodes", Status = "Borrowed", LastUpdated = new DateTime(2021, 12, 14), LabId = 1, AccessoryTypeId = 7, LabUserId = "DefaultAdmin1", DueDate = new DateTime(2022, 12, 14), ReviewStatus = "Approved" },
                new { Id = 15, Name = "TMB09A05", Status = "Available", LastUpdated = new DateTime(2021, 11, 12), LabId = 2, AccessoryTypeId = 8, ReviewStatus = "Approved" },
                new { Id = 16, Name = "TMB09A06", Status = "Available", LastUpdated = new DateTime(2021, 7, 3), LabId = 2, AccessoryTypeId = 8, ReviewStatus = "Approved" }
        );

        modelBuilder.Entity<SessionStats>().HasData(
                new { Id = 1, Date = new DateTime(2021, 7, 3), LoginTime = new DateTime(2021, 7, 3, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 3, 12, 0, 0), DataUploaded = 58.0, LabId = 1 },
                new { Id = 2, Date = new DateTime(2021, 7, 4), LoginTime = new DateTime(2021, 7, 4, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 4, 15, 0, 0), DataUploaded = 64.0, LabId = 1 },
                new { Id = 3, Date = new DateTime(2021, 7, 5), LoginTime = new DateTime(2021, 7, 5, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 5, 18, 0, 0), DataUploaded = 78.0, LabId = 1 },
                new { Id = 4, Date = new DateTime(2021, 7, 6), LoginTime = new DateTime(2021, 7, 6, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 6, 12, 0, 0), DataUploaded = 98.0, LabId = 1 },
                new { Id = 5, Date = new DateTime(2021, 7, 7), LoginTime = new DateTime(2021, 7, 7, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 7, 15, 0, 0), DataUploaded = 73.0, LabId = 1 },
                new { Id = 6, Date = new DateTime(2021, 7, 8), LoginTime = new DateTime(2021, 7, 8, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 8, 18, 0, 0), DataUploaded = 34.0, LabId = 1 },
                new { Id = 7, Date = new DateTime(2021, 7, 9), LoginTime = new DateTime(2021, 7, 8, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 9, 12, 0, 0), DataUploaded = 55.0, LabId = 1 },
                new { Id = 8, Date = new DateTime(2021, 7, 10), LoginTime = new DateTime(2021, 7, 9, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 10, 15, 0, 0), DataUploaded = 67.0, LabId = 1 },
                new { Id = 9, Date = new DateTime(2021, 7, 11), LoginTime = new DateTime(2021, 7, 10, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 11, 18, 0, 0), DataUploaded = 130.0, LabId = 1 },
                new { Id = 10, Date = new DateTime(2021, 7, 12), LoginTime = new DateTime(2021, 7, 11, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 12, 12, 0, 0), DataUploaded = 120.0, LabId = 1 },
                new { Id = 11, Date = new DateTime(2021, 7, 13), LoginTime = new DateTime(2021, 7, 12, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 13, 15, 0, 0), DataUploaded = 117.0, LabId = 1 },
                new { Id = 12, Date = new DateTime(2021, 7, 14), LoginTime = new DateTime(2021, 7, 14, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 14, 18, 0, 0), DataUploaded = 68.0, LabId = 1 },
                new { Id = 13, Date = new DateTime(2021, 7, 3), LoginTime = new DateTime(2021, 7, 3, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 3, 12, 0, 0), DataUploaded = 58.0, LabId = 2 },
                new { Id = 14, Date = new DateTime(2021, 7, 4), LoginTime = new DateTime(2021, 7, 4, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 4, 15, 0, 0), DataUploaded = 64.0, LabId = 2 },
                new { Id = 15, Date = new DateTime(2021, 7, 5), LoginTime = new DateTime(2021, 7, 5, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 5, 18, 0, 0), DataUploaded = 78.0, LabId = 2 },
                new { Id = 16, Date = new DateTime(2021, 7, 6), LoginTime = new DateTime(2021, 7, 6, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 6, 12, 0, 0), DataUploaded = 98.0, LabId = 2 },
                new { Id = 17, Date = new DateTime(2021, 7, 7), LoginTime = new DateTime(2021, 7, 7, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 7, 15, 0, 0), DataUploaded = 73.0, LabId = 2 },
                new { Id = 18, Date = new DateTime(2021, 7, 8), LoginTime = new DateTime(2021, 7, 8, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 8, 18, 0, 0), DataUploaded = 34.0, LabId = 2 },
                new { Id = 19, Date = new DateTime(2021, 7, 9), LoginTime = new DateTime(2021, 7, 8, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 9, 12, 0, 0), DataUploaded = 55.0, LabId = 2 },
                new { Id = 20, Date = new DateTime(2021, 7, 10), LoginTime = new DateTime(2021, 7, 9, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 10, 15, 0, 0), DataUploaded = 67.0, LabId = 2 },
                new { Id = 21, Date = new DateTime(2021, 7, 11), LoginTime = new DateTime(2021, 7, 10, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 11, 18, 0, 0), DataUploaded = 130.0, LabId = 2 },
                new { Id = 22, Date = new DateTime(2021, 7, 12), LoginTime = new DateTime(2021, 7, 11, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 12, 12, 0, 0), DataUploaded = 120.0, LabId = 2 },
                new { Id = 23, Date = new DateTime(2021, 7, 13), LoginTime = new DateTime(2021, 7, 12, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 13, 15, 0, 0), DataUploaded = 117.0, LabId = 2 },
                new { Id = 24, Date = new DateTime(2021, 7, 14), LoginTime = new DateTime(2021, 7, 14, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 14, 18, 0, 0), DataUploaded = 68.0, LabId = 2 },
                new { Id = 25, Date = new DateTime(2021, 7, 3), LoginTime = new DateTime(2021, 7, 3, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 3, 12, 0, 0), DataUploaded = 58.0, LabId = 3 },
                new { Id = 26, Date = new DateTime(2021, 7, 4), LoginTime = new DateTime(2021, 7, 4, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 4, 15, 0, 0), DataUploaded = 64.0, LabId = 3 },
                new { Id = 27, Date = new DateTime(2021, 7, 5), LoginTime = new DateTime(2021, 7, 5, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 5, 18, 0, 0), DataUploaded = 78.0, LabId = 3 },
                new { Id = 28, Date = new DateTime(2021, 7, 6), LoginTime = new DateTime(2021, 7, 6, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 6, 12, 0, 0), DataUploaded = 98.0, LabId = 3 },
                new { Id = 29, Date = new DateTime(2021, 7, 7), LoginTime = new DateTime(2021, 7, 7, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 7, 15, 0, 0), DataUploaded = 73.0, LabId = 3 },
                new { Id = 30, Date = new DateTime(2021, 7, 8), LoginTime = new DateTime(2021, 7, 8, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 8, 18, 0, 0), DataUploaded = 34.0, LabId = 3 },
                new { Id = 31, Date = new DateTime(2021, 7, 9), LoginTime = new DateTime(2021, 7, 8, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 9, 12, 0, 0), DataUploaded = 55.0, LabId = 3 },
                new { Id = 32, Date = new DateTime(2021, 7, 10), LoginTime = new DateTime(2021, 7, 9, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 10, 15, 0, 0), DataUploaded = 67.0, LabId = 3 },
                new { Id = 33, Date = new DateTime(2021, 7, 11), LoginTime = new DateTime(2021, 7, 10, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 11, 18, 0, 0), DataUploaded = 130.0, LabId = 3 },
                new { Id = 34, Date = new DateTime(2021, 7, 12), LoginTime = new DateTime(2021, 7, 11, 9, 0, 0), LogoutTime = new DateTime(2021, 7, 12, 12, 0, 0), DataUploaded = 120.0, LabId = 3 },
                new { Id = 35, Date = new DateTime(2021, 7, 13), LoginTime = new DateTime(2021, 7, 12, 10, 0, 0), LogoutTime = new DateTime(2021, 7, 13, 15, 0, 0), DataUploaded = 117.0, LabId = 3 },
                new { Id = 36, Date = new DateTime(2021, 7, 14), LoginTime = new DateTime(2021, 7, 14, 13, 0, 0), LogoutTime = new DateTime(2021, 7, 14, 18, 0, 0), DataUploaded = 68.0, LabId = 3 }
        );

        modelBuilder.SeedEnergyLogs();
    }
}
