using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repo
{
    public class ClaimsRepository
    {
        private readonly List<Claims> _claimsDirectory = new List<Claims>();
        private int _claimIDQueue = 0;

        // Create Claim Method
        public void AddClaimToDirectory(Claims claim)
        {
            claim.ClaimID = _claimIDQueue + 1;
            _claimsDirectory.Add(claim);
            _claimIDQueue++;
        }

        // Read All Claims Method
        public List<Claims> GetAllClaims()
        {
            return _claimsDirectory;
        }
    }
}
