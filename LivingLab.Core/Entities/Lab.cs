using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;


/// <summary>
/// Consist of the entity attributes required for Lab Accounts,
/// Lab Profile Details, Lab Booking functions, Lab Energy usage functions
/// Lab accessories functions and Lab Devices functions
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class Lab
{
    [Key]
    public int LabId { get; set; }

    public string? LabLocation { get; set; }

    public string? LabStatus { get; set; }

    public string? LabInCharge { get; set; }
    public int? Occupied { get; set; }

    public int? Capacity { get; set; }

    public int? Area { get; set; }

    public Double? EnergyUsageBenchmark { get; set; }

    public List<Booking>? Bookings { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public List<SessionStats>? Logs { get; set; }
    public List<Accessory>? Accessories { get; set; }

    public List<Device>? Devices { get; set; }

}
