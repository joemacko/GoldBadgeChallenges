using Komodo_Insurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Console
{
    class BadgeProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        private void SeedBadgeDictionary()
        {

        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to user
                Console.WriteLine("Hello Security Admin, what would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n");

                // Evaluate user input
                string input = Console.ReadLine();

                // Act on user input
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-4");
                        break;
                }

                // Clear console and move user to different menu or exit console
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new badge
        private void AddBadge()
        {
            // Clear console and bring user to AddBadge menu
            Console.Clear();

            Badge newBadge = new Badge();

            // Convert user input for badgeNumber to an int
            Console.WriteLine("What is the number on the badge?\n");
            int badgeNumber = int.Parse(Console.ReadLine());

            // Get user input on a door the badge needs access to
            Console.WriteLine("\nList a door that it needs access to:\n");
            string doorAccess = Console.ReadLine();

            // Ask if there are more doors to add and use YesOrNo loop to add multiple, if needed
            YesOrNo();
        }

        // Update existing badge
        private void EditBadge()
        {

        }

        // Read all badges
        private void ListAllBadges()
        {

        }

        // Get Yes/No response from user
        private bool YesOrNo()
        {
            while (true)
            {
                Console.WriteLine("\nAny other doors (y/n)?\n");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        Console.WriteLine("\nList a door that it needs access to:\n");
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("\nPlease enter y for yes or n for no\n");
                        break;
                }
            }
        }
    }
}
