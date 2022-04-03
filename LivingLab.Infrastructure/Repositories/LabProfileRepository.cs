using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileRepository : Repository<Lab>, ILabProfileRepository
{
    private readonly ApplicationDbContext _context;

    public LabProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<Lab>> GetAllLabs()
    {
        var labGroup = await _context.LabProfile.ToListAsync();
        return labGroup;
    }
    public async Task<Lab> GetLabDetails(int id)
    {
        Lab user = (await _context.LabProfile.SingleOrDefaultAsync(d => d.LabId == id))!;
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
    public Task<Lab> GetLabByLocation(string location)
    {
        return _context.Labs.FirstOrDefaultAsync(l => l.LabLocation == location);
    }

    public async Task<Lab> GetLabProfileDetails(string labLocation)
    {
        Lab labInfo = (await _context.Labs.SingleOrDefaultAsync(l => l.LabLocation == labLocation))!;
        return labInfo;
    }

    // public async Task<Lab> EditUserDetail(Lab editUser)
    // {
    //     ApplicationUser currentUser = (await _context.LabProfile.SingleOrDefaultAsync(d => d.Id == editUser.Id))!;
    //     currentUser.Email = editUser.Email;
    //     currentUser.UserFaculty  = editUser.UserFaculty;
    //     currentUser.LabAccesses  = editUser.LabAccesses;
    //     await _context.SaveChangesAsync();       
    //     return editUser;
    // }
    // public async Task<Lab> DeleteAccount(Lab deleteUser)
    // {
    //     ApplicationUser currentUser = (await _context.LabProfile.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
    //     _context.Users.Remove(currentUser);
    //     await _context.SaveChangesAsync();
    //     return deleteUser;    
    // }
}
