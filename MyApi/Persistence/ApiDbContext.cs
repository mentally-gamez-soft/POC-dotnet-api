using MyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Persistence;

public class ApiDbContext : DbContext {

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options){
        Console.WriteLine("----  CREATION DU DB CONTEXT  ----");
        Database.EnsureCreated();
        Console.WriteLine("----  CREATION DU DB CONTEXT  2 ----");
    }

    public DbSet<Address> Addresses {get;set;}
    public DbSet<Brand> Brands {get;set;}
    public DbSet<Dealer> Dealers {get;set;}


}