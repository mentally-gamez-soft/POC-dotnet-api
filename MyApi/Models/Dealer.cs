namespace MyApi.Models;

using System.Collections.Generic;
using System.Linq;
using Fare;

public class Dealer {
    public string DealerCode {get; set;}
    public string DealerName {get; set;}
    public Address DealerAddress {get; set;}

    private List<Brand> Brands;

    public Dealer(string dealerCode, string dealerName, Address address){
        Brands = new List<Brand>();

        DealerCode = dealerCode;
        DealerName = dealerName;
        DealerAddress = address;
    }

    public Dealer(string dealerCode, string dealerName, Address address, List<Brand> brands){
        Brands = brands;
        
        DealerCode = dealerCode;
        DealerName = DealerName;
        DealerAddress = address;
    }

    public Dealer(){
        Brands = new List<Brand>();

        DealerCode = "DC-0000-9999";
        DealerName = "Default Dealer";

        DealerAddress = new Address {
            Country = "Spain",
            Town = "Madrid",
            Street = "C/ Alcala",
            Number = "212 BIS",
        };
    }

    public static string GenerateRandomDealerCode(){
        var pattern = "[0-9]{3}-[0-9]{4}";
        var xeger = new Xeger(pattern);
        return xeger.Generate();
    }

    public static string GenerateRandomDealerName(){
        var pattern = "[a-zA-Z]{20}";
        var xeger = new Xeger(pattern);
        return xeger.Generate();
    }    

    public void RegisterBrandToDealer(Brand brand){
        Brands.Add(brand);
    }

    public override string ToString()
    {
        return $"Dealer: {DealerCode} - {DealerName} - {DealerAddress}";
    }
    
}