namespace MyApi.Models;

public class Address {

    private string country; // field
    public string Country   // property
    {
        get { return country; }
        set { country = value; }
    }
    public string Town {get;set;}
    public string Street {get;set;}
    public string Number {get;set;}

    public Guid AddressId{get;set;}

    public Address(string _country, string _town, string _street, string _number) {
        Country = _country;
        Town = _town;
        Street = _street;
        Number = _number;
        AddressId = Guid.NewGuid();
    }
        
    public Address() {
        Country = "Spain";
        Town = "Madrid";
        Street = "C/ Alcala";
        Number = "212 BIS";
        AddressId = Guid.NewGuid();
    } 

    public override string ToString()
    {
        return $"[ID -> {AddressId}] - Address: {Street} {Number} {Town}, {Country}";
    }
    
}