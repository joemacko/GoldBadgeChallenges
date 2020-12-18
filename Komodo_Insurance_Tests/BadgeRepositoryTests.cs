using System;
using System.Collections.Generic;
using Komodo_Insurance_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Insurance_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo = new BadgeRepository();

        [TestInitialize]
        public void Arrange()
        {
            Badge badgeOne = new Badge(1, new List<string>() { "100", "101", "102" });
            Badge badgeTwo = new Badge(2, new List<string>() { "200", "201", "202" });

            _repo.CreateNewBadge(badgeOne);
            _repo.CreateNewBadge(badgeTwo);
        }

        // Create A Badge Method
        [TestMethod]
        public void CreateNewBadge_ShouldGetNotNull()
        {
            // Arrange [TestInitialize]

            // Act [TestInitialize]

            // Assert
            Assert.IsTrue(_repo._badgeDictionary.ContainsKey(1));
        }

        // Read All Badges Method
        [TestMethod]
        public void ReadAllBadges_ShouldReturnTrue()
        {
            // Arrange [TestInitialize]
            Badge badgeThree = new Badge(3, new List<string>() { "100", "101", "102" });
            _repo.CreateNewBadge(badgeThree);

            // Act
            Dictionary<int, Badge> allBadges = _repo.ReadAllBadges();

            bool badgeExists = false;

            if (allBadges.ContainsKey(3))
            {
                badgeExists = true;
            }

            // Assert
            Assert.IsTrue(badgeExists);
        }

        // Get Badge By ID Helper Method
        [TestMethod]
        public void GetBadgeByID_ShouldReturnTrue()
        {
            // Arrange [TestInitialize]
            Badge firstBadge = _repo.GetBadgeByID(1);
            Badge secondBadge = _repo.GetBadgeByID(2);

            // Act
            firstBadge.BadgeID = 5;
            secondBadge.BadgeID = 6;

            // Assert
            Assert.IsTrue(firstBadge.BadgeID < secondBadge.BadgeID);
        }

        // Delete A Badge Method
        [TestMethod]
        public void RemoveBadge_ShouldReturnTrue()
        {
            // Arrange [TestInitialize]

            // Act
            bool removeBadge = _repo.RemoveBadge(2);

            // Assert
            Assert.IsTrue(removeBadge);
        }

        // Update A Badge Method
        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            // Arrange
            Badge badgeOne = _repo.GetBadgeByID(1);

            Badge badgeTwo = _repo.GetBadgeByID(2);
            Badge updatedBadgeTwo = new Badge();
            updatedBadgeTwo.DoorNames = new List<string>() { "100", "101", "102" };

            // Act
            _repo.UpdateBadge(badgeTwo.BadgeID, updatedBadgeTwo);

            bool stringTrue = false;

            if (badgeOne.DoorNames.Contains("100"))
            {
                stringTrue = true;
            }

            // Assert
            Assert.IsTrue(stringTrue);
        }

        // Add Door To Badge Helper Method
        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            // Arrange
            Badge badge = _repo.GetBadgeByID(1);
            string newDoorName = "103";

            // Act
            bool doorAdded = _repo.AddDoorToBadge(badge.BadgeID, newDoorName);

            // Assert
            Assert.IsTrue(doorAdded);
        }

        // Remove Door From Badge Helper Method
        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            // Arrange
            Badge badge = _repo.GetBadgeByID(2);
            string oldDoorName = "200";

            // Act
            bool doorRemoved = _repo.RemoveDoorFromBadge(badge.BadgeID, oldDoorName);

            // Assert
            Assert.IsTrue(doorRemoved);
        }
    }
}
