using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using Mission_3;

// Imports the classes
InventoryManagement im = new InventoryManagement();

// A nice welcoming message for the TAs
string timing = "";
if (DateTime.Now.Hour < 12)
{
    timing = "Morning TA!";
}
else if (DateTime.Now.Hour < 18)
{
    timing = "Afternoon TA!";
}
else
{
    timing = "Evening TA!";

}

Console.WriteLine($"Good {timing}");

// Allows the program to run until they type exit
while (true)
{
    Console.WriteLine("\nChoose an action: ");
    Console.WriteLine("\nAdd - Add a new food item");
    Console.WriteLine("Delete - Delete a food item");
    Console.WriteLine("Print - View your current inventory");
    Console.WriteLine("Exit - Exit the program");

    Console.Write("\nEnter you action: ");
    string action = Console.ReadLine()?.Trim().ToLower();

    // Send the input to a function to call the right method
    if (im.processInput(action))
        break;
}