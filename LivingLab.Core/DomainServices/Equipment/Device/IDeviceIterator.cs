using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;

public interface IDeviceIterator
{
    public bool HasNext();
    public ViewDeviceTypeDTO Next();

    public ViewDeviceTypeDTO First();
}
