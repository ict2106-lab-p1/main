using AutoMapper;

using LivingLab.Core.DomainServices.EnergyLog;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.DTOs;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogService : IEnergyLogService
{
    private readonly IEnergyLogDomainService _energyLogDomainService;
    private readonly IMapper _mapper;
    
    public EnergyLogService(IEnergyLogDomainService energyLogDomainService , IMapper mapper)
    {
        _energyLogDomainService = energyLogDomainService;
        _mapper = mapper;
    }
    
    public Task Log(EnergyUsageLogDTO log)
    {
        var map = _mapper.Map<EnergyUsageLog>(log);
        return _energyLogDomainService.Log(map);
    }

    public async Task<List<EnergyUsageLogViewModel>> GetLogs(int size)
    {
        var logs = await _energyLogDomainService.GetLogs(size);
        return _mapper.Map<List<EnergyUsageLogViewModel>>(logs);
    }
} 
