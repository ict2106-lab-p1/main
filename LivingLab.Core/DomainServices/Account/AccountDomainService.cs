using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Repositories.Account;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountDomainService: IAccountDomainService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger _logger;
    
    public AccountDomainService(IAccountRepository accountRepository, ILogger<AccountDomainService> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }    
    public AccountDomainService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    /// <summary>
    /// 1. Call account repo to get all accounts
    /// </summary>
    public Task<List<ApplicationUser>> ViewAccounts()
    {
        return _accountRepository.GetAllAccount();
    } 
 
    /// <summary>
    /// 1. Call account repo to get account by Id function
    /// </summary>
    /// <param name="Id">Filtered account by Id</param>
    /// <returns>Account with matching Id</returns>
    public Task<ApplicationUser> ViewAccountDetails(string Id)
    {
        return _accountRepository.GetAccountById(Id);
    }

    /// <summary>
    /// 1. Call account repo to edit account function
    /// </summary>
    /// <param name="EditAccount">Edit account by Id</param>
    /// <returns>Edited account with matching Id</returns>
    public Task<ApplicationUser> EditAccount(ApplicationUser EditAccount)
    {
        return _accountRepository.EditAccount(EditAccount);
    } 
    
    /// <summary>
    /// 1. Call account repo to delete account function
    /// </summary>
    /// <param name="EditAccount">Delete account by Id</param>
    /// <returns>Deleted account with matching Id</returns>
    public Task<ApplicationUser> DeleteAccount(ApplicationUser DeletedAccount)
    {
        return _accountRepository.DeleteAccount(DeletedAccount);
    }

    
    /*Function to update user information one by one*/
    public async Task<ApplicationUser?> UpdateUser(ApplicationUser user)
    {
        return await _accountRepository.UpdateAsync(user);
    }

    /*Generate random OTP for user*/
    public async Task<bool> GenerateCode(ApplicationUser user)
    {
        var oldValue = user.OTP;
        Random random = new Random();
        int newCode = random.Next(100000, 999999);

        DateTime newTime = DateTime.Now;
        newTime = newTime.AddMinutes(5);
        user.SMSExpiry = newTime;
        user.OTP = newCode;

        await _accountRepository.UpdateAsync(user);

        if (user.OTP != oldValue)
        {
            return true;
        }
        else
        {
            return false;
        }
        return false;
    }

    /*Verify the OTP with checking of expiry*/
    public async Task<bool> VerifyCode(string userid, int otpCode)
    {
        var result = await _accountRepository.GetAccountById(userid);
        if (result != null && result.SMSExpiry > DateTime.Now)
        {
            if (result.OTP == otpCode)
            {
                //If match returns true
                return true;
            }
        }

        return false;
    }
    
    public async Task<ApplicationUser?> Save(ApplicationUser user)
    {
        return await _accountRepository.EditAccount(user);
    }
}
