using Microsoft.VisualBasic;

namespace MyApi.Models;

public class Brand{

    public static string getRandomBrand() {
        //Console.WriteLine("Call of getRandomBrand()");
        var brands = new[]{"Ford","Renault","Peugeot","Seat","VolksWggen","BMW","FIAT","Jaguar"};
        var brand = brands[Random.Shared.Next(brands.Length)];

        //Console.WriteLine(brand);

        return brand;
    }

    public static string[] getAllBrands(){
        //Console.WriteLine("Call of getAllBrands()");
        return ["Ford","Renault","Peugeot","Seat","VolksWggen","BMW","FIAT","Jaguar"];
    }
}