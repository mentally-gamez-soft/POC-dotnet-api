namespace MyApi;

using System;
using Microsoft.AspNetCore;
using MyWeatherApi;

public class Program {
    public static void Main(string[] args){
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

}