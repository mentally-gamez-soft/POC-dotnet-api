using MyApi.Models;

namespace MyApi.Services.Brands;

public interface IBrandService
{
    public Brand CreateBrand(bool addToBDD, bool addToCache);
    public List<Brand> CreateBrands(bool addToBDD, bool addToCache); 
    public Brand GetBrandById(Guid brandId);
    public List<Brand> GetBrands();
    public bool DeleteBrand(Guid brandId);
}
   
    
    