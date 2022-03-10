using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IDeviceRepository : IRepository<Device>
{
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType();
    Task<List<Device>> GetAllDevicesByType(string deviceType);
}
