using System;
namespace dotNet_ass1
{

    //used to display the user detail in search user, statement, delete
    public class DisplayDetail
    {
        public void UserDetails(string[] accountDetail)
        {
            Console.WriteLine($"\t\t\b\b\bAccount No: {accountDetail[0]}");
            Console.WriteLine($"\t\t\b\b\bAccount Balance: ${accountDetail[1]}");
            Console.WriteLine($"\t\t\b\b\bFirst Name: {accountDetail[2]}");
            Console.WriteLine($"\t\t\b\b\bLast Name: {accountDetail[3]}");
            Console.WriteLine($"\t\t\b\b\bAddress: {accountDetail[4]}");
            Console.WriteLine($"\t\t\b\b\bPhone: {accountDetail[5]}");
            Console.WriteLine($"\t\t\b\b\bEmail: {accountDetail[6]}");
        }
    }
}
