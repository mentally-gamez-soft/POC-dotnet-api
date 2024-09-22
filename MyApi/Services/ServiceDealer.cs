namespace MyApi.Services;

using System;
using MyApi.Models;

public class ServiceDealer {

    public ServiceDealer(){}

    public static Dealer GenerateRandomDealer() {

        var dealerCode = "DC-" + Dealer.GenerateRandomDealerCode();
        var dealerName = Dealer.GenerateRandomDealerName();
        var dealerAddress = ServiceAddress.GenerateRandomAddress();

        var dealer = new Dealer(dealerCode, dealerName, dealerAddress);
        RegisterRandomBrand(dealer);

        return dealer;
    }

    public static void RegisterRandomBrand(Dealer dealer) {

        var brand = ServiceBrand.GenerateRandomBrand();

        dealer.RegisterBrandToDealer(brand);
    }

    public static List<Dealer> GenerateAllDealersRandom(){
        IEnumerable<Dealer> dealers = Enumerable.Range(1, 100).Select(a => GenerateRandomDealer());
        return dealers.ToList();
    }

    internal static object AddNewDealer()
    {
        var newDealer = GenerateRandomDealer();
        // TODO Add to cache the address
        return newDealer;
    }

    internal static object GetDealer(string id)
    {
        var newDealer = GenerateRandomDealer();
        // TODO search for the address in cache / BDD / Memory ...
        return newDealer;
    }
}
  