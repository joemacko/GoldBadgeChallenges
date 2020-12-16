using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repo
{
    public class ClaimsRepository
    {
        private readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();
        private int _claimIDQueue = 0;

        // Create Claim Method
        public void AddClaimToDirectory(Claims claim)
        {
            claim.ClaimID = _claimIDQueue + 1;
            _claimsDirectory.Enqueue(claim);
            _claimIDQueue++;
        }

        // Read All Claims Method
        public Queue<Claims> GetAllClaims()
        {
            return _claimsDirectory;
        }

        // Update a Claim Method
        public bool UpdateClaim(int claimID, Claims newClaimInfo)
        {
            Claims existingClaim = GetClaimByID(claimID);
            
            if (existingClaim != null)
            {
                existingClaim.ClaimID = newClaimInfo.ClaimID;
                existingClaim.TypeOfClaim = newClaimInfo.TypeOfClaim;
                existingClaim.Description = newClaimInfo.Description;
                existingClaim.ClaimAmount = newClaimInfo.ClaimAmount;
                existingClaim.DateOfIncident = newClaimInfo.DateOfIncident;
                existingClaim.DateOfClaim = newClaimInfo.DateOfClaim;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Get Claim By ID Method
        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims claim in _claimsDirectory)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
