using LivingLab.Core.Repositories.Lab;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileRepository : Repository<Core.Entities.Lab>, ILabProfileRepository
{
    private readonly ApplicationDbContext _context;

    public LabProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Get all labs details and store it as a list
    /// </summary>
    /// <returns>List of lab details</returns>
    public async Task<List<Core.Entities.Lab>> GetAllLabs()
    {
        var labGroup = await _context.LabProfile.ToListAsync();
        return labGroup;
    }
    public async Task<Core.Entities.Lab> GetLabDetails(int id)
    {
        Core.Entities.Lab user = (await _context.LabProfile
            .Include(d => d.Devices)
            .SingleOrDefaultAsync(d => d.LabId == id))!;
        return user;
    }

    // Added by Team P1-1
    public Task SetLabEnergyBenchmark(int labId, double energyBenchmark)
    {
        var lab = _context.Labs.FirstOrDefault(l => l.LabId == labId);
        if (lab != null)
        {
            lab.EnergyUsageBenchmark = energyBenchmark;
            _context.Labs.Update(lab);
        }
        return _context.SaveChangesAsync();
    }

    // Added by P1-1
    public Task<double> GetLabEnergyBenchmark(int labId)
    {
        var lab = _context.Labs.FirstOrDefault(l => l.LabId == labId);
        return Task.FromResult(lab != null ? lab.EnergyUsageBenchmark!.Value : 0.0);
    }

    // Added by P1-1
    public Task<Core.Entities.Lab?> GetLabByLocation(string location)
    {
        return _context.Labs.FirstOrDefaultAsync(l => l.LabLocation == location);
    }

    public Task<List<Core.Entities.Lab>> GetAllLabLocation()
    {
        return IncludeReferences(
                _context.Labs
            )
            .ToListAsync();
    }
    
}
