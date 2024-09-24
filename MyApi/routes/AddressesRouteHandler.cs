using MyApi.Models;
using MyApi.Services;
using MyApi.Services.Addresses;

namespace MyApi.routes;

public class AddressRouterHandler {

    public static RouteHandlerBuilder GetAddresses(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/list-addresses";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return addressService.GetAddresses();
        }).WithName("list-addresses");
    }

    public static RouteHandlerBuilder GetAddressByGuid(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/get-address";

        return x.MapGet(addressRoute,(string id) => { 
            return addressService.GetAddressById(Guid.Parse(id));
        }).WithName("get-address");
    }

    // method to create a set of addresses randomly generated.
    public static RouteHandlerBuilder CreateAddresses(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/generate-set-of-addresses";

        return x.MapPost(addressRoute,(bool addToBDD, bool addToCache) => {
            return addressService.CreateAddresses(addToBDD, addToCache);
        }).WithName("generate-set-of-addresses");

    }

    // method to create one address randomly
    public static RouteHandlerBuilder CreateAddress(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/create-address";

        return x.MapPost(addressRoute, (bool addToBDD, bool addToCache) => {
            return addressService.CreateAddress(addToBDD, addToCache);
        }).WithName("create-address");

    }

    public static RouteHandlerBuilder DeleteAddress(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/delete-address";

        return x.MapPost(addressRoute, (string id) => {
            addressService.DeleteAddress(Guid.Parse(id));
            return Results.Created();
        }).WithName("delete-address");

    }    



    /*public static RouteHandlerBuilder GetRandomAddress(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/address";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return addressService.GenerateRandomAddress();
        }).WithName("GetRandomAddress");

    }*/

    /*public static RouteHandlerBuilder AddNewAddress(IEndpointRouteBuilder x, IAddressService addressService){
        var addressRoute = "/add/address";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return addressService.AddNewAddress();
        }).WithName("AddNewAddress");

    }*/





}