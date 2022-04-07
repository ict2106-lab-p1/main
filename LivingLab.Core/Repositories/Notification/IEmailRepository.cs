using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;

namespace LivingLab.Core.Repositories.Notification;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEmailRepository
{
    Task<List<ApplicationUser>> GetAccountByNotiPref(NotificationType preference);
}
