using System;

namespace dotNet_ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            while (!login.LoginSuccess & !login.Exit)
            {
                login.LoginScreen();
            }
            Console.WriteLine(login.LoginSuccess);
            Console.WriteLine("after login");
        }
    }
}
