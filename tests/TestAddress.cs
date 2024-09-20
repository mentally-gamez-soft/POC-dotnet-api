using MyApi.Models;
using Xunit;
using MyApi.Services;

namespace tests;
public class TestAddress
{ 
    [Fact]
    public void Test_New_Address_With_All_Parameters()
    {
        string country = "France";
        string town = "Paris";
        string street = "Rue du pere Lachaise";
        string number = "132 BIS";

        Address address = new Address (country,town,street,number);

        Assert.Equal("France",address.Country);
        Assert.Equal("Paris",address.Town);
        Assert.Equal( "Rue du pere Lachaise",address.Street);
        Assert.Equal("132 BIS",address.Number);
    }

    [Fact]
    public void Test_New_Default_Address_With_No_Parameters()
    {
        Address address = new Address ();

        Assert.Equal("Spain",address.Country);
        Assert.Equal("Madrid",address.Town);
        Assert.Equal("C/ Alcala",address.Street);
        Assert.Equal("212 BIS",address.Number);
    }

    [Fact]
    public void Test_Service_Address_GenerateRandomAddress_Return_Address(){

        var expected = typeof(Address);
        var actual = ServiceAddress.GenerateRandomAddress();

        Assert.IsType(expected, actual);
    }

    [Fact]
    public void Test_GenerateAllAddressesRandom(){

        var expected = typeof(Address);
        var adresses = ServiceAddress.GenerateAllAddressesRandom();

        foreach(Address actual in adresses){      
            Assert.IsType(expected, actual);
        }

    }
}