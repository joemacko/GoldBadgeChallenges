using Komodo_Cafe_Repo;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Cafe_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _meal;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _meal = new Menu(5, "Chicken Sandwich Meal", "Fried chicken sandwich, fries, and a drink", null, null, 7.00m);

            _repo.AddMenuMeal(_meal);
        }

        // Create Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field [TestInitialize]

            // Act --> Get/run the code we want to test [TestInitialize]

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(_repo);
        }

        // Helper Method
        [TestMethod]
        public void GetMealByName_ShouldReturnNotNull()
        {
            // Arrange [TestInitialize]

            // Act 
            Menu helperMeal = _repo.GetMenuMealByName(_meal.Name);

            // Assert
            Assert.IsNotNull(helperMeal);
        }

        // Read Method
        [TestMethod]
        public void ReadMeal_ShouldGetAreEqual()
        {
            // Arrange
            Menu newRepoMeal = new Menu(5, "Chicken Sandwich Meal", "Fried chicken sandwich, fries, and a drink", null, null, 7.00m);
            _repo.AddMenuMeal(newRepoMeal);

            // Act
            Menu mealOne = _repo.GetMenuMealByName(_meal.Name);
            Menu mealTwo = _repo.GetMenuMealByName(newRepoMeal.Name);

            // Assert
            Assert.AreEqual(mealOne, mealTwo);
        }

        // Delete Method
        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            // Arrange [TestInitialize]

            // Act
            bool deleteResult = _repo.RemoveMenuMealFromList(_meal.Name);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
