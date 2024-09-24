using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyApi.Persistence;
using MyApi.routes;
using MyApi.Services.Addresses;
using MyApi.Services.Brands;
using MyApi.Services.Dealers;

namespace MyWeatherApi;

public class Startup {

    public Startup(IConfiguration configuration){
        Configuration = configuration;
    }

    public IConfiguration Configuration {get;}

    public void ConfigureServices(IServiceCollection services){

        var connectionStringSQLite = "Data Source=MyDB.db";
        var connectionStringPGSQL = "Host=192.168.0.15; Port=5433; Database=poc_dotnet_api; Username=api_admin; Password=pgsql.admin123";

        Console.WriteLine("Start services configuration");

        services.AddEndpointsApiExplorer();

        // Register service for in memory db
        services.AddScoped<IAppInMemoryDatabase, AppInMemoryDatabase>();

        // Register address service
        services.AddScoped<IAddressService,AddressService>();
        
        // Register brand service
        services.AddScoped<IBrandService,BrandService>();

        // Register dealer service
        services.AddScoped<IDealerService,DealerService>();

        // add database context
        // services.AddDbContext<ApiDbContext>(options => options.UseSqlite(connectionStringSQLite));        
        services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionStringPGSQL));     

        // add cache in memory
        services.AddMemoryCache();

        Console.WriteLine("Fin services configuration");
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAddressService addressService, IBrandService brandService, IDealerService dealerService){
        if (env.IsDevelopment()){
            Console.WriteLine("Env is DEV.");
        }
        else {
            Console.WriteLine("Env is PROD.");
            app.UseHttpsRedirection();
        }
        app.UseRouting();

        // register routes for addresses
        app.UseEndpoints(all_addresses => AddressRouterHandler.GetAddresses(all_addresses, addressService));
        app.UseEndpoints(address_by_id => AddressRouterHandler.GetAddressByGuid(address_by_id, addressService));
        app.UseEndpoints(create_address => AddressRouterHandler.CreateAddress(create_address, addressService));
        app.UseEndpoints(random_catalog_addresses => AddressRouterHandler.CreateAddresses(random_catalog_addresses, addressService));
        app.UseEndpoints(x => AddressRouterHandler.DeleteAddress(x, addressService));

        // register routes for brands
        app.UseEndpoints(all_brands => BrandRouterHandler.GetBrands(all_brands, brandService));
        app.UseEndpoints(brand_by_id => BrandRouterHandler.GetBrandByGuid(brand_by_id, brandService));
        app.UseEndpoints(create_brand => BrandRouterHandler.CreateBrand(create_brand, brandService));
        app.UseEndpoints(random_catalog_brands => BrandRouterHandler.CreateBrands(random_catalog_brands, brandService));
        app.UseEndpoints(x => BrandRouterHandler.DeleteBrand(x, brandService));

        // register routes for dealers
        app.UseEndpoints(all_dealers => DealersRouterHandler.GetDealers(all_dealers, dealerService));
        app.UseEndpoints(dealer_by_id => DealersRouterHandler.GetDealerByGuid(dealer_by_id, dealerService));
        app.UseEndpoints(create_dealer => DealersRouterHandler.CreateDealer(create_dealer, dealerService, addressService, brandService));
        app.UseEndpoints(random_catalog_dealers => DealersRouterHandler.CreateDealers(random_catalog_dealers, dealerService, addressService, brandService));
        app.UseEndpoints(x => DealersRouterHandler.DeleteDealer(x, dealerService));

         Console.WriteLine("Fin de configuration");
    }
}