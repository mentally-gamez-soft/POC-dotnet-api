using MyApi.Models;

namespace MyApi.routes;

public class BrandRouterHandler {

    public static RouteHandlerBuilder getAllBrands(IEndpointRouteBuilder x){
        var BrandRoute = "/brands";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return Brand.getAllBrands();
        }).WithName("GetAllBrands");

    }

    public static RouteHandlerBuilder getRandomBrand(IEndpointRouteBuilder x){
        var BrandRoute = "/brand";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return Brand.getRandomBrand();
        }).WithName("GetRandomBrand");

    }
}