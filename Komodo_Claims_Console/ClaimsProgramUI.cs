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
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

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
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ReadAllClaims()
        {
            Console.Clear();

            Queue<Claims> queueOfClaims = _claimsRepo.GetAllClaims();
            foreach (Claims claim in queueOfClaims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimAmount}\n" +
                    $"Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.ClaimAmount}\n" +
                    $"DateOfAccident: {claim.DateOfIncident}\n" +
                    $"DateOfClaim: {claim.DateOfClaim}\n" +
                    $"IsValid: {claim.IsValid}\n");
            }
        }

        private void FinishNextClaim()
        {
            Queue<Claims> queueOfClaims = _claimsRepo.GetAllClaims();
            foreach (Claims claim in queueOfClaims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimAmount}\n" +
                    $"Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: {claim.ClaimAmount}\n" +
                    $"DateOfAccident: {claim.DateOfIncident}\n" +
                    $"DateOfClaim: {claim.DateOfClaim}\n" +
                    $"IsValid: {claim.IsValid}\n");
            }

            Console.WriteLine("Press any key to finish next claim...");
            Console.ReadKey();

            // Claims firstClaim = claim.Peek();
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            Console.WriteLine("Enter the claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("Enter the incident date (dd/mm/YY):");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("Enter the claim date (dd/mm/YY):");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);
        }

        private void UpdateExistingClaim()
        {
            ReadAllClaims();
            Console.WriteLine("Enter the ID of the claim you'd like to update:");
            int oldClaimID = int.Parse(Console.ReadLine());

            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            Console.WriteLine("Enter the claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            Console.WriteLine("Enter the incident date (dd/mm/YY):");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("Enter the claim date (dd/mm/YY):");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            // Verify the update worked
            /*bool wasUpdated = _claimsRepo.UpdateExistingClaim(oldClaimID, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Claim successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update claim");
            }*/
        }

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
                        Console.WriteLine("Please enter y for yes or n for no");
                        break;
                }
            }
        }
    }
}
