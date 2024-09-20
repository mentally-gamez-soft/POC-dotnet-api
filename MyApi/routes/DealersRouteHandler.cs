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
}