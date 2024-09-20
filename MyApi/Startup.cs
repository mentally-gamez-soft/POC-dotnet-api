using MyApi.routes;

namespace MyWeatherApi;

public class Startup {

    public Startup(IConfiguration configuration){
        Configuration = configuration;
    }

    public IConfiguration Configuration {get;}

    public void ConfigureServices(IServiceCollection services){
        services.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        if (env.IsDevelopment()){
            Console.WriteLine("Env is DEV.");
        }
        else {
            Console.WriteLine("Env is PROD.");
            app.UseHttpsRedirection();
        }
        app.UseRouting();
        app.UseEndpoints(all_brands => BrandRouterHandler.getAllBrands(all_brands));
        app.UseEndpoints(random_brand => BrandRouterHandler.getRandomBrand(random_brand));

        app.UseEndpoints(all_addresses => AddressRouterHandler.getAllAddresses(all_addresses));
        app.UseEndpoints(random_address=> AddressRouterHandler.getRandomAddress(random_address));
    }
}