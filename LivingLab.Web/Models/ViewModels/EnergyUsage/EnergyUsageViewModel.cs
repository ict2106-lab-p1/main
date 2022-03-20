namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageViewModel
{
    public List<EnergyUsageLogViewModel> Logs { get; set; }
    public double EnergyUsageBenchmark { get; set; }
    public EnergyUsageLabViewModel Lab { get; set; }
}