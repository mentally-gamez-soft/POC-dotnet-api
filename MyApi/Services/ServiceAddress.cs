namespace MyApi.Services;

using MyApi.Models;

public class ServiceAddress {

    public ServiceAddress(){}

    
    public static Address GenerateRandomAddress(){
        var Countries = new List<string>(){"France","Spain","Belgium","Italy"};
        var Towns = new List<string>(){"Paris","Madrid","Marseille","Rimini","Palermo","Valencia","Barcelona"};
        var Streets = new List<string>(){"C/ Gal Pardinas","C/ La Concepcion","Rue du pere Lachaise","Via Sol","Rue du marche","Paseo el Retiro","Rua La Diagonal"};


        var country = Countries[Random.Shared.Next(Countries.Count)];
        var town = Towns[Random.Shared.Next(Towns.Count)];
        var street = Streets[Random.Shared.Next(Streets.Count)];
        var number = Random.Shared.Next(1,150).ToString();

        return new Address (country,town,street,number);
    }

    public static List<Address> GenerateAllAddressesRandom(){
        IEnumerable<Address> addresses = Enumerable.Range(1, 100).Select(a => GenerateRandomAddress());
        return addresses.ToList();
    }

}
