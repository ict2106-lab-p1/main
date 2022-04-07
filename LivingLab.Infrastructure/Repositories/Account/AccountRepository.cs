using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Repositories.Account;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    /// <summary>
    /// 1. Get all user accounts from database
    /// </summary>
    public async Task<List<ApplicationUser>> GetAllAccount()
    {
        var AccountGroup = await _context.Users.ToListAsync();
        return AccountGroup;
    }

    /// <summary>
    /// 1. Get all user accounts by user id database
    /// </summary>
    /// <param name="id">Filter by ID</param>
    /// <returns>Filter account</returns>
    public async Task<ApplicationUser?> GetAccountById(string id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(id);
    }

    /// <summary>
    /// 1. Edit user account
    /// </summary>
    /// <param name="user">Filter by user</param>
    /// <returns>Edited email and faculty when matching is </returns>
    public async Task<ApplicationUser?> EditAccount(ApplicationUser user)
    {
        ApplicationUser CurrentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == user.Id))!;
        CurrentUser.Email = user.Email;
        CurrentUser.UserFaculty  = user.UserFaculty;
        await _context.SaveChangesAsync();       
        return user;
    }
    /// <summary>
    /// 1. Delete user account
    /// </summary>
    /// <param name="user">Filter by user</param>
    /// <returns>Delete user when there is a matching id</returns>
    public async Task<ApplicationUser> DeleteAccount(ApplicationUser user)
    {
        ApplicationUser CurrentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == user.Id))!;
        _context.Users.Remove(CurrentUser);
        await _context.SaveChangesAsync();
        return user;    
    }
}
