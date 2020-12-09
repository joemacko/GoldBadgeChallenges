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
            _meal = new Menu(5, "Chicken Sandwich Meal", "Fried chicken sandwich, fries, and a drink", "Fried chicken patty, bun, pickles, fries, and soda", 7.00m);

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

        // Read Method
        [TestMethod]
        public void ReadMeal_ShouldGetAreEqual()
        {
            // Arrange

            // Act
            //Menu repoMealCreate = new Menu;
            //repoMealName = repoMealCreate.Name;
            //Menu testMealName = _repo.GetMenuMealByName(_meal.Name);

            // Assert
            //Assert.AreEqual(repoMealName, testMealName);
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
