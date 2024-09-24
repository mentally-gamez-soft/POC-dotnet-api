using MyApi.Models;
using MyApi.Services;
using MyApi.Services.Brands;

namespace MyApi.routes;

public class BrandRouterHandler {

    public static RouteHandlerBuilder GetBrands(IEndpointRouteBuilder x, IBrandService brandService){
        var addressRoute = "/list-brands";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return brandService.GetBrands();
        }).WithName("list-brands");
    }

    public static RouteHandlerBuilder GetBrandByGuid(IEndpointRouteBuilder x, IBrandService brandService){
        var addressRoute = "/get-brand";

        return x.MapGet(addressRoute,(string id) => { 
            return brandService.GetBrandById(Guid.Parse(id));
        }).WithName("get-brand");
    }
    
    public static RouteHandlerBuilder CreateBrands(IEndpointRouteBuilder x, IBrandService brandService){
        var addressRoute = "/generate-set-of-brands";

        return x.MapPost(addressRoute,(bool addToBDD, bool addToCache) => {
            return brandService.CreateBrands(addToBDD, addToCache);
        }).WithName("generate-set-of-brands");

    }

    public static RouteHandlerBuilder CreateBrand(IEndpointRouteBuilder x, IBrandService brandService){
        var addressRoute = "/create-brand";
        return x.MapPost(addressRoute, (bool addToBDD, bool addToCache) => {
            return brandService.CreateBrand(addToBDD, addToCache);
        }).WithName("create-brand");

    }

    public static RouteHandlerBuilder DeleteBrand(IEndpointRouteBuilder x, IBrandService brandService){
        var addressRoute = "/delete-brand";

        return x.MapPost(addressRoute, (string id) => {
            brandService.DeleteBrand(Guid.Parse(id));
            return Results.Created();
        }).WithName("delete-brand");

    }    
}