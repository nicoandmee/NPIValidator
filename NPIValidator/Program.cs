using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NPIValidator
{
    class Program
    {
        static void Main(string[] args)
        {
                Validator validator = new Validator();
                validator.Validate();
                Console.ReadLine();

        }


        }
    

    class Validator
    {
        public void Validate()
        {
            string npi = Prompt();
            List<int> number = new List<int>(); //Represent NPI as an array 
            int sum = 0;
            foreach (char a in npi)
            {
                number.Add((int)Char.GetNumericValue(a));
            }

            //Double value of alternating digits, add the sum of their resulting product's digits
            sum = SumDigits(number[8] * 2) + SumDigits(number[6] * 2) + SumDigits(number[4] * 2) + SumDigits(number[2] * 2) + SumDigits(number[0] * 2) + 24;
            sum += number[1] + number[3] + number[5] + number[7];
            
            //Subtract the next highest number divisible by 10 from the sum (gives us check digit)
            if (sum % 10 != 0)
            {
                sum = (sum + (10 - (sum % 10))) - sum;
            }
            else
            {
                sum = 0; //Check digit must be zero
            }
            //Check if our calculated check-digit matches the one originally provided by the user
            if (sum == number[9])
            {
                Console.WriteLine("\nThe NPI " + npi + " is valid.");
                Console.WriteLine("THe NPI was not validated succesfully. Would you like to try another NPI? (Y/N");
                if(Console.ReadLine() == "Y")
                {
                    Validate();
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("THe NPI was not validated succesfully. Would you like to try another NPI? (Y/N");
                if(Console.ReadLine() == "Y")
                {
                    Validate();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

        }

        public string Prompt()
        {
            Console.WriteLine("Enter NPI Number to validate:  ");
            string userinput = Console.ReadLine();
            if (Regex.Match(userinput, @"^\d{10}$").Success)
            {
                return userinput;

            }
            else
            {
                Console.WriteLine("Please confirm you entered the NPI properly. It should be 10-digits long with no special characters and the last digit should be the check-digit.\nWould you like to re-enter NPI? (Y/N)");
                if(Console.ReadLine() == "Y")
                {
                    Prompt();
                }
                else
                {
                    Environment.Exit(0);
                }
                
            }
            return null;


        }

        public int SumDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % 10);
                number = number / 10;
            }
            int result = digits.Sum();
            return digits.Sum();
        }







    }





    }






