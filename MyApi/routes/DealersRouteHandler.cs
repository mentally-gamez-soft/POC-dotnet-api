using MyApi.Models;
using MyApi.Services;
using MyApi.Services.Addresses;
using MyApi.Services.Brands;
using MyApi.Services.Dealers;

namespace MyApi.routes;

public class DealersRouterHandler {

    public static RouteHandlerBuilder GetDealers(IEndpointRouteBuilder x, IDealerService dealerService){
        var addressRoute = "/list-dealers";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return dealerService.GetDealers();
        }).WithName("list-dealers");
    }

    public static RouteHandlerBuilder GetDealerByGuid(IEndpointRouteBuilder x, IDealerService dealerService){
        var addressRoute = "/get-dealer";

        return x.MapGet(addressRoute,(string id) => { 
            return dealerService.GetDealerById(Guid.Parse(id));
        }).WithName("get-dealer");
    }

    public static RouteHandlerBuilder CreateDealers(IEndpointRouteBuilder x, IDealerService dealerService, IAddressService addressService, IBrandService brandService){
        var addressRoute = "/generate-set-of-dealers";

        return x.MapPost(addressRoute,(bool addToBDD, bool addToCache) => {
            return dealerService.CreateDealers(addressService, brandService, addToBDD, addToCache);
        }).WithName("generate-set-of-dealers");

    }

    public static RouteHandlerBuilder CreateDealer(IEndpointRouteBuilder x,  IDealerService dealerService, IAddressService addressService, IBrandService brandService){
        var addressRoute = "/create-dealer";
        return x.MapPost(addressRoute, (bool addToBDD, bool addToCache) => {
            return dealerService.CreateDealer(addressService, brandService, addToBDD, addToCache);
        }).WithName("create-dealer");

    } 
    public static RouteHandlerBuilder DeleteDealer(IEndpointRouteBuilder x, IDealerService dealerService){
        var addressRoute = "/delete-dealer";

        return x.MapPost(addressRoute, (string id) => {
            dealerService.DeleteDealer(Guid.Parse(id));
            return Results.Created();
        }).WithName("delete-dealer");

    }    

    /*public static RouteHandlerBuilder GetAllDealers(IEndpointRouteBuilder x, IDealerService dealerService, IAddressService addressService, IBrandService brandService){
        var addressRoute = "/dealers";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return dealerService.GenerateAllDealersRandom(addressService, brandService);
        }).WithName("getAllDealers");

    }

    public static RouteHandlerBuilder GetRandomDealer(IEndpointRouteBuilder x, IDealerService dealerService, IAddressService addressService, IBrandService brandService){
        var addressRoute = "/dealer";

        return x.MapGet(addressRoute,(HttpRequest request) => {
            return dealerService.GenerateRandomDealer(addressService, brandService);
        }).WithName("GetRandomDealer");

    }
    
    public static RouteHandlerBuilder AddNewDealer(IEndpointRouteBuilder x, IDealerService dealerService, IAddressService addressService, IBrandService brandService){
        var BrandRoute = "/add/dealer";

        return x.MapGet(BrandRoute,(HttpRequest request) => {
            return dealerService.AddNewDealer(addressService, brandService);
        }).WithName("AddNewDealer");

    }*/
 
}