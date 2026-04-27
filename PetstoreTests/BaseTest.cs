using RestSharp;

namespace PetstoreTests;

public class Inventory
{
    public int Sold { get; set; }
    public int Pending { get; set; }
    public int Available { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Pet
{
    public int Id { get; set; }
    public Category? Category { get; set; }
    public string? Name { get; set; }
    public List<string>? PhotoUrls { get; set; }
    public List<Tag>? Tags { get; set; }
    public string? Status { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public int Quantity { get; set; }
    public string? ShipDate { get; set; }
    public string? Status { get; set; }
    public bool Complete { get; set; }
}

public class BaseTest
{
    protected RestClient client;

    [SetUp]
    public void Initialise()
    {
        client = new RestClient("http://localhost/v2");
    }

    protected static string RandomName(string prefix)
    {
        return prefix + new Random().Next(1, 10000).ToString();
    }

    protected Inventory? GetInventory()
    {
        var request = new RestRequest("/store/inventory");
        return client.GetAsync<Inventory>(request).GetAwaiter().GetResult();
    }

    protected Pet? GetPet(int petId)
    {
        var request = new RestRequest("/pet/{petId}");
        request.AddUrlSegment("petId", petId);
        return client.GetAsync<Pet>(request).GetAwaiter().GetResult();
    }

    protected Pet? CreatePet(string name)
    {
        var request = new RestRequest("/pet");
        request.AddJsonBody(new
        {
            name = name,
            status = "available",
            photoUrls = new[] { "http://example.com/photo1.jpg" }
        });
        return client.PostAsync<Pet>(request).GetAwaiter().GetResult();
    }

    protected void RemovePet(Pet pet)
    {
        var request = new RestRequest("/pet/{petId}");
        request.AddUrlSegment("petId", pet.Id);
        client.DeleteAsync(request).GetAwaiter().GetResult();
    }

    protected Order? OrderPet(Pet pet, int quantity)
    {
        var request = new RestRequest("/store/order");
        request.AddJsonBody(new
        {
            petId = pet.Id,
            quantity = quantity,
            status = "placed",
            complete = false
        });
        return client.PostAsync<Order>(request).GetAwaiter().GetResult();
    }
}