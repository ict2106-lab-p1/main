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
    
    /// <summary>
    /// Get the devices type by lab Location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation)
    {
        return _deviceRepository.GetDevicesForLabProfile(labLocation);
    }

    /// <summary>
    /// Update review status of the device
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="deviceReviewStatus"></param>
    public void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        _deviceRepository.UpdateDeviceStatus(deviceId, deviceReviewStatus);
    }

    /// <summary>
    /// function to get all the devices to review, based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation)
    {
        return _deviceRepository.GetAllDevicesForReview(labLocation);
    }

    /// <summary>
    /// function to get a list of devices
    /// </summary>
    /// <returns></returns>
    public Task<List<Entities.Device>> GetAllDevices()
    {
        return _deviceRepository.GetAllAsync();
    }
    
    /// <summary>
    /// function to get a list of devices based on device type and lab location
    /// </summary>
    /// <param name="deviceType"></param>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation)
    {
        return _deviceRepository.GetAllDevicesByType(deviceType, labLocation);
    }
    
    /// <summary>
    /// function to get a list of devices and its quantity based on each device type
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation)
    {
        return _deviceRepository.GetViewDeviceType(labLocation);
    }
    
    /// <summary>
    /// function to populate the edit device pop up modal 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Entities.Device> ViewDeviceDetails(int id)
    {
        return _deviceRepository.GetDeviceDetails(id);
    }
    
    /// <summary>
    /// function to get the last row of the device
    /// </summary>
    /// <returns></returns>
    public Task<Entities.Device> GetDeviceLastRow()
    {
        return _deviceRepository.GetLastRow();
    }
    
    /// <summary>
    /// function to add device 
    /// </summary>
    /// <param name="addedDevice"></param>
    /// <returns></returns>
    public Task<Entities.Device> AddDevice(Entities.Device addedDevice)
    {
        return _deviceRepository.AddDevice(addedDevice);
    }
    
    /// <summary>
    /// function to populate edit device details
    /// </summary>
    /// <param name="editedDevice"></param>
    /// <returns></returns>
    public Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice)
    {
        return _deviceRepository.EditDeviceDetails(editedDevice);
    }
    
    /// <summary>
    /// function to delete device
    /// </summary>
    /// <param name="deleteDevice"></param>
    /// <returns></returns>
    public Task<Entities.Device> DeleteDevice(Entities.Device deletedDevice)
    {
        return _deviceRepository.DeleteDevice(deletedDevice);
    }

    /// <summary>
    /// function to get all device types
    /// </summary>
    /// <param name="deleteDevice"></param>
    /// <returns></returns> 
    public Task<List<String>> GetDeviceTypes()
    {
        return _deviceRepository.GetDeviceTypes();
    }
}
