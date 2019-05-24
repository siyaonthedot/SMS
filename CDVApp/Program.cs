using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDVApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string account;
            Console.Write("Enter a Account Number - ");
            account = Console.ReadLine();
            Console.WriteLine("Test Data");

            if (CDVValidation(account))                 
                Console.WriteLine("Valid"); 
            else
                Console.WriteLine("Invalid");
            Console.ReadLine();

        }

        static bool  CDVValidation(string account)
        {
            if (account.Length == 10)
            {
                var wieghting = "1371371";
                var number = account.Substring(2, 7);
                string lastDigit = account[account.Length - 1].ToString();
                char[] product = new char[7];
                int checkTotal = 0;
                for (int i = 0; i < number.ToCharArray().Count(); i++)
                {
                    string num = number.ToCharArray()[i].ToString();
                    string numWieght = wieghting.ToCharArray()[i].ToString();
                    product[i] = (char) (Convert.ToInt32(num) * Convert.ToInt32(numWieght));
                    checkTotal = checkTotal + (Convert.ToInt32(num) * Convert.ToInt32(numWieght));
                }
                int rem = checkTotal % 10;
                if (Convert.ToInt32(lastDigit) == (10 - rem))
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
