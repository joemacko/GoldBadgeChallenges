using Komodo_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    class ClaimsProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            SeedClaimsList();
            Menu();
        }

        private void SeedClaimsList()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claims claimTwo = new Claims(1, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims claimThree = new Claims(1, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            _claimsRepo.AddClaimToDirectory(claimOne);
            _claimsRepo.AddClaimToDirectory(claimTwo);
            _claimsRepo.AddClaimToDirectory(claimThree);
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Choose a menu number:\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Update an existing claim\n" +
                    "5. Exit\n\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ReadAllClaims();
                        break;
                    case "2":
                        FinishNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        UpdateExistingClaim();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                }
                Console.WriteLine("\nPress any key to continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private Queue<Claims> ReadAllClaims()
        {
            Console.Clear();

            Queue<Claims> queueOfClaims = _claimsRepo.GetAllClaims();
            foreach (Claims claim in queueOfClaims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                    $"Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: ${claim.ClaimAmount}\n" +
                    $"Date Of Accident: {claim.DateOfIncident.ToShortDateString()}\n" +
                    $"Date Of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                    $"Is Valid: {claim.IsValid}\n");
            }

            return queueOfClaims;
        }

        private void FinishNextClaim()
        {
            Queue<Claims> queueOfClaims = ReadAllClaims();
            Console.WriteLine("Press any key to finish next claim...\n");
            Console.ReadKey();
            Console.Clear();

            Claims firstClaim = queueOfClaims.Peek();
            Console.WriteLine($"ClaimID: {firstClaim.ClaimID}\n" +
            $"Type: {firstClaim.TypeOfClaim}\n" +
            $"Description: {firstClaim.Description}\n" +
            $"Amount: ${firstClaim.ClaimAmount}\n" +
            $"Date Of Accident: {firstClaim.DateOfIncident.ToShortDateString()}\n" +
            $"Date Of Claim: {firstClaim.DateOfClaim.ToShortDateString()}\n" +
            $"Is Valid: {firstClaim.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now (y/n)?\n");
            bool input = YesOrNo();
            if (input)
            {
                Claims deleteClaim = queueOfClaims.Dequeue();
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            /*Console.WriteLine("Enter the claim ID:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);*/

            Console.WriteLine("Enter the claim type number:\n\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("\nEnter a claim description:\n");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter the claim amount:\n");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("\nEnter the incident date (dd/mm/YYYY):\n");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("\nEnter the claim date (dd/mm/YYYY):\n");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            bool validClaim = newClaim.IsValid;
            if (validClaim == true)
            {
                Console.WriteLine("\nThis claim is valid\n");
            }
            if (validClaim == false)
            {
                Console.WriteLine("\nThis claim is not valid\n");
            }

            _claimsRepo.AddClaimToDirectory(newClaim);
        }

        // Update a claim
        private void UpdateExistingClaim()
        {
            ReadAllClaims();
            Console.WriteLine("Enter the ID of the claim you'd like to update:\n");
            int oldClaimID = int.Parse(Console.ReadLine());

            Claims newClaim = new Claims();

            Console.WriteLine("\nEnter the claim ID again:\n");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            Console.WriteLine("\nEnter the claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("\nEnter a claim description:\n");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter the claim amount:\n");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("\nEnter the incident date (dd/mm/YY):\n");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("\nEnter the claim date (dd/mm/YY):\n");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            bool validClaim = newClaim.IsValid;
            if (validClaim == true)
            {
                Console.WriteLine("\nThis claim is valid\n");
            }
            if (validClaim == false)
            {
                Console.WriteLine("\nThis claim is not valid\n");
            }

            // Verify the update worked
            bool wasUpdated = _claimsRepo.UpdateClaim(oldClaimID, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Claim successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update claim");
            }
        }

        // Get Yes/No response from user
        private bool YesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
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
