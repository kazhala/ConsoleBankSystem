using System;
using System.IO;

namespace dotNet_ass1
{
    class Login
    {
        private string userName;
        private string passWord;
        private bool loginSuccess = false;

        //main program need access to the state of loginSuccess
        //Get method for loginSuccess private field
        public bool LoginSuccess
        {
            get
            {
                return this.loginSuccess;
            }
        }
        public void LoginScreen()
        {
            Console.Clear();
            this.passWord = "";
            Console.WriteLine("\t ------------------------------------------------------------- ");
            Console.WriteLine("\t|                Welcome to KAZ Banking System                |");
            Console.WriteLine("\t =============================================================");
            Console.WriteLine("\t|                        Please Login                         |");
            Console.WriteLine("\t|                                                             |");
            Console.Write("\t| User name: ");

            //record the position for username input
            int usernameLeft = Console.CursorLeft;
            int usernameTop = Console.CursorTop;
            Console.Write("                                                 |\n");
            Console.Write("\t| Password: ");
            int passwordLeft = Console.CursorLeft;
            int passwordTop = Console.CursorTop;
            Console.Write("                                                  |\n");
            Console.WriteLine("\t|                                                             |");
            Console.WriteLine("\t ------------------------------------------------------------- ");
            int resultLeft = Console.CursorLeft;
            int resultTop = Console.CursorTop;

            //set the position for user input
            Console.SetCursorPosition(usernameLeft, usernameTop);
            this.userName = Console.ReadLine();
            Console.SetCursorPosition(passwordLeft, passwordTop);

            //handle user entering password, display * for each char enter
            //end the loop when user press enter
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    this.passWord += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && this.passWord.Length > 0)
                    {
                        //handle user press backspace
                        this.passWord = this.passWord.Substring(0, (this.passWord.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        //terminate the loop
                        break;
                    }
                }
            } while (true);
            Console.SetCursorPosition(resultLeft, resultTop);

            //store the data of the login file to an array
            string[] loginDetail = File.ReadAllLines("login.txt");

            //loop over the stored array
            foreach (string line in loginDetail)
            {
                //Split the user name and password
                string[] namepass = line.Split('|');
                //if username match, check password
                if (this.userName == namepass[0])
                {
                    if (this.passWord == namepass[1])
                    {
                        this.loginSuccess = true;
             
                    }
                }
            
            }

            //if loginSuccess still false, username or password is wrong, prompt user with error message
            if (!this.loginSuccess)
            {
                Console.Write("        Credential invalid, please re-enter your detail!");
            }else if(this.loginSuccess){
                Console.Write("        Valid credentials, press any key to continue!");
            }
            Console.ReadKey();
        }
    }
}
