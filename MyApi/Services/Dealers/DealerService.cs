namespace MyApi.Services.Dealers;

using System;
using Microsoft.Extensions.Caching.Memory;
using MyApi.Models;
using MyApi.Persistence;
using MyApi.Services.Addresses;
using MyApi.Services.Brands;

public class DealerService (IAppInMemoryDatabase appInMemoryDB, IMemoryCache cache, ApiDbContext dbContext) : IDealerService{

    private bool RefreshCacheCatalogDealers(List<Dealer> dealers){
        var cacheKey = "dealers";
        cache.Remove(cacheKey);

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, dealers, cacheOptions);

        return true;
    }
    
    public bool AddToCache(Dealer dealer){
        var cacheKey = dealer.DealerId.ToString();

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, dealer, cacheOptions);

        return true;
    }

    public bool RemoveFromCache(Guid dealerId){
        cache.Remove(dealerId.ToString());
        return true;
    }

    public Dealer ReadFromCache(Guid id){
       if (cache.TryGetValue(id.ToString(), out Dealer dealer)){
        return dealer;
       }
       return null;
    }

    private Dealer GenerateRandomDealer(IAddressService addressService, IBrandService brandService, bool addToBDD, bool addToCache) {

        var dealerCode = "DC-" + Dealer.GenerateRandomDealerCode();
        var dealerName = Dealer.GenerateRandomDealerName();
        var dealerAddress = addressService.CreateAddress(false,false);

        var dealer = new Dealer(dealerCode, dealerName, dealerAddress);
        RegisterRandomBrand(dealer,brandService,addToBDD, addToCache);

        if(addToBDD){ 
            appInMemoryDB.SaveObject(dealer);
        }

        if(addToCache){
            AddToCache(dealer);            
        }

        return dealer;
    }
    private List<Dealer> GenerateRandomDealers(IAddressService addressService, IBrandService brandService, bool addToBDD, bool addToCache){
        IEnumerable<Dealer> dealers = Enumerable.Range(1, 100).Select(a => GenerateRandomDealer(addressService, brandService, addToBDD, addToCache));
        RefreshCacheCatalogDealers(dealers.ToList()); 
        return dealers.ToList();
    }

    private void RegisterRandomBrand(Dealer dealer, IBrandService brandService, bool addToBDD, bool addToCache) {

        var brand = brandService.CreateBrand(addToBDD, addToCache);

        dealer.RegisterBrandToDealer(brand);
    }

    public Dealer CreateDealer(IAddressService addressService, IBrandService brandService, bool addToBDD, bool addToCache)
    {
        var newDealer = GenerateRandomDealer(addressService,brandService, addToBDD, addToCache);

        return newDealer;
    }

    public List<Dealer> CreateDealers(IAddressService addressService, IBrandService brandService,bool addToBDD, bool addToCache)
    {
        return GenerateRandomDealers(addressService,brandService, addToBDD, addToCache); 
    }


    public Dealer GetDealerById(Guid dealerId)
    {
        if(ReadFromCache(dealerId) is Dealer _dealer){
            return _dealer;
        }      
        else if (appInMemoryDB.GetDealerById(dealerId) is Dealer dealer)
        {
            AddToCache(dealer);
            return dealer;
        }

        return null;
    }

    public List<Dealer> GetDealers(){
        return appInMemoryDB.GetAllDealers();
    }

    public bool DeleteDealer(Guid dealerId){
        return appInMemoryDB.DeleteDealer(dealerId) && RemoveFromCache(dealerId);
    }

}
 