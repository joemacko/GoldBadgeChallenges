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
            // Arrange --> Setting up the playing field
            Menu meal = new Menu();
            meal.Name = "Barbecue Chicken Meal";
            MenuRepository repository = new MenuRepository();

            // Act --> Get/run the code we want to test
            repository.AddMenuMeal(meal);
            Menu mealFromList = repository.GetMenuMealByName("Barbecue Chicken Meal");

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(mealFromList);
        }

        // Read Method


        // Delete Method
        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveMenuMealFromList(_meal.Name);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
