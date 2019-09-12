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
            
            Console.WriteLine("after login");
        }
    }
}
