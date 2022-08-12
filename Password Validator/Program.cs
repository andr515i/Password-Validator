using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            // password validator
            // min 12 characters, max 64 characters long
            // both upper and lower case
            // a mix of letters and numbers
            // min 1 special character

            // if the password also passes these criterias, it will be degraded to a lower grade password
            // 4 of the same letters or numbers in succession. ie bbbb, 2222
            // if 1234, 3456 is in the password, at 4 or more pattern-creating numbers.


            Program.UI();
            Console.ReadLine();
        }
        static void UI()  // what the user sees
        {
            // color the strength of the password to measure the strength
            Console.WriteLine("type password to be validated");
            string password = Console.ReadLine();


            Program.Controller(password);


        }

        static void Controller(string password)
        {
            int passwordStrength = 3;
            if (!Program.ValidatePasswordLength(password) || !Program.ValidatePasswordUpperLower(password) || !Program.ValidatePasswordSpecialChar(password) || !Program.ValidatePasswordLetterAndNumber(password))
            {
                Program.UI();
            }
            else
            {
                Console.WriteLine("password is valid, and its strength is " + Program.PasswordStrength(password, passwordStrength));
            }

        }

        static int PasswordStrength(string password, int strength)
        {
            // we check individual criteria through methods in here
            if (!PasswordRecurringLetter(password))
            {
                strength--;
            }

            return strength;
        }

        static bool PasswordRecurringLetter(string password) // ty for code
        {
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (password[i].Equals(password[i + 1]).Equals(password[i + 2]).Equals(password[i + 3]))
                {
                    Console.WriteLine("inside");
                    return false;
                }
            }
            Console.WriteLine("outside");
            return true;
        }

        static bool ValidatePasswordLength(string password)  // checks that the password length is valid
        {
            if (password.Length >= 12 && password.Length <= 64)
            {
                Console.WriteLine("password has good length!");
                return true;
            }
            else if (password.Length < 12)
            {
                Console.WriteLine("password is too short, minimum 12 characters, you typed: " + password.Length + " characters");
                return false;
            }
            else if (password.Length > 64)
            {
                Console.WriteLine("Password is too long, maximum of 64 characters, you typed: " + password.Length + " characters");
                return false;
            }
            else
            {
                Console.WriteLine("something went wrong. type password again");
                return false;
            }

        }

        static bool ValidatePasswordUpperLower(string password)
        {
            bool validatedUpper = false;
            bool validatedLower = false;
            // check for upper and lower case characters
            foreach (char letter in password)
            {
                if (Char.IsUpper(letter))
                {

                    validatedUpper = true;
                }
                if (Char.IsLower(letter))
                {

                    validatedLower = true;
                }

            }
            if (validatedUpper && validatedLower)
            {
                Console.WriteLine("Password has uppercase and lowercase ");
                return true;
            }
            else
            {
                if (!validatedLower)
                {
                    Console.WriteLine("there were no lowercase letters in your password, which is a requirement");
                }
                else
                {
                    Console.WriteLine("There were no uppercase letters in your password, which is a requirement");
                }
                return false;
            }
        } // checks that there is lower and upper case characters in password

        static bool ValidatePasswordLetterAndNumber(string password)
        {


            if (password.Any(ch => Char.IsLetter(ch)) && password.Any(ch => Char.IsNumber(ch)))
            {
                Console.WriteLine("password has both numbers and letters");

                return true;
            }
            else
            {
                if (!password.Any(ch => Char.IsLetter(ch)))
                {
                    Console.WriteLine("password does not contain a letter, which is a requirement");
                }
                else
                {
                    Console.WriteLine("password does not contain a number, which is a requirement");
                }
                return false;
            }
        }
        static bool ValidatePasswordSpecialChar(string password)  // checks for special characters by asking if the char is neither letter nor digit
        {
            if (password.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                Console.WriteLine("atleast 1 special character found");
            }
            else
            {
                Console.WriteLine("found no special characters, which is a requirement");
            }
            return password.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}
