using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Entities.DTO.Lab;

namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageDomainService
{
    Task<EnergyUsageDTO> GetEnergyUsage(EnergyUsageFilterDTO filter);
    Task<LabDetailsDTO> GetLabEnergyBenchmark(int labId);
    Task SetLabEnergyBenchmark(Lab lab);
}
 
