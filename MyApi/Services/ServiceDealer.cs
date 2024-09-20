namespace MyApi.Services;

using MyApi.Models;

public class ServiceDealer {

    public ServiceDealer(){}

    public static Dealer GenerateRandomDealer() {

        var dealerCode = "DC-" + Dealer.GenerateRandomDealerCode();
        var dealerName = Dealer.GenerateRandomDealerName();
        var dealerAddress = ServiceAddress.GenerateRandomAddress();

        return new Dealer(dealerCode, dealerName, dealerAddress);
    }

    public static void RegisterRandomBrand(Dealer dealer) {

        var brand = ServiceBrand.GenerateRandomBrand();

        dealer.RegisterBrandToDealer(brand);
    }

}
  