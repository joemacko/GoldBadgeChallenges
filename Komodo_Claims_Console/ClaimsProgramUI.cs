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
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims claimTwo = new Claims(1, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims claimThree = new Claims(1, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

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
                        WorkOnNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
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

            List<Claims> listOfClaims = _claimsRepo.GetAllClaims();
                foreach(Claims claim in listOfClaims)
                {
                    Console.WriteLine($"ClaimID: {claim.ClaimAmount}\n" +
                        $"Type: {claim.TypeOfClaim}\n" +
                        $"Description: {claim.Description}\n" +
                        $"Amount: {claim.ClaimAmount}\n" +
                        $"DateOfAccident: {claim.DateOfIncident}\n" +
                        $"DateOfClaim: {claim.DateOfClaim}\n" +
                        $"IsValid: {claim.IsValid}");
                }
        }

        private void WorkOnNextClaim()
        {

        }

        private void AddNewClaim()
        {

        }
    }
}
