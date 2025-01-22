// Prompt the user to collect there responses
using Mission_3;

InventoryManagement im = new InventoryManagement();

Console.WriteLine("Good Afternoon! ");

while (true)
{
    Console.WriteLine("\nChoose an action: ");
    Console.WriteLine("\nAdd - Add a new food item");
    Console.WriteLine("Delete - Delete a food item");
    Console.WriteLine("Print - View your current inventory");
    Console.WriteLine("Exit - Exit the program");

    Console.Write("\nEnter you action: ");
    string action = Console.ReadLine()?.Trim().ToLower();
    if (im.processInput(action))
        break;
}