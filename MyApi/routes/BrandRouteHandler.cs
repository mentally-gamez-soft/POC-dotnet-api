using MyApi.Models;
using MyApi.Services;

namespace MyApi.routes;

public class BrandRouterHandler {

    public static RouteHandlerBuilder getAllBrands(IEndpointRouteBuilder x){
        var BrandRoute = "/brands";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return ServiceBrand.GenerateAllBrandsRandom();
        }).WithName("GetAllBrands");

    }

    public static RouteHandlerBuilder getRandomBrand(IEndpointRouteBuilder x){
        var BrandRoute = "/brand";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return ServiceBrand.GenerateRandomBrand();
        }).WithName("GetRandomBrand");

    }
    public static RouteHandlerBuilder AddNewBrand(IEndpointRouteBuilder x){
        var BrandRoute = "/add/brand";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return ServiceBrand.AddNewBrand();
        }).WithName("AddNewBrand");

    }

    public static RouteHandlerBuilder GetBrand(IEndpointRouteBuilder x){
        var BrandRoute = "/get/brand";

        return x.MapGet(BrandRoute,(string id) => { 
            return ServiceBrand.GetBrand(id);
        }).WithName("GetBrand");

    }
}