namespace MyApi.Services.Addresses;

using Microsoft.Extensions.Caching.Memory;
using MyApi.Models;
using MyApi.Persistence;

public class AddressService(IAppInMemoryDatabase appInMemoryDB, IMemoryCache cache, ApiDbContext dbContext) : IAddressService {    
    
    private bool RefreshCacheCatalogAddresses(List<Address> addresses){
        var cacheKey = "addresses";
        cache.Remove(cacheKey);

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, addresses, cacheOptions);

        return true;

    }

    private bool AddToCache(Address address){
        var cacheKey = address.AddressId.ToString();

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, address, cacheOptions);

        return true;
    }

    private bool RemoveFromCache(Guid id){
        cache.Remove(id.ToString());
        return true;
    }

    private Address ReadFromCache(Guid id){
       if (cache.TryGetValue(id.ToString(), out Address address)){
        return address;
       }
       return null;
    }

    private Address GenerateRandomAddress(bool addToBDD, bool addToCache){
        var Countries = new List<string>(){"France","Spain","Belgium","Italy"};
        var Towns = new List<string>(){"Paris","Madrid","Marseille","Rimini","Palermo","Valencia","Barcelona"};
        var Streets = new List<string>(){"C/ Gal Pardinas","C/ La Concepcion","Rue du pere Lachaise","Via Sol","Rue du marche","Paseo el Retiro","Rua La Diagonal"};


        var country = Countries[Random.Shared.Next(Countries.Count)];
        var town = Towns[Random.Shared.Next(Towns.Count)];
        var street = Streets[Random.Shared.Next(Streets.Count)];
        var number = Random.Shared.Next(1,150).ToString();

        Address newAddress =  new Address (country,town,street,number);

        if(addToBDD){ 
            appInMemoryDB.SaveObject(newAddress);
        }

        if(addToCache){
                AddToCache(newAddress);
            
        }

        return newAddress;
    }

    private List<Address> GenerateRandomAddresses(bool addToBDD, bool addToCache){
        IEnumerable<Address> addresses = Enumerable.Range(1, 100).Select(a => GenerateRandomAddress(addToBDD, addToCache));

        RefreshCacheCatalogAddresses(addresses.ToList());  // The full list addresses is cached.
        return addresses.ToList();
    }

    public Address CreateAddress(bool addToBDD, bool addToCache) {
        var newAddress = GenerateRandomAddress(addToBDD, addToCache);

        return newAddress;
    }

    public List<Address> CreateAddresses(bool addToBDD, bool addToCache) {
        var addresses = GenerateRandomAddresses(addToBDD, addToCache);

        return addresses;
    }

    public Address GetAddressById(Guid addressId) {
        if(ReadFromCache(addressId) is Address _address){
            return _address;
        } 
        /*else if (dbContext.Addresses.Find(addressId) is Address address)         
        {
            Console.WriteLine($"GetAddress found in in memory DB -> {address}");
            return address;
        }*/
        else if (appInMemoryDB.GetAddressById(addressId) is Address _address_)
        {
            AddToCache(_address_);
            return _address_;
        } 
        return null;
    }

    public List<Address> GetAddresses(){
        return appInMemoryDB.GetAllAddresses() ;
    }

    public bool DeleteAddress(Guid addressId){
        return appInMemoryDB.DeleteAddress(addressId) && RemoveFromCache(addressId) ;
    }

    /*public async Task AddAddress() {
        var newAddress = GenerateRandomAddress();
        
        // Add to database the address
        await dbContext.Addresses.AddAsync(newAddress);
        await dbContext.SaveChangesAsync();
    }*/

    

}
