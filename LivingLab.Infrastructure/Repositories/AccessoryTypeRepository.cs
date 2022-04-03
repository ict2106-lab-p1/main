using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class AccessoryTypeRepository : Repository<AccessoryType>, IAccessoryTypeRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryTypeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.ID == id);
    //    return todo?.Title;
    //}

}
