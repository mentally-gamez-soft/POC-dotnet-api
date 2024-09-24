using MyApi.Models;
using MyApi.Services.Addresses;
using MyApi.Services.Brands;

namespace MyApi.Services.Dealers;

public interface IDealerService
{
    public Dealer CreateDealer(IAddressService addressService, IBrandService brandService, bool addToBDD, bool addToCache);
    public List<Dealer> CreateDealers(IAddressService addressService, IBrandService brandService,bool addToBDD, bool addToCache);
    public Dealer GetDealerById(Guid dealerId);
    public List<Dealer> GetDealers();
    public bool DeleteDealer(Guid dealerId);
}