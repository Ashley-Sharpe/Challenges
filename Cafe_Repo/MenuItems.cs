using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }

        public MenuItems(int v, string v1) { }

        public MenuItems(int mealNumber, string mealName, string itemDescription, decimal price, string ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            ItemDescription = itemDescription;
            Price = price;
            Ingredients = ingredients;
        }

        public MenuItems()
        {
        }
    }
}
