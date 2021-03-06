﻿using Komodo_Insurance_Repo;
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
            Badge badgeOne = new Badge(1, new List<string>() { "A1", "A2", "A3" });
            Badge badgeTwo = new Badge(2, new List<string>() { "B1", "B2", "B3" });
            Badge badgeThree = new Badge(3, new List<string>() {"C1", "C2", "C3" });

            _badgeRepo.CreateNewBadge(badgeOne);
            _badgeRepo.CreateNewBadge(badgeTwo);
            _badgeRepo.CreateNewBadge(badgeThree);
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
                    "3. List all badges\n" +
                    "4. Exit\n");

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
                        Console.WriteLine("\nPlease enter a number 1-4");
                        break;
                }

                // Clear console and move user to different menu or exit console
                Console.WriteLine("\nPlease press any key to continue...");
                Console.WriteLine();
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

            // Get user input on a door the badge needs access to
            Console.WriteLine("List a door that the badge needs access to:\n");
            string doorName = Console.ReadLine();
            newBadge.DoorNames.Add(doorName);

            //Ask if there are more doors to add
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nAny other doors (y/n)?\n");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        Console.WriteLine("\nList a door that the badge needs access to:\n");
                        string doorNameNext = Console.ReadLine();
                        newBadge.DoorNames.Add(doorNameNext);
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter y for yes or n for no\n");
                        break;
                }
            }

            _badgeRepo.CreateNewBadge(newBadge);
        }

        // Update existing badge
        private void EditBadge()
        {
            // Clear console and bring user to EditBadge menu
            Console.Clear();
            ListAllBadges();

            Console.WriteLine("Enter the number of the badge ID you'd like to update:\n");
            int oldBadgeID = int.Parse(Console.ReadLine());
            Badge newBadge = _badgeRepo.GetBadgeByID(oldBadgeID);
            newBadge.DoorNames.ToString();
             
            Console.Write($"Badge #{newBadge.BadgeID} has access to doors \n");
            foreach(var item in newBadge.DoorNames)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("What would you like to do?\n" +
                "\n1. Remove a door\n" +
                "\n2. Add a door\n");
            string removeOrAdd = Console.ReadLine();
            switch (removeOrAdd)
            {
                case "1":
                    Console.WriteLine("\nWhich door would you like to remove?\n");
                    string doorToRemove = Console.ReadLine();
                    bool doorRemoved = _badgeRepo.RemoveDoorFromBadge(oldBadgeID, doorToRemove);
                    if (doorRemoved)
                    {
                        Console.WriteLine("Door successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Could not remove door");
                    }
                    break;
                case "2":
                    Console.WriteLine("\nWhich door would you like to add?\n");
                    string doorToAdd = Console.ReadLine();
                    bool doorAdded = _badgeRepo.AddDoorToBadge(oldBadgeID, doorToAdd);
                    if (doorAdded)
                    {
                        Console.WriteLine("Door successfully added");
                    }
                    else
                    {
                        Console.WriteLine("Could not add door");
                    }
                    break;
                default:
                    Console.WriteLine("\nPlease enter a valid door\n");
                    break;
            }

            _badgeRepo.UpdateBadge(oldBadgeID, newBadge);
        }

        // Read all badges
        private void ListAllBadges()
        {
            Console.Clear();
            var allBadges = _badgeRepo.ReadAllBadges();
            
            foreach (var badge in allBadges)
            {
                int badgeid = badge.Key;

                Console.WriteLine($"Badge #: {badgeid}");
                Console.Write("Access to Doors: ");

                foreach (var door in badge.Value.DoorNames)
                {
                    Console.Write(door + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
