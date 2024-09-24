namespace MyApi.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using MyApi.Models;

    public interface IAppInMemoryDatabase
    {
        public Object SaveObject(Object o);
  
        // Read: Retrieves all addresses
        public List<Address> GetAllAddresses();

        // Read: Retrieves all brands
        public List<Brand> GetAllBrands();

        // Read: Retrieves all brands
        public List<Dealer> GetAllDealers();


        // Read: Retrieves a single address by ID
        public Address GetAddressById(Guid id); 


        // Read: Retrieves a single brand by ID
        public Brand GetBrandById(Guid id);


        // Read: Retrieves a single dealer by ID
        public Dealer GetDealerById(Guid id);

 
        // Delete: Removes an address by ID
        public bool DeleteAddress(Guid id);


        // Delete: Removes a brand by ID
        public bool DeleteBrand(Guid id);


        // Delete: Removes a dealer by ID
        public bool DeleteDealer(Guid id);

    }
 
}