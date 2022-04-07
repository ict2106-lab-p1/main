using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.Account.Session;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ISessionStatsDomainService
{
    /// <summary>
    /// This function calls SessionStatsRepository to retrieve a list of SessionStats of each lab.
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
   Task<List<SessionStats>> ViewSessionStats(string labLocation);
}
