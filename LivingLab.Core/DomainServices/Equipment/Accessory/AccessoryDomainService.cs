using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Repositories.Equipment;

namespace LivingLab.Core.DomainServices.Equipment.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryDomainService : IAccessoryDomainService
{
    private readonly IAccessoryRepository _accessoryRepository;
    private readonly IAccessoryTypeRepository _accessoryTypeRepository;

    public AccessoryDomainService(IAccessoryRepository accessoryRepository, IAccessoryTypeRepository accessoryTypeRepository)
    {
        _accessoryRepository = accessoryRepository;
        _accessoryTypeRepository = accessoryTypeRepository;
    }
    
    /// <summary>
    /// This function retrieve a list of entities for each lab.
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Accessory>> GetAccessoriesForLabProfile(string labLocation)
    {
        return _accessoryRepository.GetAccessoriesForLabProfile(labLocation);
    }
    
    /// <summary>
    /// This function updates the review status of the accessory
    /// </summary>
    /// <param name="accessoryId"></param>
    /// <param name="accessoryReviewStatus"></param>
    public void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus)
    {
        _accessoryRepository.UpdateAccessoryStatus(accessoryId, accessoryReviewStatus);
    }
    /// <summary>
    /// This function retrieves all the accessories to be displayed for reviewing.
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Accessory>> GetAllAccessoriesForReview(string labLocation)
    {
        return _accessoryRepository.GetAllAccessoriesForReview(labLocation);
    }
    
    /// <summary>
    /// This function returns a list of accessory base on the selected accessory type and lab.
    /// </summary>
    /// <param name="accessoryType"></param>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<Entities.Accessory>> ViewAccessory(string accessoryType, string labLocation)
    {
        return _accessoryRepository.GetAccessoryWithAccessoryType(accessoryType, labLocation);
    }
    
    /// <summary>
    /// Returns a list of devices quantity and type
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    public Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType(string labLocation)
    {
        return _accessoryRepository.GetAccessoryType(labLocation);
    }
    
    /// <summary>
    /// Returns a list of AccessoryType 
    /// </summary>
    /// <returns></returns>
    public Task<List<AccessoryType>> GetAllAsyncAccessoryType()
    {
        return _accessoryTypeRepository.GetAllAsync();
    }

    /// <summary>
    /// Return the last accessory record in the db.
    /// </summary>
    /// <returns></returns>
    public Task<Entities.Accessory> GetAccessoryLastRow()
    {
        return _accessoryRepository.GetLastRow();
    }

    /// <summary>
    /// Retrieves Accessory based on id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Entities.Accessory> GetAccessory(int id)
    {
        return _accessoryRepository.GetAccessory(id);
    }

    /// <summary>
    /// Edit existing device based on the details given
    /// </summary>
    /// <param name="accessoryDetailsDto"></param>
    /// <returns></returns>
    public async Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto)
    {
        return await _accessoryRepository.EditAccessory(accessoryDetailsDto);
    }
    
    /// <summary>
    /// Return a DTO to populate p Rule
    /// </summary>
    /// <returns></returns>
    public async Task<AccessoryDetailsDTO> AddAccessoryDetails()
    {
        Entities.Accessory accessory = await _accessoryRepository.GetLastRow();
        List<AccessoryType> accessoryTypeList = await _accessoryTypeRepository.GetAllAsync();
        return new AccessoryDetailsDTO
        {
            Accessory = accessory, AccessoryTypes = accessoryTypeList
        };
    }

    /// <summary>
    /// Return DTO to edit device view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AccessoryDetailsDTO> EditAccessoryDetails(int id)
    {
        Entities.Accessory accessory = await _accessoryRepository.GetAccessory(id);
        List<AccessoryType> accessoryTypeList = await _accessoryTypeRepository.GetAllAsync();
        return new AccessoryDetailsDTO
        {
            Accessory = accessory, AccessoryTypes = accessoryTypeList
        };
    }

    /// <summary>
    /// Function to add new accessory into db
    /// </summary>
    /// <param name="accessory"></param>
    /// <returns></returns>
    public async Task<Entities.Accessory> AddAccessory(Entities.Accessory accessory)
    {
        await _accessoryRepository.AddAsync(accessory);
        
        return accessory;
    }
    
    /// <summary>
    /// Function to delete accessory base on the deletedAccessory object
    /// </summary>
    /// <param name="deletedAccessory"></param>
    /// <returns></returns>
    public Task<Entities.Accessory> DeleteAccessory(Entities.Accessory deletedAccessory)
    {
        return _accessoryRepository.DeleteAccessory(deletedAccessory);
    }
}
