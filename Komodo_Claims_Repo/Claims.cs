using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repo
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
        // POCO
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan days = DateOfClaim - DateOfIncident;
                int daysApart = days.Days;
                if (daysApart <= 30)
                    return true;
                else
                    return false;
            }
        }

        public Claims() { }

        public Claims(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, 
            DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
