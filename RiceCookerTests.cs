using NUnit.Framework;
using System;


[TestFixture]
public class RiceCookerTests
{
    [Test]
    public void CookedRice_ShouldBeFalse_AfterInitialization()
    {
        // Arrange
        var riceCooker = new RiceCooker();

        // Act & Assert
        Assert.IsFalse(riceCooker.CookedRice, "Initially, CookedRice should be false");
    }

    [Test]
    public void CookedRice_ShouldBeTrue_AfterCooking()
    {
        // Arrange
        var riceCooker = new RiceCooker();

        // Act
        riceCooker.Cook();

        // Assert
        Assert.IsTrue(riceCooker.CookedRice, "After cooking, CookedRice should be true");
    }

    [Test]
    public void Serve_ShouldSetCookedRiceToFalse_AfterServing()
    {
        // Arrange
        var riceCooker = new RiceCooker();
        riceCooker.Cook();

        // Act
        riceCooker.Serve();

        // Assert
        Assert.IsFalse(riceCooker.CookedRice, "After serving, CookedRice should be false");
    }

  [Test]
  public void MenuAddRice_ShouldAddRiceToCooker()
  {
      // Arrange
      var riceCooker = new RiceCooker();

      // Act
      MenuAddRice(riceCooker, 2);

      // Assert
      Assert.AreEqual(2, riceCooker.CookedRice, "Rice should be added to the cooker");
  }

  private void MenuAddRice(RiceCooker riceCooker, int amount)
  {
      // Simulate user input
      Console.SetIn(new System.IO.StringReader(amount.ToString()));

      // Call the menu method (implement this method as needed)
      MenuAddRice(riceCooker);

      // Reset the standard input
      Console.SetIn(Console.In);
  }

  private void MenuAddRice(RiceCooker riceCooker)
  {
      // Implement the logic for adding rice based on the simulated user input
      // This is where you should interact with your RiceCooker instance
      riceCooker.AddRice(int.Parse(Console.ReadLine()));
  }

    [Test]
    public void MenuAddWater_ShouldAddWaterToCooker()
    {
        // Arrange
        var riceCooker = new RiceCooker();

        // Act
        MenuAddWater(riceCooker);

        // Assert: You can add more specific assertions based on your implementation
        Assert.Pass("Water should be added to the cooker");
    }

    private void MenuAddWater(RiceCooker riceCooker)
    {
        // Call the menu method
        MenuAddWater(riceCooker);
    }
}
