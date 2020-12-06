using Komodo_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            UIMenu();
        }

        // Menu method
        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to user
                Console.WriteLine("Please select an option:\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. View Meal By Name\n" +
                    "4. Delete Existing Meal\n" +
                    "5. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate user input and act
                switch (input)
                {
                    case "1":
                        // Create New Meal
                        CreateNewMeal();
                        break;
                    case "2":
                        // View All Meals
                        DisplayAllMeals();
                        break;
                    case "3":
                        // View Meal By Name
                        ViewMealByName();
                        break;
                    case "4":
                        // Delete Existing Meal
                        DeleteExistingMeal();
                        break;
                    case "5":
                        // Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-5");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new meal
        private void CreateNewMeal()
        {
            Console.Clear();
            Menu newMeal = new Menu();

            // Number
            Console.WriteLine("Please enter the meal number:");
            string numberAsString = Console.ReadLine();
            newMeal.Number = int.Parse(numberAsString);

            // Name
            Console.WriteLine("Please enter the meal name:");
            newMeal.Name = Console.ReadLine();

            // Description
            Console.WriteLine("Please enter the meal description:");
            newMeal.Description = Console.ReadLine();

            // Ingredients
            Console.WriteLine("Please enter the meal ingredients:");
            newMeal.Ingredients = Console.ReadLine();

            // Price
            Console.WriteLine("Please enter the meal price:");
            string priceAsString = Console.ReadLine();
            newMeal.Price = decimal.Parse(numberAsString);

            _menuRepo.AddMenuMeal(newMeal);
        }

        // View current saved meals
        private void DisplayAllMeals()
        {

        }

        // View meal by name
        private void ViewMealByName()
        {

        }

        // Delete existing meal
        private void DeleteExistingMeal()
        {

        }
    }
}
