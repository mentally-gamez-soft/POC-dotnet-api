using MyApi.Models;
using Xunit;

namespace tests;
public class MyApiTest
{
    [Fact]
    public void Test_Brand_Jaguar_Is_Implemented()
    {

        var brand_jaguar = "Jaguar";

        var list_brands = Brand.getAllBrands();

        Assert.Contains(brand_jaguar,list_brands);
    }

    [Fact]
    public void Test_Brand_Volvo_Is_Not_Implemented()
    {

        var brand_jaguar = "Volvo";

        var list_brands = Brand.getAllBrands();

        Assert.DoesNotContain(brand_jaguar,list_brands);
    }
 
}