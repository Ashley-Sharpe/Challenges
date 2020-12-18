using Greeting_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_UI
{
    public class Program
    {
             private Customer_Repo _repo = new Customer_Repo();
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
                    "1. Create Customer\n" +
                    "2. Update Customers \n" +
                    "3. View View Items By Name\n" +
                    "4. Update Existing Customer\n" +
                    "5. Delete Existing Delete\n" +
                    "6. Exit");

                //Get users input
                string input = Console.ReadLine();

                //Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Content
                        CreateNewCustomer();
                        break;
                    case "2":
                        //View All Content
                        DisplayAllCustomers();
                        break;
                    case "3":
                        //View Content by Name
                        DisplayCustomerByName();
                        break;
                    case "4":
                        //Update Existing Content
                        UpdateExistingCustomer();
                        break;
                    case "5":
                        //Delete Content
                        DeleteExistingCustomer();
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
        private void CreateNewCustomer()
        {
            Customer customer = new Customer();

            //Customer First Name
            Console.WriteLine("Enter the Clients First Name:");
            customer.FirstName = Console.ReadLine();

            //Customer Second Name
            Console.WriteLine("Enter Clients Second Name");
            customer.LastName = Console.ReadLine();

            //Type of Customer
            Console.WriteLine("Is this a New Customer, Existing Customer, or Former Customer\n"+
                "Press 1. for New Customer\n"+
                "Press 2 for Existing Customer\n"+
                "Press 3 for Former Customer");
            customer.TypeOfCustomer = (CustomerType)Convert.ToInt32(Console.ReadLine());

            _repo.AddCustomerToList(customer);
        }
        //View Customers that are saved
        private void DisplayAllCustomers()
        {
            List<Customer> listOfCustomers = _repo.GetCustomerList();
            foreach (Customer customer in listOfCustomers)
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}\n" +
                    $"Customer Status: {customer.TypeOfCustomer}");
            }
        }

        //View existing customer by Name
        private void DisplayCustomersByName()
        {
            Console.Clear();
            //Prompt user to give name of meal
            Console.WriteLine("Enter Customer's First Name");
            // Get users input
            string firstName = Console.ReadLine();

            //Find the meal by that name
            Customer customer = _repo.GetCustomerByName(firstName);
            //Display content if is not null
            if (customer != null)
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}\n" +
                   $"Current Status: {customer.TypeOfCustomer}");
            }
            else
            {
                Console.WriteLine("Noone by that name.");
            }
        }
        //Update existing content
        private void UpdateExistingCustomers()
        {
            // Display all content
            DisplayAllCustomers();
            // Ask for the title of the content to update
            Console.WriteLine("Enter the customer you want to update.");

            // Get that title
            string oldCustomer = Console.ReadLine();
            // Build a new menu item 
            Customer Customer = new Customer();

            //Meal Name
            Console.WriteLine("Enter the name of the customer");
            Console.ReadLine();
            //Meal Number
            Console.WriteLine("Enter the second name of the customer");
            //Item Description
            Console.WriteLine("");
            newMenuItems.ItemDescription = Console.ReadLine();
            //Price
            Console.WriteLine("Enter the price of the meal");
            string priceAsString = Console.ReadLine();
            newMenuItems.Price = decimal.Parse(priceAsString);
            //Ingredients
            Console.WriteLine("Enter the ingredients used");
            newMenuItems.Ingredients = Console.ReadLine();

            //Verify the update worked
            bool wasUpdated = _repo.UpdateExistingCustomers(oldcustomers, newCustomers);

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
            MenuItems hamburger = new MenuItems(1, "Hamburger", "Angus beef topped with lettuce and tomato atop a bun", 3.99m, "Beef,tomato,lettuce,buns");
            MenuItems CoffeeCombo = new MenuItems(2, "Coffee and coffeecake", "Light roast coffee with streusel coffee cake", 4.00m, "100% arabica coffee beans , sugar , flour , baking soda , egg");
            MenuItems TeaCombo = new MenuItems(3, "Tea and biscuits", "English Breakfast Tea and traditional english bisucits", 3.50m, "English Tea , distilled water, whatever is in shortbread cookies");

            _menuItemsRepo.AddMenuItemToList(hamburger);
            _menuItemsRepo.AddMenuItemToList(TeaCombo);
            _menuItemsRepo.AddMenuItemToList(CoffeeCombo);
        }
    }
    }
}
