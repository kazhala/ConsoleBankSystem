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
            
                int choice = menu.MenuScreen();
                
                
            
            
            
            Console.WriteLine(choice);
            Console.ReadKey();
            
        }
    }
}
