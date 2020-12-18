using System;
using System.Collections.Generic;
using Komodo_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Claims_Tests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        private ClaimsRepository _repo;
        private Queue<Claims> _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();

            Claims claimFirst = new Claims(1, ClaimType.Home, "Broken window", 200.00m, new DateTime(2020, 12, 12), new DateTime(2020, 12, 16));

            _repo.AddClaimToDirectory(claimFirst);
        }

        // Create Claim Method
        [TestMethod]
        public void AddClaimToDirectory_ShouldGetNotNull()
        {
            // Arrange [TestInitialize]

            // Act [TestInitialize]
            Claims addClaim = _repo.GetClaimByID(1);

            // Assert
            Assert.IsNotNull(addClaim.DateOfClaim);
        }

        // Get Claim By ID Method
        [TestMethod]
        public void GetClaimByID_ShouldGetNotNull()
        {
            // Arrange [TestInitialize]
            Claims claim = _repo.GetAllClaims().Peek(); 
            int claimbyID = claim.ClaimID;

            // Act
            Claims claimGet = _repo.GetClaimByID(claimbyID);

            // Assert
            Assert.IsNotNull(claimGet.ClaimAmount);
        }

        // Read All Claims Method
        [TestMethod]
        public void GetAllClaims_ShouldGetAreEqual()
        {
            // Arrange
            Claims newClaim = new Claims(1, ClaimType.Home, "Broken window", 200.00m, new DateTime(2020, 12, 12), new DateTime(2020, 12, 16));
            _repo.AddClaimToDirectory(newClaim);

            // Act
            Queue<Claims> queueOfClaims = _repo.GetAllClaims();
            Claims claimFirst = queueOfClaims.Peek();

            // Assert
            Assert.AreEqual(newClaim.Description, claimFirst.Description);
        }

        // Update A Claim Method
        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            // Arrange
            Claims oldClaim = new Claims(1, ClaimType.Car, "Broken window", 200.00m, new DateTime(2020, 12, 12), new DateTime(2020, 12, 16));
            _repo.AddClaimToDirectory(oldClaim);

            // Act
            Claims newClaim = new Claims();
            newClaim.TypeOfClaim = ClaimType.Home;

            _repo.UpdateClaim(oldClaim.ClaimID, newClaim);

            // Assert
            Assert.AreEqual(oldClaim.TypeOfClaim, newClaim.TypeOfClaim);
        }
    }
}
