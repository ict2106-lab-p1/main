using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;

public class NameIterator : IDeviceIterator
{
    private int _index;
    private DeviceCollection _collection;

    public NameIterator(DeviceCollection collection)
    {
        _collection = collection;
    }

    public ViewDeviceTypeDTO First()
    {
        return _collection.GetDevice(0);
    }
    
    public bool HasNext()
    {
        return _index < _collection.Count;
    }

    public ViewDeviceTypeDTO Next()
    {
        return this.HasNext() ? _collection.GetDevice(_index++) : new ViewDeviceTypeDTO();
    }
}
