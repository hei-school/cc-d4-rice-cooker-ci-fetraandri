using System;
using System.Threading;


// Simulates a basic rice cooker
class RiceCooker
{
    private const int CookingTime = 3; // in seconds
    public bool CookedRice { get; set; }

    public RiceCooker()
    {
        CookedRice = false;
    }

    public void AddRice(int amount)
    {
        Console.WriteLine($"Adding {amount} cups of rice to the rice cooker.");
    }

    public void AddWater()
    {
        Console.WriteLine("Adding water to the rice cooker.");
    }

    public void Cook()
    {
        if (CookedRice)
        {
            Console.WriteLine("Rice is already cooked. Reheat if needed.");
        }
        else
        {
            Console.WriteLine("Cooking the rice...");
            try
            {
                // Simulate cooking time
                System.Threading.Thread.Sleep(CookingTime * 1000);
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine($"Error during cooking: {ex.Message}");
                // Optionally, you might want to handle or log the exception.
            }

            CookedRice = true;
            Console.WriteLine("Rice is cooked!");
        }
    }

    public void Serve()
    {
        if (CookedRice)
        {
            Console.WriteLine("Serving delicious rice!");
            CookedRice = false;
        }
        else
        {
            Console.WriteLine("No rice cooked. Please cook first.");
        }
    }
}

class Program
{
    // Menu option methods
    static void MenuAddRice(RiceCooker riceCooker)
    {
        Console.Write("Enter the amount of rice to add (in cups): ");
        try
        {
            int amount = int.Parse(Console.ReadLine());
            if (amount > 0)
            {
                riceCooker.AddRice(amount);
                Console.WriteLine("Rice added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Invalid input: {ex.Message}");
            // Optionally, you might want to handle or log the exception.
        }
    }

    static void MenuAddWater(RiceCooker riceCooker)
    {
        riceCooker.AddWater();
    }

    static void MenuCook(RiceCooker riceCooker)
    {
        riceCooker.Cook();
    }

    static void MenuServe(RiceCooker riceCooker)
    {
        riceCooker.Serve();
    }

    // Main program
    static void Main()
    {
        var riceCooker = new RiceCooker();

        do
        {
            DisplayMenu();
            int choice = UserChoice();
            try
            {
                ProcessUserChoice(choice, riceCooker);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Optionally, you might want to handle or log the exception.
            }

            if (choice == 5)
            {
                Console.WriteLine("Exiting the rice cooker. Goodbye!");
                break;
            }

            Console.WriteLine("Press Enter to see the menu again.");
            Console.ReadLine();
        } while (true);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nRice Cooker Menu:");
        Console.WriteLine("1. Add rice");
        Console.WriteLine("2. Add water");
        Console.WriteLine("3. Cook");
        Console.WriteLine("4. Serve");
        Console.WriteLine("5. Exit");
    }

    static int UserChoice()
    {
        Console.Write("Choose an option: ");
        return int.Parse(Console.ReadLine());
    }

    static void ProcessUserChoice(int choice, RiceCooker riceCooker)
    {
        switch (choice)
        {
            case 1:
                MenuAddRice(riceCooker);
                break;
            case 2:
                MenuAddWater(riceCooker);
                break;
            case 3:
                MenuCook(riceCooker);
                break;
            case 4:
                MenuServe(riceCooker);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid option.");
                break;
        }
    }
}
