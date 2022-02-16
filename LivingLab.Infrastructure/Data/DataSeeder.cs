using LivingLab.Core.Constants;
using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().HasData(
            new Device { Id = 1, DeviceSerialNumber = "DEVICE-3390", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 2, DeviceSerialNumber = "DEVICE-6049", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 3, DeviceSerialNumber = "DEVICE-1598", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 4, DeviceSerialNumber = "DEVICE-1232", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 5, DeviceSerialNumber = "DEVICE-1123", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 6, DeviceSerialNumber = "DEVICE-8987", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 7, DeviceSerialNumber = "DEVICE-2435", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 8, DeviceSerialNumber = "DEVICE-1234", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 9, DeviceSerialNumber = "DEVICE-5423", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()},
            new Device { Id = 10, DeviceSerialNumber = "DEVICE-7452", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber()}
        );
    }

    private static int GetRandomNumber()
    {
        var random  = new Random();
        return random.Next(1000, 9999);
    }
}