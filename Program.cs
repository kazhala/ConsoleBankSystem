using System;

namespace dotNet_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            while (!login.LoginSuccess)
            {
                login.LoginScreen();
            }
            Menu menu = new Menu();
            
            do
            {
                int choice = menu.MenuScreen();
                switch (choice)
                {
                    case 1:
                        CreateAccount newAcc = new CreateAccount();
                        newAcc.NewAccScreen();
                        break;
                    case 7:
                        System.Environment.Exit(0);

                        break;
                    default:
                        break;
                }
            } while (true);


            //Console.ReadKey();
                
            
                
            
        }
    }
}
