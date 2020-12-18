using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class MenuItemsRepo
    {
        private List<MenuItems> _listOfMenuItems = new List<MenuItems>();
        //Create
        public void AddMenuItemToList(MenuItems item)
        {
            _listOfMenuItems.Add(item);
        }
        //Read
        public List<MenuItems> GetItemList()
        {
            return _listOfMenuItems;
        }
        
        //Update
        public bool UpdateExistingMenuItems(string originalMenuItem, MenuItems newMenuItems)
        {
            // Find the content
            MenuItems oldMenuItems = GetItemByMealName(originalMenuItem);

            //Update the content
            if (oldMenuItems != null)
            {
                oldMenuItems.MealName = newMenuItems.MealName;
                oldMenuItems.MealNumber = newMenuItems.MealNumber;
                oldMenuItems.Price = newMenuItems.Price;
                oldMenuItems.Ingredients = newMenuItems.Ingredients;
                oldMenuItems.ItemDescription = newMenuItems.ItemDescription;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveMenuItemFromList(string mealName)
        {
            MenuItems menuItems = GetItemByMealName(mealName);

            if (menuItems == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItems);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public MenuItems GetItemByMealName(string mealName)
        {
            foreach (MenuItems menuItems in _listOfMenuItems)
            {
                if (menuItems.MealName.ToLower() == mealName)
                {
                    return menuItems;
                }
            }

            return null;
        }
    }
}
