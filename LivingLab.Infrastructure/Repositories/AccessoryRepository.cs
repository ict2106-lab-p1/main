using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType)
    {
        // retrieve accessory table together with accessory type details using include to join entities 
        List <Accessory> accessories = await _context.Accessory.Include(a => a.AccessoryType)
            .Where(t => accessoryType.Contains(t.AccessoryType.Type))
            .ToListAsync();
        return accessories;
    }
   

    public async Task<List<ViewAccessoryTypeDTO>> GetAccessoryType()
    {
        var accessoryGroup = await _context.Accessory.Include(a => a.AccessoryType)
            .GroupBy(t => t.AccessoryType!.Type)
            .Select(t=> new{Key = t.Key, Count = t.Count()})
            .ToListAsync();
        List<ViewAccessoryTypeDTO> accessoryTypeDtos = new List<ViewAccessoryTypeDTO>();
        foreach (var group in accessoryGroup)
        {
            ViewAccessoryTypeDTO accessoryTypeDto = new ViewAccessoryTypeDTO();
            accessoryTypeDto.Type = group.Key;
            accessoryTypeDto.Quantity = group.Count;
            accessoryTypeDtos.Add(accessoryTypeDto);
        }
        
        return accessoryTypeDtos;
    }

}