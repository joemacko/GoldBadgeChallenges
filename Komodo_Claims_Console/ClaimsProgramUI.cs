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

        }
    }
}
