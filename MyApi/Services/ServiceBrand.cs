namespace MyApi.Services;

using MyApi.Models;

public class ServiceBrand {
    public ServiceBrand(){}

    public static Brand GenerateRandomBrand(){
        var brands = Brand.getAllBrands();
        var brandName = brands[Random.Shared.Next(brands.Count)];
        var brandCode = "BR-" + Brand.GenerateRandomBrandCode();

        return new Brand (brandCode,brandName);
    }

    public static List<Brand> GenerateAllBrandsRandom(){
        IEnumerable<Brand> brands = Enumerable.Range(1, 30).Select(a => GenerateRandomBrand());
        return brands.ToList();
    }
 
}
