using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repo
{
     public enum CustomerType { Potential =1, Current, Past}
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerType TypeOfCustomer { get; set; }

        public string Email
        {
            get
            {
                if (TypeOfCustomer == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (TypeOfCustomer == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you, and we want you back!";
                }
                else
                    return "We currently have the lowest rates on Helicopter Insurance!";
            }

        }

        public Customer()
        {
            Id++;
        }

        public Customer(string firstName, string lastName, CustomerType typeOfCustomer)
        {
            Id++;
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
        }
    }
}