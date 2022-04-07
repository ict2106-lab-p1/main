using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Repositories.Equipment;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceDomainService : IDeviceDomainService
{
    public readonly IDeviceRepository _deviceRepository;

    public DeviceDomainService(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation)
    {
        return _deviceRepository.GetDevicesForLabProfile(labLocation);
    }

    public void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        _deviceRepository.UpdateDeviceStatus(deviceId, deviceReviewStatus);
    }

    public Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation)
    {
        return _deviceRepository.GetAllDevicesForReview(labLocation);
    }

    public Task<List<Entities.Device>> GetAllDevices()
    {
        return _deviceRepository.GetAllAsync();
    }

    public Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation)
    {
        return _deviceRepository.GetAllDevicesByType(deviceType, labLocation);
    }

    public async Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation)
    {
        var collection = await _deviceRepository.GetViewDeviceType(labLocation);

        
        var iterator = collection.CreateIterator();

        List<ViewDeviceTypeDTO> deviceTypeDtos = new List<ViewDeviceTypeDTO>();
        for (var device = iterator.First(); iterator.HasNext(); device = iterator.Next())
        {
            deviceTypeDtos.Add(new ViewDeviceTypeDTO
            {
                Type = device.Type,
                Quantity = device.Quantity
            });
        }
        return deviceTypeDtos;
    }
    
    public Task<Entities.Device> ViewDeviceDetails(int id)
    {
        return _deviceRepository.GetDeviceDetails(id);
    }
    public Task<Entities.Device> GetDeviceLastRow()
    {
        return _deviceRepository.GetLastRow();
    }
    public Task<Entities.Device> AddDevice(Entities.Device addedDevice)
    {
        return _deviceRepository.AddDevice(addedDevice);
    }
    public Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice)
    {
        return _deviceRepository.EditDeviceDetails(editedDevice);
    }
    public Task<Entities.Device> DeleteDevice(Entities.Device deletedDevice)
    {
        return _deviceRepository.DeleteDevice(deletedDevice);
    }

    public Task<List<String>> GetDeviceTypes()
    {
        return _deviceRepository.GetDeviceTypes();
    }
}
