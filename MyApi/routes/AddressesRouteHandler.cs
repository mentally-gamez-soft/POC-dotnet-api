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

    public static RouteHandlerBuilder AddNewAddress(IEndpointRouteBuilder x){
        var addressRoute = "/add/address";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return ServiceAddress.AddNewAddress();
        }).WithName("AddNewAddress");

    }

    public static RouteHandlerBuilder GetAddress(IEndpointRouteBuilder x){
        var addressRoute = "/get/address";

        return x.MapGet(addressRoute,(string id) => { 
            return ServiceAddress.GetAddress(id);
        }).WithName("GetAddress");

    }
}