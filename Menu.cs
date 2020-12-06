using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Repo
{
    // Plain Old C# Object (POCO)
    public class Menu
    {
        // Define what data the POCO will hold through properties
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        // Empty constructor
        public Menu() { }

        // Another constructor, this time with parameters assigned
        public Menu(int number, string name, string description, string ingredients, decimal price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
