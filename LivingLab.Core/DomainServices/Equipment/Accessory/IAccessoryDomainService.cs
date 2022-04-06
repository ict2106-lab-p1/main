using LivingLab.Core.Entities.DTO.Accessory;

namespace LivingLab.Core.DomainServices.Equipment.Accessory;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryDomainService
{   
    /// <summary>
    /// This function returns a list of accessory base on the selected accessory type and lab.
    /// </summary>
    /// <param name="accessoryType"></param>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Accessory>> ViewAccessory(string accessoryType, string labLocation);

    /// <summary>
    /// This function retrieve a list of entities for each lab.
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Accessory>> GetAccessoriesForLabProfile(string labLocation);
    void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus);
    
    /// <summary>
    /// This function retrieves all the accessories to be displayed for reviewing.
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Accessory>> GetAllAccessoriesForReview(string labLocation);
    
    /// <summary>
    /// Returns a list of devices quantity and type
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType(string labLocation);
    
    /// <summary>
    /// Function to add new accessory into db
    /// </summary>
    /// <param name="accessory"></param>
    /// <returns></returns>
    Task<Entities.Accessory> AddAccessory(Entities.Accessory accessory);
    
    /// <summary>
    /// Return DTO to edit device view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto);
    /// <summary>
    /// Function to delete accessory base on the deletedAccessory object
    /// </summary>
    /// <param name="deletedAccessory"></param>
    /// <returns></returns>
    Task<Entities.Accessory> DeleteAccessory(Entities.Accessory deleteAccessory);
    Task<AccessoryDetailsDTO> AddAccessoryDetails();
    
    /// <summary>
    /// Retrieves Accessory based on id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Entities.Accessory> GetAccessory(int id);
    Task<AccessoryDetailsDTO> EditAccessoryDetails(int id);
}
