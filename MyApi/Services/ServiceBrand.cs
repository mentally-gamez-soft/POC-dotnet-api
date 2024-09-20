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
}
