using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageDomainService : IEnergyUsageDomainService
{
    private readonly ILabProfileRepository _labRepository;
    private readonly IEnergyUsageRepository _energyUsageRepository;
    public EnergyUsageDomainService(ILabProfileRepository labRepository, IEnergyUsageRepository energyUsageRepository)
    {
        _labRepository = labRepository;
        _energyUsageRepository = energyUsageRepository;
    }
    /// <summary>
    /// 1. Call Energy Usage repo to get filtered energy usage data
    /// 2. Map logs to DTO
    /// </summary>
    /// <param name="filter">Filter DTO object</param>
    /// <returns>EnergyUsageDTO</returns>
    public async Task<EnergyUsageDTO> GetEnergyUsage(EnergyUsageFilterDTO filter)
    {
        // Grouping done here because SQLite doesn't support it :(
        var logs = (await _energyUsageRepository
            .GetDeviceEnergyUsageByLabAndDate(filter.LabId, filter.Start, filter.End))
            .GroupBy(log => log.LoggedDate.Date)
            .Select(log => new EnergyUsageLog
            {
                LoggedDate = log.Key,
                EnergyUsage = log.Sum(l => l.EnergyUsage),
                Device = log.First().Device,
                Lab = log.First().Lab
            })
            .OrderBy(log => log.LoggedDate).ToList(); ;

        var lab = await _labRepository.GetByIdAsync(filter.LabId);

        var dto = new EnergyUsageDTO
        {
            Logs = logs,
            Lab = lab,
            Median = GetMedian(logs)
        };
        return dto;
    }

    public async Task<LabDetailsDTO> GetLabEnergyBenchmark(int labId)
    {
        var lab = await _labRepository.GetLabDetails(labId);
        return new LabDetailsDTO
        {
            LabId = lab.LabId,
            LabLocation = lab.LabLocation,
            Capacity = lab.Capacity.GetValueOrDefault(),
            EnergyUsageBenchmark = lab.EnergyUsageBenchmark.GetValueOrDefault(),
            NoOfDevices = lab.Devices.Count
        };
    }

    /// <summary>
    /// Call Lab repo to set the current lab total energy benchmark
    /// </summary>
    /// <param name="benchmark">Benchmark DTO object</param>
    public Task SetLabEnergyBenchmark(Lab lab)
    {
        return _labRepository.SetLabEnergyBenchmark(lab.LabId, lab.EnergyUsageBenchmark!.Value);
    }

    /// <summary>
    /// Find the median of the energy usage logs
    /// </summary>
    /// <param name="logs">Energy Usage Logs</param>
    /// <returns>Median</returns>
    private double GetMedian(List<EnergyUsageLog> logs)
    {
        if (logs.Count == 0) return 0;

        var sortedLogs = logs.OrderBy(log => log.EnergyUsage).ToList();
        var count = sortedLogs.Count;

        var mid = count / 2;
        if (count % 2 == 0)
        {
            return (sortedLogs.ElementAt(mid).EnergyUsage.Value + sortedLogs.ElementAt(mid - 1).EnergyUsage.Value) / 2;
        }
        return sortedLogs.ElementAt(mid).EnergyUsage.Value;
    }
}
