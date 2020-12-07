using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repo
{
    public class MenuRepository
    {
        // Field list that holds menu data
        private List<Menu> _menuList = new List<Menu>();

        // Create
        public void AddMenuMeal(Menu meal)
        {
            _menuList.Add(meal);
        }

        // Read
        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        // Delete
        public bool RemoveMenuMealFromList(string name)
        {
            Menu meal = GetMenuMealByName(name);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _menuList.Count;
            _menuList.Remove(meal);

            if(initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper method
        public Menu GetMenuMealByName(string name)
        {
            foreach (Menu meal in _menuList)
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
