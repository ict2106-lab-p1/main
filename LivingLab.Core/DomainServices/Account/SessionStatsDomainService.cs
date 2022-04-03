using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Repositories.Account;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices.Account;

public class SessionStatsDomainService : ISessionStatsDomainService
{
    private readonly ISessionStatsRepository _sessionStatsRepository;

    public SessionStatsDomainService(ISessionStatsRepository sessionStatsRepository)
    {
        _sessionStatsRepository = sessionStatsRepository;
    }
    
    
    public Task<List<SessionStats>> ViewSessionStats(string labLocation)
    {
        return _sessionStatsRepository.GetSessionStatsView(labLocation);
    }
    
}
