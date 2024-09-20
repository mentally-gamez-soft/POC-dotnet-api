using MyApi.Models;
using Xunit;
using System.Text.RegularExpressions;
using MyApi.Services;

namespace tests;
public class TestBrand {

    [Fact]
    public void Test_New_Brand_With_All_Parameters()
    {
        string brandCode = "BR-001-1000";
        string brandName = "Ford";

        Brand brand = new Brand (brandCode,brandName);

        Assert.Equal("BR-001-1000",brand.BrandCode);
        Assert.Equal("Ford",brand.BrandName); 
    }

    [Fact]
    public void Test_New_Default_Brand_With_No_Parameters()
    {
        Brand brand = new Brand ();

        Assert.Equal("BR-000-9999",brand.BrandCode);
        Assert.Equal("Default Brand",brand.BrandName); 
    }

    [Fact]
    public void Test_Generate_Random_Brand_Code()
    {
        string actual = Brand.GenerateRandomBrandCode();

        Assert.True(Regex.Match(actual, @"[0-9]{3}-[0-9]{4}", RegexOptions.IgnoreCase).Success);
    }  
    
    [Fact]
    public void Test_Generate_Random_Brand()
    {
        var actual = ServiceBrand.GenerateRandomBrand();
        var expected = typeof(Brand);

        Assert.IsType(expected, actual);
    }  
}

