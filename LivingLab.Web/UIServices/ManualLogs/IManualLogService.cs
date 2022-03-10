using LivingLab.Web.Models.ViewModels;

namespace LivingLab.Web.UIServices.ManualLogs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IManualLogService
{
    List<LogItemViewModel> UploadLogs(IFormFile file);
    Task SaveLogs(List<LogItemViewModel> logs);
}