using QaVerification;
using System.Net;
using RestSharp;

namespace PetstoreTests;

[TestFixture]
public class PetTests : BaseTest
{
    [Grading]
    [Test]
    public void GetPetThatExists()
    {
        // Act
        var result = GetPet(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Name, Is.Not.Null);
    }

    [Grading]
    [Test]
    public void GetPetThatDoesNotExist()
    {
        // Act
        var request = new RestRequest("/pet/{petId}");
        request.AddUrlSegment("petId", 99);
        var response = client.GetAsync(request).GetAwaiter().GetResult();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Grading]
    [Test]
    public void AddPetTest()
    {
        // Arrange
        var petName = RandomName("Cat");

        // Act
        var result = CreatePet(petName);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(petName));
        Assert.That(result.Status, Is.EqualTo("available"));
    }

    [Grading]
    [Test]
    public void AddRemovePetTest()
    {
        // Arrange
        var petName = RandomName("Dog");

        // Act - Add the pet
        var createdPet = CreatePet(petName);

        // Assert - pet was created
        Assert.That(createdPet, Is.Not.Null);
        Assert.That(createdPet.Name, Is.EqualTo(petName));

        // Act - Remove the pet
        RemovePet(createdPet);

        // Act - Try to get the removed pet
        var request = new RestRequest("/pet/{petId}");
        request.AddUrlSegment("petId", createdPet.Id);
        var response = client.GetAsync(request).GetAwaiter().GetResult();

        // Assert - pet no longer exists
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}