using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repo
{
    public class Customer_Repo
    {
        private List<Customer> _listOfCustomer = new List<Customer>();

        //Create
        public void AddCustomerToList(Customer person)
        {
            
            _listOfCustomer.Add(person);
        }
        //Read
        public List<Customer> GetCustomerList()
        {
            return _listOfCustomer;
        }
        //Update
        public bool UpdateExistingCustomers(string originalCustomer, Customer newCustomer)
        {
            // Find the content
            Customer oldCustomer  = GetCustomerByName(originalCustomer);

            //Update the content
            if (originalCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
               
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveCustomerFromList(string name)
        {
            Customer customer = GetCustomerByName(name);

            if (customer == null)
            {
                return false;
            }

            int initialCount = _listOfCustomer.Count;
            _listOfCustomer.Remove(customer);

            if (initialCount > _listOfCustomer.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public Customer GetCustomerByName(string name)
        {
            foreach (Customer customer in _listOfCustomer)
            {
                if (name.ToLower() == name)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}