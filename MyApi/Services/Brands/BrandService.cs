namespace MyApi.Services.Brands;

using Microsoft.Extensions.Caching.Memory;
using MyApi.Models;
using MyApi.Persistence;

public class BrandService (IAppInMemoryDatabase appInMemoryDB, IMemoryCache cache, ApiDbContext dbContext): IBrandService {

    private bool RefreshCacheCatalogBrands(List<Brand> brands){
        var cacheKey = "brands";
        cache.Remove(cacheKey);

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, brands, cacheOptions);

        return true;
    }
    
    public bool AddToCache(Brand brand){
        var cacheKey = brand.BrandId.ToString();

        var cacheOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                                .SetPriority(CacheItemPriority.Normal);
        
        cache.Set(cacheKey, brand, cacheOptions);

        return true;
    }
    
    public bool RemoveFromCache(Guid brandId){
        cache.Remove(brandId.ToString());
        return true;
    }

    public Brand ReadFromCache(Guid id){
       if (cache.TryGetValue(id.ToString(), out Brand brand)){
        return brand;
       }
       return null;
    }
 
    private Brand GenerateRandomBrand(bool addToBDD, bool addToCache){
        var brands = Brand.getAllBrands();
        var brandName = brands[Random.Shared.Next(brands.Count)];
        var brandCode = "BR-" + Brand.GenerateRandomBrandCode();

        var newBrand = new Brand (brandCode,brandName);

        if(addToBDD){ 
            appInMemoryDB.SaveObject(newBrand);
        }

        if(addToCache){
            AddToCache(newBrand);            
        }

        return newBrand;
    }

    private List<Brand> GenerateRandomBrands(bool addToBDD, bool addToCache){
        IEnumerable<Brand> brands = Enumerable.Range(1, 30).Select(a => GenerateRandomBrand(addToBDD, addToCache));

        RefreshCacheCatalogBrands(brands.ToList()); 

        return brands.ToList();
    }

    public Brand CreateBrand(bool addToBDD, bool addToCache)
    {
        var newBrand = GenerateRandomBrand(addToBDD, addToCache);

        return newBrand;
    }
    public List<Brand> CreateBrands(bool addToBDD, bool addToCache)
    {
        var newBrand = GenerateRandomBrands(addToBDD, addToCache);

        return newBrand;
    }

    public Brand GetBrandById(Guid brandId) {
        if(ReadFromCache(brandId) is Brand _brand){
            return _brand;
        }      
        else if (appInMemoryDB.GetBrandById(brandId) is Brand brand)
        {
            AddToCache(brand);
            return brand;
        }

        return null;
    }
   
    public List<Brand> GetBrands(){
        return appInMemoryDB.GetAllBrands() ;
    }

    public bool DeleteBrand(Guid brandId){
        return appInMemoryDB.DeleteBrand(brandId) && RemoveFromCache(brandId) ;
    }

}
