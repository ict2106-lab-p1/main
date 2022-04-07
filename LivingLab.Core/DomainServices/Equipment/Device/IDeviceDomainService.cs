using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    /// <summary>
    /// function to get a list of devices
    /// </summary>
    /// <returns></returns>
    Task<List<Entities.Device>> GetAllDevices();
    
    /// <summary>
    /// function to get a list of devices based on device type and lab location
    /// </summary>
    /// <param name="deviceType"></param>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation);
    
    /// <summary>
    /// function to get a list of available devices to populate in the lablocation
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation);
    
    /// <summary>
    /// function to update the review status
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="deviceReviewStatus"></param>
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    
    /// <summary>
    /// function to get all the devices to review, based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation);
    
    /// <summary>
    /// function to get a list of devices and its quantity based on each device type
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation);
    
    /// <summary>
    /// function to populate the edit device pop up modal 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Entities.Device> ViewDeviceDetails(int id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Entities.Device> GetDeviceLastRow();
    Task<Entities.Device> AddDevice(Entities.Device addedDevice);
    Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice);
    Task<Entities.Device> DeleteDevice(Entities.Device deleteDevice);
    Task<List<String>> GetDeviceTypes();
}
