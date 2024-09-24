using MyApi.Models;

namespace MyApi.Services.Addresses;

public interface IAddressService
{
    public Address CreateAddress(bool addToBDD, bool addToCache);
    public List<Address> CreateAddresses(bool addToBDD, bool addToCache);
    public Address GetAddressById(Guid addressId);
    public List<Address> GetAddresses();
    public bool DeleteAddress(Guid addressId);
}