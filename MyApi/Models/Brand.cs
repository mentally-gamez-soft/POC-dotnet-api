using Microsoft.VisualBasic;
using Fare;

namespace MyApi.Models;

public class Brand{

    public string BrandCode {get; set;}
    public string BrandName {get; set;}

    public Guid BrandId {get;set;}

    public Brand(string brandCode, string brandName){
        BrandCode = brandCode;
        BrandName = brandName;
        BrandId = Guid.NewGuid();
    }

    public Brand() {
        BrandCode = "BR-000-9999";
        BrandName = "Default Brand";
        BrandId = Guid.NewGuid();
    }

    public static string GenerateRandomBrandCode(){
        var pattern = "[0-9]{3}-[0-9]{4}";
        var xeger = new Xeger(pattern);
        return xeger.Generate();
    }

    public static string getRandomBrand() {
        var brands = getAllBrands();
        var brand = brands[Random.Shared.Next(brands.Count)];

        return brand;
    }

    public static List<string> getAllBrands() {
        return new List<string>(){"Ford","Renault","Peugeot","Jaguar","Fiat","Seat","BMW","Volkswaggen","Abarth","Mazda","Toyota"};
    }

    public override string ToString()
    {
        return $"[ID -> {BrandId}] - Brand: {BrandCode} - {BrandName}";
    }
}