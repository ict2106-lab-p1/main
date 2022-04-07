using AutoMapper;

using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.DomainServices.Lab;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;
using LivingLab.Web.UIServices.EnergyUsage;

namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardService : ILivingLabDashboardService
{
    private readonly IEnergyUsageAnalysisUIService _energyAnalysisService;

    public LivingLabDashboardService(IEnergyUsageAnalysisUIService energyAnalysisService)
    {
        _energyAnalysisService = energyAnalysisService;
    }

    public async Task<List<string>> GetUsages()
    {
        var usages = new List<string>();
        DateTime thisDay = DateTime.Now;
        DateTime previousWeek = DateTime.Now.AddMonths(-1);
        DateTime previousDay = DateTime.Now.AddDays(-1);
        var oneMtnDeviceResult = _energyAnalysisService.GetDeviceEnergyUsageByDate(previousWeek, thisDay);
        var oneDayDeviceResult = _energyAnalysisService.GetDeviceEnergyUsageByDate(previousDay, thisDay);
        var oneMthEnergyResult = _energyAnalysisService.GetLabEnergyUsageByDate(previousWeek, thisDay);
        var oneDayEnergyResult = _energyAnalysisService.GetLabEnergyUsageByDate(previousDay, thisDay);

        Double totalDeviceUsage = 0.0;
        Double totalEnergyUsage = 0.0;
        Double todayDeviceUsage = 0.0;
        Double todayEnergyUsage = 0.0;
        foreach (var data in oneMtnDeviceResult)
        {
            totalDeviceUsage += data.TotalEnergyUsage;
        }
        foreach (var data in oneDayDeviceResult)
        {
            todayDeviceUsage += data.TotalEnergyUsage;
        }
        foreach (var data in oneMthEnergyResult)
        {
            totalEnergyUsage += data.TotalEnergyUsage;
        }
        foreach (var data in oneDayEnergyResult)
        {
            todayEnergyUsage += data.TotalEnergyUsage;
        }

        usages.Add(String.Format("{0:0.00}", totalDeviceUsage));
        usages.Add(String.Format("{0:0.00}", totalEnergyUsage));
        usages.Add(String.Format("{0:0.00}", todayDeviceUsage));
        usages.Add(String.Format("{0:0.00}", todayEnergyUsage)); 
        return usages;
    }
}
