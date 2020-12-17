using System;
using System.Collections.Generic;
using Komodo_Insurance_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Insurance_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo;
        private Dictionary<int, Badge> _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            _badge = new Dictionary<int, Badge>();

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
            Assert.IsNotNull(_badge.Values);
        }
    }
}
