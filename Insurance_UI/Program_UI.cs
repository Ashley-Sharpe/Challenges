using Insurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Insurance_UI
{
    public class Program_UI
    {

        private Claims_Repo claims_Repo = new Claims_Repo();
        //Method that runs the application
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool KeepRunning = true;
            while (KeepRunning)
            {

                //Display options to user
                Console.WriteLine("Select a menu option: \n" +
                    "1.View All Claims \n" +
                    "2.Take care of next claim \n" +
                    "3.Enter a new claim \n" +
                    "4.Exit");
                //Get user's Input
                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //View All Claims
                        ViewAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        RemoveClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye");
                        KeepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }

        }
        //Enter a new claim
        private void EnterNewClaim()
        {
            Claims newclaims = new Claims();

            //Claim ID
            Console.WriteLine("Enter the claim ID");
            newclaims.ClaimID = int.Parse(Console.ReadLine());

            //Claim Type
            Console.WriteLine("Enter the claim type (ex: Car / Home / Theft");
            newclaims.ClaimType = Console.ReadLine();
            //Description
            Console.WriteLine("Enter the description");
            newclaims.Description = Console.ReadLine();
            //Claim amount 
            Console.WriteLine("Enter the claim amount.");
            newclaims.ClaimAmount = int.Parse(Console.ReadLine());
            //Date of incident
            Console.WriteLine("Enter the date of incident. ie:(mm/dd/yyyy)");
            newclaims.DateOfIncident = DateTime.Parse(Console.ReadLine());
            //Date of claim
            Console.WriteLine("Enter the date of the claim. ie: (mm/dd/yyyy)");
            newclaims.DateOfClaim = DateTime.Parse(Console.ReadLine());
            //IsValid
            Console.WriteLine("Enter if the claim is valid ex: true or false");
            newclaims.IsValid = bool.Parse(Console.ReadLine());

            claims_Repo.AddClaimToQueue(newclaims);

        }

        //View all Claims
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> directory = claims_Repo.GetClaims();


            Console.WriteLine($"ClaimID\t" + " Type " + " Description\t" + "ClaimAmount\t" + "  DateOfIncident\t" + "" + "  DateOfClaim"
                + " Claim Is Valid");
            foreach (Claims claims in directory)
            {
                Console.WriteLine($"{claims.ClaimID}\t { claims.ClaimType}\t" +
                    $"{claims.Description}\t ${claims.ClaimAmount}\t\t {claims.DateOfIncident:ddd MMM, yyyy}\t\t " +
                    $"{claims.DateOfClaim:ddd MMM, yyyy}\t {claims.IsValid}");

            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        //Take Care of next claim
        private void RemoveClaim()
        {
            Console.Clear();
            Queue<Claims> current = claims_Repo.GetClaims();

            Claims preview = current.Peek();
            Console.WriteLine($"{preview.ClaimID}\t { preview.ClaimType}\t" +
                    $"{preview.Description}\t ${preview.ClaimAmount}\t {preview.DateOfIncident}\t " +
                    $"{preview.DateOfClaim}\t {preview.IsValid}");

             string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // yes
                    current.Dequeue();
                    Console.WriteLine("It has been removed.");
                    Console.ReadKey();
                    break;
                case "2":
                    //no
                    Console.WriteLine("It wasn't removed.");
                    Console.ReadKey();
                    break;
            }
        }
        private void SeedMethod()
        {
            Claims seed = new Claims(34, "Car", "hit a tree", 1000, new DateTime(1992, 12, 10), new DateTime(2020, 12, 10), false);
            claims_Repo.AddClaimToQueue(seed);
        }
    }

}

