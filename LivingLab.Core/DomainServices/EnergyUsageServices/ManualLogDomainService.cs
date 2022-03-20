using LivingLab.Core.Constants;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Models;

using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class ManualLogDomainService : IManualLogDomainService
{
    private readonly IEnergyUsageLogCsvParser _csvParser;
    private readonly IEnergyUsageRepository _repository;
    
    public ManualLogDomainService(IEnergyUsageLogCsvParser csvParser, IEnergyUsageRepository repository)
    {
        _csvParser = csvParser;
        _repository = repository;
    }

    public List<EnergyUsageCsvModel> UploadLogs(IFormFile file)
    {
        return _csvParser.Parse(file).ToList();
    }

    public Task SaveLogs(List<EnergyUsageLog> data)
    {
        // var loggedUser = await _userManager.GetUserAsync(User);
        var loggedUser = DummyUser.INSTANCE;
        return  _repository.BulkInsertAsync(data);
        // await _repository.BulkInsertAsyncByUser(data, loggedUser);
    }
}