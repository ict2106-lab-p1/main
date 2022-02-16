using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.ViewModels;

public class LogItemViewModel
{
    [Display(Name = "Device Serial Number")]
    public string DeviceSerialNo { get; set; }
    
    [Display(Name = "Energy Usage")]
    public double EnergyUsage { get; set; }

    [Display(Name = "Interval (mins)")]
    public double Interval { get; set; }
    
    [Display(Name = "Logged At")]
    public DateTime LoggedDate { get; set; }
}