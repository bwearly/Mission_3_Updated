using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3
{
    internal class InventoryManagement
    {
        private List<FoodItem> foodItems = new List<FoodItem>();
        public bool processInput(string input)
        {
            switch (input)
            {
                case "add":
                    addFoodItem();
                    break;
                case "delete":
                    deleteFoodItem();
                    break;
                case "print":
                    printAllFood();
                    break;
                case "exit":
                    Console.WriteLine("Have a nice day, exiting program...");
                    return true;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
            return false;
        }

        public void addFoodItem()
        {
            Console.WriteLine("\nWhat food would you like to add to the inventory? ");
            string newFoodItem = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(newFoodItem))
            {
                Console.WriteLine("\nFood item cannot be empty.");
                return;
            }

            string category = chooseCategory(newFoodItem);

            Console.WriteLine($"How many {newFoodItem}s do you have?");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                return;
            }

            Console.WriteLine($"When does {newFoodItem} expire? (ex. MM-DD-YYYY)");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                return;
            }

            foodItems.Add(new FoodItem(newFoodItem, category, quantity, expirationDate));
            Console.WriteLine($"\nYour addition of {newFoodItem} in category {category} was successful.");
        }


        public string chooseCategory(string newFoodItem)
        {
            Console.WriteLine($"\nWhat food category does '{newFoodItem}' belong to?");
            Console.WriteLine("Options: Dairy, Meat, Produce, Canned Goods");
            string categoryInput = Console.ReadLine()?.Trim().ToLower();

            switch (categoryInput)
            {
                case "dairy":
                    return "Dairy";
                case "meat":
                    return "Meat";
                case "produce":
                    return "Produce";
                case "canned goods":
                    return "Canned Goods";
                default:
                    Console.WriteLine("Invalid category. Please try again.");
                    return chooseCategory(newFoodItem);
            }
        }

        public void deleteFoodItem()
        {
            Console.WriteLine("\nWhat food item would you like to delete?");
            string deleteFoodItem = Console.ReadLine()?.Trim();

            FoodItem itemToRemove = foodItems.Find(item => item.Name.Equals(deleteFoodItem, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                foodItems.Remove(itemToRemove);
                Console.WriteLine($"\nYour deletion of {deleteFoodItem} was successful.");
            }
            else
            {
                Console.WriteLine("\nItem not found in inventory.");
            }
        }

        public void printAllFood()
        {
            if (foodItems.Count == 0)
            {
                Console.WriteLine("\nThe inventory is currently empty.");
                return;
            }

            Console.WriteLine("\nCurrent Food Inventory:");
            foreach (var item in foodItems)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
