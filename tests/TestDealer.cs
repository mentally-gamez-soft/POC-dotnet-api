using MyApi.Models;
using Xunit;

namespace tests;
public class TestDealer {

    [Fact]
    public void Test_New_Dealer_With_All_Parameters()
    {
        string dealerCode = "DC-0001-1000";
        string dealerName = "Madrid Automotive";

        Address dealerAddress = new Address {
            Country = "Spain",
            Town = "Valencia",
            Street = "C/ La Concepcion",
            Number = "42",
        };
        Dealer dealer = new Dealer(dealerCode, dealerName, dealerAddress);

        Assert.Equal("DC-0001-1000",dealer.DealerCode);
        Assert.Equal("Madrid Automotive",dealer.DealerName); 
        Assert.Equal("C/ La Concepcion",dealer.DealerAddress.Street); 
    }

    [Fact]
    public void Test_New_Default_Dealer_With_No_Parameters()
    {
        Dealer dealer = new Dealer();

        Assert.Equal("DC-0000-9999",dealer.DealerCode);
        Assert.Equal("Default Dealer",dealer.DealerName); 
        Assert.Equal("Madrid",dealer.DealerAddress.Town); 
        Assert.Equal("C/ Alcala",dealer.DealerAddress.Street); 
    }
}