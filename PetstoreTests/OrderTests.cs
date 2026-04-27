using QaVerification;

namespace PetstoreTests;

[TestFixture]
public class OrderTests : BaseTest
{
    [Grading]
    [Test]
    public void OrderPetTest()
    {
        // Arrange - create a pet to order
        var petName = RandomName("Bird");
        var pet = CreatePet(petName);

        // Act - place an order for the pet
        Assert.That(pet, Is.Not.Null);
        var order = OrderPet(pet!, 1);

        // Assert
        Assert.That(order, Is.Not.Null);
        Assert.That(order.PetId, Is.EqualTo(pet.Id));
        Assert.That(order.Quantity, Is.EqualTo(1));
        Assert.That(order.Status, Is.EqualTo("placed"));
    }
}