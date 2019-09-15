using System;
namespace dotNet_ass1
{
    //struct to hold the detail for email body information
    public struct EmailBody
    {
        public string userFirstName, userLastName, userAddress, userEmail;
        public int userAccNum, userPhone;
        public EmailBody(string firstname, string lastname, string address, string email, int accnum, int phone)
        {
            userFirstName = firstname;
            userLastName = lastname;
            userAddress = address;
            userEmail = email;
            userAccNum = accnum;
            userPhone = phone;
        }
    }
}
