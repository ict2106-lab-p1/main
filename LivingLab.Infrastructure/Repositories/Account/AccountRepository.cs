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
    /// 1. Get all user accounts 
    /// </summary>
    public async Task<List<ApplicationUser>> GetAllAccount()
    {
        var AccountGroup = await _context.Users.ToListAsync();
        return AccountGroup;
    }

    /// <summary>
    /// 1. Get all user accounts by user id 
    /// </summary>
    /// <param name="id">Filter by ID</param>
    /// <returns>Filter account</returns>
    public async Task<ApplicationUser?> GetAccountById(string Id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(Id);
    }

    /// <summary>
    /// 1. Edit user account
    /// </summary>
    /// <param name="user">Filter by user</param>
    /// <returns>Edited email and faculty when matching id is found</returns>
    public async Task<ApplicationUser?> EditAccount(ApplicationUser User)
    {
        ApplicationUser CurrentAccount = (await _context.Users.SingleOrDefaultAsync(d => d.Id == User.Id))!;
        CurrentAccount.Email = User.Email;
        CurrentAccount.UserFaculty  = User.UserFaculty;
        await _context.SaveChangesAsync();       
        return User;
    }
    /// <summary>
    /// 1. Delete user account
    /// </summary>
    /// <param name="user">Filter by user</param>
    /// <returns>Delete user when there is a matching id</returns>
    public async Task<ApplicationUser> DeleteAccount(ApplicationUser User)
    {
        ApplicationUser CurrentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == User.Id))!;
        _context.Users.Remove(CurrentUser);
        await _context.SaveChangesAsync();
        return User;    
    }
}
