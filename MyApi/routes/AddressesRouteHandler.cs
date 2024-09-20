using MyApi.Models;
using MyApi.Services;

namespace MyApi.routes;

public class AddressRouterHandler {

    public static RouteHandlerBuilder getAllAddresses(IEndpointRouteBuilder x){
        var addressRoute = "/addresses";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return ServiceAddress.GenerateAllAddressesRandom();
        }).WithName("GetAllAddresses");

    }

    public static RouteHandlerBuilder getRandomAddress(IEndpointRouteBuilder x){
        var addressRoute = "/address";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return ServiceAddress.GenerateRandomAddress();
        }).WithName("GetRandomAddress");

    }
}