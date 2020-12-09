using Komodo_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Console
{
    class MenuProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenuList();
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
            string ingredient = Console.ReadLine();
            List<string> ingredientList = new List<string>();
            ingredientList.Add(ingredient);

            // Price
            Console.WriteLine("Please enter the meal price:");
            string priceAsString = Console.ReadLine();
            newMeal.Price = decimal.Parse(numberAsString);

            _menuRepo.AddMenuMeal(newMeal);
        }

        // View current saved meals
        private void DisplayAllMeals()
        {
            Console.Clear();

            List<Menu> menuList = _menuRepo.GetMenuList();

            foreach(Menu meal in menuList)
            {
                Console.WriteLine($"Meal name: {meal.Name}\n" +
                    $"Meal number: {meal.Number}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Price: {meal.Price}");
            }
        }

        // View meal by name
        private void ViewMealByName()
        {
            Console.Clear();
            // Prompt user to give meal name
            Console.WriteLine("Enter the name of the meal you'd like to view:");

            // Get user's input
            string name = Console.ReadLine();

            // Find meal by that name
            Menu meal = _menuRepo.GetMenuMealByName(name);

            // Display meal if it isn't null
            if (meal != null)
            {
                Console.WriteLine($"Meal number: {meal.Number}\n" +
                    $"Meal name: {meal.Name}\n" +
                    $"Description: {meal.Description}\n" +
                    $"Ingredients: {meal.BaseIngredients} + {meal.SpecialIngredients}\n" +
                    $"Price: {meal.Price}");
            }
            else
            {
                Console.WriteLine("No meal by that name");
            }
        }

        // Delete existing meal
        private void DeleteExistingMeal()
        {
            DisplayAllMeals();

            // Get the meal user wants to delete
            Console.WriteLine("\nEnter the name of the meal you'd like to delete:");
            string input = Console.ReadLine();

            // Call delete method
            bool wasDeleted = _menuRepo.RemoveMenuMealFromList(input);

            // If meal was deleted, say so
            if(wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted from the menu");
            }
            // Otherwise state meal couldn't be deleted
            else
            {
                Console.WriteLine("The meal couldn't be deleted");
            }
        }

        // Seed method
        private void SeedMenuList()
        {
            List<string> baseIngredientList = new List<string> { "beef", "bun", "cheese", "pickles", "onions", "tomatoes", "lettuce", "ketchup", "mayonnaise", "fries", "soda" };
            List<string> bacon = new List<string> { "bacon" };
            List<string> chickenMealIngredients = new List<string> { "fried chicken patty, bun, pickles, fries, soda" };

            Menu cheeseburgMeal = new Menu(1, "Cheeseburger Meal", "Cheeseburger, fries, and a drink", baseIngredientList, null, 6.50m);
            Menu dubCheeseburgMeal = new Menu(2, "Double Cheeseburger Meal", "Double cheeseburger, fries, and a drink", baseIngredientList, null, 7.50m);
            Menu cheeseburgDeluxeMeal = new Menu(3, "Cheeseburger Deluxe Meal", "Bacon cheeseburger, fries, and a drink", baseIngredientList, bacon, 7.00m);
            Menu dubCheeseburgDeluxeMeal = new Menu(4, "Double Cheeseburger Deluxe Meal", "Double bacon cheeseburger, fries, and a drink", baseIngredientList, bacon, 8.00m);
            Menu chickenMeal = new Menu(5, "Chicken Sandwich Meal", "Fried chicken sandwich, fries, and a drink", chickenMealIngredients, null, 7.00m);

            _menuRepo.AddMenuMeal(cheeseburgMeal);
            _menuRepo.AddMenuMeal(dubCheeseburgMeal);
            _menuRepo.AddMenuMeal(cheeseburgDeluxeMeal);
            _menuRepo.AddMenuMeal(dubCheeseburgDeluxeMeal);
            _menuRepo.AddMenuMeal(chickenMeal);
        }
    }
}
