namespace LivingLab.Core.Repositories.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>


/// <summary>
/// Consist of Interfaces for lab profile repository
/// </summary>
public interface ILabProfileRepository : IRepository<Entities.Lab>
{
    Task<List<Entities.Lab>> GetAllLabs();
    Task<Entities.Lab> GetLabDetails(int id);
    Task SetLabEnergyBenchmark(int labId, double energyBenchmark);
    Task<double> GetLabEnergyBenchmark(int labId);
    Task<Entities.Lab?> GetLabByLocation(string location);
    Task<List<Entities.Lab>> GetAllLabLocation();
}
