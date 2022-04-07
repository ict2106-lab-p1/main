using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.Repositories.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceRepository : IRepository<Device>
{
    /// <summary>
    /// Get device based on serial Number
    /// </summary>
    /// <param name="serialNo"></param>
    /// <returns></returns>
    Task<Device> GetDeviceBySerialNo(string serialNo);
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType(string labLocation);
    Task<List<Device>> GetAllDevicesByType(string deviceType, string labLocation);
    
    /// <summary>
    /// Function to update the device status based on device id and review status
    /// <param name="deviceId">string deviceId</param>
    /// <param name="deviceReviewStatus">string deviceReviewStatus</param>
    /// </summary>
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    /// <summary>
    /// Function to get the list of devices for review based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns>device</returns>
    Task<List<Device>> GetAllDevicesForReview(string labLocation);
    
    /// <summary>
    /// Get device details based on device id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>device</returns>
    Task<Device> GetDeviceDetails(int id);
    
    /// <summary>
    /// Function to get the list of devices based on lab location
    /// <param name="labLocation"></param>
    /// <returns>device</returns>
    /// </summary>
    Task<List<Device>> GetDevicesForLabProfile(string labLocation);
    
    /// <summary>
    /// Get the device based on the last device id
    /// </summary>
    /// <returns></returns>
    Task<Device> GetLastRow();
    
    /// <summary>
    /// Function to add the device
    /// </summary>
    /// <param name="addedDevice"></param>
    /// <returns>addDevice</returns>
    Task<Device> AddDevice(Device addedDevice);
    
    /// <summary>
    /// Function to update the device
    /// </summary>
    /// <param name="editedDevice"></param>
    /// <returns>editedDevice</returns>
    Task<Device> EditDeviceDetails(Device editedDevice);
    
    /// <summary>
    /// Function to delete the device
    /// </summary>
    /// <param name="deleteDevice"></param>
    /// <returns>deleteDevice</returns>
    Task<Device> DeleteDevice(Device deleteDevice);
    
    /// <summary>
    /// Function to get all devices type 
    /// </summary>
    /// <returns>device</returns>
    Task<List<Device>> GetAllDeviceType();
    
    /// <summary>
    /// Function to get unique device type 
    /// </summary>
    /// <returns>device</returns>
    Task<List<String>> GetDeviceTypes();
}
