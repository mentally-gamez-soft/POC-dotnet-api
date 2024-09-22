using MyApi.Models;
using MyApi.Services;

namespace MyApi.routes;

public class DealersRouterHandler {

    public static RouteHandlerBuilder getAllDealers(IEndpointRouteBuilder x){
        var addressRoute = "/dealers";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return ServiceDealer.GenerateAllDealersRandom();
        }).WithName("getAllDealers");

    }

    public static RouteHandlerBuilder getRandomDealer(IEndpointRouteBuilder x){
        var addressRoute = "/dealer";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return ServiceDealer.GenerateRandomDealer();
        }).WithName("GetRandomDealer");

    }
    
    public static RouteHandlerBuilder AddNewDealer(IEndpointRouteBuilder x){
        var BrandRoute = "/add/dealer";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return ServiceDealer.AddNewDealer();
        }).WithName("AddNewDealer");

    }

    public static RouteHandlerBuilder GetDealer(IEndpointRouteBuilder x){
        var BrandRoute = "/get/dealer";

        return x.MapGet(BrandRoute,(string id) => { 
            return ServiceDealer.GetDealer(id);
        }).WithName("GetDealer");

    }
}