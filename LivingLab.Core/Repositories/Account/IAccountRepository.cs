using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Repositories.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>

/// <summary>
/// 1. IAccountRepository is an interface to map AccountRepository methods 
/// </summary>
public interface IAccountRepository : IRepository<ApplicationUser>
{
    Task<List<ApplicationUser>?> GetAllAccount();
    Task<ApplicationUser?> GetAccountById(string id);
    Task<ApplicationUser?> EditAccount(ApplicationUser user);
    Task<ApplicationUser> DeleteAccount(ApplicationUser user);

}
