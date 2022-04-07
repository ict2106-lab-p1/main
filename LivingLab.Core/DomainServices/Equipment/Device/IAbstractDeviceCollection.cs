namespace LivingLab.Core.DomainServices.Equipment.Device;

public interface IAbstractDeviceCollection
{
    IDeviceIterator CreateIterator();
}
