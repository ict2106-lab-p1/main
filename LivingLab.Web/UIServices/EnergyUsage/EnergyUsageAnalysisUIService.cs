using AutoMapper;

using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.EnergyUsage;

/// <remarks>
///     Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisUIService : IEnergyUsageAnalysisUIService
{
    private readonly IMapper _mapper;
    private readonly IEnergyUsageAnalysisService _analysis;
    private readonly ILabProfileService _labProfileService;

    public EnergyUsageAnalysisUIService(IMapper mapper, IEnergyUsageAnalysisService analysis,
        ILabProfileService labProfileService)
    {
        _mapper = mapper;
        _analysis = analysis;
        _labProfileService = labProfileService;
    }

    /// <summary>
    ///     1. get the colname
    ///     2. store the col name and data in byte format
    /// </summary>
    /// <param name="content">List of data to be export</param>
    /// <returns>byte string of the data</returns>
    public byte[] Export(List<DeviceEnergyUsageDTO> content)
    {
        return _analysis.ExportDeviceEU(content);
    }

    /// <summary>
    ///     1. retrieve device energy usage log according to data
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of DeviceEnergyUsageDTO</returns>
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end)
    {
        return _analysis.GetDeviceEnergyUsageByDate(start, end);
    }

    /// <summary>
    ///     1. retrieve lab energy usage log according to data
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of LabEnergyUsageDTO</returns>
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end)
    {
        return _analysis.GetLabEnergyUsageByDate(start, end);
    }

    /// <summary>
    ///     1. map EnergyUsageFilterViewModel and EnergyUsageFilterDTO
    ///     2. set logs using async to parse EnergyUsageFilterViewModel into GetEnergyUsageTrendSelectedLab
    ///     3. map IndividualLabMonthlyEnergyUsageDTO and EnergyUsageTrendSelectedLabViewModel using logs
    /// </summary>
    /// <param name="filter">filter</param>
    /// <returns>EnergyUsageTrendSelectedLabViewModel</returns>
    public async Task<EnergyUsageTrendSelectedLabViewModel> GetEnergyUsageTrendSelectedLab(
        EnergyUsageFilterViewModel filter)
    {
        var energyUsageFilter = _mapper.Map<EnergyUsageFilterViewModel, EnergyUsageFilterDTO>(filter);
        var logs = await _analysis.GetEnergyUsageTrendSelectedLab(energyUsageFilter);
        return _mapper.Map<IndividualLabMonthlyEnergyUsageDTO, EnergyUsageTrendSelectedLabViewModel>(logs);
    }

    /// <summary>
    ///     1. map EnergyUsageFilterViewModel and EnergyUsageFilterDTO
    ///     2. set logs using async to parse EnergyUsageFilterViewModel into GetEnergyUsageTrendAllLab
    ///     3. map MonthlyEnergyUsageDTO and EnergyUsageTrendAllLabViewModel using logs
    /// </summary>
    /// <param name="filter">filter</param>
    /// <returns>EnergyUsageTrendAllLabViewModel</returns>
    public async Task<EnergyUsageTrendAllLabViewModel> GetEnergyUsageTrendAllLab(EnergyUsageFilterViewModel filter)
    {
        var energyUsageFilter = _mapper.Map<EnergyUsageFilterViewModel, EnergyUsageFilterDTO>(filter);
        var logs = await _analysis.GetEnergyUsageTrendAllLab(energyUsageFilter);
        return _mapper.Map<MonthlyEnergyUsageDTO, EnergyUsageTrendAllLabViewModel>(logs);
    }

    /// <summary>
    ///     1. map Lab and EnergyBenchmarkViewModel using GetLabEnergyBenchmark by lab Id
    /// </summary>
    /// <param name="filter">filter</param>
    /// <returns>EnergyUsageTrendAllLabViewModel</returns>
    public async Task<EnergyBenchmarkViewModel> GetLabEnergyBenchmark(int labId)
    {
        var data = await _analysis.GetLabEnergyBenchmark(labId);
        return _mapper.Map<Lab, EnergyBenchmarkViewModel>(data);
    }
}
