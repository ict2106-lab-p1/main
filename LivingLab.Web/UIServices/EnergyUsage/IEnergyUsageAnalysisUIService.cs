using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.UIServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageAnalysisUIService
{
    // chendong
    public byte[] Export(List<DeviceEnergyUsageDTO> content);
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end);

    // joey
    public Task<EnergyUsageTrendAllLabViewModel> GetEnergyUsageTrendAllLab(EnergyUsageFilterViewModel filter);
    public Task<EnergyUsageTrendSelectedLabViewModel> GetEnergyUsageTrendSelectedLab(EnergyUsageFilterViewModel filter);
    public Task<EnergyBenchmarkViewModel> GetLabEnergyBenchmark(int labId);

}
