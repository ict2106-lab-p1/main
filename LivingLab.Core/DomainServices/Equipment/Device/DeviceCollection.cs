using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;

public class DeviceCollection : IAbstractDeviceCollection
{
    private List<ViewDeviceTypeDTO> _deviceDTOList = new();

    public IDeviceIterator CreateIterator()
    {
        return new NameIterator(this);
    }
    public int Count
    {
        get { return _deviceDTOList.Count; }
    }

    public void AddDevice(ViewDeviceTypeDTO device)
    {
        _deviceDTOList.Add(device);
    }

    public ViewDeviceTypeDTO GetDevice(int index)
    {
        return _deviceDTOList[index];
    }
}