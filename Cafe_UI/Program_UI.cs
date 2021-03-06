﻿using Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI
{
    class Program_UI
    {
        private MenuItemsRepo _menuItemsRepo = new MenuItemsRepo();
        //Method that runs/starts the application
        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        //menu 
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View Menu Items \n" +
                    "3. View Menu Items By Name\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

             //Get users input
                string input = Console.ReadLine();

                //Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Content
                        CreateNewMenuItem();
                        break;
                    case "2":
                        //View All Content
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        //View Content by Name
                        DisplayAllMenuItemsByName();
                        break;
                    case "4":
                        //Update Existing Content
                        UpdateExistingMenuItems();
                        break;
                    case "5":
                        //Delete Content
                        DeleteExistingMenuItems();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                        
                        default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }

        }
       //Create
        private void CreateNewMenuItem()
        {
            MenuItems newMenuItems = new MenuItems();

            //Meal Name
            Console.WriteLine("Enter the name of the meal:");
            newMenuItems.MealName = Console.ReadLine();
            //Meal Number
            Console.WriteLine("Enter the meal number ex: a #5 please");
            string mealNumberAsString = Console.ReadLine();
            newMenuItems.MealNumber = int.Parse(mealNumberAsString);
            //Item Description
            Console.WriteLine("Enter the meal description");
            newMenuItems.ItemDescription = Console.ReadLine();
            //Price
            Console.WriteLine("Enter the price of the meal");
            string priceAsString = Console.ReadLine();
            newMenuItems.Price = decimal.Parse(priceAsString);
            //Ingredients
            Console.WriteLine("Enter the ingredients used");
            newMenuItems.Ingredients = Console.ReadLine();

            _menuItemsRepo.AddMenuItemToList(newMenuItems);
        }
        //View Current MenuItem that is saved
        private void DisplayAllMenuItems()
        {
            List<MenuItems> listOfMenuItems = _menuItemsRepo.GetItemList();
            foreach(MenuItems menuItems in listOfMenuItems)
            {
                Console.WriteLine($"Name: {menuItems.MealName}\n" +
                    $"Description: {menuItems.ItemDescription}");
            }
        }

        //View existing content by title
        private void DisplayAllMenuItemsByName()
        {
            Console.Clear();
            //Prompt user to give name of meal
            Console.WriteLine("Enter the name of the meal:");
            // Get users input
            string mealName = Console.ReadLine();

            //Find the meal by that name
            MenuItems menuItems = _menuItemsRepo.GetItemByMealName(mealName);
            //Display content if is not null
            if(menuItems != null)
            {
                Console.WriteLine($"Name: {menuItems.MealName}\n" +
                   $"Description: {menuItems.ItemDescription}\n" +
                   $"Price: {menuItems.Price}\n" +
                   $"Meal Number: {menuItems.MealNumber}\n" +
                   $"Ingredients: {menuItems.Ingredients}");
            }
            else
            {
                Console.WriteLine("No content by that name.");
            }
        }
        //Update existing content
        private void UpdateExistingMenuItems()
        {
            // Display all content
            DisplayAllMenuItems();
            // Ask for the title of the content to update
            Console.WriteLine("Enter the menu item you want to update:");

            // Get that title
            string oldMenuItems = Console.ReadLine();
            // Build a new menu item 
            MenuItems newMenuItems = new MenuItems();

            //Meal Name
            Console.WriteLine("Enter the name of the meal:");
            newMenuItems.MealName = Console.ReadLine();
            //Meal Number
            Console.WriteLine("Enter the meal number ex: a #5 please");
            string mealNumberAsString = Console.ReadLine();
            newMenuItems.MealNumber = int.Parse(mealNumberAsString);
            //Item Description
            Console.WriteLine("Enter the meal description");
            newMenuItems.ItemDescription = Console.ReadLine();
            //Price
            Console.WriteLine("Enter the price of the meal");
            string priceAsString = Console.ReadLine();
            newMenuItems.Price = decimal.Parse(priceAsString);
            //Ingredients
            Console.WriteLine("Enter the ingredients used");
            newMenuItems.Ingredients = Console.ReadLine();

            //Verify the update worked
            bool wasUpdated = _menuItemsRepo.UpdateExistingMenuItems(oldMenuItems, newMenuItems);

            if (wasUpdated)
            {
                Console.WriteLine("Menu item was updated!");

            }
            else
            {
                Console.WriteLine("Menu item could not be updated!");
            }
          
        }
        //Delete existing content
        private void DeleteExistingMenuItems()
        {

            DisplayAllMenuItems();

            //Get the title they want to remove
            Console.WriteLine("\nEnter the meal you would like to remove:");

            string input = Console.ReadLine();

            //Call the delete method
           bool wasDeleted = _menuItemsRepo.RemoveMenuItemFromList(input);
            //If the content was deleted , say so
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }
                
            //Otherwise state it couldn't be deleted
        }

        //Seed method
        private void SeedMenuList()
        {
            MenuItems hamburger = new MenuItems(1, "Hamburger","Angus beef topped with lettuce and tomato atop a bun", 3.99m, "Beef,tomato,lettuce,buns");
            MenuItems CoffeeCombo = new MenuItems(2, "Coffee and coffeecake", "Light roast coffee with streusel coffee cake", 4.00m, "100% arabica coffee beans , sugar , flour , baking soda , egg");
            MenuItems TeaCombo = new MenuItems(3, "Tea and biscuits", "English Breakfast Tea and traditional english bisucits",3.50m,"English Tea , distilled water, whatever is in shortbread cookies");

            _menuItemsRepo.AddMenuItemToList(hamburger);
            _menuItemsRepo.AddMenuItemToList(TeaCombo);
            _menuItemsRepo.AddMenuItemToList(CoffeeCombo);
        }
    }
}
