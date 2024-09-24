namespace MyApi.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using MyApi.Models;

    public class AppInMemoryDatabase : IAppInMemoryDatabase
    {
        private readonly List<Address> addresses;
        private readonly List<Dealer> dealers;
        private readonly List<Brand> brands;
 
        public AppInMemoryDatabase()
        {
            addresses = new List<Address> ();
            dealers = new List<Dealer> ();
            brands = new List<Brand> ();
        }

        public Object SaveObject(Object o){
            if(o.GetType() == typeof(Address)){
                addresses.Add((Address)o);
            }
            else if(o.GetType() == typeof(Brand)){
                brands.Add((Brand)o);
            }
            else if(o.GetType() == typeof(Dealer)){
                dealers.Add((Dealer)o);
            }
            return o;
        }
  
        // Read: Retrieves all addresses
        public List<Address> GetAllAddresses()
        {
            Thread.Sleep(2000);
            return addresses;
        }
        // Read: Retrieves all brands
        public List<Brand> GetAllBrands()
        {
            Thread.Sleep(2000);
            return brands;
        }
        // Read: Retrieves all brands
        public List<Dealer> GetAllDealers()
        {
            Thread.Sleep(2000);
            return dealers;
        }

        // Read: Retrieves a single address by ID
        public Address GetAddressById(Guid id)
        {
            Thread.Sleep(2000);
            return addresses.FirstOrDefault(e => e.AddressId == id);
        }

        // Read: Retrieves a single brand by ID
        public Brand GetBrandById(Guid id)
        {
            Thread.Sleep(2000);
            return brands.FirstOrDefault(e => e.BrandId == id);
        }

        // Read: Retrieves a single dealer by ID
        public Dealer GetDealerById(Guid id)
        {
            Thread.Sleep(2000);
            return dealers.FirstOrDefault(e => e.DealerId == id);
        }
 
        // Delete: Removes an address by ID
        public bool DeleteAddress(Guid id)
        {
            Thread.Sleep(2000);
            var address = GetAddressById(id);            
            if (address == null) return false;
 
            addresses.Remove(address);
            return true;
        }

        // Delete: Removes a brand by ID
        public bool DeleteBrand(Guid id)
        {
            Thread.Sleep(2000);
            var brand = GetBrandById(id);            
            if (brand == null) return false;
 
            brands.Remove(brand);
            return true;
        }

        // Delete: Removes a dealer by ID
        public bool DeleteDealer(Guid id)
        {
            Thread.Sleep(2000);
            var dealer = GetDealerById(id);            
            if (dealer == null) return false;
 
            dealers.Remove(dealer);
            return true;
        }

    }
 
}